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
                    item.Id = !dr.IsDBNull(dr.GetOrdinal("id_cfdiFormaPagoDetalle")) ? dr.GetString(dr.GetOrdinal("id_cfdiFormaPagoDetalle")) : string.Empty;
                    item.Value = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
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

        //internal List<CFDIConceptosTipoProductoModels> ListaTipoProducto(object oAuxSQLModel)
        //{
        //    throw new NotImplementedException();
        //}

        public List<ComboModel> ListaMetodoPagoDetalle(AuxSQLModel oAuxSQLModel)
        {
            try
            {
                List<ComboModel> lista = new List<ComboModel>();
                ComboModel item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[CFDIMetodoPagoDetalle_Combo_sp]");
                while (dr.Read())
                {
                    item = new ComboModel();
                    item.Id = !dr.IsDBNull(dr.GetOrdinal("id_cfdiMetodoPagoDetalle")) ? dr.GetString(dr.GetOrdinal("id_cfdiMetodoPagoDetalle")) : string.Empty;
                    item.Value = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
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

        public List<ComboModel> ListaUsoCFDIDetalle(AuxSQLModel oAuxSQLModel, string id_cfdiTipoPersona)
        {
            try
            {
                List<ComboModel> lista = new List<ComboModel>();
                ComboModel item;
                SqlDataReader dr = null;
                object[] parametro = { id_cfdiTipoPersona };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[CFDIUsoCFDIDetalle_Combo_sp]", parametro);
                while (dr.Read())
                {
                    item = new ComboModel();
                    item.Id = !dr.IsDBNull(dr.GetOrdinal("id_cfdiUsoCFDIDetalle")) ? dr.GetString(dr.GetOrdinal("id_cfdiUsoCFDIDetalle")) : string.Empty;
                    item.Value = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
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

        public List<ComboModel> ListaMonedaDetalle(AuxSQLModel oAuxSQLModel)
        {
            try
            {
                List<ComboModel> lista = new List<ComboModel>();
                ComboModel item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[CFDIMonedaDetalle_Combo_sp]");
                while (dr.Read())
                {
                    item = new ComboModel();
                    item.Id = !dr.IsDBNull(dr.GetOrdinal("id")) ? dr.GetString(dr.GetOrdinal("id")) : string.Empty;
                    item.Value = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
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

        public List<CFDIConceptosTipoProductoModels> ListaTipoProducto(CFDIDatosConceptosModels datos)
        {
            try
            {
                List<CFDIConceptosTipoProductoModels> lista = new List<CFDIConceptosTipoProductoModels>();
                CFDIConceptosTipoProductoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.Conexion, "[dbo].[CFDIDatosConceptosTipoProduc_Combo_sp]");
                while (dr.Read())
                {
                    item = new CFDIConceptosTipoProductoModels();
                    item.Id_cfdiTipoProducto = !dr.IsDBNull(dr.GetOrdinal("id_cfdiTipoProducto")) ? dr.GetString(dr.GetOrdinal("id_cfdiTipoProducto")) : string.Empty;
                    item.TipoProducto = !dr.IsDBNull(dr.GetOrdinal("tipoProducto")) ? dr.GetString(dr.GetOrdinal("tipoProducto")) : string.Empty;
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
        public List<CFDIConceptoDivicionModels> ListaDivicionConcepto(CFDIDatosConceptosModels datos)
        {
            try
            {
                List<CFDIConceptoDivicionModels> lista = new List<CFDIConceptoDivicionModels>();
                CFDIConceptoDivicionModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.Conexion, "[dbo].[CFDIDatosConceptosDivicion_Combo_sp]");
                while (dr.Read())
                {
                    item = new CFDIConceptoDivicionModels();
                    item.Id_cfdiDivision = !dr.IsDBNull(dr.GetOrdinal("id_cfdiDivision")) ? dr.GetString(dr.GetOrdinal("id_cfdiDivision")) : string.Empty;
                    item.Division = !dr.IsDBNull(dr.GetOrdinal("division")) ? dr.GetString(dr.GetOrdinal("division")) : string.Empty;
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