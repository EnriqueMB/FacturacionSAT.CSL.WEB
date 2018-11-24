﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIDatosConceptosModels
    {
        public CFDIDatosConceptosModels()
        {
            Id_cfdiDatosConceptos = string.Empty;
            Descripcion = string.Empty;
            Id_cfdiTipoProducto = string.Empty;
            Id_cfdiDivision = string.Empty;
            Id_cfdiGrupo = string.Empty;
            Id_cfdiClase = string.Empty;
            Id_cfdiClaveProdServDetalle = string.Empty;
            Id_cfdiClaveUnidad = string.Empty;
            Id_usuario = string.Empty;

        }


       private string _Id_cfdiDatosConceptos;

        public string Id_cfdiDatosConceptos
        {
            get { return _Id_cfdiDatosConceptos; }
            set { _Id_cfdiDatosConceptos = value; }
        }

        private string _Descripcion;

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
        private string _Id_cfdiClaveUnidad;

        public string Id_cfdiClaveUnidad
        {
            get { return _Id_cfdiClaveUnidad; }
            set { _Id_cfdiClaveUnidad = value; }
        }
        private string _Id_usuario;

        public string Id_usuario
        {
            get { return _Id_usuario; }
            set { _Id_usuario = value; }
        }

    }
    }
