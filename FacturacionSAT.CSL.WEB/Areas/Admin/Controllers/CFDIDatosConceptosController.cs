using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    public class CFDIDatosConceptosController : Controller
    {
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
                if(string.IsNullOrEmpty(Id))
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