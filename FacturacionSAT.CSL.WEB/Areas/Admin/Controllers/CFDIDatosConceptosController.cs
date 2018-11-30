using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacturacionSAT.CSL.WEB.Models.Datos;
using FacturacionSAT.CSL.WEB.Models;
using FacturacionSAT.CSL.WEB.App_Start;
using System.Configuration;
using FacturacionSAT.CSL.WEB.Filters;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    [Autorizado]
    public class CFDIDatosConceptosController : Controller
    {
        private TokenProcessor Token = TokenProcessor.GetInstance();
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
       // private object oAuxSQLModel;

        // GET: Admin/CFDIDatosConceptos
        public ActionResult Index()
        {
            try
            {
                CFDIDatosConceptosModels CFDIConcepto = new CFDIDatosConceptosModels();
                CFDIConceptosDatos CFDIconcepto = new CFDIConceptosDatos();
                AuxSQLModel oAuxSQLModel = new AuxSQLModel();
                oAuxSQLModel.Conexion = Conexion;
                CFDIConcepto.ListaCFDIConceptos = CFDIconcepto.CFDIConceptos(oAuxSQLModel);

                return View(CFDIConcepto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return View();
        }

        [HttpGet]
        public ActionResult crear(/*string id*/)
        {
            try
            {
                Token.SaveToken();
                CFDIDatosConceptosModels Model = new CFDIDatosConceptosModels();
                CFDIConceptosDatos ConceptoDatos = new CFDIConceptosDatos();
                Model.Predeterminado = true;
                //ComboDatos listTipoPoduc = new ComboDatos();
                Model.Conexion = Conexion;

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
            //ComboDatos listTipoPoduc = new ComboDatos();
            try
            {
                if (Token.IsTokenValid())
                {
                    if (ModelState.IsValid)
                    {
                        Model.Conexion = Conexion;

                        Model.Id_usuario = User.Identity.Name;
                        Model.Opcion = 1;
                        Model.Id_cfdiDatosConceptos = string.Empty;
                        Model = ConceptoDatos.ABCCFDIconceptos(Model);
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
                            //Model.ListaTipoProducto = listTipoPoduc.ListaTipoProducto(Model);
                            //Model.ListaDivicion = listTipoPoduc.ListaDivicionConcepto(Model);
                            //Model.ListaGrupo = listTipoPoduc.ListaGrupoConcepto(Model);
                            //Model.ListaClase = listTipoPoduc.ListaCFDIClase(Model);
                            //Model.ListaClaveProducto = listTipoPoduc.ListaConceptoClaveProducto(Model);
                            //Model.ListaClaveunidad = listTipoPoduc.ListaConceptoClaveUnidad(Model);

                            //var ListTipoProduct = new SelectList(Model.ListaTipoProducto, " Id_cfdiTipoProducto", "TipoProducto");
                            //var ListDivicion = new SelectList(Model.ListaDivicion, " Id_cfdiDivision", "Division");
                            //var ListGrupo = new SelectList(Model.ListaGrupo, " Id_cfdiGrupo", "Grupo");
                            //var ListCFDIClase = new SelectList(Model.ListaClase, "Id_CfdiClase", "clase");
                            //var listaClaveProducto = new SelectList(Model.ListaClaveProducto, "Id_cfdiClaveProdServDetalle", "Descripcion");
                            //var listaClaveUnidad = new SelectList(Model.ListaClaveunidad, "Id_cfdiClaveUnidad", "Nombre");

                            //ViewData["cmbTipoProducto"] = ListTipoProduct;
                            //ViewData["cmbDivicion"] = ListDivicion;
                            //ViewData["cmbClase"] = ListCFDIClase;
                            //ViewData["cmbGrupo"] = ListGrupo;
                            //ViewData["cmbclaveproducto"] = listaClaveProducto;
                            //ViewData["cmbclaveunidad"] = listaClaveUnidad;
                            return View(Model);
                        }
                    }
                    else
                    {
                        Model.Conexion = Conexion;
                        //Model.ListaTipoProducto = listTipoPoduc.ListaTipoProducto(Model);
                        //Model.ListaDivicion = listTipoPoduc.ListaDivicionConcepto(Model);
                        //Model.ListaGrupo = listTipoPoduc.ListaGrupoConcepto(Model);
                        //Model.ListaClase = listTipoPoduc.ListaCFDIClase(Model);
                        //Model.ListaClaveProducto = listTipoPoduc.ListaConceptoClaveProducto(Model);
                        //Model.ListaClaveunidad = listTipoPoduc.ListaConceptoClaveUnidad(Model);
                        return View(Model);
                    }
                }
                else
                {
                    Model.Conexion = Conexion;
                    //Model.ListaTipoProducto = listTipoPoduc.ListaTipoProducto(Model);
                    //Model.ListaDivicion = listTipoPoduc.ListaDivicionConcepto(Model);
                    //Model.ListaGrupo = listTipoPoduc.ListaGrupoConcepto(Model);
                    //Model.ListaClase = listTipoPoduc.ListaCFDIClase(Model);
                    //Model.ListaClaveProducto = listTipoPoduc.ListaConceptoClaveProducto(Model);
                    //Model.ListaClaveunidad = listTipoPoduc.ListaConceptoClaveUnidad(Model);
                    return View(Model);
                }
            }

            catch (Exception)
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                //Model.ListaTipoProducto = listTipoPoduc.ListaTipoProducto(Model);
                //Model.ListaDivicion = listTipoPoduc.ListaDivicionConcepto(Model);
                //Model.ListaGrupo = listTipoPoduc.ListaGrupoConcepto(Model);
                //Model.ListaClase = listTipoPoduc.ListaCFDIClase(Model);
                //Model.ListaClaveProducto = listTipoPoduc.ListaConceptoClaveProducto(Model);
                //Model.ListaClaveunidad = listTipoPoduc.ListaConceptoClaveUnidad(Model);

                //var ListTipoProduct = new SelectList(Model.ListaTipoProducto, " Id_cfdiTipoProducto", "TipoProducto");
                //var ListDivicion = new SelectList(Model.ListaDivicion, " Id_cfdiDivision", "Division");
                //var ListGrupo = new SelectList(Model.ListaGrupo, " Id_cfdiGrupo", "Grupo");
                //var ListCFDIClase = new SelectList(Model.ListaClase, "Id_CfdiClase", "clase");
                //var listaClaveProducto = new SelectList(Model.ListaClaveProducto, "Id_cfdiClaveProdServDetalle", "Descripcion");
                //var listaClaveUnidad = new SelectList(Model.ListaClaveunidad, "Id_cfdiClaveUnidad", "Nombre");

                //ViewData["cmbTipoProducto"] = ListTipoProduct;
                //ViewData["cmbDivicion"] = ListDivicion;
                //ViewData["cmbClase"] = ListCFDIClase;
                //ViewData["cmbGrupo"] = ListGrupo;
                //ViewData["cmbclaveproducto"] = listaClaveProducto;
                //ViewData["cmbclaveunidad"] = listaClaveUnidad;
                return View(Model);
            }
        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            try
            {

                Token.SaveToken();
                CFDIDatosConceptosModels Model = new CFDIDatosConceptosModels();
                //ComboDatos listTipoPoduc = new ComboDatos();
                CFDIConceptosDatos detalleEditDatos = new CFDIConceptosDatos();
                
                Model.Conexion = Conexion;
                Model.Id_cfdiDatosConceptos = Id;
                //Model.ListaTipoProducto = listTipoPoduc.ListaTipoProducto(Model);
                //Model.ListaDivicion = listTipoPoduc.ListaDivicionConcepto(Model);
                //Model.ListaGrupo = listTipoPoduc.ListaGrupoConcepto(Model);
                //Model.ListaClase = listTipoPoduc.ListaCFDIClase(Model);
                //Model.ListaClaveProducto = listTipoPoduc.ListaConceptoClaveProducto(Model);
                //Model.ListaClaveunidad = listTipoPoduc.ListaConceptoClaveUnidad(Model);

                //var ListTipoProduct = new SelectList(Model.ListaTipoProducto, "Id_cfdiTipoProducto", "TipoProducto");
                //var ListDivicion = new SelectList(Model.ListaDivicion, "Id_cfdiDivision", "Division");
                //var ListGrupo = new SelectList(Model.ListaGrupo, "Id_cfdiGrupo", "Grupo");
                //var ListCFDIClase = new SelectList(Model.ListaClase, "Id_CfdiClase", "clase");
                //var listaClaveProducto = new SelectList(Model.ListaClaveProducto, "Id_cfdiClaveProdServDetalle", "Descripcion");
                //var listaClaveUnidad = new SelectList(Model.ListaClaveunidad, "id_cfdiClaveUnidadDetalle", "Nombre");

                //ViewData["cmbTipoProducto"] = ListTipoProduct;
                //ViewData["cmbDivicion"] = ListDivicion;
                //ViewData["cmbClase"] = ListCFDIClase;
                //ViewData["cmbGrupo"] = ListGrupo;
                //ViewData["cmbclaveproducto"] = listaClaveProducto;
                //ViewData["cmbclaveunidad"] = listaClaveUnidad;
                Model = detalleEditDatos.GetCFDIConceptosEdit(Model);
                //Model.ListaCFDIConceptos= detalleEditDatos.GetCFDIConceptosEdit(Model);

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
        public ActionResult Edit(string Id, CFDIDatosConceptosModels Model)
            
        {
            
            CFDIConceptosDatos editarDatos = new CFDIConceptosDatos();
           
            //ComboDatos listTipoPoduc = new ComboDatos();
            try
            {
                if (Token.IsTokenValid())
                {
                    if (ModelState.IsValid)
                    {
                        Model.Conexion = Conexion;
                        Model.Opcion = 2;
                        Model.Id_usuario = User.Identity.Name;
                        Model.Id_cfdiDatosConceptos = Id;
                        Model = editarDatos.ABCCFDIconceptos(Model);
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
                            TempData["message"] = "Ocurrió un error al guardar el registro. Por default el predeterminado tiene que estar activo.";
                            return View(Model);
                        }
                    }
                    else
                    {
                        Model.Conexion = Conexion;
                        
                        //Model.ListaTipoProducto = listTipoPoduc.ListaTipoProducto(Model);
                        //Model.ListaDivicion = listTipoPoduc.ListaDivicionConcepto(Model);
                        //Model.ListaGrupo = listTipoPoduc.ListaGrupoConcepto(Model);
                        //Model.ListaClase = listTipoPoduc.ListaCFDIClase(Model);
                        //Model.ListaClaveProducto = listTipoPoduc.ListaConceptoClaveProducto(Model);
                        //Model.ListaClaveunidad = listTipoPoduc.ListaConceptoClaveUnidad(Model);
                        Model = editarDatos.GetCFDIConceptosEdit(Model);
                       
                        return View(Model);
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "No se pudo guardar los datos. Por default el predeterminado tiene que estar activo.";
                return View(Model);
            }
        }
        
        [HttpGet]
        public ActionResult Delete(string id)
        {
            return View();
        }
          
        [HttpPost]     
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CFDIDatosConceptosModels CFDIModelConcepto = new CFDIDatosConceptosModels();
                CFDIConceptosDatos CFDIConcepto = new CFDIConceptosDatos();
                //AuxSQLModel oAuxSQLModel = new AuxSQLModel();
                CFDIModelConcepto.Conexion = Conexion;
                CFDIModelConcepto.Opcion = 3;
                CFDIModelConcepto.Id_cfdiDatosConceptos = id;
                //CFDIModel.Predeterminado = id2;
                CFDIModelConcepto.Id_usuario = User.Identity.Name;
                CFDIModelConcepto = CFDIConcepto.ABCCFDIconceptos(CFDIModelConcepto);
                if (CFDIModelConcepto.Id_cfdiDatosConceptos == "")
                {
                    return RedirectToAction("Index");
                }
                return Json("");
            }
            catch
            {
                CFDIDatosConceptosModels CFDIModelConcepto = new CFDIDatosConceptosModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrió un error al guardar el registro. No puede eliminar este registro cuando es predeterminado!";
                return View(CFDIModelConcepto);
               
            }
        }

        #region Modales
        [HttpPost]
        public ActionResult ModalClaveUnidad()
        {
            return PartialView("ModalClaveUnidad");
        }

        public ActionResult DataTableClaveUnidad(DataTableParameters dataTableParameters)
        {

            AuxSQLModel oAuxSQLModel = new AuxSQLModel();
            oAuxSQLModel.Conexion = Conexion;

            JsonDatos oJsonDatos = new JsonDatos();
            oJsonDatos.Datatable_CFDIConceptos_get_ClaveUnidad(oAuxSQLModel, dataTableParameters);

            return Content(oAuxSQLModel.Mensaje);
        }

        [HttpPost]
        public ActionResult ModalClaveProducto()
        {
            return PartialView("ModalClaveProducto");
        }

        public ActionResult DataTableClaveProducto(DataTableParameters dataTableParameters)
        {

            AuxSQLModel oAuxSQLModel = new AuxSQLModel();
            oAuxSQLModel.Conexion = Conexion;

            JsonDatos oJsonDatos = new JsonDatos();
            oJsonDatos.Datatable_CFDIConceptos_get_ClaveProducto(oAuxSQLModel, dataTableParameters);

            return Content(oAuxSQLModel.Mensaje);
        }


        [HttpPost]
        public ActionResult ModalTipoProducto()
        {
            return PartialView("ModalTipoProducto");
        }

        public ActionResult DataTableTipoProducto(DataTableParameters dataTableParameters)
        {

            AuxSQLModel oAuxSQLModel = new AuxSQLModel();
            oAuxSQLModel.Conexion = Conexion;

            JsonDatos oJsonDatos = new JsonDatos();
            oJsonDatos.Datatable_CFDIConceptos_get_TipoProducto(oAuxSQLModel, dataTableParameters);

            return Content(oAuxSQLModel.Mensaje);
        }

        public ActionResult ModalClaveDivision()
        {
            return PartialView("ModalClaveDivision");
        }

        public ActionResult DataTableClaveDivision(DataTableParameters dataTableParameters)
        {

            AuxSQLModel oAuxSQLModel = new AuxSQLModel();
            oAuxSQLModel.Conexion = Conexion;

            JsonDatos oJsonDatos = new JsonDatos();
            oJsonDatos.Datatable_CFDIConceptos_get_ClaveDivision(oAuxSQLModel, dataTableParameters);

            return Content(oAuxSQLModel.Mensaje);
        }

        public ActionResult ModalClaveGrupo()
        {
            return PartialView("ModalClaveGrupo");
        }

        public ActionResult DataTableClaveGrupo(DataTableParameters dataTableParameters)
        {

            AuxSQLModel oAuxSQLModel = new AuxSQLModel();
            oAuxSQLModel.Conexion = Conexion;

            JsonDatos oJsonDatos = new JsonDatos();
            oJsonDatos.Datatable_CFDIConceptos_get_ClaveGrupo(oAuxSQLModel, dataTableParameters);

            return Content(oAuxSQLModel.Mensaje);
        }
        public ActionResult ModalClaveClase()
        {
            return PartialView("ModalClaveClase");
        }

        public ActionResult DataTableClaveClase(DataTableParameters dataTableParameters)
        {

            AuxSQLModel oAuxSQLModel = new AuxSQLModel();
            oAuxSQLModel.Conexion = Conexion;

            JsonDatos oJsonDatos = new JsonDatos();
            oJsonDatos.Datatable_CFDIConceptos_get_ClaveClase(oAuxSQLModel, dataTableParameters);

            return Content(oAuxSQLModel.Mensaje);
        }

        #endregion
    }
}