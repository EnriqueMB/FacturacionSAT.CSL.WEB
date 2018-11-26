using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIConceptoGrupoModels
    {
        public CFDIConceptoGrupoModels()
        {
            Id_cfdiGrupo = string.Empty;
            CveTipoProducto = string.Empty;
            CveDivisionShort = string.Empty;
            CveGrupoShort = string.Empty;
            Grupo = string.Empty;
            _ListaGrupo = new List<CFDIConceptoDivicionModels>();
        }
        public List<CFDIConceptoDivicionModels> _ListaGrupo { set; get;}
        private string _Id_cfdiGrupo;

        public string Id_cfdiGrupo
        {
            get { return _Id_cfdiGrupo; }
            set { _Id_cfdiGrupo = value; }
        }
        private string _CveTipoProducto;

        public string CveTipoProducto
        {
            get { return _CveTipoProducto; }
            set { _CveTipoProducto = value; }
        }
        private string _CveDivisionShort;

        public string CveDivisionShort
        {
            get { return _CveDivisionShort; }
            set { _CveDivisionShort = value; }
        }

        private string _CveGrupoShort;

        public string CveGrupoShort
        {
            get { return _CveGrupoShort; }
            set { _CveGrupoShort = value; }
        }

        private string _Grupo;

        public string Grupo
        {
            get { return _Grupo; }
            set { _Grupo = value; }
        }




    }
}