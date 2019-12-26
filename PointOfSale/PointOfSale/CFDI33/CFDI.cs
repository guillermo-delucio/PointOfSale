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
        //Propiedades
        public Venta Venta { get; set; }

        //Controladores
        private VentaController ventaController;
        private VentapController ventapController;
        private ClienteController clienteController;
        private EmpresaController empresaController;
        private DymErrorController dymErrorController;


        //Objetos
        private Cliente cliente;
        private List<Ventap> partidas;
        private Empresa empresa;



        //Variables
        private string cadenaOriginal;
        private string facturaActual;
        private string noCertificado;
        private string xml;
        private decimal totalIva;
        private decimal totalIeps;
        private string s;



        //Utils
        private RespuestaCFDi respuestaCFDI;
        private TimbradoClient timbradoClient;
        private SelloDigital selloDigital;
        private XslCompiledTransform transformador;

        //Comprobante
        private Comprobante comprobante;
        private ComprobanteEmisor emisor;
        private ComprobanteReceptor receptor;
        private List<ComprobanteConcepto> conceptos;
        private List<ComprobanteImpuestosTraslado> impuestosComprobante;

        // Nivel concepto
        private ComprobanteConcepto concepto;
        private List<ComprobanteConceptoImpuestosTraslado> impuestosConcepto;
        private ComprobanteConceptoImpuestosTraslado ivaConcepto;
        private ComprobanteConceptoImpuestosTraslado iepsConcepto;

        //Nivel comprobante
        private ComprobanteImpuestos totalImpuestosComprobante;
        private ComprobanteImpuestosTraslado ivaComprobante;
        private ComprobanteImpuestosTraslado iepsComprobante;




        //Inicizalizar
        public void Inicializar()
        {

            //Controladores
            ventaController = new VentaController();
            ventapController = new VentapController();
            clienteController = new ClienteController();
            empresaController = new EmpresaController();
            dymErrorController = new DymErrorController();

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
            impuestosConcepto = new List<ComprobanteConceptoImpuestosTraslado>();
            ivaConcepto = new ComprobanteConceptoImpuestosTraslado();
            iepsConcepto = new ComprobanteConceptoImpuestosTraslado();



            //Nivel comprobante
            impuestosComprobante = new List<ComprobanteImpuestosTraslado>();
            totalImpuestosComprobante = new ComprobanteImpuestos();
            ivaComprobante = new ComprobanteImpuestosTraslado();
            iepsComprobante = new ComprobanteImpuestosTraslado();


            //inicializacion de propiedades
            empresa = empresaController.SelectTopOne();
            partidas = ventapController.SelectPartidas(Venta.VentaId);
            cliente = clienteController.SelectOne(Venta.ClienteId);
            s = "";


        }


        public bool Facturar()
        {
            Inicializar();
            if (Venta == null || partidas.Count == 0 || empresa == null || cliente == null)
            {
                Ambiente.Mensaje("Venta || partidas || empresa || Cliente == null");
                return false;
            }

            if (cliente.Rfc == null)
            {
                Ambiente.Mensaje("PROCESO ABORTADO, RFC DEL CLIENTE NO ES VÁLIDO");
                return false;
            }

            if (cliente.Rfc.Trim().Length == 0)
            {
                Ambiente.Mensaje("PROCESO ABORTADO, RFC DEL CLIENTE NO ES VÁLIDO");
                return false;
            }

            SelloDigital.leerCER(empresa.RutaCer, out string a, out string b, out string c, out string NoCer);
            noCertificado = NoCer;

            //Encabezado
            comprobante.Version = "3.3";
            comprobante.Serie = "F";
            comprobante.Folio = Venta.NoRef.ToString();
            comprobante.Fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            comprobante.FormaPago = Venta.FormaPago1;
            comprobante.NoCertificado = noCertificado;
            comprobante.SubTotal = Math.Round(Venta.SubTotal, 2);
            //comprobante.Descuento = 0;
            comprobante.Moneda = "MXN";
            comprobante.Total = Math.Round(Venta.Total, 2);
            comprobante.TipoDeComprobante = Venta.TipoComprobante;
            comprobante.MetodoPago = Venta.MetodoPago;
            comprobante.LugarExpedicion = empresa.Cp;

            //Emisor 
            emisor.Rfc = empresa.Rfc;
            emisor.Nombre = empresa.RazonSocial;
            emisor.RegimenFiscal = empresa.RegimenFiscalId;

            //Receptor
            receptor.Nombre = cliente.RazonSocial;
            receptor.Rfc = cliente.Rfc;
            receptor.UsoCFDI = cliente.UsoCfdiid;

            //Asignar emisor y receptor al comprobante
            comprobante.Emisor = emisor;
            comprobante.Receptor = receptor;

            //Agregar los conceptos
            totalIeps = 0;
            totalIva = 0;
            /**********************************CONCEPTOS********************************/

            foreach (var p in partidas)
            {
                concepto = new ComprobanteConcepto();
                impuestosConcepto = new List<ComprobanteConceptoImpuestosTraslado>();


                concepto.ClaveProdServ = "01010101";

                if (Venta.EsFacturaGlobal)
                    concepto.ClaveUnidad = "ACT";
                else
                    concepto.ClaveUnidad = "H87";

                //concepto.ClaveUnidad = p.ClaveUnidad;
                //concepto.ClaveProdServ = p.ClaveProdServ;
                concepto.Descripcion = p.Descripcion;
                concepto.Cantidad = p.Cantidad;
                concepto.ValorUnitario = p.Precio;
                concepto.Importe = p.SubTotal;


                //Llenado del impuesto
                if (p.ImporteImpuesto1 == 0 && p.ImporteImpuesto2 == 0)
                {
                    /*EXCENTO DE IMPUESTOS (IVA EXCENTO)*/
                    ivaConcepto = new ComprobanteConceptoImpuestosTraslado();
                    ivaConcepto.Base = p.SubTotal;
                    ivaConcepto.Impuesto = p.ClaveImpuesto1;
                    ivaConcepto.TipoFactor = "Exento";
                    impuestosConcepto.Add(ivaConcepto);
                }
                else if (p.ImporteImpuesto1 == 0 && p.ImporteImpuesto2 > 0)
                {
                    /*SOLO IEPS*/
                    iepsConcepto = new ComprobanteConceptoImpuestosTraslado();
                    iepsConcepto.Base = p.SubTotal;
                    iepsConcepto.TasaOCuota = p.Impuesto2;
                    iepsConcepto.TipoFactor = p.TasaOcuota2;
                    iepsConcepto.Impuesto = p.ClaveImpuesto2;
                    iepsConcepto.Importe = p.ImporteImpuesto2;
                    impuestosConcepto.Add(iepsConcepto);
                    totalIeps += p.ImporteImpuesto2;
                }
                else if (p.ImporteImpuesto1 > 0 && p.ImporteImpuesto2 == 0)
                {
                    /*SOLO IVA*/
                    ivaConcepto = new ComprobanteConceptoImpuestosTraslado();
                    ivaConcepto.Base = p.SubTotal;
                    ivaConcepto.TasaOCuota = p.Impuesto1;
                    ivaConcepto.TipoFactor = p.TasaOcuota1;
                    ivaConcepto.Impuesto = p.ClaveImpuesto1;
                    ivaConcepto.Importe = p.ImporteImpuesto1;
                    impuestosConcepto.Add(ivaConcepto);
                    totalIva += p.ImporteImpuesto1;


                }
                else if (p.ImporteImpuesto1 > 0 && p.ImporteImpuesto2 > 0)
                {
                    /*IVA + IEPS*/
                    ivaConcepto = new ComprobanteConceptoImpuestosTraslado();
                    ivaConcepto.Base = p.SubTotal;
                    ivaConcepto.TasaOCuota = p.Impuesto1;
                    ivaConcepto.TipoFactor = p.TasaOcuota1;
                    ivaConcepto.Impuesto = p.ClaveImpuesto1;
                    ivaConcepto.Importe = p.ImporteImpuesto1;
                    impuestosConcepto.Add(ivaConcepto);
                    totalIva += p.ImporteImpuesto1;

                    iepsConcepto = new ComprobanteConceptoImpuestosTraslado();
                    iepsConcepto.Base = p.SubTotal;
                    iepsConcepto.TasaOCuota = p.Impuesto2;
                    iepsConcepto.TipoFactor = p.TasaOcuota2;
                    iepsConcepto.Impuesto = p.ClaveImpuesto2;
                    iepsConcepto.Importe = p.ImporteImpuesto2;
                    impuestosConcepto.Add(iepsConcepto);
                    totalIeps += p.ImporteImpuesto2;

                }

                //Agregar los impuestos del concepto al concepto y agregar el concepto a la lista//
                concepto.Impuestos = new ComprobanteConceptoImpuestos();
                concepto.Impuestos.Traslados = impuestosConcepto.ToArray();
                conceptos.Add(concepto);

            }

            /***************************************************************************/
            /********************Operaciones a nivel del comprobante********************/
            comprobante.Conceptos = conceptos.ToArray();
            totalImpuestosComprobante = new ComprobanteImpuestos();
            impuestosComprobante = new List<ComprobanteImpuestosTraslado>();
            ivaComprobante = new ComprobanteImpuestosTraslado();
            iepsComprobante = new ComprobanteImpuestosTraslado();

            if (totalIva > 0)
            {
                //Total IVA
                ivaComprobante.Importe = totalIva;
                ivaComprobante.Impuesto = "002";
                ivaComprobante.TipoFactor = "Tasa";
                ivaComprobante.TasaOCuota = 0.160000m;
                impuestosComprobante.Add(ivaComprobante);

            }

            if (totalIeps > 0)
            {
                //Total IEPS
                iepsComprobante.Importe = totalIeps;
                iepsComprobante.Impuesto = "003";
                iepsComprobante.TipoFactor = "Tasa";
                iepsComprobante.TasaOCuota = 0.080000m;
                impuestosComprobante.Add(iepsComprobante);
            }


            if ((totalIva + totalIeps) > 0)
            {
                //Total impuestos trasladados
                totalImpuestosComprobante.TotalImpuestosTrasladados = Math.Round(totalIva + totalIeps, 2);
                totalImpuestosComprobante.Traslados = impuestosComprobante.ToArray();
                comprobante.Impuestos = totalImpuestosComprobante;
            }


            /***************************************************************************/
            facturaActual = empresa.DirectorioComprobantes + "FACTURA " + Venta.NoRef.ToString() + "_" + Venta.CreatedBy + "_" + Ambiente.TimeText(Venta.CreatedAt) + ".XML";


            //Crear Xml
            Serializar(comprobante);
            cadenaOriginal = GetCadenaOriginal();
            comprobante.Certificado = selloDigital.Certificado(empresa.RutaCer);
            comprobante.Sello = selloDigital.Sellar(cadenaOriginal, empresa.RutaKey, empresa.ClavePrivada);
            Serializar(comprobante);
            return Timbrar(facturaActual);

        }


        public void Cancelar()
        {
            Inicializar();
            if (Venta == null || partidas.Count == 0 || empresa == null || cliente == null)
            {
                Ambiente.Mensaje("Venta || partidas || empresa || Cliente == null");
                return;
            }

            if (cliente.Rfc == null)
            {
                Ambiente.Mensaje("PROCESO ABORTADO, RFC DEL CLIENTE NO ES VÁLIDO");
                return;
            }

            if (cliente.Rfc.Trim().Length == 0)
            {
                Ambiente.Mensaje("PROCESO ABORTADO, RFC DEL CLIENTE NO ES VÁLIDO");
                return;
            }
            if (Venta.UuId == null)
            {
                Ambiente.Mensaje("Proceso abortado, este documento no es una factura o no está timbrada");
                return;
            }



            respuestaCFDI = timbradoClient.CancelarAsincrono(
                empresa.UserWstimbrado,
                empresa.PassWstimbrado,
                File.ReadAllBytes(empresa.RutaArchivoPfx),
                Venta.UuId,
                empresa.ClavePrivada,
                (double)Venta.Total,
                empresa.Rfc,
                cliente.Rfc);

            s = respuestaCFDI.Mensaje;


            respuestaCFDI = timbradoClient.VerStatus(
                 empresa.UserWstimbrado,
                empresa.PassWstimbrado,
                 Venta.UuId,
                 (double)Math.Round(Venta.Total, 2),
                 empresa.Rfc,
                cliente.Rfc);

            s = respuestaCFDI.Mensaje;

            if (respuestaCFDI.Mensaje.Equals("Cancelado"))
            {
                Venta.EstatusSat = respuestaCFDI.Mensaje;
                ventaController.UpdateOne(Venta);
                Ambiente.Mensaje(s);
            }

        }

        public void ActualizarStatusSAT()
        {

            Inicializar();
            bool CrearLog = false;
            string s = "";
            if (Venta == null || partidas.Count == 0 || empresa == null || cliente == null)
            {
                CrearLog = true;
                s += "Venta || partidas || empresa || Cliente == null";
            }

            if (cliente.Rfc == null)
            {
                CrearLog = true;
                s += "/";
                s += "PROCESO ABORTADO, RFC DEL CLIENTE NO ES VÁLIDO";
            }

            if (cliente.Rfc.Trim().Length == 0)
            {
                CrearLog = true;
                s += "/";
                s += "PROCESO ABORTADO, RFC DEL CLIENTE NO ES VÁLIDO";
            }
            if (Venta.UuId == null)
            {
                CrearLog = true;
                s += "/";
                s += "Proceso abortado, este documento no es una factura o no está timbrada";
            }


            if (CrearLog)
            {
                var error = new DymError();
                error.Message = s;
                error.ToString = s;
                error.VentaId = Venta == null ? "NULL" : Venta.VentaId.ToString();
                error.LoggedUser = Ambiente.LoggedUser.UsuarioId;
                error.CreatedAt = DateTime.Now;
                dymErrorController.InsertOne(error);
                return;
            }



            respuestaCFDI = timbradoClient.VerStatus(
                 empresa.UserWstimbrado,
                empresa.PassWstimbrado,
                 Venta.UuId,
                 (double)Math.Round(Venta.Total, 2),
                 empresa.Rfc,
                cliente.Rfc);
            Venta.EstatusSat = respuestaCFDI.Mensaje;
            ventaController.UpdateOne(Venta);

        }
        //Cobvierte el objeto comprobante a xml
        private void Serializar(Comprobante comprobante)
        {
            XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
            xmlNameSpace.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
            xmlNameSpace.Add("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            xmlNameSpace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            XmlSerializer serializer = new XmlSerializer(typeof(Comprobante));

            using (var stringWriter = new StringWriterEncoding(Encoding.UTF8))
            {
                using (XmlWriter writter = XmlWriter.Create(stringWriter))
                {
                    serializer.Serialize(writter, comprobante, xmlNameSpace);
                    xml = stringWriter.ToString();
                }
            }
            //guardamos el string en un archivo
            File.WriteAllText(facturaActual, xml);
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
            transformador.Load(empresa.RutaCadenaOriginal);

            using (StringWriter sw = new StringWriter())
            using (XmlWriter xwo = XmlWriter.Create(sw, transformador.OutputSettings))
            {

                transformador.Transform(facturaActual, xwo);
                cadenaOriginal = sw.ToString();
                return cadenaOriginal;
            }

        }

        private bool Timbrar(String pathXML)
        {

            //TIMBRE DEL XML


            byte[] bXML = File.ReadAllBytes(pathXML);
            if (empresa.TimbradoTest)
                respuestaCFDI = timbradoClient.TimbrarTest(empresa.UserWstimbrado, empresa.PassWstimbrado, bXML);
            else
                respuestaCFDI = timbradoClient.Timbrar(empresa.UserWstimbrado, empresa.PassWstimbrado, bXML);
            if (respuestaCFDI.Documento == null)
            {
                Ambiente.Mensaje(respuestaCFDI.Mensaje);
                return false;
            }
            else
            {
                File.WriteAllBytes(pathXML, respuestaCFDI.Documento);
                Deserializar(pathXML);
                Venta.CadenaOriginal = cadenaOriginal;
                Venta.SelloCfdi = comprobante.TimbreFiscalDigital.SelloCFD;
                Venta.SelloSat = comprobante.TimbreFiscalDigital.SelloSAT;
                Venta.UuId = comprobante.TimbreFiscalDigital.UUID;
                Venta.NoCertificado = noCertificado;
                Venta.RutaXml = facturaActual;
                Venta.EstatusSat = "Vigente";
                return ventaController.UpdateOne(Venta);
            }
        }
    }
}
