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

        public List<ComboModel> ListaUnidadMedidaDetalle(AuxSQLModel oAuxSQLModel, string unidadMedidaBuscar)
        {
            try
            {
                List<ComboModel> lista = new List<ComboModel>();
                ComboModel item;
                SqlDataReader dr = null;
                object[] parametro = { unidadMedidaBuscar };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[CFDIClaveUnidadDetalle_Combo_sp_2]", parametro);
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

        public string DatatableIndexConceptos(AuxSQLModel oAuxSQLModel)
        {
            try
            {
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[CFDIDatosConceptos_Consulta_sp]");
                string datatable = SystemHelper.SystemHelper.SqlReaderToJson(dr);

                dr.Close();
                return datatable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Datatable_CFDIConceptos_get_ClaveUnidad(AuxSQLModel oAuxSQLModel, DataTableParameters oDataTableParameters)
        {
            try
            {
                SqlDataReader dr = null;
                object[] parametros = { oDataTableParameters.Draw, oDataTableParameters.Search.Value, oDataTableParameters.Length, oDataTableParameters.Start };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[spCSLDB_CFDIConceptos_get_ClaveUnidad]", parametros);
                string resultado = string.Empty;

                while (dr.Read())
                {
                    oAuxSQLModel.Mensaje = !dr.IsDBNull(dr.GetOrdinal("resultado")) ? dr.GetString(dr.GetOrdinal("resultado")) : string.Empty;
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Datatable_CFDIConceptos_get_ClaveProducto(AuxSQLModel oAuxSQLModel, DataTableParameters oDataTableParameters)
        {
            try
            {
                SqlDataReader dr = null;
                object[] parametros = { oDataTableParameters.Draw, oDataTableParameters.Search.Value, oDataTableParameters.Length, oDataTableParameters.Start };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[spCSLDB_CFDIConceptos_get_ClaveProducto]", parametros);
                string resultado = string.Empty;

                while (dr.Read())
                {
                    oAuxSQLModel.Mensaje = !dr.IsDBNull(dr.GetOrdinal("resultado")) ? dr.GetString(dr.GetOrdinal("resultado")) : string.Empty;
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Datatable_CFDIConceptos_get_TipoProducto(AuxSQLModel oAuxSQLModel, DataTableParameters oDataTableParameters)
        {
            try
            {
                SqlDataReader dr = null;
                object[] parametros = { oDataTableParameters.Draw, oDataTableParameters.Search.Value, oDataTableParameters.Length, oDataTableParameters.Start };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[spCSLDB_CFDIConceptos_get_TipoProducto]", parametros);
                string resultado = string.Empty;

                while (dr.Read())
                {
                    oAuxSQLModel.Mensaje = !dr.IsDBNull(dr.GetOrdinal("resultado")) ? dr.GetString(dr.GetOrdinal("resultado")) : string.Empty;
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Datatable_CFDIConceptos_get_ClaveDivision(AuxSQLModel oAuxSQLModel, DataTableParameters oDataTableParameters)
        {
            try
            {
                SqlDataReader dr = null;
                object[] parametros = { oDataTableParameters.Draw, oDataTableParameters.Search.Value, oDataTableParameters.Length, oDataTableParameters.Start };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[spCSLDB_CFDIConceptos_get_ClaveDivicion]", parametros);
                string resultado = string.Empty;

                while (dr.Read())
                {
                    oAuxSQLModel.Mensaje = !dr.IsDBNull(dr.GetOrdinal("resultado")) ? dr.GetString(dr.GetOrdinal("resultado")) : string.Empty;
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Datatable_CFDIConceptos_get_ClaveGrupo(AuxSQLModel oAuxSQLModel, DataTableParameters oDataTableParameters)
        {
            try
            {
                SqlDataReader dr = null;
                object[] parametros = { oDataTableParameters.Draw, oDataTableParameters.Search.Value, oDataTableParameters.Length, oDataTableParameters.Start };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[spCSLDB_CFDIConceptos_get_ClaveGrupo]", parametros);
                string resultado = string.Empty;

                while (dr.Read())
                {
                    oAuxSQLModel.Mensaje = !dr.IsDBNull(dr.GetOrdinal("resultado")) ? dr.GetString(dr.GetOrdinal("resultado")) : string.Empty;
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Datatable_CFDIConceptos_get_ClaveClase(AuxSQLModel oAuxSQLModel, DataTableParameters oDataTableParameters)
        {
            try
            {
                SqlDataReader dr = null;
                object[] parametros = { oDataTableParameters.Draw, oDataTableParameters.Search.Value, oDataTableParameters.Length, oDataTableParameters.Start };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[spCSLDB_CFDIConceptos_get_ClaveClase]", parametros);
                string resultado = string.Empty;

                while (dr.Read())
                {
                    oAuxSQLModel.Mensaje = !dr.IsDBNull(dr.GetOrdinal("resultado")) ? dr.GetString(dr.GetOrdinal("resultado")) : string.Empty;
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DtFactura_get_Facturas(AuxSQLModel oAuxSQLModel, DataTableParameters oDataTableParameters)
        {
            try
            {
                SqlDataReader dr = null;
                object[] parametros = { oDataTableParameters.Draw, oDataTableParameters.Search.Value, oDataTableParameters.Length, oDataTableParameters.Start };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[spCSLDB_Factura_get_Facturas]", parametros);
                string resultado = string.Empty;

                while (dr.Read())
                {
                    oAuxSQLModel.Mensaje = !dr.IsDBNull(dr.GetOrdinal("resultado")) ? dr.GetString(dr.GetOrdinal("resultado")) : string.Empty;
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}