using FacturacionSAT.CSL.WEB.Models.ViewModel;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Xml;
using static FacturacionSAT.CSL.WEB.Models.ViewModel.FacturacionViewModel;

namespace FacturacionSAT.CSL.WEB.Models.Datos
{
    public class FacturaDatos
    {
        public FacturacionViewModel Factura_get_Generales_ADD(AuxSQLModel oAuxSQLModel, string codigoBarra, string RFCReceptor)
        {
            try
            {
                FacturacionViewModel item = new FacturacionViewModel();
                SqlDataReader dr = null;
                object[] parametros = { codigoBarra, RFCReceptor };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[spCSLDB_Factura_get_Generales]", parametros);
                while (dr.Read())
                {
                    oAuxSQLModel.Success = !dr.IsDBNull(dr.GetOrdinal("success")) ? dr.GetBoolean(dr.GetOrdinal("success")) : false;
                    oAuxSQLModel.Mensaje = !dr.IsDBNull(dr.GetOrdinal("mensaje")) ? dr.GetString(dr.GetOrdinal("mensaje")) : string.Empty;


                    if (oAuxSQLModel.Success)
                    {
                        item = new FacturacionViewModel();
                        //generales
                        item.Total = !dr.IsDBNull(dr.GetOrdinal("costoConIVA")) ? dr.GetDecimal(dr.GetOrdinal("costoConIVA")) : 0; 
                        item.Moneda = !dr.IsDBNull(dr.GetOrdinal("CFDI_moneda")) ? dr.GetString(dr.GetOrdinal("CFDI_moneda")) : string.Empty;
                        item.TotalDescuento = !dr.IsDBNull(dr.GetOrdinal("descuento")) ? dr.GetDecimal(dr.GetOrdinal("descuento")) : 0;
                        item.Subtotal = !dr.IsDBNull(dr.GetOrdinal("subtotal")) ? dr.GetDecimal(dr.GetOrdinal("subtotal")) : 0;
                        item.Folio = !dr.IsDBNull(dr.GetOrdinal("folio")) ? dr.GetString(dr.GetOrdinal("folio")) : string.Empty;
                        item.FormaDePago = !dr.IsDBNull(dr.GetOrdinal("CFDI_formaPago")) ? dr.GetString(dr.GetOrdinal("CFDI_formaPago")) : string.Empty;
                        item.TipoComprobante = !dr.IsDBNull(dr.GetOrdinal("CFDI_tipoComprobante")) ? dr.GetString(dr.GetOrdinal("CFDI_tipoComprobante")) : string.Empty;
                        item.LugarExpedicion = !dr.IsDBNull(dr.GetOrdinal("CFDI_LugarExpedicion")) ? dr.GetString(dr.GetOrdinal("CFDI_LugarExpedicion")) : string.Empty;
                        //emisor
                        item.NombreEmisor = !dr.IsDBNull(dr.GetOrdinal("nombreEmisor")) ? dr.GetString(dr.GetOrdinal("nombreEmisor")) : string.Empty;
                        item.RFCEmisor = !dr.IsDBNull(dr.GetOrdinal("rfcEmisor")) ? dr.GetString(dr.GetOrdinal("rfcEmisor")) : string.Empty;
                        item.RegimenFiscal = !dr.IsDBNull(dr.GetOrdinal("regimenFiscal")) ? dr.GetString(dr.GetOrdinal("regimenFiscal")) : string.Empty;
                        //receptor
                        item.RazonSocial = !dr.IsDBNull(dr.GetOrdinal("razonSocial")) ? dr.GetString(dr.GetOrdinal("razonSocial")) : string.Empty;
                        item.RFCReceptor = !dr.IsDBNull(dr.GetOrdinal("rfcReceptor")) ? dr.GetString(dr.GetOrdinal("rfcReceptor")) : RFCReceptor;

                        List<Concepto> ListaConceptos = new List<Concepto>();
                        Concepto itemConcepto = new Concepto();
                        Impuesto Impuesto = new Impuesto();
                        List<Impuesto> ListaImpuesto = new List<Impuesto>();

                        itemConcepto.Cantidad = !dr.IsDBNull(dr.GetOrdinal("cantidadConceptos")) ? dr.GetDecimal(dr.GetOrdinal("cantidadConceptos")) : 0;
                        itemConcepto.ClaveProducto = !dr.IsDBNull(dr.GetOrdinal("CFDI_ClaveProdServ")) ? dr.GetString(dr.GetOrdinal("CFDI_ClaveProdServ")) : string.Empty;
                        itemConcepto.ClaveUnidad = !dr.IsDBNull(dr.GetOrdinal("CFDI_ClaveUnidad")) ? dr.GetString(dr.GetOrdinal("CFDI_ClaveUnidad")) : string.Empty;
                        itemConcepto.Descripcion = !dr.IsDBNull(dr.GetOrdinal("CFDI_Descripcion")) ? dr.GetString(dr.GetOrdinal("CFDI_Descripcion")) : string.Empty;
                        itemConcepto.Descuento = !dr.IsDBNull(dr.GetOrdinal("CFDI_DescuentoConcepto")) ? dr.GetDecimal(dr.GetOrdinal("CFDI_DescuentoConcepto")) : 0;
                        itemConcepto.PrecioUnitario = !dr.IsDBNull(dr.GetOrdinal("CFDI_ValorUnitario")) ? dr.GetDecimal(dr.GetOrdinal("CFDI_ValorUnitario")) : 0;

                        Impuesto.Nombre = !dr.IsDBNull(dr.GetOrdinal("CFDI_NombreImpuesto")) ? dr.GetString(dr.GetOrdinal("CFDI_NombreImpuesto")) : string.Empty;
                        Impuesto.Importe = !dr.IsDBNull(dr.GetOrdinal("impuestoIVA")) ? dr.GetDecimal(dr.GetOrdinal("impuestoIVA")) : 0;
                        Impuesto.Tasa = (!dr.IsDBNull(dr.GetOrdinal("porcentajeIVA")) ? dr.GetDecimal(dr.GetOrdinal("porcentajeIVA")) : 0) / 1000000;
                        Impuesto.Tipo = !dr.IsDBNull(dr.GetOrdinal("CFDI_TipoImpuesto")) ? dr.GetString(dr.GetOrdinal("CFDI_TipoImpuesto")) : string.Empty;

                        itemConcepto.PrecioUnitario = !dr.IsDBNull(dr.GetOrdinal("CFDI_ValorUnitario")) ? dr.GetDecimal(dr.GetOrdinal("CFDI_ValorUnitario")) : 0;

                        ListaImpuesto.Add(Impuesto);

                        itemConcepto.Impuestos = ListaImpuesto;

                        ListaConceptos.Add(itemConcepto);

                        item.Conceptos = ListaConceptos;
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
    
        public List<Concepto> Factura_get_Conceptos(string codigoBarra, AuxSQLModel oAuxSQLModel)
        {
            try
            {
                List<Concepto> Lista = new List<Concepto>();
                Concepto item = new Concepto();
                SqlDataReader dr = null;
                object[] parametros = { codigoBarra };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[spCSLDB_Factura_get_Conceptos]", parametros);

                while (dr.Read())
                {
                    oAuxSQLModel.Success = !dr.IsDBNull(dr.GetOrdinal("success")) ? dr.GetBoolean(dr.GetOrdinal("success")) : false;
                    oAuxSQLModel.Mensaje = !dr.IsDBNull(dr.GetOrdinal("mensaje")) ? dr.GetString(dr.GetOrdinal("mensaje")) : string.Empty;

                    if (oAuxSQLModel.Success)
                    {
                        item = new Concepto();
                        Impuesto Impuesto = new Impuesto();
                        List<Impuesto> ListaImpuesto = new List<Impuesto>();

                        item.Cantidad = !dr.IsDBNull(dr.GetOrdinal("cantidad_venta")) ? dr.GetDecimal(dr.GetOrdinal("cantidad_venta")) : 0;
                        item.PrecioUnitario = !dr.IsDBNull(dr.GetOrdinal("precio")) ? dr.GetDecimal(dr.GetOrdinal("precio")) : 0;
                        item.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcionAURY")) ? dr.GetString(dr.GetOrdinal("descripcionAURY")) : string.Empty;
                        item.ClaveProducto = !dr.IsDBNull(dr.GetOrdinal("c_ClaveProdServ")) ? dr.GetString(dr.GetOrdinal("c_ClaveProdServ")) : string.Empty;
                        item.ClaveUnidad = !dr.IsDBNull(dr.GetOrdinal("c_ClaveUnidad")) ? dr.GetString(dr.GetOrdinal("c_ClaveUnidad")) : string.Empty;
                        decimal totalProdServ = !dr.IsDBNull(dr.GetOrdinal("precio")) ? dr.GetDecimal(dr.GetOrdinal("precio")) : 0; 

                        Impuesto.Nombre = !dr.IsDBNull(dr.GetOrdinal("nombre_cve_impuesto_iva")) ? dr.GetString(dr.GetOrdinal("nombre_cve_impuesto_iva")) : string.Empty;
                        Impuesto.Importe = !dr.IsDBNull(dr.GetOrdinal("iva")) ? dr.GetDecimal(dr.GetOrdinal("iva")) : 0;
                        Impuesto.Tasa = !dr.IsDBNull(dr.GetOrdinal("porcentaje_iva")) ? dr.GetDecimal(dr.GetOrdinal("porcentaje_iva")) : 0;

                        item.PrecioUnitario = totalProdServ - Impuesto.Importe;

                        ListaImpuesto.Add(Impuesto);

                        item.Impuestos = ListaImpuesto;

                        Lista.Add(item);
                    }
                }
                dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Factura_Save_Factura(AuxSQLModel oAuxSQLModel, string pathXML)
        {
            try
            {
                // construct sql connection and sql command objects.
                using (SqlConnection sqlcon = new SqlConnection(oAuxSQLModel.Conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[spCSLDB_Factura_Save_FacturaXML]", sqlcon))
                    {
                        //parametros de entrada
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlXml ParametroSQLXML = new SqlXml(new XmlTextReader(pathXML));
                        cmd.Parameters.AddWithValue("@xmlFacturaSAT" , ParametroSQLXML);
                        
                        //parametros de salida
                        cmd.Parameters.Add(new SqlParameter("@mensaje", SqlDbType.NVarChar, -1)); //-1 para tipo MAX
                        cmd.Parameters["@mensaje"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@success", SqlDbType.Bit));
                        cmd.Parameters["@success"].Direction = ParameterDirection.Output;
                        // execute
                        sqlcon.Open();

                        cmd.ExecuteNonQuery();
                        oAuxSQLModel.Mensaje = cmd.Parameters["@mensaje"].Value.ToString();
                        if (bool.TryParse(cmd.Parameters["@success"].Value.ToString(), out bool success))
                        {
                            oAuxSQLModel.Success = success;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}