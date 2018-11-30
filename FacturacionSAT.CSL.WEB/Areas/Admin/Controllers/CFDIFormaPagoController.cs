using FacturacionSAT.CSL.WEB.Models;
using FacturacionSAT.CSL.WEB.App_Start;
using FacturacionSAT.CSL.WEB.Models.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    public class CFDIFormaPagoController : Controller
    {
        private TokenProcessor Token = TokenProcessor.GetInstance();
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CFDIFormaPago
        public ActionResult Index()
        {
            try
            {
                CFDIFormaPago_AuryModels CFDIFormaPago = new CFDIFormaPago_AuryModels();
                CFDIFormaPagoDatos CFDIDatos = new CFDIFormaPagoDatos();
                AuxSQLModel oAuxSQLModel = new AuxSQLModel();
                oAuxSQLModel.Conexion = Conexion;
                CFDIFormaPago.ListaCFDIFP = CFDIDatos.ListaFP(oAuxSQLModel);
                return View(CFDIFormaPago);
            }
            catch (Exception)
            {
                CFDIFormaPagoDetalleModels CFDIFormaPago = new CFDIFormaPagoDetalleModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrió un error al guardar el registro.";
                return View(CFDIFormaPago);
            }
        }

        [HttpGet]
        public ActionResult UpdateCFDIFP(string id)
        {
            try
            {
                Token.SaveToken();
                CFDIFormaPago_AuryModels CFDIFormaPago = new CFDIFormaPago_AuryModels();
                CFDIFormaPagoDatos CFDIDatos = new CFDIFormaPagoDatos();
                CFDIFormaPago.Conexion = Conexion;
                CFDIFormaPago.ID_FormaPago = id;
                CFDIFormaPago.ListaCFDIDetalleCMB = CFDIDatos.ListaCFDI_CMB(CFDIFormaPago);
                CFDIFormaPago = CFDIDatos.GetCFDIFPDitail(CFDIFormaPago);
                return View(CFDIFormaPago);            
            }
            catch (Exception ex)            
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult UpdateCFDIFP(CFDIFormaPago_AuryModels item)
        {
            try
            {
                if (Token.IsTokenValid())
                {
                    CFDIFormaPagoDatos CFDIDatosFP = new CFDIFormaPagoDatos();
                    item.Conexion = Conexion;
                    if (ModelState.IsValid)
                    {
                        item.Id_usuario = User.Identity.Name;
                        item = CFDIDatosFP.UpdateCFDIFP(item);

                        if (item.Completado == true)
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
                            return View(item);
                        }
                    }
                    else
                    {
                        item.ListaCFDIDetalleCMB = CFDIDatosFP.ListaCFDI_CMB(item);
                        return View(item);
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}