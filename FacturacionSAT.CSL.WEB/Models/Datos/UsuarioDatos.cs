using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            catch (Exception) //ex)
            {
                return 0;
            }
        }

        public UsuarioModels ObtenerNombreUsuarioLogeado(UsuarioModels Datos)
        {
            try
            {
                object[] Parametros = { Datos.Id_Usuario, Datos.Id_TipoUsuario };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(Datos.Conexion, "[dbo].[NombreUsuarioLogeado_Facturacion_Web]", Parametros);
                while (dr.Read())
                {
                    Datos.NombreCompleto = !dr.IsDBNull(dr.GetOrdinal("NombreCompleto")) ? dr.GetString(dr.GetOrdinal("NombreCompleto")) : string.Empty;
                    break;
                }
                dr.Close();
                return Datos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UsuarioModels ValidarUsuario(UsuarioModels Datos)
        {
            try
            {
                object[] parametros = { Datos.user, Datos.Password };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Login_sp_Facturacion_Web", parametros);
                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        DataTableReader DTRD = Ds.Tables[0].CreateDataReader();
                        while (DTRD.Read())
                        {
                            Datos.Opcion = Convert.ToInt32(DTRD["id"].ToString());
                            break;
                        }
                        if (Datos.Opcion == 1)
                        {
                            DataTableReader Dr = Ds.Tables[1].CreateDataReader();
                            while (Dr.Read())
                            {
                                Datos.Id_Usuario = !Dr.IsDBNull(Dr.GetOrdinal("Id_U")) ? Dr.GetInt32(Dr.GetOrdinal("Id_U")): 0;
                                Datos.NombreCompleto = !Dr.IsDBNull(Dr.GetOrdinal("U_Nombre")) ? Dr.GetString(Dr.GetOrdinal("U_Nombre")) : string.Empty;
                                Datos.Id_TipoUsuario = !Dr.IsDBNull(Dr.GetOrdinal("Id_Tu")) ? Dr.GetInt32(Dr.GetOrdinal("Id_Tu")) : 0;
                                Datos.user = !Dr.IsDBNull(Dr.GetOrdinal("Cu_User")) ? Dr.GetString(Dr.GetOrdinal("Cu_User")): string.Empty;
                                Datos.Password = !Dr.IsDBNull(Dr.GetOrdinal("Cu_Pass")) ? Dr.GetString(Dr.GetOrdinal("Cu_Pass")): string.Empty;
                            }
                        }
                    }
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}