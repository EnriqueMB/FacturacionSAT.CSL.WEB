﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class UsuarioModels
    {
        public string Id_Usuario { get; set; }
        public string user { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string Conexion { get; set; }
    }
}