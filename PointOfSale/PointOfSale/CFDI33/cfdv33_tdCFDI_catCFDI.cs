//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// <Jesus Mendoza>.
//     Versión de runtime:4.0.30319.42000
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
// </Jesus Mendoza>
//------------------------------------------------------------------------------

//------------------------------------------------------------------------------

using CFD33;
using System.Xml.Schema;
using System.Xml.Serialization;



/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3", IsNullable = false)]
public partial class Comprobante
{

    private ComprobanteCfdiRelacionados cfdiRelacionadosField;

    private ComprobanteEmisor emisorField;

    private ComprobanteReceptor receptorField;

    private ComprobanteConcepto[] conceptosField;

    private ComprobanteImpuestos impuestosField;

    private ComprobanteComplemento[] complementoField;

    private ComprobanteAddenda addendaField;

    private string versionField;

    private string serieField;

    private string folioField;

    private string fechaField;

    private string selloField;

    private string formaPagoField;

    private bool formaPagoFieldSpecified;

    private string noCertificadoField;

    private string certificadoField;

    private string condicionesDePagoField;

    private decimal subTotalField;

    private decimal descuentoField;

    private bool descuentoFieldSpecified;

    private string monedaField;

    private decimal tipoCambioField;

    private bool tipoCambioFieldSpecified;

    private decimal totalField;

    private string tipoDeComprobanteField;

    private string metodoPagoField;

    private bool metodoPagoFieldSpecified;

    private string lugarExpedicionField;

    private string confirmacionField;

    [XmlAttribute("schemaLocation", Namespace = XmlSchema.InstanceNamespace)]
    public string xsiSchemaLocation = "http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd";

    public TimbreFiscalDigital TimbreFiscalDigital;
    public Comprobante()
    {
        this.versionField = "3.3";
    }

    /// <remarks/>
    public ComprobanteCfdiRelacionados CfdiRelacionados
    {
        get
        {
            return this.cfdiRelacionadosField;
        }
        set
        {
            this.cfdiRelacionadosField = value;
        }
    }

    /// <remarks/>
    public ComprobanteEmisor Emisor
    {
        get
        {
            return this.emisorField;
        }
        set
        {
            this.emisorField = value;
        }
    }

