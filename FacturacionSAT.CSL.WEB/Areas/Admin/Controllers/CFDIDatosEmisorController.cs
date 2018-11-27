using FacturacionSAT.CSL.WEB.App_Start;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacturacionSAT.CSL.WEB.Models;
using FacturacionSAT.CSL.WEB.Models.Datos;
using System.IO;
using System.Drawing;

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
                Token.SaveToken();
                CFDIDatosEmisorModels DatosEmisor = new CFDIDatosEmisorModels();
                CFDIDatosEmisorDatos Datos = new CFDIDatosEmisorDatos();
                DatosEmisor.Conexion = Conexion;
                DatosEmisor.ListaTipoPersona = Datos.ListaPersonaCMB(DatosEmisor);
                return View(DatosEmisor);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Create(CFDIDatosEmisorModels Datos, HttpPostedFileBase file)
        {
            try
            {
                if (Token.IsTokenValid())
                {
                    if (ModelState.IsValid)
                    {
                        HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                        if (!string.IsNullOrEmpty(bannerImage.FileName))
                        {
                            if (bannerImage != null && bannerImage.ContentLength > 0)
                            {
                                string baseDir = Server.MapPath("~/SAT/SAT1/");
                                string fileExtension = Path.GetExtension(bannerImage.FileName);
                                string fileName = Datos.IDCFDIDatosEmisor + fileExtension;
                                bannerImage.SaveAs(baseDir + bannerImage.FileName);
                            }
                        }
                        HttpPostedFileBase bannerImage1 = Request.Files[1] as HttpPostedFileBase;
                        if (!string.IsNullOrEmpty(bannerImage1.FileName))
                        {
                            if (bannerImage1 != null && bannerImage1.ContentLength > 0)
                            {
                                string baseDir = Server.MapPath("~/SAT/SAT1/");
                                string fileExtension = Path.GetExtension(bannerImage.FileName);
                                string fileName = Datos.IDCFDIDatosEmisor + fileExtension;
                                bannerImage1.SaveAs(baseDir + bannerImage1.FileName);
                            }
                        }
                        HttpPostedFileBase bannerImage2 = Request.Files[2] as HttpPostedFileBase;
                        if (!string.IsNullOrEmpty(bannerImage2.FileName))
                        {
                            if (bannerImage2 != null && bannerImage2.ContentLength > 0)
                            {
                                string baseDir = Server.MapPath("~/SAT/SAT1/");
                                string fileExtension = Path.GetExtension(bannerImage.FileName);
                                string fileName = Datos.IDCFDIDatosEmisor + fileExtension;
                                Stream s = bannerImage.InputStream;
                                Bitmap img = new Bitmap(s);
                                img.Save(baseDir + fileName);
                            }
                        }
                        return View(Datos);
                    }
                    else
                    {
                        return View(Datos);
                    }
                }
                else
                {
                    return View(Datos);
                }
            }
            catch (Exception ex)
            {
                CFDIDatosEmisorModels DatosEmisor = new CFDIDatosEmisorModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(DatosEmisor);
            }
        }

        [HttpPost]
        public ActionResult ObtenerRegimenFiscalPersona(string IDTipoPersona)
        {
            try
            {
                CFDIDatosEmisorModels DatosEmisor = new CFDIDatosEmisorModels();
                CFDIDatosEmisorDatos Datos = new CFDIDatosEmisorDatos();
                DatosEmisor.Conexion = Conexion;
                DatosEmisor.IDCFDITipoPersona = IDTipoPersona;
                DatosEmisor.ListaRegimenFiscalDetalle = Datos.ListaRegimenFiscalDetalle(DatosEmisor);
                return Content(DatosEmisor.ListaRegimenFiscalDetalle.ToJSON(), "application/json");
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error. Por favor contacte a soporte técnico";
                return Json("");
            }
        }
    }
}