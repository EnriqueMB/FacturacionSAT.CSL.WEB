using FacturacionSAT.CSL.WEB.Models;
using FacturacionSAT.CSL.WEB.Models.Datos;
using FacturacionSAT.CSL.WEB.Models.ViewModel;
using FacturacionSAT.CSL.WEB.SystemHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Diagnostics;

namespace FacturacionSAT.CSL.WEB.Controllers
{
    public class FacturaController : Controller
    {
        private string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        private string pathXML, idFile, pathRootSystemHelperSAT, pahtRootSATTempFile, pathHTMLTempFilePDF, pathRootSATEmisorXML;

        [HttpGet]
        public ActionResult Reimpresion(IndexFacturaViewModel Model)
        {
            try
            {
                ModelState.Remove("RFCReceptor");
                ModelState.Remove("CodigoBarra");
                if (!ModelState.IsValid)
                {
                    TempData["message"] = "Verifique sus datos";
                    TempData["typemessage"] = "2";
                    return RedirectToAction("Facturacion", "Home");
                }

                AuxSQLModel oAuxSQLModel = new AuxSQLModel();
                FacturaDatos oFacturaDatos = new FacturaDatos();

                oAuxSQLModel.Conexion = Conexion;

                FacturaReimpresionModel oReimpresionModel = oFacturaDatos.Factura_get_Reimpresion(oAuxSQLModel, Model.CodigoBarraReimpresion);

                if (oAuxSQLModel.Success)
                {
                    //guardamos el string en un archivo
                    idFile = Guid.NewGuid().ToString();
                    string getNameXML = idFile + ".xml";
                    pahtRootSATTempFile = Server.MapPath("~/SATTempFile");
                    pathXML = pahtRootSATTempFile + "\\" + getNameXML;

                    System.IO.File.WriteAllText(pathXML, oReimpresionModel.XMLFactura);

                    //generamos un objeto comprobante ya que la mayoría de la informacion de la factura esta en el xml
                    Comprobante oComprobante = GenerarComprobanteDeXMLPath();

                    if (System.IO.File.Exists(pathXML))
                    {
                        System.IO.File.Delete(pathXML);
                    }
                    FacturacionViewModel oFactura = new FacturacionViewModel();

                    oFactura.Id_factura = oReimpresionModel.Id;
                    oFactura.Version = oComprobante.Version;
                    oFactura.TipoComprobante = oComprobante.TipoDeComprobante;
                    oFactura.Moneda = oComprobante.Moneda;
                    oFactura.Subtotal = oComprobante.SubTotal;
                    oFactura.TotalDescuento = oComprobante.Descuento;
                    oFactura.Total = oComprobante.Total;
                    oFactura.LugarExpedicion = oComprobante.LugarExpedicion;
                    oFactura.CodigoBarraBoleto = Model.CodigoBarraReimpresion;
                    oFactura.FormaDePago = oComprobante.FormaPago;
                    oFactura.RegimenFiscal = oComprobante.Emisor.RegimenFiscal;
                    oFactura.Folio = oComprobante.Folio;
                    oFactura.Fecha = DateTime.Now;
                    
                    oFactura.RFCReceptor = oComprobante.Receptor.Rfc;
                    oFactura.RazonSocial = oComprobante.Receptor.Nombre;
                    oFactura.UsoCFDI = oComprobante.Receptor.UsoCFDI;

                    oAuxSQLModel.ResetValuesSQL();

                    oFacturaDatos.Factura_get_Generales_Reimpresion(oAuxSQLModel, Model.CodigoBarraReimpresion, oComprobante, oFactura);

                    if (oAuxSQLModel.Success)
                    {
                        for (int i = 0; i < oComprobante.Conceptos.Length; i++)
                        {
                            oFactura.Conceptos[i].Descripcion = oComprobante.Conceptos[i].Descripcion;
                            oFactura.Conceptos[i].PrecioUnitario = oComprobante.Conceptos[i].ValorUnitario;
                            oFactura.Conceptos[i].Impuestos[0].TasaOCuota = oComprobante.Conceptos[i].Impuestos.Traslados[0].TasaOCuota;
                            oFactura.Conceptos[i].Impuestos[0].Importe = oComprobante.Conceptos[i].Impuestos.Traslados[0].Importe;
                            oFactura.Conceptos[i].Impuestos[0].Clave_Impuesto = oComprobante.Conceptos[i].Impuestos.Traslados[0].Impuesto;
                            oFactura.Conceptos[i].Impuestos[0].TipoFactor = oComprobante.Conceptos[i].Impuestos.Traslados[0].TipoFactor;
                        }
                        return View(oFactura);
                    }
                    else
                    {
                        TempData["message"] = "Hubo un error al obtener los datos, contacte con soporte técnico.";
                        TempData["typemessage"] = "2";

                        return RedirectToAction("Facturacion", "Home");
                    }
                }
                else
                {
                    TempData["message"] = "Verifique sus datos";
                    TempData["typemessage"] = "2";

                    return RedirectToAction("Facturacion", "Home");
                }
            }
            catch (Exception ex)
            {
                if (System.IO.File.Exists(pathXML))
                {
                    System.IO.File.Delete(pathXML);
                }
                string Mensaje = ex.Message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                TempData["message"] = "Hubo un error al obtener los datos, contacte con soporte técnico.";
                TempData["typemessage"] = "2";
                return RedirectToAction("Facturacion", "Home");
            }

        }

