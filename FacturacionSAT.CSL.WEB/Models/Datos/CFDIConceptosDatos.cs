
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;


namespace FacturacionSAT.CSL.WEB.Models.Datos
{
    public class CFDIConceptosDatos
    {
        public List<CFDIDatosConceptosModels> CFDIConceptos(AuxSQLModel oAuxSQLModel)
        {
            try
            {
                List<CFDIDatosConceptosModels> Lista = new List<CFDIDatosConceptosModels>();

                CFDIDatosConceptosModels Item;

                SqlDataReader dr = null;

                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "[dbo].[CFDIDatosConceptos_Consulta_sp]");
                while (dr.Read())
                {
                    Item = new CFDIDatosConceptosModels();
                    Item.Id_cfdiDatosConceptos = !dr.IsDBNull(dr.GetOrdinal("id_cfdiDatosConceptos")) ? dr.GetString(dr.GetOrdinal("id_cfdiDatosConceptos")) : string.Empty;
                    Item.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                    Item.CFDI_TipoProducto.TipoProducto = !dr.IsDBNull(dr.GetOrdinal("tipoProducto")) ? dr.GetString(dr.GetOrdinal("tipoProducto")) : string.Empty;
                    Item.divicion.Division = !dr.IsDBNull(dr.GetOrdinal("division")) ? dr.GetString(dr.GetOrdinal("division")) : string.Empty;
                    Item.grupo.Grupo = !dr.IsDBNull(dr.GetOrdinal("grupo")) ? dr.GetString(dr.GetOrdinal("grupo")) : string.Empty;
                    Item.clase.clase = !dr.IsDBNull(dr.GetOrdinal("clase")) ? dr.GetString(dr.GetOrdinal("clase")) : string.Empty;
                    Item.CFDI_Claveproducto.Descripcion = !dr.IsDBNull(dr.GetOrdinal("claveProducto")) ? dr.GetString(dr.GetOrdinal("claveProducto")) : string.Empty;
                    Item.servicioDetalle.Nombre = !dr.IsDBNull(dr.GetOrdinal("unidad")) ? dr.GetString(dr.GetOrdinal("unidad")) : string.Empty;
                    Item.Predeterminado = !dr.IsDBNull(dr.GetOrdinal("predeterminado")) ? dr.GetBoolean(dr.GetOrdinal("predeterminado")) : false;
                    //Item.Id_cfdiClaveUnidad = !dr.IsDBNull(dr.GetOrdinal("id_cfdiClaveUnidad")) ? dr.GetString(dr.GetOrdinal("id_cfdiClaveUnidad")) : string.Empty;
                    //Item.Id_usuario = !dr.IsDBNull(dr.GetOrdinal("id_usuario")) ? dr.GetString(dr.GetOrdinal("id_usuario")) : string.Empty;

                    Lista.Add(Item);

                }

                dr.Close();
                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CFDIDatosConceptosModels ABCCFDIconceptos(CFDIDatosConceptosModels datos)
        {
            try
            {
                object[] parametros =
                {
                  datos.Opcion, datos.Id_cfdiDatosConceptos, datos.Descripcion, datos.CFDI_TipoProducto.Id_cfdiTipoProducto,
                  datos.CFDI_ClaveDivision.Id_cfdiDivision, datos.CFDI_Grupo.Id_cfdiGrupo, datos.CFDI_Clase.Id_CfdiClase, datos.CFDI_Claveproducto.Id_cfdiClaveProdServDetalle,
                  datos.CFDI_ClaveUnidad.Id_cfdiClaveUnidadDetalle, datos.Predeterminado, datos.Id_usuario
                };
                object aux = SqlHelper.ExecuteScalar(datos.Conexion, "dbo.abc_CFDIDatosConceptos", parametros);
                datos.Id_cfdiDatosConceptos = aux.ToString();

                if (!string.IsNullOrEmpty(datos.Id_cfdiDatosConceptos))
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

        public CFDIDatosConceptosModels GetCFDIConceptosEdit(CFDIDatosConceptosModels datos)
        {
            try
            {
                object[] parametros = { datos.Id_cfdiDatosConceptos };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.Conexion, "[dbo].[CFDIDatosConceptos_ConsultaDetalle_sp]", parametros);
                while (dr.Read())
                {
                    datos.Id_cfdiDatosConceptos = !dr.IsDBNull(dr.GetOrdinal("id_cfdiDatosConceptos")) ? dr.GetString(dr.GetOrdinal("id_cfdiDatosConceptos")) : string.Empty;
                    datos.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                    datos.CFDI_TipoProducto.Id_cfdiTipoProducto = !dr.IsDBNull(dr.GetOrdinal("tipoProducto")) ? dr.GetString(dr.GetOrdinal("tipoProducto")) : string.Empty;
                    datos.CFDI_TipoProducto.TipoProducto = !dr.IsDBNull(dr.GetOrdinal("ClavetipoProducto")) ? dr.GetString(dr.GetOrdinal("ClavetipoProducto")) : string.Empty; 
                    datos.CFDI_ClaveDivision.Id_cfdiDivision = !dr.IsDBNull(dr.GetOrdinal("division")) ? dr.GetString(dr.GetOrdinal("division")) : string.Empty;
                    datos.CFDI_ClaveDivision.Division = !dr.IsDBNull(dr.GetOrdinal("ClavDivision")) ? dr.GetString(dr.GetOrdinal("ClavDivision")): string.Empty;
                    datos.CFDI_Grupo.Id_cfdiGrupo = !dr.IsDBNull(dr.GetOrdinal("grupo")) ? dr.GetString(dr.GetOrdinal("grupo")) : string.Empty;
                    datos.CFDI_Grupo.Grupo = !dr.IsDBNull(dr.GetOrdinal("ClavGrupo")) ? dr.GetString(dr.GetOrdinal("ClavGrupo")) : string.Empty;
                    datos.CFDI_Clase.Id_CfdiClase = !dr.IsDBNull(dr.GetOrdinal("clase")) ? dr.GetString(dr.GetOrdinal("clase")) : string.Empty;
                    datos.CFDI_Clase.clase = !dr.IsDBNull(dr.GetOrdinal("ClavClase")) ? dr.GetString(dr.GetOrdinal("ClavClase")) : string.Empty;
                    datos.CFDI_ClaveUnidad.Id_cfdiClaveUnidadDetalle = !dr.IsDBNull(dr.GetOrdinal("unidad")) ? dr.GetString(dr.GetOrdinal("unidad")) : string.Empty;
                    datos.CFDI_ClaveUnidad.Nombre = !dr.IsDBNull(dr.GetOrdinal("nombreClaveUnidad")) ? dr.GetString(dr.GetOrdinal("nombreClaveUnidad")) : string.Empty; 
                    datos.CFDI_Claveproducto.Id_cfdiClaveProdServDetalle = !dr.IsDBNull(dr.GetOrdinal("claveProducto")) ? dr.GetString(dr.GetOrdinal("claveProducto")) : string.Empty;
                    datos.CFDI_Claveproducto.Descripcion = !dr.IsDBNull(dr.GetOrdinal("claveProduct")) ? dr.GetString(dr.GetOrdinal("claveProduct")) : string.Empty;
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