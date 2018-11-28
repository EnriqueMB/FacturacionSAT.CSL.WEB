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
            catch (Exception ex)
            {
                CFDIDatosEmisorModels DatosEmisor = new CFDIDatosEmisorModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(DatosEmisor);
            }
        }
        // GET: Admin/CFDIDatosEmisor/Create
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
        // POST: Admin/CFDIDatosEmisor/Create(Model)
        [HttpPost]
        public ActionResult Create(CFDIDatosEmisorModels DatosAux, HttpPostedFileBase file)
        {
            try
            {
                CFDIDatosEmisorDatos Datos = new CFDIDatosEmisorDatos();
                if (Token.IsTokenValid())
                {
                    if (ModelState.IsValid)
                    {
                        DatosAux.Conexion = Conexion;
                        DatosAux.Opcion = 1;
                        DatosAux.IDUsuario = User.Identity.Name;
                        DatosAux = Datos.AbcDatosEmisor(DatosAux);
                        if (!string.IsNullOrEmpty(DatosAux.IDCFDIDatosEmisor))
                        {
                            HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                            if (!string.IsNullOrEmpty(bannerImage.FileName))
                            {
                                if (bannerImage != null && bannerImage.ContentLength > 0)
                                {
                                    string baseDir = Server.MapPath("~/SAT/SAT1/");
                                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                                    string fileName = DatosAux.IDCFDIDatosEmisor + fileExtension;
                                    bannerImage.SaveAs(baseDir + fileName);
                                    DatosAux.URLArchivoCER = "~/SAT/SAT1/" + fileName;
                                }
                            }
                            HttpPostedFileBase bannerImage1 = Request.Files[1] as HttpPostedFileBase;
                            if (!string.IsNullOrEmpty(bannerImage1.FileName))
                            {
                                if (bannerImage1 != null && bannerImage1.ContentLength > 0)
                                {
                                    string baseDir = Server.MapPath("~/SAT/SAT1/");
                                    string fileExtension = Path.GetExtension(bannerImage1.FileName);
                                    string fileName = DatosAux.IDCFDIDatosEmisor + fileExtension;
                                    bannerImage1.SaveAs(baseDir + fileName);
                                    DatosAux.URLArchivoKEY = "~/SAT/SAT1/" + fileName;
                                }
                            }
                            HttpPostedFileBase bannerImage2 = Request.Files[2] as HttpPostedFileBase;
                            if (!string.IsNullOrEmpty(bannerImage2.FileName))
                            {
                                if (bannerImage2 != null && bannerImage2.ContentLength > 0)
                                {
                                    string baseDir = Server.MapPath("~/SAT/SAT1/");
                                    string fileExtension = Path.GetExtension(bannerImage2.FileName);
                                    string fileName = DatosAux.IDCFDIDatosEmisor + fileExtension;
                                    bannerImage2.SaveAs(baseDir + fileName);
                                    DatosAux.Imagen = "~/SAT/SAT1/" + fileName;
                                }
                            }
                            DatosAux.Opcion = 4;
                            DatosAux = Datos.AbcDatosEmisor(DatosAux);
                            if (!string.IsNullOrEmpty(DatosAux.IDCFDIDatosEmisor))
                            {
                                TempData["typemessage"] = "1";
                                TempData["message"] = "Los datos se guardarón correctamente.";
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                DatosAux.ListaTipoPersona = Datos.ListaPersonaCMB(DatosAux);
                                TempData["typemessage"] = "2";
                                TempData["message"] = "Ocurrio un error al intentar guardar las los archivo con las extenciones. CER, KEY, IMG";
                                return View(DatosAux);
                            }
                        }
                        else
                        {
                            DatosAux.ListaTipoPersona = Datos.ListaPersonaCMB(DatosAux);
                            TempData["typemessage"] = "2";
                            TempData["message"] = "Ocurrio un error al intentar guardar los datos.";
                            return View(DatosAux);
                        }
                    }
                    else
                    {
                        DatosAux.Conexion = Conexion;
                        DatosAux.ListaTipoPersona = Datos.ListaPersonaCMB(DatosAux);
                        return View(Datos);
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error.Por favor contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }

        //GET:Admi/CFDIDatosEmisor/Create/id
        [HttpGet]
        public ActionResult Edit(string id)
        {
            try
            {
                CFDIDatosEmisorModels DatosEmisor = new CFDIDatosEmisorModels();
                CFDIDatosEmisorDatos Datos = new CFDIDatosEmisorDatos();
                DatosEmisor.Conexion = Conexion;
                DatosEmisor.IDCFDIDatosEmisor = id;
                DatosEmisor.ListaTipoPersona = Datos.ListaPersonaCMB(DatosEmisor);
                DatosEmisor = Datos.ObtenerDatosEmisorID(DatosEmisor);
                DatosEmisor.ListaRegimenFiscalDetalle = Datos.ListaRegimenFiscalDetalle(DatosEmisor);
                return View(DatosEmisor);
            }
            catch (Exception)
            { 
                throw;
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