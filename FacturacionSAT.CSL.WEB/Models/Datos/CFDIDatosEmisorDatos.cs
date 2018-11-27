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
        public CFDIDatosEmisorModels AbcDatosEmisor(CFDIDatosEmisorModels Datos)
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
                return Datos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CFDIDatosEmisorModels> IndexCFDIDatosEmisor(CFDIDatosEmisorModels Datos)
        {
            try
            {
                List<CFDIDatosEmisorModels> Lista = new List<CFDIDatosEmisorModels>();
                CFDIDatosEmisorModels Item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(Datos.Conexion, "CFDIDatosEmisor_Consulta_sp_2");
                while (dr.Read())
                {
                    Item = new CFDIDatosEmisorModels();
                    Item.IDCFDIDatosEmisor = !dr.IsDBNull(dr.GetOrdinal("id_cfdiDatosEmisor")) ? dr.GetString(dr.GetOrdinal("id_cfdiDatosEmisor")) : string.Empty;
                    Item.IDCFDITipoPersona = !dr.IsDBNull(dr.GetOrdinal("id_cfdiTipoPersona")) ? dr.GetString(dr.GetOrdinal("id_cfdiTipoPersona")) : string.Empty;
                    Item.CFDITipoPersona.TipoPersona = !dr.IsDBNull(dr.GetOrdinal("tipoPersona")) ? dr.GetString(dr.GetOrdinal("tipoPersona")) : string.Empty;
                    Item.RazonSocial = !dr.IsDBNull(dr.GetOrdinal("razonSocial")) ? dr.GetString(dr.GetOrdinal("razonSocial")) : string.Empty;
                    Item.RFC = !dr.IsDBNull(dr.GetOrdinal("rfc")) ? dr.GetString(dr.GetOrdinal("rfc")) : string.Empty;
                    Item.IDCFDIReqgimenFiscalDetalle = !dr.IsDBNull(dr.GetOrdinal("id_cfdiRegimenFiscalDetalle")) ? dr.GetString(dr.GetOrdinal("id_cfdiRegimenFiscalDetalle")) : string.Empty;
                    Item.CFDIRegimenFiscalDetalle.C_RegimenFiscal = !dr.IsDBNull(dr.GetOrdinal("regimenFiscalDetalle")) ? dr.GetString(dr.GetOrdinal("regimenFiscalDetalle")) : string.Empty;
                    Item.CFDIRegimenFiscalDetalle.Descripcion = !dr.IsDBNull(dr.GetOrdinal("regimenFiscalDetalleFULL")) ? dr.GetString(dr.GetOrdinal("regimenFiscalDetalleFULL")) : string.Empty;
                    Item.Direccion = !dr.IsDBNull(dr.GetOrdinal("direccion")) ? dr.GetString(dr.GetOrdinal("direccion")) : string.Empty;
                    Item.CodigoPostal = !dr.IsDBNull(dr.GetOrdinal("codigoPostal")) ? dr.GetString(dr.GetOrdinal("codigoPostal")) : string.Empty;
                    Item.Predeterminado = !dr.IsDBNull(dr.GetOrdinal("predeterminada")) ? dr.GetBoolean(dr.GetOrdinal("predeterminada")) : false;
                    Item.Correo = !dr.IsDBNull(dr.GetOrdinal("correo")) ? dr.GetString(dr.GetOrdinal("correo")) : string.Empty;
                    Item.URLArchivoCER = !dr.IsDBNull(dr.GetOrdinal("urlArchivoCER")) ? dr.GetString(dr.GetOrdinal("urlArchivoCER")) : string.Empty;
                    Item.URLArchivoKEY = !dr.IsDBNull(dr.GetOrdinal("urlArchivoKEY")) ? dr.GetString(dr.GetOrdinal("urlArchivoKEY")) : string.Empty;
                    Item.PasswordArchivoKEY = !dr.IsDBNull(dr.GetOrdinal("PasswordArchivoKEY")) ? dr.GetString(dr.GetOrdinal("PasswordArchivoKEY")) : string.Empty;
                    Item.Password = !dr.IsDBNull(dr.GetOrdinal("passwordCorreo")) ? dr.GetString(dr.GetOrdinal("passwordCorreo")) : string.Empty;
                    Item.Imagen = !dr.IsDBNull(dr.GetOrdinal("imagen")) ? dr.GetString(dr.GetOrdinal("imagen")) : string.Empty;
                    Lista.Add(Item);
                }
                dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public CFDIDatosEmisorModels ObtenerDatosEmisorID(CFDIDatosEmisorModels Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCFDIDatosEmisor };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(Datos.Conexion, "CFDIDatosEmisor_Consulta_sp_ID_2", Parametros);
                while (dr.Read())
                {
                    Datos.IDCFDIDatosEmisor = !dr.IsDBNull(dr.GetOrdinal("id_cfdiDatosEmisor")) ? dr.GetString(dr.GetOrdinal("id_cfdiDatosEmisor")) : string.Empty;
                    Datos.IDCFDITipoPersona = !dr.IsDBNull(dr.GetOrdinal("id_cfdiTipoPersona")) ? dr.GetString(dr.GetOrdinal("id_cfdiTipoPersona")) : string.Empty;
                    Datos.CFDITipoPersona.TipoPersona = !dr.IsDBNull(dr.GetOrdinal("tipoPersona")) ? dr.GetString(dr.GetOrdinal("tipoPersona")) : string.Empty;
                    Datos.RazonSocial = !dr.IsDBNull(dr.GetOrdinal("razonSocial")) ? dr.GetString(dr.GetOrdinal("razonSocial")) : string.Empty;
                    Datos.RFC = !dr.IsDBNull(dr.GetOrdinal("rfc")) ? dr.GetString(dr.GetOrdinal("rfc")) : string.Empty;
                    Datos.IDCFDIReqgimenFiscalDetalle = !dr.IsDBNull(dr.GetOrdinal("id_cfdiRegimenFiscalDetalle")) ? dr.GetString(dr.GetOrdinal("id_cfdiRegimenFiscalDetalle")) : string.Empty;
                    Datos.CFDIRegimenFiscalDetalle.C_RegimenFiscal = !dr.IsDBNull(dr.GetOrdinal("regimenFiscalDetalle")) ? dr.GetString(dr.GetOrdinal("regimenFiscalDetalle")) : string.Empty;
                    Datos.CFDIRegimenFiscalDetalle.Descripcion = !dr.IsDBNull(dr.GetOrdinal("regimenFiscalDetalleFULL")) ? dr.GetString(dr.GetOrdinal("regimenFiscalDetalleFULL")) : string.Empty;
                    Datos.Direccion = !dr.IsDBNull(dr.GetOrdinal("direccion")) ? dr.GetString(dr.GetOrdinal("direccion")) : string.Empty;
                    Datos.CodigoPostal = !dr.IsDBNull(dr.GetOrdinal("codigoPostal")) ? dr.GetString(dr.GetOrdinal("codigoPostal")) : string.Empty;
                    Datos.Predeterminado = !dr.IsDBNull(dr.GetOrdinal("predeterminada")) ? dr.GetBoolean(dr.GetOrdinal("predeterminada")) : false;
                    Datos.Correo = !dr.IsDBNull(dr.GetOrdinal("correo")) ? dr.GetString(dr.GetOrdinal("correo")) : string.Empty;
                    Datos.URLArchivoCER = !dr.IsDBNull(dr.GetOrdinal("urlArchivoCER")) ? dr.GetString(dr.GetOrdinal("urlArchivoCER")) : string.Empty;
                    Datos.URLArchivoKEY = !dr.IsDBNull(dr.GetOrdinal("urlArchivoKEY")) ? dr.GetString(dr.GetOrdinal("urlArchivoKEY")) : string.Empty;
                    Datos.PasswordArchivoKEY = !dr.IsDBNull(dr.GetOrdinal("PasswordArchivoKEY")) ? dr.GetString(dr.GetOrdinal("PasswordArchivoKEY")) : string.Empty;
                    Datos.Password = !dr.IsDBNull(dr.GetOrdinal("passwordCorreo")) ? dr.GetString(dr.GetOrdinal("passwordCorreo")) : string.Empty;
                    Datos.Imagen = !dr.IsDBNull(dr.GetOrdinal("imagen")) ? dr.GetString(dr.GetOrdinal("imagen")) : string.Empty;
                    break;
                }
                dr.Close();
                return Datos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CFDITipoPersonaModels> ListaPersonaCMB(CFDIDatosEmisorModels Datos)
        {
            try
            {
                CFDITipoPersonaModels Item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(Datos.Conexion, "CFDITipoPersona_Combo_sp");
                while (dr.Read())
                {
                    Item = new CFDITipoPersonaModels();
                    Item.IDCFDITIpoPersona = !dr.IsDBNull(dr.GetOrdinal("id_cfdiTipoPersona")) ? dr.GetString(dr.GetOrdinal("id_cfdiTipoPersona")) : string.Empty;
                    Item.TipoPersona = !dr.IsDBNull(dr.GetOrdinal("TipoPersona")) ? dr.GetString(dr.GetOrdinal("TipoPersona")) : string.Empty;
                    Datos.ListaTipoPersona.Add(Item);
                }
                dr.Close();
                return Datos.ListaTipoPersona;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CFDIRegimenFiscalDetalleModels> ListaRegimenFiscalDetalle(CFDIDatosEmisorModels Datos)
        {
            try
            {
                CFDIRegimenFiscalDetalleModels Item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(Datos.Conexion, "CFDIRegimenFiscalDetalle_Combo_sp", Datos.IDCFDITipoPersona);
                while (dr.Read())
                {
                    Item = new CFDIRegimenFiscalDetalleModels();
                    Item.IDCFDIRegimenFiscalDetalle = !dr.IsDBNull(dr.GetOrdinal("id_cfdiRegimenFiscalDetalle")) ? dr.GetString(dr.GetOrdinal("id_cfdiRegimenFiscalDetalle")) : string.Empty;
                    Item.C_RegimenFiscal = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                    Datos.ListaRegimenFiscalDetalle.Add(Item);
                }
                return Datos.ListaRegimenFiscalDetalle;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}