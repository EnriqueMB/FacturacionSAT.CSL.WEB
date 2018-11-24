﻿using FacturacionSAT.CSL.WEB.App_Start;
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
            catch (Exception ex)
            {
                throw ex;
            }
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
            catch (Exception ex)
            {
                throw ex;
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
                        productos = CFDIDatos.InsertCFDIPac(productos);

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
    }
}