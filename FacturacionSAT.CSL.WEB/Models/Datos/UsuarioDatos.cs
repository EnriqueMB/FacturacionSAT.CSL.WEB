using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models.Datos
{
    public class UsuarioDatos
    {
        public int ObtenerTipoUsuarioByUserName(UsuarioModels usuario)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(usuario.Conexion, "TipoUsuarioByUserName_Facturacion_Web", usuario.Id_Usuario);
                return Convert.ToInt32(aux.ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}