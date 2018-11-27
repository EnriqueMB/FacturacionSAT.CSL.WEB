using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace FacturacionSAT.CSL.WEB.App_Start
{
    public static class ClaseAux
    {
        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }
        public static string ToJSON(this object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer
            {
                RecursionLimit = recursionDepth
            };
            return serializer.Serialize(obj);
        }
    }
}