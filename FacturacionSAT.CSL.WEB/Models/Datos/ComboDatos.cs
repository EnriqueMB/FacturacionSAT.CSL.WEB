using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;

namespace FacturacionSAT.CSL.WEB.Models.Datos
{
    public class ComboDatos
    {
        public List<ComboModel> ListaEmisores(AuxSQLModel oAuxSQLModel)
        {
            try
            {
                List<ComboModel> lista = new List<ComboModel>();
                ComboModel item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[CFDIDatosEmisorV2_Combo_sp]");
                while (dr.Read())
                {
                    item = new ComboModel();
                    item.Id = !dr.IsDBNull(dr.GetOrdinal("id")) ? dr.GetString(dr.GetOrdinal("id")) : string.Empty;
                    item.Value = !dr.IsDBNull(dr.GetOrdinal("value")) ? dr.GetString(dr.GetOrdinal("value")) : string.Empty;
                    lista.Add(item);
                }
                dr.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboModel> ListaFormaPagoDetalle(AuxSQLModel oAuxSQLModel)
        {
            try
            {
                List<ComboModel> lista = new List<ComboModel>();
                ComboModel item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[CFDIFormaPagoDetalle_Combo_sp]");
                while (dr.Read())
                {
                    item = new ComboModel();
                    item.Id = !dr.IsDBNull(dr.GetOrdinal("id")) ? dr.GetString(dr.GetOrdinal("id")) : string.Empty;
                    item.Value = !dr.IsDBNull(dr.GetOrdinal("value")) ? dr.GetString(dr.GetOrdinal("value")) : string.Empty;
                    lista.Add(item);
                }
                dr.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}