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
                Model.ListaClaveProducto = listTipoPoduc.ListaConceptoClaveProducto(Model);
                Model.ListaClaveunidad = listTipoPoduc.ListaConceptoClaveUnidad(Model);

                var ListTipoProduct = new SelectList(Model.ListaTipoProducto, " Id_cfdiTipoProducto", "TipoProducto");
                var ListDivicion = new SelectList(Model.ListaDivicion, " Id_cfdiDivision", "Division");
                var ListGrupo = new SelectList(Model.ListaGrupo, " Id_cfdiGrupo", "Grupo");
                var ListCFDIClase = new SelectList(Model.ListaClase, "Id_CfdiClase", "clase");
                var listaClaveProducto = new SelectList(Model.ListaClaveProducto, "Id_cfdiClaveProdServDetalle", "Descripcion");
                var listaClaveUnidad = new SelectList(Model.ListaClaveunidad, "Id_cfdiClaveUnidad", "Nombre");

                ViewData["cmbTipoProducto"] = ListTipoProduct;
                ViewData["cmbDivicion"] = ListDivicion;
                ViewData["cmbClase"] = ListCFDIClase;
                ViewData["cmbGrupo"] = ListGrupo;
                ViewData["cmbclaveproducto"] = listaClaveProducto;
                ViewData["cmbclaveunidad"] = listaClaveUnidad;

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
        public ActionResult Crear(CFDIDatosConceptosModels Model)
        {
           
            CFDIConceptosDatos ConceptoDatos = new CFDIConceptosDatos();
            ComboDatos listTipoPoduc = new ComboDatos();
            try
            {
                if (Token.IsTokenValid())
                {
                    if (ModelState.IsValid)
                    {
                        Model.Conexion = Conexion;

                        Model.Id_usuario = User.Identity.Name;
                        Model.Opcion = 1;
                        //Model.Id_cfdiDatosConceptos = string.Empty;
                        Model = ConceptoDatos.ABCCFDIconcepto(Model);
                        //Si abc fue completado correctamente
                        if (Model.Completado == true)
                        {
                            TempData["typemessage"] = "1";
                            TempData["message"] = "El registro se guardo correctamente.";
                            Token.ResetToken();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["typemessage"] = "2";
                            TempData["message"] = "Ocurrió un error al guardar el registro.";
                            Model.ListaTipoProducto = listTipoPoduc.ListaTipoProducto(Model);
                            Model.ListaDivicion = listTipoPoduc.ListaDivicionConcepto(Model);
                            Model.ListaGrupo = listTipoPoduc.ListaGrupoConcepto(Model);
                            Model.ListaClase = listTipoPoduc.ListaCFDIClase(Model);
                            Model.ListaClaveProducto = listTipoPoduc.ListaConceptoClaveProducto(Model);
                            Model.ListaClaveunidad = listTipoPoduc.ListaConceptoClaveUnidad(Model);

                            var ListTipoProduct = new SelectList(Model.ListaTipoProducto, " Id_cfdiTipoProducto", "TipoProducto");
                            var ListDivicion = new SelectList(Model.ListaDivicion, " Id_cfdiDivision", "Division");
                            var ListGrupo = new SelectList(Model.ListaGrupo, " Id_cfdiGrupo", "Grupo");
                            var ListCFDIClase = new SelectList(Model.ListaClase, "Id_CfdiClase", "clase");
                            var listaClaveProducto = new SelectList(Model.ListaClaveProducto, "Id_cfdiClaveProdServDetalle", "Descripcion");
                            var listaClaveUnidad = new SelectList(Model.ListaClaveunidad, "Id_cfdiClaveUnidad", "Nombre");

                            ViewData["cmbTipoProducto"] = ListTipoProduct;
                            ViewData["cmbDivicion"] = ListDivicion;
                            ViewData["cmbClase"] = ListCFDIClase;
                            ViewData["cmbGrupo"] = ListGrupo;
                            ViewData["cmbclaveproducto"] = listaClaveProducto;
                            ViewData["cmbclaveunidad"] = listaClaveUnidad;
                            return View(Model);
                        }
                    }
                    else
                    {
                        Model.Conexion = Conexion;
                        Model.ListaTipoProducto = listTipoPoduc.ListaTipoProducto(Model);
                        Model.ListaDivicion = listTipoPoduc.ListaDivicionConcepto(Model);
                        Model.ListaGrupo = listTipoPoduc.ListaGrupoConcepto(Model);
                        Model.ListaClase = listTipoPoduc.ListaCFDIClase(Model);
                        Model.ListaClaveProducto = listTipoPoduc.ListaConceptoClaveProducto(Model);
                        Model.ListaClaveunidad = listTipoPoduc.ListaConceptoClaveUnidad(Model);
                        return View(Model);
                    }
                }
                else
                {
                    Model.Conexion = Conexion;
                    Model.ListaTipoProducto = listTipoPoduc.ListaTipoProducto(Model);
                    Model.ListaDivicion = listTipoPoduc.ListaDivicionConcepto(Model);
                    Model.ListaGrupo = listTipoPoduc.ListaGrupoConcepto(Model);
                    Model.ListaClase = listTipoPoduc.ListaCFDIClase(Model);
                    Model.ListaClaveProducto = listTipoPoduc.ListaConceptoClaveProducto(Model);
                    Model.ListaClaveunidad = listTipoPoduc.ListaConceptoClaveUnidad(Model);
                    return View(Model);
                }
            }
            
            catch (Exception)
            {
               
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                Model.ListaTipoProducto = listTipoPoduc.ListaTipoProducto(Model);
                Model.ListaDivicion = listTipoPoduc.ListaDivicionConcepto(Model);
                Model.ListaGrupo = listTipoPoduc.ListaGrupoConcepto(Model);
                Model.ListaClase = listTipoPoduc.ListaCFDIClase(Model);
                Model.ListaClaveProducto = listTipoPoduc.ListaConceptoClaveProducto(Model);
                Model.ListaClaveunidad = listTipoPoduc.ListaConceptoClaveUnidad(Model);

                var ListTipoProduct = new SelectList(Model.ListaTipoProducto, " Id_cfdiTipoProducto", "TipoProducto");
                var ListDivicion = new SelectList(Model.ListaDivicion, " Id_cfdiDivision", "Division");
                var ListGrupo = new SelectList(Model.ListaGrupo, " Id_cfdiGrupo", "Grupo");
                var ListCFDIClase = new SelectList(Model.ListaClase, "Id_CfdiClase", "clase");
                var listaClaveProducto = new SelectList(Model.ListaClaveProducto, "Id_cfdiClaveProdServDetalle", "Descripcion");
                var listaClaveUnidad = new SelectList(Model.ListaClaveunidad, "Id_cfdiClaveUnidad", "Nombre");

                ViewData["cmbTipoProducto"] = ListTipoProduct;
                ViewData["cmbDivicion"] = ListDivicion;
                ViewData["cmbClase"] = ListCFDIClase;
                ViewData["cmbGrupo"] = ListGrupo;
                ViewData["cmbclaveproducto"] = listaClaveProducto;
                ViewData["cmbclaveunidad"] = listaClaveUnidad;
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