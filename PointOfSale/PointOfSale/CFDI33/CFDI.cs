using CFD33;
using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.WsTimbrado;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace PointOfSale.CFDI33
{
    public class CFDI
    {

        //Controladores
        private ProductoController productoController;
        private VentaController ventaController;
        private VentapController ventapController;
        private ClienteController clienteController;
        private EmpresaController empresaController;


        //Dym pos
        public Cliente Cliente { get; set; }
        public Venta Venta { get; set; }
        public List<Ventap> Partidas { get; set; }
        public Empresa Empresa { get; set; }



        //Configuracion
        public string CadenaOriginal { get; set; }
        public string FacturaActual { get; set; }
        public string NoCertificado { get; set; }
        public decimal TotalIva { get; set; }
        public decimal TotalIeps { get; set; }



        //Utils
        public RespuestaCFDi respuestaCFDI;
        public TimbradoClient timbradoClient;
        public SelloDigital selloDigital;
        public XslCompiledTransform transformador;

        //Comprobante
        public Comprobante comprobante;
        public ComprobanteEmisor emisor;
        public ComprobanteReceptor receptor;


        // Nivel concepto
        public List<ComprobanteConcepto> conceptos;
        public ComprobanteConcepto concepto;
        public ComprobanteConceptoImpuestosTraslado ivaConcepto;
        public ComprobanteConceptoImpuestosTraslado iepsConcepto;
        public List<ComprobanteConceptoImpuestosTraslado> impuestosConcepto;


        //Nivel comprobante
        public List<ComprobanteImpuestosTraslado> impuestosComprobante;
        public ComprobanteImpuestos totalImpuestosComprobante;
        public ComprobanteImpuestosTraslado ivaComprobante;
        public ComprobanteImpuestosTraslado iepsComprobante;




        //Inicizalizar
        public void Inicializar()
        {

            //Controladores
            productoController = new ProductoController();
            ventaController = new VentaController();
            ventapController = new VentapController();
            clienteController = new ClienteController();
            empresaController = new EmpresaController();

            //Utils
            respuestaCFDI = new RespuestaCFDi();
            timbradoClient = new TimbradoClient();
            selloDigital = new SelloDigital();
            transformador = new XslCompiledTransform();

            //Comprobante
            comprobante = new Comprobante();
            emisor = new ComprobanteEmisor();
            receptor = new ComprobanteReceptor();


            // Nivel concepto
            conceptos = new List<ComprobanteConcepto>();
            concepto = new ComprobanteConcepto();
            ivaConcepto = new ComprobanteConceptoImpuestosTraslado();
            iepsConcepto = new ComprobanteConceptoImpuestosTraslado();
            impuestosConcepto = new List<ComprobanteConceptoImpuestosTraslado>();


            //Nivel comprobante
            impuestosComprobante = new List<ComprobanteImpuestosTraslado>();
            totalImpuestosComprobante = new ComprobanteImpuestos();
            ivaComprobante = new ComprobanteImpuestosTraslado();
            iepsComprobante = new ComprobanteImpuestosTraslado();


            //inicializacion de propiedades
            Empresa = empresaController.SelectTopOne();
            Partidas = ventapController.SelectPartidas(Venta.VentaId);
            Cliente = clienteController.SelectOne(Venta.ClienteId);


        }


        public bool Facturar()
        {
            Inicializar();
            if (Venta == null || Partidas.Count == 0 || Empresa == null || Cliente == null)
            {
                Ambiente.Mensaje("Venta || Partidas || Empresa || Cliente == null");
                return false;
            }

            if (Cliente.Rfc == null)
            {
                Ambiente.Mensaje("PROCESO ABORTADO, RFC DEL CLIENTE NO ES VÁLIDO");
                return false;
            }

            if (Cliente.Rfc.Trim().Length == 0)
            {
                Ambiente.Mensaje("PROCESO ABORTADO, RFC DEL CLIENTE NO ES VÁLIDO");
                return false;
            }

            SelloDigital.leerCER(Empresa.RutaCer, out string a, out string b, out string c, out string NoCer);
            NoCertificado = NoCer;

            //Encabezado
            comprobante.Version = "3.3";
            comprobante.Serie = "F";
            comprobante.Folio = Venta.NoRef.ToString();
            comprobante.Fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            comprobante.FormaPago = Venta.FormaPago1;
            comprobante.NoCertificado = NoCertificado;
            comprobante.SubTotal = Venta.SubTotal;
            //comprobante.Descuento = 0;
            comprobante.Moneda = "MXN";
            comprobante.Total = Venta.Total;
            comprobante.TipoDeComprobante = "I";
            comprobante.MetodoPago = Venta.MetodoPago;
            comprobante.MetodoPago = "PUE";
            comprobante.LugarExpedicion = Empresa.Cp;

            //Emisor
            emisor.Rfc = "AAA010101AAA"; //los sellos estan utilizando este rfc 
            //emisor.Rfc = Empresa.Rfc;
            emisor.Nombre = "JESUS MENDOZA JUAREZ";
            emisor.RegimenFiscal = Empresa.RegimenFiscalId;

            //Receptor
            receptor.Nombre = Cliente.RazonSocial;
            receptor.Rfc = Cliente.Rfc;
            receptor.UsoCFDI = Cliente.UsoCfdiid;

            //Asignar emisor y receptor al comprobante
            comprobante.Emisor = emisor;
            comprobante.Receptor = receptor;

            //Agregar los conceptos
            TotalIeps = 0;
            TotalIva = 0;
            foreach (var p in Partidas)
            {
                concepto = new ComprobanteConcepto();
                concepto.ClaveProdServ = p.ClaveProdServ.Trim().Length == 0 ? "01010101" : p.ClaveProdServ.Trim();
                concepto.ClaveUnidad = p.ClaveUnidad.Trim().Length == 0 ? "H87" : p.ClaveUnidad.Trim();
                concepto.Descripcion = p.Descripcion;
                concepto.Cantidad = p.Cantidad;
                concepto.ValorUnitario = p.Precio;
                concepto.Importe = p.SubTotal;
                //concepto.Descuento = 0;

                //Inicializar objetos para el traslado de impuestos
                concepto.Impuestos = new ComprobanteConceptoImpuestos();
                impuestosConcepto = new List<ComprobanteConceptoImpuestosTraslado>();
                ivaConcepto = new ComprobanteConceptoImpuestosTraslado();
                iepsConcepto = new ComprobanteConceptoImpuestosTraslado();


                //Calculo de impuestos
                if (p.Impuesto1 == 0 && p.Impuesto2 == 0)
                {
                    //Iva excento
                    ivaConcepto.Base = p.SubTotal;
                    ivaConcepto.TipoFactor = "Exento";
                    ivaConcepto.Impuesto = "002";
                    impuestosConcepto.Add(ivaConcepto);

                    //Agregar impuestos al concepto y concepto a la lista
                    concepto.Impuestos.Traslados = impuestosConcepto.ToArray();
                    conceptos.Add(concepto);
                }
                else if (p.Impuesto1 == 0 && p.Impuesto2 > 0)
                {
                    //Solo ieps
                    iepsConcepto.Base = p.SubTotal;
                    iepsConcepto.TasaOCuota = p.Impuesto2;
                    iepsConcepto.TipoFactor = p.TasaOcuota2;
                    iepsConcepto.Impuesto = p.ClaveImpuesto2;
                    iepsConcepto.Importe = p.ImporteImpuesto2;
                    impuestosConcepto.Add(iepsConcepto);

                    //Agregar impuestos al concepto y concepto a la lista
                    concepto.Impuestos.Traslados = impuestosConcepto.ToArray();
                    conceptos.Add(concepto);

                    TotalIeps += p.ImporteImpuesto2;
                }
                else if (p.Impuesto1 > 0 && p.Impuesto2 == 0)
                {
                    //solo iva
                    ivaConcepto.Base = p.SubTotal;
                    ivaConcepto.TasaOCuota = p.Impuesto1;
                    ivaConcepto.TipoFactor = p.TasaOcuota1;
                    ivaConcepto.Impuesto = p.ClaveImpuesto1;
                    ivaConcepto.Importe = p.ImporteImpuesto1;
                    impuestosConcepto.Add(ivaConcepto);

                    //Agregar impuestos al concepto y concepto a la lista
                    concepto.Impuestos.Traslados = impuestosConcepto.ToArray();
                    conceptos.Add(concepto);

                    TotalIva += p.ImporteImpuesto1;

                }
                else if (p.Impuesto1 > 0 && p.Impuesto2 > 0)
                {
                    //iva
                    ivaConcepto.Base = p.SubTotal;
                    ivaConcepto.TasaOCuota = p.Impuesto1;
                    ivaConcepto.TipoFactor = p.TasaOcuota1;
                    ivaConcepto.Impuesto = p.ClaveImpuesto1;
                    ivaConcepto.Importe = p.ImporteImpuesto1;
                    impuestosConcepto.Add(ivaConcepto);

                    //ieps
                    iepsConcepto.Base = p.SubTotal;
                    iepsConcepto.TasaOCuota = p.Impuesto2;
                    iepsConcepto.TipoFactor = p.TasaOcuota2;
                    iepsConcepto.Impuesto = p.ClaveImpuesto2;
                    iepsConcepto.Importe = p.ImporteImpuesto2;
                    impuestosConcepto.Add(iepsConcepto);

                    //Agregar impuestos al concepto y concepto a la lista
                    concepto.Impuestos.Traslados = impuestosConcepto.ToArray();
                    conceptos.Add(concepto);

                    TotalIva += p.ImporteImpuesto1;
                    TotalIeps += p.ImporteImpuesto2;
                }

            }
            comprobante.Conceptos = conceptos.ToArray();

            //Totales comprobante
            //NODO IMPUESTO*************************************************************************************
            if (TotalIva > 0)
            {
                //iva comprobante
                ivaComprobante.Importe = TotalIva;
                ivaComprobante.Impuesto = "002";
                ivaComprobante.TipoFactor = "Tasa";
                ivaComprobante.TasaOCuota = 0.160000m;
                impuestosComprobante.Add(ivaComprobante);
            }

            if (TotalIeps > 0)
            {
                //ieps comprobante
                iepsComprobante.Importe = TotalIeps;
                iepsComprobante.Impuesto = "003";
                iepsComprobante.TipoFactor = "Tasa";
                iepsComprobante.TasaOCuota = 0.080000m;
                impuestosComprobante.Add(iepsComprobante);
            }

            //totales de impuestos trasladados
            if ((TotalIva + TotalIeps) > 0)
            {
                totalImpuestosComprobante.TotalImpuestosTrasladados = TotalIva + TotalIeps;
                totalImpuestosComprobante.Traslados = impuestosComprobante.ToArray();
                comprobante.Impuestos = totalImpuestosComprobante;
            }

            /**********************************CREAR XML********************************/
            FacturaActual = Empresa.DirectorioComprobantes + "FACTURA " + Venta.NoRef.ToString() + "_" + Venta.CreatedBy + "_" + Ambiente.TimeText((DateTime)Venta.CreatedAt) + ".XML";


            //Crear Xml
            Serializar(comprobante);
            CadenaOriginal = GetCadenaOriginal();
            comprobante.Certificado = selloDigital.Certificado(Empresa.RutaCer);
            comprobante.Sello = selloDigital.Sellar(CadenaOriginal, Empresa.RutaKey, Empresa.ClavePrivada);
            Serializar(comprobante);

            return Timbrar(FacturaActual);
        }



        //Cobvierte el objeto comprobante a xml
        private string Serializar(Comprobante comprobante)
        {
            XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
            xmlNameSpace.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
            xmlNameSpace.Add("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            xmlNameSpace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            XmlSerializer serializer = new XmlSerializer(typeof(Comprobante));
            string XmlString = "";
            using (var stringWriter = new StringWriterEncoding(Encoding.UTF8))
            {
                using (XmlWriter writter = XmlWriter.Create(stringWriter))
                {
                    serializer.Serialize(writter, comprobante, xmlNameSpace);
                    XmlString = stringWriter.ToString();
                }
            }
            //guardamos el string en un archivo
            System.IO.File.WriteAllText(FacturaActual, XmlString);
            return XmlString;
        }


        //Recupera el Xml timbrado y lo conveierte a un objeto
        private void Deserializar(string pathXML)
        {

            //Paso 1 - xml timbrado lo pasamos a clase

            XmlSerializer oSerializer = new XmlSerializer(typeof(Comprobante));

            using (StreamReader reader = new StreamReader(pathXML))
            {
                //aqui deserializamos
                comprobante = (Comprobante)oSerializer.Deserialize(reader);


                //complementos
                foreach (var oComplemento in comprobante.Complemento)
                {
                    foreach (var oComplementoInterior in oComplemento.Any)
                    {
                        if (oComplementoInterior.Name.Contains("TimbreFiscalDigital"))
                        {

                            XmlSerializer oSerializerComplemento = new XmlSerializer(typeof(TimbreFiscalDigital));
                            using (var readerComplemento = new StringReader(oComplementoInterior.OuterXml))
                            {
                                comprobante.TimbreFiscalDigital =
                                    (TimbreFiscalDigital)oSerializerComplemento.Deserialize(readerComplemento);
                            }

                        }
                    }
                }
            }

        }


        //Genera la cadena original
        private string GetCadenaOriginal()
        {

            XslCompiledTransform transformador = new XslCompiledTransform(true);
            transformador.Load(Empresa.RutaCadenaOriginal);

            using (StringWriter sw = new StringWriter())
            using (XmlWriter xwo = XmlWriter.Create(sw, transformador.OutputSettings))
            {

                transformador.Transform(FacturaActual, xwo);
                CadenaOriginal = sw.ToString();
                return CadenaOriginal;
            }

        }

        private bool Timbrar(String pathXML)
        {

            //TIMBRE DEL XML


            byte[] bXML = File.ReadAllBytes(pathXML);
            respuestaCFDI = timbradoClient.TimbrarTest(Empresa.UserWstimbrado, Empresa.PassWstimbrado, bXML);

            if (respuestaCFDI.Documento == null)
            {
                Ambiente.Mensaje(respuestaCFDI.Mensaje);
                return false;
            }
            else
            {

                File.WriteAllBytes(pathXML, respuestaCFDI.Documento);

                Deserializar(pathXML);

                Venta.CadenaOriginal = CadenaOriginal;
                Venta.SelloCfdi = comprobante.TimbreFiscalDigital.SelloCFD;
                Venta.SelloSat = comprobante.TimbreFiscalDigital.SelloSAT;
                Venta.UuId = comprobante.TimbreFiscalDigital.UUID;
                Venta.NoCertificado = NoCertificado;
                Venta.RutaXml = FacturaActual;

                return ventaController.UpdateOne(Venta);
            }
        }
    }
}
