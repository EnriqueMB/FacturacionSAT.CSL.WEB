using FacturacionSAT.CSL.WEB.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Mail;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    [Autorizado]
    public class HomeAdminController : Controller
    {
        // GET: Areas/HomeAdmin
        public ActionResult Index()
        {
            //List<string> ListaArchivos = new List<string>();
            //ListaArchivos.Add("C:/Dll/DDL.txt");
            //ListaArchivos.Add("C:/Dll/DDL2.txt");

            //FacturacionSAT.CSL.WEB.App_Start.ClaseAux.EnviarCorreo(
            //  "kikeballina1@gmail.com"
            //  , "drink9220066"
            //  , "lopezfloresjuandaniel123@gmail.com" // Correo receptor
            //  , "Asunto de facturacion. Prueba de envio de Achivos con textos MoificacionNombre"
            //  , "Se enviarán dos archivos adjuntos con una lista de string saludos verificar si lo envia"
            //  , true
            //  , ""
            //  , false
            //  , "smtp.gmail.com"
            //  , 587
            //  , true
            //  ,ListaArchivos);


            FacturacionSAT.CSL.WEB.App_Start.ClaseAux.EnviarCorreo(
                "kikeballina1@gmail.com"
                , "drink9220066"
                , "lopezfloresjuandaniel123@gmail.com" // Correo receptor
                , "Asunto de facturacion. Prueba de envio de Achivos con textos MoificacionNombre"
                , "Se enviarán dos archivos adjuntos con una lista de string saludos verificar si lo envia"
                , true
                , ""
                , false
                , "smtp.gmail.com"
                , 587
                , true
                , ListaArchivos);
            //FacturacionSAT.CSL.WEB.App_Start.ClaseAux.EnviarCorreo(
            //  ConfigurationManager.AppSettings.Get("CorreoTxt")
            //  , ConfigurationManager.AppSettings.Get("PasswordTxt")
            //  , "kikeballina1@gmail.com" // Correo receptor
            //  , "Asunto de facturacion"
            //  , "Datos que se van a eviar al correo"
            //  , false
            //  , ListaArchivos
            //  , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
            //  , ConfigurationManager.AppSettings.Get("HostTxt")
            //  , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
            //  , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
            return View();
        }

        public ActionResult Prueba()
        {
            return View();
        }
        
    }
}