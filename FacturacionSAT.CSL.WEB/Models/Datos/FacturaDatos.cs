using FacturacionSAT.CSL.WEB.Models.ViewModel;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models.Datos
{
    public class FacturaDatos
    {
        public FacturacionViewModel Factura_get_Generales_ADD(AuxSQLModel oAuxSQLModel, string codigoBarra, string RFCReceptor, string Id_emisor = null)
        {
            try
            {
                FacturacionViewModel item = new FacturacionViewModel();
                SqlDataReader dr = null;
                object[] parametros = { codigoBarra, RFCReceptor, Id_emisor };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[spCSLDB_Factura_get_Generales]");
                while (dr.Read())
                {
                    oAuxSQLModel.Success = !dr.IsDBNull(dr.GetOrdinal("id")) ? dr.GetBoolean(dr.GetOrdinal("id")) : false;
                    oAuxSQLModel.Mensaje = !dr.IsDBNull(dr.GetOrdinal("id")) ? dr.GetString(dr.GetOrdinal("id")) : string.Empty;
                    
                    if (oAuxSQLModel.Success)
                    {
                        item = new FacturacionViewModel();
                        //emisor
                        item.NombreEmisor = !dr.IsDBNull(dr.GetOrdinal("nombreEmisor")) ? dr.GetString(dr.GetOrdinal("nombreEmisor")) : string.Empty;
                        item.RFCEmisor = !dr.IsDBNull(dr.GetOrdinal("rfcEmisor")) ? dr.GetString(dr.GetOrdinal("rfcEmisor")) : string.Empty;
                        item.RegimenFiscal = !dr.IsDBNull(dr.GetOrdinal("regimenFiscal")) ? dr.GetString(dr.GetOrdinal("regimenFiscal")) : string.Empty;
                        //receptor
                        item.RazonSocial = !dr.IsDBNull(dr.GetOrdinal("razonSocial")) ? dr.GetString(dr.GetOrdinal("razonSocial")) : string.Empty;
                        item.RFCReceptor = !dr.IsDBNull(dr.GetOrdinal("rfcReceptor")) ? dr.GetString(dr.GetOrdinal("rfcReceptor")) : RFCReceptor;
                    }
                }
                dr.Close();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}