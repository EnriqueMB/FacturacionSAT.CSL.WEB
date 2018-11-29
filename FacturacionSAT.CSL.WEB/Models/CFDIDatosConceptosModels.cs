using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIDatosConceptosModels
    {
        public CFDIDatosConceptosModels()
        {
            Opcion = 0;
            Completado = false;
            Id_cfdiDatosConceptos = string.Empty;
            Descripcion = string.Empty;
            Id_cfdiTipoProducto = string.Empty;
            Id_cfdiDivision = string.Empty;
            Id_cfdiGrupo = string.Empty;
            Id_cfdiClase = string.Empty;
            Id_cfdiClaveProdServDetalle = string.Empty;
            Id_cfdiClaveUnidadDetalle = string.Empty;
            Id_usuario = string.Empty;
            Conexion = string.Empty;
            Completado = false;
            //tipoProducto = new CFDIConceptosTipoProductoModels();
            divicion = new CFDIConceptoDivicionModels();
            grupo = new CFDIConceptoGrupoModels();
            clase = new CFDIConceptoClaseModels();
            servicioDetalle = new CFDIConceptoClaveUnidadModels();
           
            this._ListaTipoProducto = new List<CFDIConceptosTipoProductoModels>();
            this._ListaDivicion = new List<CFDIConceptoDivicionModels>();
            this._ListaClase = new List<CFDIConceptoClaseModels>();
            this._ListaGrupo = new List<CFDIConceptoGrupoModels>();
            this._ListaClaveProducto = new List<CFDIConceptosClaveProductoModels>();
            this._ListaClaveunidad = new List<CFDIConceptoClaveUnidadModels>();
            this.ListaCFDIConceptos = new List<CFDIDatosConceptosModels>();
            this.CFDI_ClaveUnidad = new CFDIConceptoClaveUnidadModels();
            this.CFDI_Claveproducto = new CFDIConceptosClaveProductoModels();
            this.CFDI_TipoProducto = new CFDIConceptosTipoProductoModels();
            this.CFDI_ClaveDivision = new CFDIConceptoDivicionModels();
            this.CFDI_Grupo = new CFDIConceptoGrupoModels();
            this.CFDI_Clase = new CFDIConceptoClaseModels();

        }
        // private int _Opcion;

        public bool Completado { get; set; }
        public int Opcion { get; set; }
        public CFDIConceptoDivicionModels divicion { get; set; }
        public CFDIConceptoGrupoModels grupo { get; set; }
        public CFDIConceptoClaseModels clase { get; set; }
        public CFDIConceptoClaveUnidadModels servicioDetalle { get; set; }
        public CFDIConceptoClaveUnidadModels CFDI_ClaveUnidad { get; set; }
        public CFDIConceptosClaveProductoModels CFDI_Claveproducto { get; set; }
        public CFDIConceptosTipoProductoModels CFDI_TipoProducto { get; set; } 
        public CFDIConceptoDivicionModels CFDI_ClaveDivision { get; set; }
        public CFDIConceptoGrupoModels CFDI_Grupo { get; set; }
        public CFDIConceptoClaseModels CFDI_Clase { get; set; }

        public string Conexion { get; set; }

        private string _Id_cfdiDatosConceptos;

        public string Id_cfdiDatosConceptos
        {
            get { return _Id_cfdiDatosConceptos; }
            set { _Id_cfdiDatosConceptos = value; }
        }

        private string _Descripcion;
        [Required]
        [Display (Name ="Descripcion")]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Id_cfdiTipoProducto;

        public string Id_cfdiTipoProducto
        {
            get { return _Id_cfdiTipoProducto; }
            set { _Id_cfdiTipoProducto = value; }
        }
        private string _Id_cfdiDivision;

        public string Id_cfdiDivision
        {
            get { return _Id_cfdiDivision; }
            set { _Id_cfdiDivision = value; }
        }

        private string _Id_cfdiGrupo;

        public string Id_cfdiGrupo
        {
            get { return _Id_cfdiGrupo; }
            set { _Id_cfdiGrupo = value; }
        }
        private string _Id_cfdiClase;

        public string Id_cfdiClase
        {
            get { return _Id_cfdiClase; }
            set { _Id_cfdiClase = value; }
        }
        private string _Id_cfdiClaveProdServDetalle;

        public string Id_cfdiClaveProdServDetalle
        {
            get { return _Id_cfdiClaveProdServDetalle; }
            set { _Id_cfdiClaveProdServDetalle = value; }
        }
        private string _Id_cfdiClaveUnidadDetalle;

        public string Id_cfdiClaveUnidadDetalle
        {
            get { return _Id_cfdiClaveUnidadDetalle; }
            set { _Id_cfdiClaveUnidadDetalle = value; }
        }
        private string _Id_usuario;

        public string Id_usuario
        {
            get { return _Id_usuario; }
            set { _Id_usuario = value; }
        }

        private CFDIConceptosTipoProductoModels _tipoProducto;

        public CFDIConceptosTipoProductoModels tipoProducto
        {
            get { return _tipoProducto; }
            set { _tipoProducto = value; }
        }
        private List<CFDIConceptosTipoProductoModels> _ListaTipoProducto;

        public List<CFDIConceptosTipoProductoModels> ListaTipoProducto
        {
            get { return _ListaTipoProducto; }
            set { _ListaTipoProducto = value; }
        }
        private List<CFDIConceptoDivicionModels> _ListaDivicion;

        public List<CFDIConceptoDivicionModels> ListaDivicion
        {
            get { return _ListaDivicion; }
            set { _ListaDivicion = value; }
        }
        private List<CFDIConceptoGrupoModels> _ListaGrupo;

        public List<CFDIConceptoGrupoModels> ListaGrupo
        {
            get { return _ListaGrupo; }
            set { _ListaGrupo = value; }
        }


        private List<CFDIConceptoClaseModels> _ListaClase;
        public List<CFDIConceptoClaseModels> ListaClase
        {
            get { return _ListaClase; }
            set { _ListaClase = value; }
        }
        private List<CFDIConceptosClaveProductoModels> _ListaClaveProducto;

        public List<CFDIConceptosClaveProductoModels> ListaClaveProducto
        {
            get { return _ListaClaveProducto; }
            set { _ListaClaveProducto = value; }
        }
        private List<CFDIConceptoClaveUnidadModels> _ListaClaveunidad;

        public List<CFDIConceptoClaveUnidadModels> ListaClaveunidad
        {
            get { return _ListaClaveunidad; }
            set { _ListaClaveunidad = value; }
        }
        

        private List<CFDIDatosConceptosModels> _ListaCFDIConceptos;

        public List<CFDIDatosConceptosModels> ListaCFDIConceptos
        {
            get { return _ListaCFDIConceptos; }
            set { _ListaCFDIConceptos = value; }
        }

    }
    }

