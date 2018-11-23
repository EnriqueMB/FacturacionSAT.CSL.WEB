using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models.Datos
{
    public class JsonDatos
    {
        public List<ComboModel> ListaFormaPagoDetalle(AuxSQLModel oAuxSQLModel, string prodServBuscar)
        {
            try
            {
                List<ComboModel> lista = new List<ComboModel>();
                ComboModel item;
                SqlDataReader dr = null;
                object[] parametro = { prodServBuscar };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[CFDIClaveProdServDetalle_Combo_sp_2]", parametro);
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
        // 
    }
}