using FacturacionSAT.CSL.WEB.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        // GET: Areas/Account
        public ActionResult Index()
        {
            return View();
        }
    }
}