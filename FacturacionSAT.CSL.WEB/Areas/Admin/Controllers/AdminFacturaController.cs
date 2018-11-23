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
            oAuxSQLModel.Conexion = Conexion;
            var ListaEmisores = oComboDatos.ListaEmisores(oAuxSQLModel);

            ViewBag.ListaEmisores = ListaEmisores;
            return View();
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
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index", Model);
            }
            ComboDatos oComboDatos = new ComboDatos();
            AuxSQLModel oAuxSQLModel = new AuxSQLModel();
            oAuxSQLModel.Conexion = Conexion;

            ViewBag.ListaFormaPago = oComboDatos.ListaFormaPagoDetalle(oAuxSQLModel);
            ViewBag.ListaMetodoPago = oComboDatos.ListaMetodoPagoDetalle(oAuxSQLModel);
            ViewBag.ListaMoneda = oComboDatos.ListaMonedaDetalle(oAuxSQLModel);
            /*
             * El RFC se divide en 2, personas fisicas y morales, la diferencia:
             * Morales: Se compone de 3 letras seguidas por 6 dígitos y 3 caracteres alfanumericos = 12
             * Físicas: consta de 4 letras seguida por 6 dígitos y 3 caracteres alfanuméricos = 13
            */
            
            if (Model.RFCReceptor.Length == 13)
            {
                ViewBag.ListaUsoCFDI = oComboDatos.ListaUsoCFDIDetalle(oAuxSQLModel, "78654122-1130-405B-A739-1D19C19955EF");
            }
            else
            {
                ViewBag.ListaUsoCFDI = oComboDatos.ListaUsoCFDIDetalle(oAuxSQLModel, "25BD8A08-3C23-4359-8E34-76A2C8E95B3D");
            }

            return View();
        }
    }
}