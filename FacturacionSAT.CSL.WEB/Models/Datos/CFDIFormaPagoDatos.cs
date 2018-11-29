using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models.Datos
{
    public class CFDIFormaPagoDatos
    {       
        public List<CFDIFormaPago_AuryModels> ListaFP(AuxSQLModel oAuxSQLModel)
        {
            try
            {
                List<CFDIFormaPago_AuryModels> Lista = new List<CFDIFormaPago_AuryModels>();
                CFDIFormaPago_AuryModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[CFDIFormaPago_Consulta_sp]");
                while (dr.Read())
                {
                    item = new CFDIFormaPago_AuryModels();
                    item.ID_FormaPago = !dr.IsDBNull(dr.GetOrdinal("ID_FormaPago")) ? dr.GetString(dr.GetOrdinal("ID_FormaPago")) : string.Empty;
                    item.TipoPago = !dr.IsDBNull(dr.GetOrdinal("TipoPago")) ? dr.GetString(dr.GetOrdinal("TipoPago")) : string.Empty;
                    item.TipoDePago.Id_cfdiFormaPagoDetalle = !dr.IsDBNull(dr.GetOrdinal("ID_FormaPagoDetalle")) ? dr.GetString(dr.GetOrdinal("ID_FormaPagoDetalle")) : string.Empty;
                    item.TipoDePago.Descripcion = !dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? dr.GetString(dr.GetOrdinal("Descripcion")) : string.Empty;
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

        public CFDIFormaPago_AuryModels GetCFDIFPDitail(CFDIFormaPago_AuryModels datos)
        {
            try
            {
                object[] parametros = { datos.ID_FormaPago };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.Conexion, "[dbo].[CFDIFormaPago_GetDitail_sp]", parametros);
                while (dr.Read())
                {
                    datos.ID_FormaPago = !dr.IsDBNull(dr.GetOrdinal("ID_FormaPago")) ? dr.GetString(dr.GetOrdinal("ID_FormaPago")) : string.Empty;
                    datos.TipoPago = !dr.IsDBNull(dr.GetOrdinal("TipoPago")) ? dr.GetString(dr.GetOrdinal("TipoPago")) : string.Empty;
                    datos.TipoDePago.Id_cfdiFormaPagoDetalle = !dr.IsDBNull(dr.GetOrdinal("ID_FormaPagoDetalle")) ? dr.GetString(dr.GetOrdinal("ID_FormaPagoDetalle")) : string.Empty;
                    datos.TipoDePago.Descripcion = !dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? dr.GetString(dr.GetOrdinal("Descripcion")) : string.Empty;
                }
                dr.Close();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CFDIFormaPagoDetalleModels> ListaCFDI_CMB(CFDIFormaPago_AuryModels Datos)
        {
            try
            {
                CFDIFormaPagoDetalleModels Item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(Datos.Conexion, "[dbo].[CFDIFormaPagoDetalle_Combo_sp]");
                while (dr.Read())
                {
                    Item = new CFDIFormaPagoDetalleModels();
                    Item.Id_cfdiFormaPagoDetalle = !dr.IsDBNull(dr.GetOrdinal("id_cfdiFormaPagoDetalle")) ? dr.GetString(dr.GetOrdinal("id_cfdiFormaPagoDetalle")) : string.Empty;
                    Item.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                    Datos.ListaCFDIDetalleCMB.Add(Item);
                }
                dr.Close();
                return Datos.ListaCFDIDetalleCMB;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CFDIFormaPago_AuryModels UpdateCFDIFP(CFDIFormaPago_AuryModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.ID_FormaPago,
                    datos.TipoDePago.Id_cfdiFormaPagoDetalle, 
                    datos.Id_usuario 
                };
                object aux = SqlHelper.ExecuteScalar(datos.Conexion, "[dbo].[abc_CFDIFormaPago]", parametros);
                datos.ID_FormaPago = aux.ToString();
                if (!string.IsNullOrEmpty(datos.ID_FormaPago))
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
    }
}