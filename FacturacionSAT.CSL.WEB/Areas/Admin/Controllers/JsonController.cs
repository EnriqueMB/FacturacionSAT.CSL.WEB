using FacturacionSAT.CSL.WEB.Models;
using FacturacionSAT.CSL.WEB.Models.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    public class JsonController : Controller
    {
        private string Conexion = ConfigurationManager.AppSettings.Get("strConnection");

        [HttpPost]
        public JsonResult ProductoServicio(string prodServBuscar)
        {
            List<ComboModel> Lista = new List<ComboModel>();
            JsonDatos oJsonDatos = new JsonDatos();
            AuxSQLModel oAuxSQLModel = new AuxSQLModel();
            oAuxSQLModel.Conexion = Conexion;
            Lista = oJsonDatos.ListaFormaPagoDetalle(oAuxSQLModel, prodServBuscar);

            return Json(Lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UnidadMedida(string unidadMedidaBuscar)
        {
            List<ComboModel> Lista = new List<ComboModel>();
            JsonDatos oJsonDatos = new JsonDatos();
            AuxSQLModel oAuxSQLModel = new AuxSQLModel();
            oAuxSQLModel.Conexion = Conexion;
            Lista = oJsonDatos.ListaUnidadMedidaDetalle(oAuxSQLModel, unidadMedidaBuscar);

            return Json(Lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CFDI_Conceptos()
        {
            List<ComboModel> Lista = new List<ComboModel>();
            JsonDatos oJsonDatos = new JsonDatos();
            AuxSQLModel oAuxSQLModel = new AuxSQLModel();
            oAuxSQLModel.Conexion = Conexion;
            oAuxSQLModel.Mensaje = oJsonDatos.DatatableIndexConceptos(oAuxSQLModel);

            return Content(oAuxSQLModel.Mensaje, "application/json");

           // return Json(oAuxSQLModel.Mensaje, JsonRequestBehavior.AllowGet);
        }
    }
}