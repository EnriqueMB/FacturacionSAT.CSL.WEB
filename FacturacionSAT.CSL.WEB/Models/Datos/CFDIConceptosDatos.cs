
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
                    Item.tipoProducto.TipoProducto = !dr.IsDBNull(dr.GetOrdinal("tipoProducto")) ? dr.GetString(dr.GetOrdinal("tipoProducto")) : string.Empty;
                    Item.divicion.Division = !dr.IsDBNull(dr.GetOrdinal("division")) ? dr.GetString(dr.GetOrdinal("division")) : string.Empty;
                    Item.grupo.Grupo = !dr.IsDBNull(dr.GetOrdinal("grupo")) ? dr.GetString(dr.GetOrdinal("grupo")) : string.Empty;
                    Item.clase.clase = !dr.IsDBNull(dr.GetOrdinal("clase")) ? dr.GetString(dr.GetOrdinal("clase")) : string.Empty;
                    Item.servicioDetalle.Nombre = !dr.IsDBNull(dr.GetOrdinal("unidad")) ? dr.GetString(dr.GetOrdinal("unidad")) : string.Empty;
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
                  datos.Opcion,datos.Id_cfdiDatosConceptos,datos.Descripcion,datos.Id_cfdiTipoProducto,
                  datos.Id_cfdiDivision,datos.Id_cfdiGrupo,datos.Id_cfdiClase,datos.Id_cfdiClaveProdServDetalle,
                  datos.Id_cfdiClaveUnidad,datos.Id_usuario
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

    }
}