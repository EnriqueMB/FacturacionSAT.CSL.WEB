﻿using System;
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
        public ActionResult Facturacion(FormCollection collection)
        {
            string nombre = collection["name"].ToString();
            return View();
        }
    }
}