    /// <remarks/>
    public ComprobanteReceptor Receptor
    {
        get
        {
            return this.receptorField;
        }
        set
        {
            this.receptorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Concepto", IsNullable = false)]
    public ComprobanteConcepto[] Conceptos
    {
        get
        {
            return this.conceptosField;
        }
        set
        {
            this.conceptosField = value;
        }
    }

    /// <remarks/>
    public ComprobanteImpuestos Impuestos
    {
        get
        {
            return this.impuestosField;
        }
        set
        {
            this.impuestosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Complemento")]
    public ComprobanteComplemento[] Complemento
    {
        get
        {
            return this.complementoField;
        }
        set
        {
            this.complementoField = value;
        }
    }

    /// <remarks/>
    public ComprobanteAddenda Addenda
    {
        get
        {
            return this.addendaField;
        }
        set
        {
            this.addendaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Version
    {
        get
        {
            return this.versionField;
        }
        set
        {
            this.versionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Serie
    {
        get
        {
            return this.serieField;
        }
        set
        {

            this.serieField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Folio
    {
        get
        {
            return this.folioField;
        }
        set
        {

            this.folioField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Fecha
    {
        get
        {
            return this.fechaField;
        }
        set
        {
            this.fechaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Sello
    {
        get
        {
            return this.selloField;
        }
        set
        {
            this.selloField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string FormaPago
    {
        get
        {
            return this.formaPagoField;
        }
        set
        {
            formaPagoFieldSpecified = true;
            this.formaPagoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool FormaPagoSpecified
    {
        get
        {
            return this.formaPagoFieldSpecified;
        }
        set
        {
            this.formaPagoFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NoCertificado
    {
        get
        {
            return this.noCertificadoField;
        }
        set
        {
            this.noCertificadoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Certificado
    {
        get
        {
            return this.certificadoField;
        }
        set
        {
            this.certificadoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CondicionesDePago
    {
        get
        {
            return this.condicionesDePagoField;
        }
        set
        {
            this.condicionesDePagoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal SubTotal
    {
        get
        {
            return this.subTotalField;
        }
        set
        {
            this.subTotalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Descuento
    {
        get
        {
            return this.descuentoField;
        }
        set
        {
            descuentoFieldSpecified = true;
            this.descuentoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DescuentoSpecified
    {
        get
        {
            return this.descuentoFieldSpecified;
        }
        set
        {
            this.descuentoFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Moneda
    {
        get
        {
            return this.monedaField;
        }
        set
        {

            this.monedaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TipoCambio
    {
        get
        {
            return this.tipoCambioField;
        }
        set
        {
            this.tipoCambioFieldSpecified = true;
            this.tipoCambioField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TipoCambioSpecified
    {
        get
        {
            return this.tipoCambioFieldSpecified;
        }
        set
        {
            this.tipoCambioFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Total
    {
        get
        {
            return this.totalField;
        }
        set
        {
            this.totalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TipoDeComprobante
    {
        get
        {
            return this.tipoDeComprobanteField;
        }
        set
        {

            this.tipoDeComprobanteField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string MetodoPago
    {
        get
        {
            return this.metodoPagoField;
        }
        set
        {
            metodoPagoFieldSpecified = true;
            this.metodoPagoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool MetodoPagoSpecified
    {
        get
        {
            return this.metodoPagoFieldSpecified;
        }
        set
        {
            this.metodoPagoFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string LugarExpedicion
    {
        get
        {
            return this.lugarExpedicionField;
        }
        set
        {
            this.lugarExpedicionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Confirmacion
    {
        get
        {
            return this.confirmacionField;
        }
        set
        {
            this.confirmacionField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteCfdiRelacionados
{

    private ComprobanteCfdiRelacionadosCfdiRelacionado[] cfdiRelacionadoField;

    private string tipoRelacionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CfdiRelacionado")]
    public ComprobanteCfdiRelacionadosCfdiRelacionado[] CfdiRelacionado
    {
        get
        {
            return this.cfdiRelacionadoField;
        }
        set
        {
            this.cfdiRelacionadoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TipoRelacion
    {
        get
        {
            return this.tipoRelacionField;
        }
        set
        {
            this.tipoRelacionField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteCfdiRelacionadosCfdiRelacionado
{

    private string uUIDField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string UUID
    {
        get
        {
            return this.uUIDField;
        }
        set
        {
            this.uUIDField = value;
        }
    }
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteEmisor
{

    private string rfcField;

    private string nombreField;

    private string regimenFiscalField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Rfc
    {
        get
        {
            return this.rfcField;
        }
        set
        {
            this.rfcField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Nombre
    {
        get
        {
            return this.nombreField;
        }
        set
        {
            this.nombreField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string RegimenFiscal
    {
        get
        {
            return this.regimenFiscalField;
        }
        set
        {
            this.regimenFiscalField = value;
        }
    }
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteReceptor
{

    private string rfcField;

    private string nombreField;

    private string residenciaFiscalField;

    private bool residenciaFiscalFieldSpecified;

    private string numRegIdTribField;

    private string usoCFDIField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Rfc
    {
        get
        {
            return this.rfcField;
        }
        set
        {
            this.rfcField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Nombre
    {
        get
        {
            return this.nombreField;
        }
        set
        {
            this.nombreField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ResidenciaFiscal
    {
        get
        {
            return this.residenciaFiscalField;
        }
        set
        {
            this.residenciaFiscalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ResidenciaFiscalSpecified
    {
        get
        {
            return this.residenciaFiscalFieldSpecified;
        }
        set
        {
            this.residenciaFiscalFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NumRegIdTrib
    {
        get
        {
            return this.numRegIdTribField;
        }
        set
        {
            this.numRegIdTribField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string UsoCFDI
    {
        get
        {
            return this.usoCFDIField;
        }
        set
        {
            this.usoCFDIField = value;
        }
    }
}



/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConcepto
{

    private ComprobanteConceptoImpuestos impuestosField;

    private ComprobanteConceptoInformacionAduanera[] informacionAduaneraField;

    private ComprobanteConceptoCuentaPredial cuentaPredialField;

    private ComprobanteConceptoComplementoConcepto complementoConceptoField;

    private ComprobanteConceptoParte[] parteField;

    private string claveProdServField;

    private string noIdentificacionField;

    private decimal cantidadField;

    private string claveUnidadField;

    private string unidadField;

    private string descripcionField;

    private decimal valorUnitarioField;

    private decimal importeField;

    private decimal descuentoField;

    private bool descuentoFieldSpecified;

    /// <remarks/>
    public ComprobanteConceptoImpuestos Impuestos
    {
        get
        {
            return this.impuestosField;
        }
        set
        {
            this.impuestosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("InformacionAduanera")]
    public ComprobanteConceptoInformacionAduanera[] InformacionAduanera
    {
        get
        {
            return this.informacionAduaneraField;
        }
        set
        {
            this.informacionAduaneraField = value;
        }
    }

    /// <remarks/>
    public ComprobanteConceptoCuentaPredial CuentaPredial
    {
        get
        {
            return this.cuentaPredialField;
        }
        set
        {
            this.cuentaPredialField = value;
        }
    }

    /// <remarks/>
    public ComprobanteConceptoComplementoConcepto ComplementoConcepto
    {
        get
        {
            return this.complementoConceptoField;
        }
        set
        {
            this.complementoConceptoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Parte")]
    public ComprobanteConceptoParte[] Parte
    {
        get
        {
            return this.parteField;
        }
        set
        {
            this.parteField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ClaveProdServ
    {
        get
        {
            return this.claveProdServField;
        }
        set
        {
            this.claveProdServField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NoIdentificacion
    {
        get
        {
            return this.noIdentificacionField;
        }
        set
        {
            this.noIdentificacionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Cantidad
    {
        get
        {
            return this.cantidadField;
        }
        set
        {
            this.cantidadField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ClaveUnidad
    {
        get
        {
            return this.claveUnidadField;
        }
        set
        {
            this.claveUnidadField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Unidad
    {
        get
        {
            return this.unidadField;
        }
        set
        {
            this.unidadField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Descripcion
    {
        get
        {
            return this.descripcionField;
        }
        set
        {
            this.descripcionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal ValorUnitario
    {
        get
        {
            return this.valorUnitarioField;
        }
        set
        {
            this.valorUnitarioField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe
    {
        get
        {
            return this.importeField;
        }
        set
        {
            this.importeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Descuento
    {
        get
        {
            return this.descuentoField;
        }
        set
        {
            DescuentoSpecified = true;
            this.descuentoField = value;

        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DescuentoSpecified
    {
        get
        {
            return this.descuentoFieldSpecified;
        }
        set
        {
            this.descuentoFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoImpuestos
{

    private ComprobanteConceptoImpuestosTraslado[] trasladosField;

    private ComprobanteConceptoImpuestosRetencion[] retencionesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable = false)]
    public ComprobanteConceptoImpuestosTraslado[] Traslados
    {
        get
        {
            return this.trasladosField;
        }
        set
        {
            this.trasladosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable = false)]
    public ComprobanteConceptoImpuestosRetencion[] Retenciones
    {
        get
        {
            return this.retencionesField;
        }
        set
        {
            this.retencionesField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoImpuestosTraslado
{

    private decimal baseField;

    private string impuestoField;

    private string tipoFactorField;

    private decimal tasaOCuotaField;

    private bool tasaOCuotaFieldSpecified;

    private decimal importeField;

    private bool importeFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Base
    {
        get
        {
            return this.baseField;
        }
        set
        {
            this.baseField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Impuesto
    {
        get
        {
            return this.impuestoField;
        }
        set
        {
            this.impuestoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TipoFactor
    {
        get
        {
            return this.tipoFactorField;
        }
        set
        {

            this.tipoFactorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TasaOCuota
    {
        get
        {
            return this.tasaOCuotaField;
        }
        set
        {
            this.tasaOCuotaFieldSpecified = true;
            this.tasaOCuotaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TasaOCuotaSpecified
    {
        get
        {
            return this.tasaOCuotaFieldSpecified;
        }
        set
        {
            this.tasaOCuotaFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe
    {
        get
        {
            return this.importeField;
        }
        set
        {
            this.importeFieldSpecified = true;
            this.importeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ImporteSpecified
    {
        get
        {
            return this.importeFieldSpecified;
        }
        set
        {
            this.importeFieldSpecified = value;
        }
    }
}



/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoImpuestosRetencion
{

    private decimal baseField;

    private string impuestoField;

    private string tipoFactorField;

    private decimal tasaOCuotaField;

    private decimal importeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Base
    {
        get
        {
            return this.baseField;
        }
        set
        {
            this.baseField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Impuesto
    {
        get
        {
            return this.impuestoField;
        }
        set
        {
            this.impuestoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TipoFactor
    {
        get
        {
            return this.tipoFactorField;
        }
        set
        {
            this.tipoFactorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TasaOCuota
    {
        get
        {
            return this.tasaOCuotaField;
        }
        set
        {
            this.tasaOCuotaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe
    {
        get
        {
            return this.importeField;
        }
        set
        {
            this.importeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoInformacionAduanera
{

    private string numeroPedimentoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NumeroPedimento
    {
        get
        {
            return this.numeroPedimentoField;
        }
        set
        {
            this.numeroPedimentoField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoCuentaPredial
{

    private string numeroField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Numero
    {
        get
        {
            return this.numeroField;
        }
        set
        {
            this.numeroField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoComplementoConcepto
{

    private System.Xml.XmlElement[] anyField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Any
    {
        get
        {
            return this.anyField;
        }
        set
        {
            this.anyField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoParte
{

    private ComprobanteConceptoParteInformacionAduanera[] informacionAduaneraField;

    private string claveProdServField;

    private string noIdentificacionField;

    private decimal cantidadField;

    private string unidadField;

    private string descripcionField;

    private decimal valorUnitarioField;

    private bool valorUnitarioFieldSpecified;

    private decimal importeField;

    private bool importeFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("InformacionAduanera")]
    public ComprobanteConceptoParteInformacionAduanera[] InformacionAduanera
    {
        get
        {
            return this.informacionAduaneraField;
        }
        set
        {
            this.informacionAduaneraField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ClaveProdServ
    {
        get
        {
            return this.claveProdServField;
        }
        set
        {
            this.claveProdServField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NoIdentificacion
    {
        get
        {
            return this.noIdentificacionField;
        }
        set
        {
            this.noIdentificacionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Cantidad
    {
        get
        {
            return this.cantidadField;
        }
        set
        {
            this.cantidadField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Unidad
    {
        get
        {
            return this.unidadField;
        }
        set
        {
            this.unidadField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Descripcion
    {
        get
        {
            return this.descripcionField;
        }
        set
        {
            this.descripcionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal ValorUnitario
    {
        get
        {
            return this.valorUnitarioField;
        }
        set
        {
            this.valorUnitarioField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ValorUnitarioSpecified
    {
        get
        {
            return this.valorUnitarioFieldSpecified;
        }
        set
        {
            this.valorUnitarioFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe
    {
        get
        {
            return this.importeField;
        }
        set
        {
            this.importeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ImporteSpecified
    {
        get
        {
            return this.importeFieldSpecified;
        }
        set
        {
            this.importeFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoParteInformacionAduanera
{

    private string numeroPedimentoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NumeroPedimento
    {
        get
        {
            return this.numeroPedimentoField;
        }
        set
        {
            this.numeroPedimentoField = value;
        }
    }
}



/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteImpuestos
{

    private ComprobanteImpuestosRetencion[] retencionesField;

    private ComprobanteImpuestosTraslado[] trasladosField;

    private decimal totalImpuestosRetenidosField;

    private bool totalImpuestosRetenidosFieldSpecified;

    private decimal totalImpuestosTrasladadosField;

    private bool totalImpuestosTrasladadosFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable = false)]
    public ComprobanteImpuestosRetencion[] Retenciones
    {
        get
        {
            return this.retencionesField;
        }
        set
        {
            this.retencionesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable = false)]
    public ComprobanteImpuestosTraslado[] Traslados
    {
        get
        {
            return this.trasladosField;
        }
        set
        {
            this.trasladosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TotalImpuestosRetenidos
    {
        get
        {
            return this.totalImpuestosRetenidosField;
        }
        set
        {
            this.totalImpuestosRetenidosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TotalImpuestosRetenidosSpecified
    {
        get
        {
            return this.totalImpuestosRetenidosFieldSpecified;
        }
        set
        {
            this.totalImpuestosRetenidosFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TotalImpuestosTrasladados
    {
        get
        {
            return this.totalImpuestosTrasladadosField;
        }
        set
        {
            this.totalImpuestosTrasladadosFieldSpecified = true;
            this.totalImpuestosTrasladadosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TotalImpuestosTrasladadosSpecified
    {
        get
        {
            return this.totalImpuestosTrasladadosFieldSpecified;
        }
        set
        {
            this.totalImpuestosTrasladadosFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteImpuestosRetencion
{

    private string impuestoField;

    private decimal importeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Impuesto
    {
        get
        {
            return this.impuestoField;
        }
        set
        {
            this.impuestoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe
    {
        get
        {
            return this.importeField;
        }
        set
        {
            this.importeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteImpuestosTraslado
{

    private string impuestoField;

    private string tipoFactorField;

    private decimal tasaOCuotaField;

    private decimal importeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Impuesto
    {
        get
        {
            return this.impuestoField;
        }
        set
        {
            this.impuestoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TipoFactor
    {
        get
        {
            return this.tipoFactorField;
        }
        set
        {
            this.tipoFactorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TasaOCuota
    {
        get
        {
            return this.tasaOCuotaField;
        }
        set
        {
            this.tasaOCuotaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe
    {
        get
        {
            return this.importeField;
        }
        set
        {
            this.importeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteComplemento
{

    private System.Xml.XmlElement[] anyField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Any
    {
        get
        {
            return this.anyField;
        }
        set
        {
            this.anyField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteAddenda
{

    private System.Xml.XmlElement[] anyField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Any
    {
        get
        {
            return this.anyField;
        }
        set
        {
            this.anyField = value;
        }
    }
}