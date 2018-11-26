using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacturacionSAT.CSL.WEB.Models.Datos;
using FacturacionSAT.CSL.WEB.Models;
using FacturacionSAT.CSL.WEB.App_Start;
using System.Configuration;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    public class CFDIDatosConceptosController : Controller
    {
        private TokenProcessor Token = TokenProcessor.GetInstance();
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        private object oAuxSQLModel;

        // GET: Admin/CFDIDatosConceptos
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string Id)
        {
            try
            {
                if (string.IsNullOrEmpty(Id))
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public ActionResult crear(/*string id*/)
        {
            try
            {

                Token.SaveToken();
                CFDIDatosConceptosModels Model = new CFDIDatosConceptosModels();
                ComboDatos listTipoPoduc = new ComboDatos();
                Model.Conexion = Conexion;               
                Model.ListaTipoProducto = listTipoPoduc.ListaTipoProducto(Model);
                Model.ListaDivicion = listTipoPoduc.ListaDivicionConcepto(Model);
                Model.ListaGrupo = listTipoPoduc.ListaGrupoConcepto(Model);
                Model.ListaClase = listTipoPoduc.ListaCFDIClase(Model);

                var ListTipoProduct = new SelectList(Model.ListaTipoProducto, " Id_cfdiTipoProducto", "TipoProducto");
                var ListDivicion = new SelectList(Model.ListaDivicion, " Id_cfdiDivision", "Division");
                var ListGrupo = new SelectList(Model.ListaGrupo, " Id_cfdiGrupo", "Grupo");
                var ListCFDIClase = new SelectList(Model.ListaClase, "Id_CfdiClase", "clase");

                ViewData["cmbTipoProducto"] = ListTipoProduct;
                ViewData["cmbDivicion"] = ListDivicion;
                ViewData["cmbClase"] = ListCFDIClase;
                ViewData["cmbGrupo"] = ListGrupo;
                return View(Model);
               
            }
            catch (Exception)
            {

                CFDIDatosConceptosModels Model = new CFDIDatosConceptosModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Model);
            }
        }
        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                if (string.IsNullOrEmpty(Id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}