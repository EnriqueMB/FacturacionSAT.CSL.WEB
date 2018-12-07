using FacturacionSAT.CSL.WEB.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturacionSAT.CSL.WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Facturacion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Facturacion(IndexFacturaViewModel Model)
        {
            ModelState.Remove("CodigoBarraReimpresion");
            if (!ModelState.IsValid)
            {
                TempData["message"] = "Verifique sus datos";
                TempData["typemessage"] = "2";
                return View(Model);
            }
            else
            {
                
                return RedirectToAction("Add", "Factura", Model);
            }
        }

        [HttpPost]
        public ActionResult Reimpresion(IndexFacturaViewModel Model)
        {
            ModelState.Remove("RFCReceptor");
            ModelState.Remove("CodigoBarra");
            if (!ModelState.IsValid)
            {
                TempData["message"] = "Verifique sus datos";
                TempData["typemessage"] = "2";
                return View(Model);
            }
            else
            {

                return RedirectToAction("Reimpresion", "Factura", Model);
            }
        }
    }
}