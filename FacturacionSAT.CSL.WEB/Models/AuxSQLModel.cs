using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class AuxSQLModel
    {
        public string Conexion { get; set; }
        public string Id_usuario { get; set; }
        public bool Success { get; set; }
        public string Mensaje { get; set; }

        public void ResetValuesSQL()
        {
            this.Success = false;
            this.Mensaje = string.Empty;
        }
    }
}