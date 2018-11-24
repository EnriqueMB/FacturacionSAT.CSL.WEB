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
                    int.TryParse(User.Identity.Name, out int UsuarioL);
                    usuario.Id_Usuario = UsuarioL;
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
            //UsuarioDatos DatosU = new UsuarioDatos();
            //model.Conexion = Conexion;
            //model = DatosU.ValidarUsuario(model);
            //if (model.Opcion == 1)
            //{
            //    FormsAuthentication.SignOut();
            //    if (model.Id_TipoUsuario != 3)
            //    {
            //        int TipoUsario = DatosU.ObtenerTipoUsuarioByUserName(model);
            //        System.Web.HttpContext.Current.Session["SessionTipoUsuario"] = TipoUsario;
            //        model.Id_TipoUsuario = TipoUsario;
            //    }
            //    FormsAuthentication.SetAuthCookie(model.Id_Usuario.ToString(), model.RememberMe);
            //    HttpCookie authCookie = FormsAuthentication.GetAuthCookie(model.Id_Usuario.ToString(), model.RememberMe);
            //    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            //    if (model.Id_TipoUsuario == 3)
            //    {
            //        return RedirectToAction("Index", "HomeAdmin", new { Area = "Admin" });
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "El usuario no tiene permiso para entrar el sistema facturación");
            //        Session.Abandon();
            //        Session.Clear();
            //        Session.RemoveAll();
            //        return View(model);
            //    }
            //}
            //else if (model.Opcion == 4)
            //{
            //    ModelState.AddModelError("", "El usuario tiene que ser de tipo. Administrador");
            //    Session.Abandon();
            //    Session.Clear();
            //    Session.RemoveAll();
            //    return View(model);
            //}
            //else if (model.Opcion == 2)
            //{
            //    ModelState.AddModelError("", "Usuario no existe");
            //    Session.Abandon();
            //    Session.Clear();
            //    Session.RemoveAll();
            //    return View(model);
            //}
            //else if (model.Opcion == 9)
            //{
            //    ModelState.AddModelError("", "El password es incorrecto");
            //    Session.Abandon();
            //    Session.Clear();
            //    Session.RemoveAll();
            //    return View(model);
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Contacte a soporte técnico.");
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