using FacturacionSAT.CSL.WEB.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    [Autorizado]
    public class HomeAdminController : Controller
    {
        // GET: Areas/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Prueba()
        {
            return View();
        }
    }
}