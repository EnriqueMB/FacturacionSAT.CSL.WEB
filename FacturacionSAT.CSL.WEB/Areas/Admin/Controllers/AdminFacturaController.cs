using FacturacionSAT.CSL.WEB.Models;
using FacturacionSAT.CSL.WEB.Models.Datos;
using FacturacionSAT.CSL.WEB.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    public class AdminFacturaController : Controller
    {
        private string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/Facturacion
        public ActionResult Index()
        {
            ComboDatos oComboDatos = new ComboDatos();
            AuxSQLModel oAuxSQLModel = new AuxSQLModel();
            IndexFacturaViewModel Model = new IndexFacturaViewModel();
            oAuxSQLModel.Conexion = Conexion;
            Model.ListaEmisores = oComboDatos.ListaEmisores(oAuxSQLModel);
            return View(Model);
        }
        [HttpPost]
        public ActionResult Index(IndexFacturaViewModel Model)
        {
            if (!ModelState.IsValid)
            {
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

            return View();
        }
    }
}