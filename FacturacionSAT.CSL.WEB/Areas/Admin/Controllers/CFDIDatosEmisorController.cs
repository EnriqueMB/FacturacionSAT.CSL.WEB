using FacturacionSAT.CSL.WEB.App_Start;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacturacionSAT.CSL.WEB.Models;
using FacturacionSAT.CSL.WEB.Models.Datos;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    public class CFDIDatosEmisorController : Controller
    {
        private TokenProcessor Token = TokenProcessor.GetInstance();
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CFDIDatosEmisor
        public ActionResult Index()
        {
            try
            {
                CFDIDatosEmisorModels DatosEmisor = new CFDIDatosEmisorModels();
                CFDIDatosEmisorDatos Datos = new CFDIDatosEmisorDatos();
                DatosEmisor.Conexion = Conexion;
                DatosEmisor.ListaDatosEmisor = Datos.IndexCFDIDatosEmisor(DatosEmisor);
                return View(DatosEmisor);
            }
            catch (Exception)
            {
                CFDIDatosEmisorModels DatosEmisor = new CFDIDatosEmisorModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(DatosEmisor);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                CFDIDatosEmisorModels DatosEmisor = new CFDIDatosEmisorModels();

                return View(DatosEmisor);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}