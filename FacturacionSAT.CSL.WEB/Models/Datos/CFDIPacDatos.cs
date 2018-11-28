using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;

namespace FacturacionSAT.CSL.WEB.Models.Datos
{
    public class CFDIPacDatos
    {
        public List<CFDIDatosPacModels> ListaPac(AuxSQLModel oAuxSQLModel)
        {
            try
            {
                List<CFDIDatosPacModels> Lista = new List<CFDIDatosPacModels>();
                CFDIDatosPacModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "dbo.CFDIDatosPac_Consulta_sp");
                while (dr.Read())
                {
                    item = new CFDIDatosPacModels();
                    item.Id_cfdiDatosPac = !dr.IsDBNull(dr.GetOrdinal("id_cfdiDatosPac")) ? dr.GetString(dr.GetOrdinal("id_cfdiDatosPac")) : string.Empty;
                    item.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                    item.UserPac = !dr.IsDBNull(dr.GetOrdinal("userPac")) ? dr.GetString(dr.GetOrdinal("userPac")) : string.Empty;
                    //item.PasswordPac = !dr.IsDBNull(dr.GetOrdinal("PasswordPac")) ? dr.GetString(dr.GetOrdinal("PasswordPac")) : string.Empty;
                    item.UserPacTest = !dr.IsDBNull(dr.GetOrdinal("userPacTest")) ? dr.GetString(dr.GetOrdinal("userPacTest")) : string.Empty;
                    //item.PasswordPacTest = !dr.IsDBNull(dr.GetOrdinal("PasswordPacTest")) ? dr.GetString(dr.GetOrdinal("PasswordPacTest")) : string.Empty;
                    item.Predeterminado = !dr.IsDBNull(dr.GetOrdinal("predeterminado")) ? dr.GetBoolean(dr.GetOrdinal("predeterminado")) : false;
                    Lista.Add(item);                    
                }
                dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }       
        }

        public CFDIDatosPacModels ABCCFDIPac(CFDIDatosPacModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.Opcion,
                    datos.Id_cfdiDatosPac ?? string.Empty ,
                    datos.Descripcion ?? string.Empty,
                    datos.UserPac ?? string.Empty,
                    datos.PasswordPac ?? string.Empty,
                    datos.UserPacTest ?? string.Empty,
                    datos.PasswordPacTest ?? string.Empty,
                    datos.Predeterminado,
                    datos.Id_usuario ?? string.Empty                  
                };
                object aux = SqlHelper.ExecuteScalar(datos.Conexion, "dbo.abc_CFDIDatosPac", parametros);
                datos.Id_cfdiDatosPac = aux.ToString();

                if (!string.IsNullOrEmpty(datos.Id_cfdiDatosPac))
                {
                    datos.Completado = true;
                }
                else
                {
                    datos.Completado = false;
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CFDIDatosPacModels GetCFDIPacDetail(CFDIDatosPacModels datos)
        {
            try
            {
                object[] parametros = { datos.Id_cfdiDatosPac };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.Conexion, "dbo.CFDIDatosPacDetalle_sp", parametros);
                while (dr.Read())
                {
                    datos.Id_cfdiDatosPac = !dr.IsDBNull(dr.GetOrdinal("id_cfdiDatosPac")) ? dr.GetString(dr.GetOrdinal("id_cfdiDatosPac")) : string.Empty;
                    datos.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                    datos.UserPac = !dr.IsDBNull(dr.GetOrdinal("userPac")) ? dr.GetString(dr.GetOrdinal("userPac")) : string.Empty;
                    datos.PasswordPac = !dr.IsDBNull(dr.GetOrdinal("passwordPac")) ? dr.GetString(dr.GetOrdinal("passwordPac")) : string.Empty;
                    datos.UserPacTest = !dr.IsDBNull(dr.GetOrdinal("userPacTest")) ? dr.GetString(dr.GetOrdinal("userPacTest")) : string.Empty;
                    datos.PasswordPacTest = !dr.IsDBNull(dr.GetOrdinal("passwordPacTest")) ? dr.GetString(dr.GetOrdinal("passwordPacTest")) : string.Empty;
                    datos.Predeterminado = !dr.IsDBNull(dr.GetOrdinal("predeterminado")) ? dr.GetBoolean(dr.GetOrdinal("predeterminado")) : false;
                }
                dr.Close();
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}