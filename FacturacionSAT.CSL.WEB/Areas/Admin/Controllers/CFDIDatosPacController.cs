using FacturacionSAT.CSL.WEB.App_Start;
using FacturacionSAT.CSL.WEB.Models.Datos;
using FacturacionSAT.CSL.WEB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    public class CFDIDatosPacController : Controller
    {
        private TokenProcessor Token = TokenProcessor.GetInstance();
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CFDIDatosPac
        public ActionResult Index()
        {
            try
            {
                CFDIDatosPacModels CFDIModel = new CFDIDatosPacModels();
                CFDIPacDatos CFDIDatos = new CFDIPacDatos();
                AuxSQLModel oAuxSQLModel = new AuxSQLModel();
                oAuxSQLModel.Conexion = Conexion;
                CFDIModel.ListaCFDIPac = CFDIDatos.ListaPac(oAuxSQLModel);

                return View(CFDIModel);
            }
            catch (Exception)
            {
                CFDIDatosPacModels CFDIModel = new CFDIDatosPacModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrió un error al guardar el registro.";
                return View(CFDIModel);
            }
        }
        public ActionResult Indxprueba()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateCFDIPac()
        {
            try
            {
                Token.SaveToken();
                CFDIDatosPacModels CFDIModel = new CFDIDatosPacModels();
                CFDIPacDatos CFDIDatos = new CFDIPacDatos();
                CFDIModel.Predeterminado = true;
                return View(CFDIModel);
            }
            catch (Exception)
            {
                CFDIDatosPacModels CFDIModel = new CFDIDatosPacModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrió un error al guardar el registro.";
                return View(CFDIModel);
            }
        }

        [HttpPost]
        public ActionResult CreateCFDIPac(CFDIDatosPacModels productos)
        {
            CFDIPacDatos CFDIDatos = new CFDIPacDatos();
            try
            {
                if (Token.IsTokenValid())
                {
                    if (ModelState.IsValid)
                    {
                        productos.Conexion = Conexion;
                        productos.Id_usuario = User.Identity.Name;
                        productos.Opcion = 1;
                        productos = CFDIDatos.ABCCFDIPac(productos);

                        if (productos.Completado == true)
                        {
                            TempData["typemessage"] = "1";
                            TempData["message"] = "El registro se guardo correctamente.";
                            Token.ResetToken();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["typemessage"] = "2";
                            TempData["message"] = "Ocurrió un error al guardar el registro.";
                            return View(productos);
                        }
                    }
                    else
                    {
                        productos.Conexion = Conexion;
                        return View(productos);
                    }

                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(productos);
            }
        }

        [HttpGet]
        public ActionResult UpdateCFDIPac(string id)
        {
            try
            {
                Token.SaveToken();
                CFDIDatosPacModels CFDIModel = new CFDIDatosPacModels();
                CFDIPacDatos CFDIDatos = new CFDIPacDatos();
                CFDIModel.Id_cfdiDatosPac = id;
                CFDIModel.Conexion = Conexion;
                CFDIModel = CFDIDatos.GetCFDIPacDetail(CFDIModel);
                return View(CFDIModel);
            }
            catch (Exception)
            {
                CFDIDatosPacModels CFDIModel = new CFDIDatosPacModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(CFDIModel);
            }
        }
        [HttpPost]
        public ActionResult UpdateCFDIPac(string id, CFDIDatosPacModels productos)
        {
            
                CFDIPacDatos CFDIDatos = new CFDIPacDatos();
                try
                {
                    if (Token.IsTokenValid())
                    {
                        if (ModelState.IsValid)
                        {
                            productos.Conexion = Conexion;
                            productos.Id_usuario = User.Identity.Name;
                            productos.Opcion = 2;
                            productos.Id_cfdiDatosPac = id;
                            productos = CFDIDatos.ABCCFDIPac(productos);

                            if (productos.Completado == true)
                            {
                                TempData["typemessage"] = "1";
                                TempData["message"] = "El registro se guardo correctamente.";
                                Token.ResetToken();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                TempData["typemessage"] = "2";
                                TempData["message"] = "Ocurrió un error al guardar el registro.";
                                return View(productos);
                            }
                        }
                        else
                        {                            
                            return View(productos);
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                    TempData["message"] = "Ocurrió un error al guardar el registro.";
                    return View(productos);
                }        
        }

        [HttpGet]
        public ActionResult DeleteCFDIPac(string id, bool id2)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteCFDIPac(string id, FormCollection collection)
        {
            try
            {
                CFDIDatosPacModels CFDIModel = new CFDIDatosPacModels();
                CFDIPacDatos CFDIDatos = new CFDIPacDatos();
                //AuxSQLModel oAuxSQLModel = new AuxSQLModel();
                CFDIModel.Conexion = Conexion;
                CFDIModel.Opcion = 3;
                CFDIModel.Id_cfdiDatosPac = id;
                //CFDIModel.Predeterminado = id2;
                CFDIModel.Id_usuario = User.Identity.Name;
                CFDIModel = CFDIDatos.ABCCFDIPac(CFDIModel);

                if (CFDIModel.Id_cfdiDatosPac == "" )
                {
                    return RedirectToAction("Index");
                }             

                return Json("");               
            }
            catch
            {
                CFDIDatosPacModels CFDIModel = new CFDIDatosPacModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrió un error al guardar el registro.";
                return View(CFDIModel);
            }
        }
    }
}