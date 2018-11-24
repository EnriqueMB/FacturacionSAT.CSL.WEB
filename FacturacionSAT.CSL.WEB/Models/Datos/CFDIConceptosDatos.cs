
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

                dr = SqlHelper.ExecuteReader(oAuxSQLModel.Conexion, "CFDIDatosConceptos_Consulta_sp");
                while (dr.Read())
                {
                    Item = new CFDIDatosConceptosModels();

                    Item.Id_cfdiDatosConceptos = !dr.IsDBNull(dr.GetOrdinal("id_cfdiDatosConceptos")) ? dr.GetString(dr.GetOrdinal("id_cfdiDatosConceptos")) : string.Empty;
                    Item.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                    Item.Id_cfdiTipoProducto = !dr.IsDBNull(dr.GetOrdinal("id_cfdiTipoProducto")) ? dr.GetString(dr.GetOrdinal("id_cfdiTipoProducto")) : string.Empty;
                    Item.Id_cfdiDivision = !dr.IsDBNull(dr.GetOrdinal("id_cfdiDivision")) ? dr.GetString(dr.GetOrdinal("id_cfdiDivision")) : string.Empty;
                    Item.Id_cfdiGrupo = !dr.IsDBNull(dr.GetOrdinal("id_cfdiGrupo")) ? dr.GetString(dr.GetOrdinal("id_cfdiGrupo")) : string.Empty;
                    Item.Id_cfdiClase = !dr.IsDBNull(dr.GetOrdinal("id_cfdiClase")) ? dr.GetString(dr.GetOrdinal("id_cfdiClase")) : string.Empty;
                    Item.Id_cfdiClaveProdServDetalle = !dr.IsDBNull(dr.GetOrdinal("id_cfdiClaveProdServDetalle")) ? dr.GetString(dr.GetOrdinal("id_cfdiClaveProdServDetalle")) : string.Empty;
                    Item.Id_cfdiClaveUnidad = !dr.IsDBNull(dr.GetOrdinal("id_cfdiClaveUnidad")) ? dr.GetString(dr.GetOrdinal("id_cfdiClaveUnidad")) : string.Empty;
                    Item.Id_usuario = !dr.IsDBNull(dr.GetOrdinal("id_usuario")) ? dr.GetString(dr.GetOrdinal("id_usuario")) : string.Empty;

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

    }
}