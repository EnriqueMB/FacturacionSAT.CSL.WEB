using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models.Datos
{
    public class CFDIDatosEmisorDatos
    {
        public CFDIDatosEmisor AbcDatosEmisor(CFDIDatosEmisor Datos)
        {
            try
            {
                object[] Parametros = {
                    Datos.Opcion,
                    Datos.IDCFDIDatosEmisor ?? string.Empty,
                    Datos.IDCFDITipoPersona ?? string.Empty,
                    Datos.RazonSocial ?? string.Empty,
                    Datos.RFC ?? string.Empty,
                    Datos.IDCFDIReqgimenFiscalDetalle ?? string.Empty,
                    Datos.Direccion ?? string.Empty,
                    Datos.CodigoPostal ?? string.Empty,
                    Datos.Predeterminado,
                    Datos.Correo ?? string.Empty,
                    Datos.Password ?? string.Empty,
                    Datos.URLArchivoCER ?? string.Empty,
                    Datos.URLArchivoKEY ?? string.Empty,
                    Datos.PasswordArchivoKEY ?? string.Empty,
                    Datos.Imagen ?? string.Empty,
                    Datos.IDUsuario ?? string.Empty
                };
                object Aux = SqlHelper.ExecuteScalar(Datos.Conexion, "abc_CFDIDatosEmisor2", Parametros);
                Datos.IDCFDIDatosEmisor = Aux.ToString();
                if (!string.IsNullOrEmpty(Datos.IDCFDIDatosEmisor))
                {
                    Datos.Resultado = 1;
                }
                else
                {
                    Datos.Resultado = 0;
                }
                return Datos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CFDIDatosEmisor> IndexCFDIDatosEmisor(CFDIDatosEmisor Datos)
        {
            try
            {
                List<CFDIDatosEmisor> Lista = new List<CFDIDatosEmisor>();
                CFDIDatosEmisor Item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(Datos.Conexion, "CFDIDatosEmisor_Consulta_sp_2");
                while (dr.Read())
                {
                    Item = new CFDIDatosEmisor();
                    Item.IDCFDIDatosEmisor = !dr.IsDBNull(dr.GetOrdinal("id_cfdiDatosEmisor")) ? dr.GetString(dr.GetOrdinal("id_cfdiDatosEmisor")) : string.Empty;
                    Item.IDCFDITipoPersona = !dr.IsDBNull(dr.GetOrdinal("id_cfdiTipoPersona")) ? dr.GetString(dr.GetOrdinal("id_cfdiTipoPersona")) : string.Empty;
                    Item.CFDITipoPersona.TipoPersona = !dr.IsDBNull(dr.GetOrdinal("tipoPersona")) ? dr.GetString(dr.GetOrdinal("tipoPersona")) : string.Empty;

                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}