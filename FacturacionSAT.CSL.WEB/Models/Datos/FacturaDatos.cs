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
                object[] parametros = { codigoBarra, RFCReceptor, oAuxSQLModel.Id_usuario };
                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[spCSLDB_Factura_get_Generales]", parametros);
                while (dr.Read())
                {
                    oAuxSQLModel.Success = !dr.IsDBNull(dr.GetOrdinal("success")) ? dr.GetBoolean(dr.GetOrdinal("success")) : false;
                    oAuxSQLModel.Mensaje = !dr.IsDBNull(dr.GetOrdinal("mensaje")) ? dr.GetString(dr.GetOrdinal("mensaje")) : string.Empty;


                    if (oAuxSQLModel.Success)
                    {
                        item = new FacturacionViewModel();

                        item.Moneda = !dr.IsDBNull(dr.GetOrdinal("CFDI_moneda")) ? dr.GetString(dr.GetOrdinal("CFDI_moneda")) : string.Empty;
                        item.TotalDescuento = !dr.IsDBNull(dr.GetOrdinal("descuento_boleto")) ? dr.GetDecimal(dr.GetOrdinal("descuento_boleto")) : 0;
                        item.PorcentajeIVA = !dr.IsDBNull(dr.GetOrdinal("porcentajeIVA")) ? dr.GetDecimal(dr.GetOrdinal("porcentajeIVA")) : 0;
                        item.Subtotal = !dr.IsDBNull(dr.GetOrdinal("subtotal")) ? dr.GetDecimal(dr.GetOrdinal("subtotal")) : 0;
                        item.Total = !dr.IsDBNull(dr.GetOrdinal("total")) ? dr.GetDecimal(dr.GetOrdinal("total")) : 0;

                        item.TotalDescuento = Math.Round(item.TotalDescuento, 2);
                        item.Subtotal = Math.Round(item.Subtotal, 2);
                        item.Total = Math.Round(item.Total, 2);

                        item.Folio = !dr.IsDBNull(dr.GetOrdinal("folio")) ? dr.GetString(dr.GetOrdinal("folio")) : string.Empty;
                        item.FormaDePago = !dr.IsDBNull(dr.GetOrdinal("CFDI_formaPago")) ? dr.GetString(dr.GetOrdinal("CFDI_formaPago")) : string.Empty;
                        item.TipoComprobante = !dr.IsDBNull(dr.GetOrdinal("CFDI_tipoComprobante")) ? dr.GetString(dr.GetOrdinal("CFDI_tipoComprobante")) : string.Empty;
                        item.LugarExpedicion = !dr.IsDBNull(dr.GetOrdinal("CFDI_LugarExpedicion")) ? dr.GetString(dr.GetOrdinal("CFDI_LugarExpedicion")) : string.Empty;
                        item.Version = !dr.IsDBNull(dr.GetOrdinal("CFDI_version")) ? dr.GetString(dr.GetOrdinal("CFDI_version")) : string.Empty;
                        item.Moneda_Generico = !dr.IsDBNull(dr.GetOrdinal("CFDI_moneda_generico")) ? dr.GetString(dr.GetOrdinal("CFDI_moneda_generico")) : string.Empty;
                        item.TipoComprobante_Generico = !dr.IsDBNull(dr.GetOrdinal("CFDI_tipoComprobante_generico")) ? dr.GetString(dr.GetOrdinal("CFDI_tipoComprobante_generico")) : string.Empty;
                        item.FormaDePago_Generico = !dr.IsDBNull(dr.GetOrdinal("CFDI_FormaPago_generico")) ? dr.GetString(dr.GetOrdinal("CFDI_FormaPago_generico")) : string.Empty;
                        item.RegimenFiscal_Generico = !dr.IsDBNull(dr.GetOrdinal("regimenFiscal_Generico")) ? dr.GetString(dr.GetOrdinal("regimenFiscal_Generico")) : string.Empty;
                        item.NombreEmisor = !dr.IsDBNull(dr.GetOrdinal("nombreEmisor")) ? dr.GetString(dr.GetOrdinal("nombreEmisor")) : string.Empty;
                        item.RFCEmisor = !dr.IsDBNull(dr.GetOrdinal("rfcEmisor")) ? dr.GetString(dr.GetOrdinal("rfcEmisor")) : string.Empty;
                        item.RegimenFiscal = !dr.IsDBNull(dr.GetOrdinal("regimenFiscal")) ? dr.GetString(dr.GetOrdinal("regimenFiscal")) : string.Empty;
                        item.RazonSocial = !dr.IsDBNull(dr.GetOrdinal("razonSocial")) ? dr.GetString(dr.GetOrdinal("razonSocial")) : string.Empty;
                        item.RFCReceptor = !dr.IsDBNull(dr.GetOrdinal("rfcReceptor")) ? dr.GetString(dr.GetOrdinal("rfcReceptor")) : RFCReceptor;
                        item.EmailReceptor = !dr.IsDBNull(dr.GetOrdinal("emailReceptor")) ? dr.GetString(dr.GetOrdinal("emailReceptor")) : string.Empty;

                        List<Concepto> ListaConceptos = new List<Concepto>();
                        Concepto itemConcepto = new Concepto();
                        Impuesto Impuesto = new Impuesto();
                        List<Impuesto> ListaImpuesto = new List<Impuesto>();

                        itemConcepto.Cantidad = !dr.IsDBNull(dr.GetOrdinal("CFDI_Concepto_Cantidad")) ? dr.GetDecimal(dr.GetOrdinal("CFDI_Concepto_Cantidad")) : 0;
                        itemConcepto.ClaveProducto = !dr.IsDBNull(dr.GetOrdinal("CFDI_Concepto_ClaveProdServ")) ? dr.GetString(dr.GetOrdinal("CFDI_Concepto_ClaveProdServ")) : string.Empty;
                        itemConcepto.ClaveProducto_Generico = !dr.IsDBNull(dr.GetOrdinal("CFDI_Concepto_ClaveProdServ_generico")) ? dr.GetString(dr.GetOrdinal("CFDI_Concepto_ClaveProdServ_generico")) : string.Empty;
                        itemConcepto.ClaveUnidad = !dr.IsDBNull(dr.GetOrdinal("CFDI_Concepto_ClaveUnidad")) ? dr.GetString(dr.GetOrdinal("CFDI_Concepto_ClaveUnidad")) : string.Empty;
                        itemConcepto.ClaveUnidad_Generico = !dr.IsDBNull(dr.GetOrdinal("CFDI_Concepto_ClaveUnidad_generico")) ? dr.GetString(dr.GetOrdinal("CFDI_Concepto_ClaveUnidad_generico")) : string.Empty;
                        itemConcepto.Descripcion = !dr.IsDBNull(dr.GetOrdinal("CFDI_Concepto_Descripcion")) ? dr.GetString(dr.GetOrdinal("CFDI_Concepto_Descripcion")) : string.Empty;
                        itemConcepto.Descuento = !dr.IsDBNull(dr.GetOrdinal("CFDI_Concepto_Descuento")) ? dr.GetDecimal(dr.GetOrdinal("CFDI_Concepto_Descuento")) : 0;
                        itemConcepto.PrecioUnitario = !dr.IsDBNull(dr.GetOrdinal("CFDI_Concepto_PrecioUnitario")) ? dr.GetDecimal(dr.GetOrdinal("CFDI_Concepto_PrecioUnitario")) : 0;
                        Impuesto.Nombre = !dr.IsDBNull(dr.GetOrdinal("CFDI_Impuesto_Impuesto_generico")) ? dr.GetString(dr.GetOrdinal("CFDI_Impuesto_Impuesto_generico")) : string.Empty;
                        Impuesto.Clave_Impuesto = !dr.IsDBNull(dr.GetOrdinal("CFDI_Impuesto_Impuesto")) ? dr.GetString(dr.GetOrdinal("CFDI_Impuesto_Impuesto")) : string.Empty; 
                        Impuesto.Base = !dr.IsDBNull(dr.GetOrdinal("CFDI_Impuesto_Base")) ? dr.GetDecimal(dr.GetOrdinal("CFDI_Impuesto_Base")) : 0;
                        Impuesto.Importe = !dr.IsDBNull(dr.GetOrdinal("CFDI_Impuesto_Importe")) ? dr.GetDecimal(dr.GetOrdinal("CFDI_Impuesto_Importe")) : 0;
                        Impuesto.TasaOCuota = !dr.IsDBNull(dr.GetOrdinal("CFDI_Impuesto_TasaOCuota")) ? dr.GetDecimal(dr.GetOrdinal("CFDI_Impuesto_TasaOCuota")) : 0;
                        Impuesto.TipoFactor = !dr.IsDBNull(dr.GetOrdinal("CFDI_Impuesto_TipoFactor")) ? dr.GetString(dr.GetOrdinal("CFDI_Impuesto_TipoFactor")) : string.Empty;

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
                        Impuesto.TasaOCuota = !dr.IsDBNull(dr.GetOrdinal("porcentaje_iva")) ? dr.GetDecimal(dr.GetOrdinal("porcentaje_iva")) : 0;

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

        public void Factura_Save_Factura(AuxSQLModel oAuxSQLModel, string pathXML, FacturacionViewModel oFactura)
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

                        string xmlString = System.IO.File.ReadAllText(pathXML);
                        cmd.Parameters.AddWithValue("@xmlFacturaSAT", xmlString);
                        cmd.Parameters.Add("@rfcEmisor", SqlDbType.VarChar).Value = oFactura.RFCEmisor;
                        cmd.Parameters.Add("@rfcReceptor", SqlDbType.VarChar).Value = oFactura.RFCReceptor;
                        cmd.Parameters.Add("@codigoBarra", SqlDbType.VarChar).Value = oFactura.CodigoBarraBoleto;
                        cmd.Parameters.Add("@totalFactura", SqlDbType.Money).Value = oFactura.Total;
                        cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = oAuxSQLModel.Id_usuario;
                        cmd.Parameters.Add("@emailReceptor", SqlDbType.NVarChar).Value = oFactura.EmailReceptor;
                        cmd.Parameters.Add("@emailEmisor", SqlDbType.NVarChar).Value = oFactura.EmailEmisor;



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