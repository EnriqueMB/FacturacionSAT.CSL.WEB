
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
        public CFDIDatosConceptosModels ABCCFDIconcepto(CFDIDatosConceptosModels datos)
        {
            try
            {
                object[] parametros =
                {
                   datos.Opcion,datos.Id_cfdiDatosConceptos,datos.Descripcion,datos.Id_cfdiTipoProducto,datos.Id_cfdiDivision,datos.Id_cfdiGrupo,datos.Id_cfdiClase,datos.Id_cfdiClaveProdServDetalle,datos.Id_cfdiClaveUnidad,datos.Id_usuario
                    };
                object aux = SqlHelper.ExecuteScalar(datos.Conexion, "abc_CFDIDatosConceptos", parametros);
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