        [HttpPost]
        public ActionResult Reimpresion(FacturacionViewModel Factura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AuxSQLModel oAuxSQLModel = new AuxSQLModel();
                    FacturaDatos oFacturaDatos = new FacturaDatos();

                    oAuxSQLModel.Conexion = Conexion;

                    FacturaReimpresionModel oReimpresionModel = oFacturaDatos.Factura_get_Reimpresion(oAuxSQLModel, Factura.CodigoBarraBoleto);

                    if (oAuxSQLModel.Success)
                    {
                        //guardamos el string en un archivo
                        /**************************************/
                        /*paths*/
                        idFile = Guid.NewGuid().ToString();
                        string getNameXML = idFile + ".xml";
                        pahtRootSATTempFile = Server.MapPath("~/SATTempFile");
                        pathXML = pahtRootSATTempFile + "\\" + getNameXML;
                        pathRootSystemHelperSAT = Server.MapPath("~/SystemHelper/SAT");
                        /**************************************/
                        //generamos el xml
                        System.IO.File.WriteAllText(pathXML, oReimpresionModel.XMLFactura);
                        //generamos un objeto comprobante ya que la mayoría de la informacion de la factura esta en el xml
                        Comprobante oComprobante = GenerarComprobanteDeXMLPath();

                        oAuxSQLModel.ResetValuesSQL();
                        CFDIDatosEmisorModels oEmisor = new CFDIDatosEmisorModels();
                        CFDIDatosEmisorDatos oEmisorDatos = new CFDIDatosEmisorDatos();
                        oEmisor = oEmisorDatos.ObtenerDatosEmisorPredeterminado(oAuxSQLModel);
                        Factura.Logotipo = oEmisor.Imagen;

                        if (GenerarPDFReimpresion(oComprobante, Factura))
                        {
                            TempData["message"] = "Archivo pdf creado con éxito.";
                            //faltaria enviar al correo
                            /*Obtenemos los datos del emisor*/
                            
                            oAuxSQLModel.ResetValuesSQL();
                            oAuxSQLModel.Conexion = Conexion;
                            Factura.EmailEmisor = oEmisor.Correo;
                            oFacturaDatos.Factura_Save_Factura_ReimpresionFactura(oAuxSQLModel, Factura); //guardamos la factura, ya generada

                            List<string> ListaPathArchivos = new List<string>();

                            ListaPathArchivos.Add(pathXML);
                            ListaPathArchivos.Add(pathHTMLTempFilePDF);

                            if (EnviarFacturaEmail(oEmisor.Correo, oEmisor.Password, Factura.EmailReceptor, ListaPathArchivos))
                            {
                                TempData["message"] = "Factura enviada a su email, por favor verifique su bandeja.";
                                TempData["typemessage"] = "1";
                            }
                            else
                            {
                                TempData["message"] = "Hubo un error al enviar la factura a su correo.";
                                TempData["typemessage"] = "2";
                            }

                            //borramos los archivos
                            if (System.IO.File.Exists(pathXML))
                            {
                                System.IO.File.Delete(pathXML);
                            }
                            if (System.IO.File.Exists(pathHTMLTempFilePDF))
                            {
                                System.IO.File.Delete(pathHTMLTempFilePDF);
                            }

                            return RedirectToAction("Facturacion", "Home");
                        }
                        else
                        {
                            TempData["message"] = "Hubo un error al obtener los datos, contacte con soporte técnico.";
                            TempData["typemessage"] = "2";
                            return View(Factura);
                        }
                    }
                    else
                    {
                        TempData["message"] = "Hubo un error al obtener los datos, contacte con soporte técnico.";
                        TempData["typemessage"] = "2";
                        return View(Factura);
                    }
                }
                else
                {
                    TempData["message"] = "Hubo un error al obtener los datos, contacte con soporte técnico.";
                    TempData["typemessage"] = "2";
                    return View(Factura);
                }
            }
            catch (Exception ex)
            {
                if (System.IO.File.Exists(pathXML))
                {
                    System.IO.File.Delete(pathXML);
                }
                if (System.IO.File.Exists(pathHTMLTempFilePDF))
                {
                    System.IO.File.Delete(pathHTMLTempFilePDF);
                }

                //string Mensaje = ex.Message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                //TempData["message"] = Mensaje;
                TempData["message"] = "Hubo un error al obtener los datos, contacte con soporte técnico.";
                TempData["typemessage"] = "2";

                return RedirectToAction("Facturacion", "Home");
            }
        }

        [HttpGet]
        public ActionResult Add(IndexFacturaViewModel Model)
        {
            try
            {
                ModelState.Remove("CodigoBarraReimpresion");
                if (!ModelState.IsValid)
                {
                    TempData["message"] = "Verifique sus datos";
                    TempData["typemessage"] = "2";
                    return RedirectToAction("Facturacion", "Home");
                }

                ComboDatos oComboDatos = new ComboDatos();
                AuxSQLModel oAuxSQLModel = new AuxSQLModel();
                FacturaDatos oFacturaDatos = new FacturaDatos();
                oAuxSQLModel.Conexion = Conexion;
                oAuxSQLModel.Id_usuario = Convert.ToInt32(User.Identity.Name);

                GetListasSAT(oComboDatos, oAuxSQLModel, Model.RFCReceptor);

                FacturacionViewModel oFactura = new FacturacionViewModel();
                oFactura = oFacturaDatos.Factura_get_Generales_ADD(oAuxSQLModel, Model.CodigoBarra, Model.RFCReceptor);
                oFactura.CodigoBarraBoleto = Model.CodigoBarra;
                oFactura.Fecha = DateTime.Now;

                if (!oAuxSQLModel.Success)
                {
                    TempData["message"] = oAuxSQLModel.Mensaje;
                    TempData["typemessage"] = "2";

                    return RedirectToAction("Facturacion", "Home");
                }

                return View(oFactura);
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                TempData["message"] = Mensaje;
                TempData["typemessage"] = "2";
                return RedirectToAction("Facturacion", "Home");
            }

        }

        [HttpPost]
        public ActionResult Add(FacturacionViewModel Factura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    /*Generales*/
                    AuxSQLModel oAuxSQLModel = new AuxSQLModel();
                    oAuxSQLModel.Conexion = Conexion;
                    oAuxSQLModel.Id_usuario = Convert.ToInt32(User.Identity.Name);
                    /**************************************/
                    /*paths*/
                    pathRootSystemHelperSAT = Server.MapPath("~/SystemHelper/SAT");
                    pathRootSATEmisorXML = Server.MapPath("~/SAT");
                    pahtRootSATTempFile = Server.MapPath("~/SATTempFile");

                    //string getNameXML = string.Format("Factura-{0:yyyy-MM-dd_hh-mm-ss}.xml", DateTime.Now);
                    idFile = Guid.NewGuid().ToString();
                    string getNameXML = idFile + ".xml";
                    pathXML = pahtRootSATTempFile + "\\" + getNameXML;
                    string pathCadenaOriginal = pathRootSystemHelperSAT + "\\xslt33\\cadenaoriginal_3_3.xslt";
                    /**************************************/
                    /*Obtenemos los datos del emisor*/
                    CFDIDatosEmisorModels oEmisor = new CFDIDatosEmisorModels();
                    CFDIDatosEmisorDatos oEmisorDatos = new CFDIDatosEmisorDatos();


                    oEmisor = oEmisorDatos.ObtenerDatosEmisorPredeterminado(oAuxSQLModel);
                    /**************************************/
                    /*Obtenemos los datos del pac*/
                    oAuxSQLModel.ResetValuesSQL();
                    CFDIDatosPacModels oPac = new CFDIDatosPacModels();
                    CFDIPacDatos oPacDatos = new CFDIPacDatos();

                    oPac = oPacDatos.ObtenerDatosPacPredeterminado(oAuxSQLModel);
                    /**************************************/

                    //podemos validar el boleto antes por si le dan regresar y no vaya a facturar de nuevo 

                    //if (oAuxSQLModel.Success)
                    //{
                    //    throw new Exception(oAuxSQLModel.Mensaje);
                    //}

                    bool result = GenerarXML(pathRootSATEmisorXML, pathXML, pathCadenaOriginal, oEmisor, Factura, oPac);

                    if (result)
                    {
                        if (System.IO.File.Exists(pathXML))
                        {
                            TempData["message"] = "Archivo xml creado con éxito.";
                            TempData["typemessage"] = "1";

                            Factura.Logotipo = Server.MapPath(oEmisor.Imagen);

                            if (GenerarPDF(Factura))
                            {
                                TempData["message"] = "Archivo pdf creado con éxito.";
                                //faltaria enviar al correo
                                FacturaDatos oFacturaDatos = new FacturaDatos();
                                oAuxSQLModel.ResetValuesSQL();
                                oAuxSQLModel.Conexion = Conexion;
                                Factura.EmailEmisor = oEmisor.Correo;
                                oFacturaDatos.Factura_Save_Factura(oAuxSQLModel, pathXML, Factura); //guardamos la factura, ya generada

                                List<string> ListaPathArchivos = new List<string>();

                                ListaPathArchivos.Add(pathXML);
                                ListaPathArchivos.Add(pathHTMLTempFilePDF);

                                if (EnviarFacturaEmail(oEmisor.Correo, oEmisor.Password, Factura.EmailReceptor, ListaPathArchivos))
                                {
                                    TempData["message"] = "Factura enviada a su email, por favor verifique su bandeja.";
                                    TempData["typemessage"] = "1";
                                }
                                else
                                {
                                    TempData["message"] = "Hubo un error al enviar la factura a su correo.";
                                    TempData["typemessage"] = "2";
                                }

                                //borramos los archivos
                                if (System.IO.File.Exists(pathXML))
                                {
                                    System.IO.File.Delete(pathXML);
                                }
                                if (System.IO.File.Exists(pathHTMLTempFilePDF))
                                {
                                    System.IO.File.Delete(pathHTMLTempFilePDF);
                                }

                            }
                            else
                            {
                                //borramos los archivos
                                if (System.IO.File.Exists(pathXML))
                                {
                                    System.IO.File.Delete(pathXML);
                                }
                                if (System.IO.File.Exists(pathHTMLTempFilePDF))
                                {
                                    System.IO.File.Delete(pathHTMLTempFilePDF);
                                }
                            }
                        }

                        return RedirectToAction("Facturacion", "Home");
                    }
                    else
                    {
                        TempData["message"] = "Verifique sus datos";
                        TempData["typemessage"] = "2";

                        ComboDatos oComboDatos = new ComboDatos();
                        oAuxSQLModel = new AuxSQLModel();
                        FacturaDatos oFacturaDatos = new FacturaDatos();
                        oAuxSQLModel.Conexion = Conexion;
                        oAuxSQLModel.Id_usuario = Convert.ToInt32(User.Identity.Name);
                        GetListasSAT(oComboDatos, oAuxSQLModel, Factura.RFCReceptor);

                        return View(Factura);
                    }
                }
                else
                {
                    ComboDatos oComboDatos = new ComboDatos();
                    AuxSQLModel oAuxSQLModel = new AuxSQLModel();
                    FacturaDatos oFacturaDatos = new FacturaDatos();
                    oAuxSQLModel.Conexion = Conexion;
                    oAuxSQLModel.Id_usuario = Convert.ToInt32(User.Identity.Name);
                    GetListasSAT(oComboDatos, oAuxSQLModel, Factura.RFCReceptor);
                    return View(Factura);
                }
            }
            catch (Exception ex)
            {
                if (System.IO.File.Exists(pathXML))
                {
                    System.IO.File.Delete(pathXML);
                }
                if (System.IO.File.Exists(pathHTMLTempFilePDF))
                {
                    System.IO.File.Delete(pathHTMLTempFilePDF);
                }

                string Mensaje = ex.Message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                TempData["message"] = Mensaje;
                TempData["typemessage"] = "2";

                return RedirectToAction("Facturacion", "Home");
            }
        }

        private bool GenerarXML(string pathRootSATEmisorXML, string pathXML, string pathCadenaOriginal, CFDIDatosEmisorModels Emisor, FacturacionViewModel Factura, CFDIDatosPacModels Pac)
        {
            try
            {
                string pathKey = pathRootSATEmisorXML + "\\" + Emisor.URLArchivoKEY;
                string pathCer = pathRootSATEmisorXML + "\\" + Emisor.URLArchivoCER;
                string clavePrivada = Emisor.PasswordArchivoKEY;

                Factura.NombreEmisor = Emisor.RazonSocial;
                Factura.RFCEmisor = Emisor.RFC;
                Factura.RegimenFiscal = Emisor.CFDIRegimenFiscalDetalle.C_RegimenFiscal;

                string numeroCertificado, inicio, final, serie;
                SystemHelper.SelloDigital.leerCER(pathCer, out inicio, out final, out serie, out numeroCertificado);

                Comprobante oComprobante = new Comprobante();
                oComprobante.Version = Factura.Version; //requerido, se puede poner en la tabla configuracion
                                                        // oComprobante.Serie = Factura.Serie; //opcional, clasificacion interna en la empresa
                oComprobante.Folio = Factura.Folio; //opcional, numero del folio
                oComprobante.Fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"); //requerido, fecha y hora de la expedicion del comprobante, hora local
                oComprobante.Sello = ""; //requerido: quien realiza la factura
                oComprobante.FormaPago = Factura.FormaDePago; //requerido, del catálogo: Cfdi:FormaPago
                oComprobante.NoCertificado = numeroCertificado; //requerido, es en relacion al .cer 
                oComprobante.Certificado = "";
                oComprobante.SubTotal = Factura.Subtotal; // Atributo requerido para representar la suma de los importes de los conceptos antes de descuentos e 
                                                          //impuesto.No se permiten valores negativos.
                oComprobante.Descuento = Factura.TotalDescuento;
                oComprobante.Moneda = Factura.Moneda; // Catálogo del Cfdi:Moneda, si no es moneda nacional, se debe de poner el tipo de cambio
                                                      //oComprobante.TipoCambio
                oComprobante.Total = Factura.Total; //Subtotal menos descuento
                oComprobante.TipoDeComprobante = Factura.TipoComprobante; // Atributo requerido para expresar la clave del efecto del comprobante fiscal para el contribuyente emisor.
                                                                          //Se obtiene de la tabla Cfdi:TipoComprobante

                //oComprobante.MetodoPago = "PUE"; // opcional, Se obtiene de la tabla Cfdi:MetodoPago
                oComprobante.LugarExpedicion = Factura.LugarExpedicion; //requerido, Se obtiene de la tabla Cfdi:CodigoPostal
                ComprobanteEmisor oEmisor = new ComprobanteEmisor();
                oEmisor.Rfc = Factura.RFCEmisor;
                oEmisor.Nombre = Factura.NombreEmisor;
                oEmisor.RegimenFiscal = Factura.RegimenFiscal;
                ComprobanteReceptor oReceptor = new ComprobanteReceptor();
                oReceptor.Nombre = Factura.RazonSocial;
                oReceptor.Rfc = Factura.RFCReceptor;
                oReceptor.UsoCFDI = Factura.UsoCFDI; // requerido, uso del Cfdi por parte del receptor, se obtiene de la tabla Cfdi:UsoCFDI

                //asigno emisor y receptor
                oComprobante.Emisor = oEmisor;
                oComprobante.Receptor = oReceptor;

                //obtenemos los detalles del concepto, en este caso siempre será 1 por que se factura a 1 boleto
                List<ComprobanteConcepto> lstConceptos = new List<ComprobanteConcepto>();
                ComprobanteConcepto oConcepto = new ComprobanteConcepto();

                foreach (var Concepto in Factura.Conceptos)
                {
                    oConcepto.Importe = Concepto.PrecioUnitario;
                    oConcepto.ClaveProdServ = Concepto.ClaveProducto;
                    oConcepto.Cantidad = Concepto.Cantidad;
                    oConcepto.ClaveUnidad = Concepto.ClaveUnidad;
                    oConcepto.Descripcion = Concepto.Descripcion;
                    oConcepto.ValorUnitario = Concepto.PrecioUnitario;
                    oConcepto.Descuento = Concepto.Descuento.Value;
                    lstConceptos.Add(oConcepto);
                }

                //ComprobanteConceptoImpuestosTraslado 
                List<ComprobanteConceptoImpuestosTraslado> ListaImpuestosTraladado = new List<ComprobanteConceptoImpuestosTraslado>();
                ComprobanteConceptoImpuestosTraslado oImpuestosTraslado = new ComprobanteConceptoImpuestosTraslado();
                oImpuestosTraslado.Base = oConcepto.Importe - oConcepto.Descuento;
                oImpuestosTraslado.TasaOCuota = Factura.Conceptos[0].Impuestos[0].TasaOCuota;
                oImpuestosTraslado.TipoFactor = Factura.Conceptos[0].Impuestos[0].TipoFactor;
                oImpuestosTraslado.Impuesto = Factura.Conceptos[0].Impuestos[0].Clave_Impuesto;
                oImpuestosTraslado.Importe = Factura.Conceptos[0].Impuestos[0].Importe;

                ListaImpuestosTraladado.Add(oImpuestosTraslado);
                oConcepto.Impuestos = new ComprobanteConceptoImpuestos();
                oConcepto.Impuestos.Traslados = ListaImpuestosTraladado.ToArray();

                oComprobante.Conceptos = lstConceptos.ToArray();

                //ComprobanteImpuestosTraslado
                List<ComprobanteImpuestosTraslado> ListaComprobanteImpuestosTraslados = new List<ComprobanteImpuestosTraslado>();
                ComprobanteImpuestos oComprobanteImpuestos = new ComprobanteImpuestos();
                ComprobanteImpuestosTraslado oComprobanteImpuestosTraslado = new ComprobanteImpuestosTraslado();

                oComprobanteImpuestos.TotalImpuestosTrasladados = Factura.Conceptos[0].Impuestos[0].Importe;

                oComprobanteImpuestosTraslado.Importe = Math.Round(Factura.Conceptos[0].Impuestos[0].Importe, 2);
                oComprobanteImpuestosTraslado.Impuesto = Factura.Conceptos[0].Impuestos[0].Clave_Impuesto;
                oComprobanteImpuestosTraslado.TipoFactor = Factura.Conceptos[0].Impuestos[0].TipoFactor;
                oComprobanteImpuestosTraslado.TasaOCuota = Factura.Conceptos[0].Impuestos[0].TasaOCuota;

                ListaComprobanteImpuestosTraslados.Add(oComprobanteImpuestosTraslado);
                oComprobanteImpuestos.Traslados = ListaComprobanteImpuestosTraslados.ToArray();
                //agregamos el impuesto
                oComprobante.Impuestos = oComprobanteImpuestos;
                //oComprobante.Impuestos.TotalImpuestosTrasladados = Factura.Conceptos[0].Impuestos[0].Importe;
                oComprobante.Impuestos.TotalImpuestosTrasladados = Math.Round(Factura.Conceptos[0].Impuestos[0].Importe, 2);

                this.CreateXML(oComprobante, pathXML);

                /*Sellado del xml*/
                string cadenaOriginal = "";

                System.Xml.Xsl.XslCompiledTransform transformador = new System.Xml.Xsl.XslCompiledTransform(true);
                transformador.Load(pathCadenaOriginal);

                using (StringWriter sw = new StringWriter())
                using (XmlWriter xwo = XmlWriter.Create(sw, transformador.OutputSettings))
                {

                    transformador.Transform(pathXML, xwo);
                    cadenaOriginal = sw.ToString();
                }

                SelloDigital oSelloDigital = new SelloDigital();
                oComprobante.Certificado = oSelloDigital.Certificado(pathCer);
                oComprobante.Sello = oSelloDigital.Sellar(cadenaOriginal, pathKey, clavePrivada);

                CreateXML(oComprobante, pathXML);

                string usuario = Pac.UserPac;
                string contrasena = Pac.PasswordPac;

                bool produccion = false;
                string prod_endpoint = "TimbradoEndpoint_PRODUCCION";
                string test_endpoint = "TimbradoHttpSoap11Endpoint";

                SolucionFactible.TimbradoPortTypeClient portClient = null;
                portClient = (produccion)
                    ? new SolucionFactible.TimbradoPortTypeClient(prod_endpoint)
                    : portClient = new SolucionFactible.TimbradoPortTypeClient(test_endpoint);

                byte[] xmlSAT = System.IO.File.ReadAllBytes(pathXML);

                SolucionFactible.CFDICertificacion response = portClient.timbrar(usuario, contrasena, xmlSAT, false);

                SolucionFactible.CFDIResultadoCertificacion[] resultados = response.resultados;

                if (resultados == null)
                {
                    if (System.IO.File.Exists(pathXML))
                    {
                        System.IO.File.Delete(pathXML);
                    }
                    throw new System.Exception(response.mensaje);
                }
                else
                {
                    if (resultados[0].status == 200)
                    {
                        System.IO.File.WriteAllBytes(pathXML, resultados[0].cfdiTimbrado); //creamos el xml ya timbrado
                        return true;
                    }
                    else
                    {
                        if (System.IO.File.Exists(pathXML))
                        {
                            System.IO.File.Delete(pathXML);
                        }

                        throw new System.Exception(resultados[0].mensaje);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CreateXML(Comprobante oComprobante, string pathXML)
        {
            try
            {
                //SERIALIZAMOS.------------------------------------------------- 
                XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
                xmlNameSpace.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
                xmlNameSpace.Add("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
                xmlNameSpace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

                XmlSerializer oXmlSerializar = new XmlSerializer(typeof(Comprobante));
                string sXml = "";
                using (var sww = new SystemHelper.StringWriterWithEncoding(Encoding.UTF8))
                {
                    using (XmlWriter writter = XmlWriter.Create(sww))
                    {
                        oXmlSerializar.Serialize(writter, oComprobante, xmlNameSpace);
                        sXml = sww.ToString();
                    }
                }
                //guardamos el string en un archivo 
                System.IO.File.WriteAllText(pathXML, sXml);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetListasSAT(ComboDatos oComboDatos, AuxSQLModel oAuxSQLModel, string RFCReceptor)
        {
            FacturaDatos oFacturaDatos = new FacturaDatos();

            oAuxSQLModel.Conexion = Conexion;

            //ViewBag.ListaFormaPago = oComboDatos.ListaFormaPagoDetalle(oAuxSQLModel);
            //ViewBag.ListaMetodoPago = oComboDatos.ListaMetodoPagoDetalle(oAuxSQLModel);
            //ViewBag.ListaMoneda = oComboDatos.ListaMonedaDetalle(oAuxSQLModel);
            /*
             * El RFC se divide en 2, personas fisicas y morales, la diferencia:
             * Morales: Se compone de 3 letras seguidas por 6 dígitos y 3 caracteres alfanumericos = 12
             * Físicas: consta de 4 letras seguida por 6 dígitos y 3 caracteres alfanuméricos = 13
            */
            if (RFCReceptor.Length == 13)
            {
                ViewBag.ListaUsoCFDI = oComboDatos.ListaUsoCFDIDetalleFactura(oAuxSQLModel, "78654122-1130-405B-A739-1D19C19955EF");
            }
            else
            {
                ViewBag.ListaUsoCFDI = oComboDatos.ListaUsoCFDIDetalleFactura(oAuxSQLModel, "25BD8A08-3C23-4359-8E34-76A2C8E95B3D");
            }
        }

        private bool GenerarPDF(FacturacionViewModel oFactura)
        {
            try
            {
                Comprobante oComprobante;
                XmlSerializer oXmlSerializer = new XmlSerializer(typeof(Comprobante));

                using (StreamReader oReader = new StreamReader(pathXML))
                {
                    oComprobante = (Comprobante)oXmlSerializer.Deserialize(oReader);

                    if (oComprobante.Complemento != null)
                    {
                        //Complemento
                        foreach (var oComplemento in oComprobante.Complemento)
                        {
                            foreach (var oComplementoInterior in oComplemento.Any)
                            {
                                if (oComplementoInterior.Name.Contains("TimbreFiscalDigital"))
                                {
                                    XmlSerializer oXmlSerializerComplemento = new XmlSerializer(typeof(TimbreFiscalDigital));
                                    using (var readerComplemento = new StringReader(oComplementoInterior.OuterXml))
                                    {
                                        oComprobante.TimbreFiscalDigital = (TimbreFiscalDigital)oXmlSerializerComplemento.Deserialize(readerComplemento);
                                    }
                                }
                            }
                        }
                    }
                }

                //Aplicando razor
                string path = pathRootSystemHelperSAT + "\\Plantilla\\";
                string pathHTMLTempFileHtml = pahtRootSATTempFile + "\\" + idFile + ".html";
                pathHTMLTempFilePDF = pahtRootSATTempFile + "\\" + idFile + ".pdf";

                string pathHtmlPlantilla = path + "plantillaFactura.html";
                string sHtml = GetStringOfFile(pathHtmlPlantilla);
                string resultHtml = "";

                SystemHelper.SAT.CFDI3_3_PDF cFDI3_3_PDF = new SystemHelper.SAT.CFDI3_3_PDF(oComprobante, oFactura);

                resultHtml = RazorEngine.Razor.Parse(sHtml, cFDI3_3_PDF);

                //creamos el archivo temporal
                System.IO.File.WriteAllText(pathHTMLTempFileHtml, resultHtml);

                string pathWkhtml = pathRootSystemHelperSAT + "\\Wkhtml\\wkhtmltopdf.exe";

                ProcessStartInfo oProcessStartInfo = new ProcessStartInfo();
                oProcessStartInfo.UseShellExecute = false;
                oProcessStartInfo.FileName = pathWkhtml;
                oProcessStartInfo.Arguments = pathHTMLTempFileHtml + " " + pathHTMLTempFilePDF;

                using (Process oProcess = Process.Start(oProcessStartInfo))
                {
                    oProcess.WaitForExit();
                }

                //eliminamos el archivo temporal, el pdf se borrará después de enviarlo por email
                if (System.IO.File.Exists(pathHTMLTempFileHtml))
                {
                    System.IO.File.Delete(pathHTMLTempFileHtml);
                }

                return true;
            }
            catch (Exception ex)
            {
                //string Mensaje = ex.Message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                string Mensaje = "Error al generar el pdf";
                TempData["message"] = Mensaje;
                TempData["typemessage"] = "2";
                throw;
            }

        }

        private Comprobante GenerarComprobanteDeXMLPath()
        {
            Comprobante oComprobante;
            XmlSerializer oXmlSerializer = new XmlSerializer(typeof(Comprobante));

            using (StreamReader oReader = new StreamReader(pathXML))
            {
                oComprobante = (Comprobante)oXmlSerializer.Deserialize(oReader);

                if (oComprobante.Complemento != null)
                {
                    //Complemento
                    foreach (var oComplemento in oComprobante.Complemento)
                    {
                        foreach (var oComplementoInterior in oComplemento.Any)
                        {
                            if (oComplementoInterior.Name.Contains("TimbreFiscalDigital"))
                            {
                                XmlSerializer oXmlSerializerComplemento = new XmlSerializer(typeof(TimbreFiscalDigital));
                                using (var readerComplemento = new StringReader(oComplementoInterior.OuterXml))
                                {
                                    oComprobante.TimbreFiscalDigital = (TimbreFiscalDigital)oXmlSerializerComplemento.Deserialize(readerComplemento);
                                }
                            }
                        }
                    }
                }
            }
            return oComprobante;
        }

        private bool GenerarPDFReimpresion(Comprobante oComprobante, FacturacionViewModel oFactura)
        {
            try
            {
                //Aplicando razor
                string path = pathRootSystemHelperSAT + "\\Plantilla\\";
                string pathHTMLTempFileHtml = pahtRootSATTempFile + "\\" + idFile + ".html";
                pathHTMLTempFilePDF = pahtRootSATTempFile + "\\" + idFile + ".pdf";

                string pathHtmlPlantilla = path + "plantillaFactura.html";
                string sHtml = GetStringOfFile(pathHtmlPlantilla);
                string resultHtml = "";

                //necesito obtener los datos

                SystemHelper.SAT.CFDI3_3_PDF cFDI3_3_PDF = new SystemHelper.SAT.CFDI3_3_PDF(oComprobante, oFactura);

                resultHtml = RazorEngine.Razor.Parse(sHtml, cFDI3_3_PDF);

                //creamos el archivo temporal
                System.IO.File.WriteAllText(pathHTMLTempFileHtml, resultHtml);

                string pathWkhtml = pathRootSystemHelperSAT + "\\Wkhtml\\wkhtmltopdf.exe";

                ProcessStartInfo oProcessStartInfo = new ProcessStartInfo();
                oProcessStartInfo.UseShellExecute = false;
                oProcessStartInfo.FileName = pathWkhtml;
                oProcessStartInfo.Arguments = pathHTMLTempFileHtml + " " + pathHTMLTempFilePDF;

                using (Process oProcess = Process.Start(oProcessStartInfo))
                {
                    oProcess.WaitForExit();
                }

                //eliminamos el archivo temporal, el pdf se borrará después de enviarlo por email
                if (System.IO.File.Exists(pathHTMLTempFileHtml))
                {
                    System.IO.File.Delete(pathHTMLTempFileHtml);
                }

                return true;
            }
            catch (Exception ex)
            {
                //string Mensaje = ex.Message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                string Mensaje = "Error al generar el pdf";
                TempData["message"] = Mensaje;
                TempData["typemessage"] = "2";
                throw;
            }

        }

        private string GetStringOfFile(string pathFile)
        {
            string contenido = System.IO.File.ReadAllText(pathFile);
            return contenido;
        }

        private bool EnviarFacturaEmail(string emailEmisor, string passwordEmisor, string emailReceptor, List<string> ListaArchivos)
        {
            try
            {
                bool respuesta =
                FacturacionSAT.CSL.WEB.App_Start.ClaseAux.EnviarCorreo(
                    emailEmisor
                  , passwordEmisor
                  , emailReceptor
                  , "Factura: Viajes Aury"
                  , "Se le envía el siguiente email, en la cual se le adjunta su factura."
                  , true
                  , ""
                  , false
                  , "smtp.gmail.com"
                  , 587
                  , true
                  , ListaArchivos);

                return respuesta;
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                TempData["message"] = Mensaje;
                TempData["typemessage"] = "2";
                throw;
            }
        }
    }
}