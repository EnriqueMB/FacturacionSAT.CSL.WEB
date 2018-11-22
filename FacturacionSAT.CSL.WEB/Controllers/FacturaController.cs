using FacturacionSAT.CSL.WEB.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturacionSAT.CSL.WEB.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        public ActionResult Index()
        {
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
                return Content("1");
            }
        }

        public ActionResult Add(IndexFacturaViewModel Model)
        {

            return View();
        }
    }
}