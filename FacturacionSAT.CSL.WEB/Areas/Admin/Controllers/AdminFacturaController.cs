using FacturacionSAT.CSL.WEB.Filters;
using FacturacionSAT.CSL.WEB.Models;
using FacturacionSAT.CSL.WEB.Models.Datos;
using FacturacionSAT.CSL.WEB.Models.ViewModel;
using FacturacionSAT.CSL.WEB.SystemHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    [Autorizado]
    public class AdminFacturaController : Controller
    {
        private string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        private string pathXML, idFile, pathRootSystemHelperSAT, pahtRootSATTempFile;



        // GET: Admin/Facturacion
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                TempData["message"] = Mensaje;
                TempData["typemessage"] = "2";
                return View();
            }

        }
        [HttpPost]
        public ActionResult Index(IndexFacturaViewModel Model)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = "Verifique sus datos";
                TempData["typemessage"] = "2";
                return View(Model);
            }
            else
            {
                return RedirectToAction("Add", Model);
            }
        }
        [HttpGet]
        public ActionResult Add(IndexFacturaViewModel Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["message"] = "Verifique sus datos";
                    TempData["typemessage"] = "2";
                    return RedirectToAction("Index", Model);
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

                    return RedirectToAction("Index");
                }

                return View(oFactura);
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                TempData["message"] = Mensaje;
                TempData["typemessage"] = "2";
                return RedirectToAction("Index");
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
                    /**************************************/
                    /*paths*/
                    pathRootSystemHelperSAT = Server.MapPath("~/SystemHelper/SAT");
                    string pathRootSATEmisorXML = Server.MapPath("~/SAT");
                    pahtRootSATTempFile = Server.MapPath("~/SATTempFile");

                    //string getNameXML = string.Format("Factura-{0:yyyy-MM-dd_hh-mm-ss}.xml", DateTime.Now);
                    idFile = Guid.NewGuid().ToString();
                    string getNameXML =  idFile + ".xml";
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

                    bool result = GenerarXML(pathRootSATEmisorXML, pathXML, pathCadenaOriginal, oEmisor, Factura, oPac);

                    if (result)
                    {
                        if (System.IO.File.Exists(pathXML))
                        {
                            TempData["message"] = "Archivo xml creado con éxito.";
                            TempData["typemessage"] = "1";

                            if (GenerarPDF())
                            {
                                TempData["message"] = "Archivo pdf creado con éxito.";
                                //faltaria enviar al correo
                                FacturaDatos oFacturaDatos = new FacturaDatos();
                                oAuxSQLModel.ResetValuesSQL();
                                oAuxSQLModel.Conexion = Conexion;
                                //oFacturaDatos.Factura_Save_Factura(oAuxSQLModel, pathXML, Factura);
                            }
                            System.IO.File.Delete(pathXML);
                        }

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["message"] = "Verifique sus datos";
                        TempData["typemessage"] = "2";

                        return View(Factura);
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                if (System.IO.File.Exists(pathXML))
                {
                    System.IO.File.Delete(pathXML);
                }
                string Mensaje = ex.Message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                TempData["message"] = Mensaje;
                TempData["typemessage"] = "2";
                
                return RedirectToAction("Index");
            }
        }

        private bool GenerarXML(string pathRootSATEmisorXML, string pathXML, string pathCadenaOriginal, CFDIDatosEmisorModels Emisor, FacturacionViewModel Factura, CFDIDatosPacModels Pac)
        {
            try
            {

                //string pathKey = pathRootSATEmisorXML +"\\"  + "CSD_Pruebas_CFDI_LAN7008173R5.key";
                //string pathCer = pathRootSATEmisorXML + "\\" + "CSD_Pruebas_CFDI_LAN7008173R5.cer";
                //string clavePrivada = "12345678a";

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
                oComprobante.Certificado = ""; //sig video 
                oComprobante.SubTotal = Factura.Subtotal; // Atributo requerido para representar la suma de los importes de los conceptos antes de descuentos e 
                                                          //impuesto.No se permiten valores negativos.
                oComprobante.Descuento = Factura.TotalDescuento;
                oComprobante.Moneda = Factura.MonedaDB; // Catálogo del Cfdi:Moneda, si no es moneda nacional, se debe de poner el tipo de cambio
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
                oComprobante.Conceptos = lstConceptos.ToArray();

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


                /*Timbrado del CFDI con el proveedor del pack*/
                //string usuario = "testing@solucionfactible.com";
                //string contraseña = "timbrado.SF.16672";
                string usuario = Pac.UserPac;
                string contrasena = Pac.PasswordPac;

                /*Datos del pack que se maneja en su momento será el que se desea*/
                bool produccion = false;
                //Checar esto lo da el proveedor del pac, pero puede que no sea en todos
                string prod_endpoint = "TimbradoEndpoint_PRODUCCION";
                string test_endpoint = "TimbradoHttpSoap11Endpoint";

                //Si recibe error 417 deberá descomentar la linea a continuación
                //System.Net.ServicePointManager.Expect100Continue = false;

                //El paquete o namespace en el que se encuentran las clases
                //será el que se define al agregar la referencia al WebService,
                //en este ejemplo es: com.sf.ws.Timbrado

                SolucionFactible.TimbradoPortTypeClient portClient = null;
                portClient = (produccion)
                    ? new SolucionFactible.TimbradoPortTypeClient(prod_endpoint)
                    : portClient = new SolucionFactible.TimbradoPortTypeClient(test_endpoint);


                byte[] xmlSAT = System.IO.File.ReadAllBytes(pathXML);

                SolucionFactible.CFDICertificacion response = portClient.timbrar(usuario, contrasena, xmlSAT, false);

                //System.Console.WriteLine("Información de la transacción");
                //System.Console.WriteLine(response.status);
                //System.Console.WriteLine(response.mensaje);
                //System.Console.WriteLine("Resultados recibidos" + response.resultados.Length);

                SolucionFactible.CFDIResultadoCertificacion[] resultados = response.resultados;

                if(resultados == null)
                {
                    if (System.IO.File.Exists(pathXML))
                    {
                        System.IO.File.Delete(pathXML); 
                    }
                    throw new System.Exception(response.mensaje);
                }
                else
                {
                    if(resultados[0].status == 200)
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

        private bool GenerarPDF()
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
                string pathHTMLTempFilePDF = pahtRootSATTempFile + "\\" + idFile + ".pdf";

                string pathHtmlPlantilla = path + "plantillaFactura.html";
                string sHtml = GetStringOfFile(pathHtmlPlantilla);
                string resultHtml = "";

                SystemHelper.SAT.CFDI3_3_PDF cFDI3_3_PDF = new SystemHelper.SAT.CFDI3_3_PDF(oComprobante);


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

                //eliminamos el archivo temporal
                System.IO.File.Delete(pathHTMLTempFileHtml);

                return true;
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
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
    }
}