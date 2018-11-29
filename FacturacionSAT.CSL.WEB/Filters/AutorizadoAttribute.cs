using FacturacionSAT.CSL.WEB.Models;
using FacturacionSAT.CSL.WEB.Models.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace FacturacionSAT.CSL.WEB.Filters
{
    public class AutorizadoAttribute : ActionFilterAttribute
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.Session["SessionTipoUsuario"] == null)
                {
                    UsuarioModels Usuario = new UsuarioModels();
                    UsuarioDatos usuario_datos = new UsuarioDatos();
                    Usuario.Conexion = Conexion;
                    IPrincipal user = HttpContext.Current.User;
                    int.TryParse(user.Identity.Name, out int IDUSUARIO);
                    Usuario.Id_Usuario = IDUSUARIO;
                    int TipoUsario = usuario_datos.ObtenerTipoUsuarioByUserName(Usuario);
                    HttpContext.Current.Session["SessionTipoUsuario"] = TipoUsario;
                }
                else
                {
                    int TipoUsuario = (int)HttpContext.Current.Session["SessionTipoUsuario"];
                    HttpContext.Current.Session["SessionTipoUsuario"] = TipoUsuario;
                }
                if (HttpContext.Current.Session["NombreUsuario"] == null)
                {
                    UsuarioModels CuentaUsuario = new UsuarioModels();
                    UsuarioDatos usuario_datos = new UsuarioDatos();
                    CuentaUsuario.Conexion = Conexion;
                    IPrincipal user = HttpContext.Current.User;
                    int.TryParse(user.Identity.Name, out int IDUSUARIO);
                    CuentaUsuario.Id_Usuario = IDUSUARIO;
                    int TipoUsuario = (int)HttpContext.Current.Session["SessionTipoUsuario"];
                    CuentaUsuario.Id_TipoUsuario = TipoUsuario;
                    CuentaUsuario = usuario_datos.ObtenerNombreUsuarioLogeado(CuentaUsuario);
                    HttpContext.Current.Session["NombreUsuario"] = CuentaUsuario.NombreCompleto;
                }
                else
                {
                    string NombreUsuario = (string)HttpContext.Current.Session["NombreUsuario"];
                    HttpContext.Current.Session["NombreUsuario"] = NombreUsuario;
                }
            }
        }
    }
}