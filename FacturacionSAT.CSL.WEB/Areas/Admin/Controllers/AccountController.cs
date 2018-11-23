using FacturacionSAT.CSL.WEB.Filters;
using FacturacionSAT.CSL.WEB.Models;
using FacturacionSAT.CSL.WEB.Models.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FacturacionSAT.CSL.WEB.Areas.Admin.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Areas/Account
        [AllowAnonymous]
        public ActionResult Index()
        {
            try
            {
                FormsAuthentication.SignOut();
                if (User.Identity.IsAuthenticated)
                {
                    UsuarioModels usuario = new UsuarioModels();
                    UsuarioDatos UsuarioD = new UsuarioDatos();
                    usuario.Conexion = Conexion;
                    int.TryParse(User.Identity.Name, out int tipousuario);
                    usuario.Id_Usuario = tipousuario;
                    int TipoUsario = UsuarioD.ObtenerTipoUsuarioByUserName(usuario);
                    if (TipoUsario == 3)
                    {
                        return RedirectToAction("Index", "HomeAdmin", new { Area = "Admin" });
                    }
                    else
                        return RedirectToAction("LogOff", "Account");
                }
                else
                    return View();
            }
            catch (Exception)
            {
                return RedirectToAction("LogOff", "Account");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index(UsuarioModels model, string returnUrl)
        {
            FormsAuthentication.SetAuthCookie("1", model.RememberMe);
            return RedirectToAction("Index", "HomeAdmin", new { Area = "Admin" });
            //LoginDatos UD = new LoginDatos();
            //model.conexion = Conexion;
            //model = UD.ValidarUsuario(model);
            //if (model.opcion == 1)
            //{
            //    FormsAuthentication.SignOut();
            //    _Usuario_Datos usuario_datos = new _Usuario_Datos();
            //    UsuarioModels usuario = new UsuarioModels();
            //    //usuario.conexion = Conexion;
            //    //usuario.cuenta = model.id_usuario;
            //    int TipoUsario = usuario_datos.ObtenerTipoUsuarioByUserName(usuario);
            //    System.Web.HttpContext.Current.Session["SessionTipoUsuario"] = TipoUsario;
            //    FormsAuthentication.SetAuthCookie(model.id_usuario, model.RememberMe);
            //    HttpCookie authCookie = FormsAuthentication.GetAuthCookie(model.id_usuario, model.RememberMe);
            //    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            //    List<string> listaPermiso = new List<string>();
            //    foreach (var item in model.ListaPermisos)
            //    {
            //        listaPermiso.Add(item.NombreUrl);
            //    }
            //    System.Web.HttpContext.Current.Session["SessionListaPermiso"] = listaPermiso;
            //    System.Web.HttpContext.Current.Session["NombreUsuario"] = model.nombreCompleto;
            //    if (TipoUsario == 1)
            //    {
            //        return RedirectToAction("Index", "HomeAdmin", new { Area = "Admin" });
            //    }
            //    //else if (id_tipoUsuario == "1")
            //    //{
            //    //    return RedirectToAction("Index", "HomeProfesor", new { Area = "Profesor" });
            //    //}
            //    else
            //    {
            //        ModelState.AddModelError("", "No tienes permisos");
            //        Session.Abandon();
            //        Session.Clear();
            //        Session.RemoveAll();
            //        return View(model);
            //    }
            //}
            //else if (model.opcion == 2)
            //{
            //    ModelState.AddModelError("", "Usuario no existe");
            //    Session.Abandon();
            //    Session.Clear();
            //    Session.RemoveAll();
            //    return View(model);
            //}
            //else if (model.opcion == 3)
            //{
            //    ModelState.AddModelError("", "Error de Contraseña");
            //    Session.Abandon();
            //    Session.Clear();
            //    Session.RemoveAll();
            //    return View(model);
            //}
            //else if (model.opcion == 4)
            //{
            //    ModelState.AddModelError("", "El usuario tiene que ser de tipo. Administrador");
            //    Session.Abandon();
            //    Session.Clear();
            //    Session.RemoveAll();
            //    return View(model);
            //}
            //else
            //{
            //    ModelState.AddModelError("", "El usuario o contraseña son incorrectos!!.");
            //    Session.Abandon();
            //    Session.Clear();
            //    Session.RemoveAll();
            //    return View(model);
            //}
        }

        // GET: /Account/LogOff
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account");
        }
    }
}