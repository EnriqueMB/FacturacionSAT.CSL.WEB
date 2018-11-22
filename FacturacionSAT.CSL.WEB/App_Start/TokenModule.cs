using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.App_Start
{
    public class TokenModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.PreRequestHandlerExecute += new EventHandler(Aplication_PreRequestHandlerExecute);
        }

        private void Aplication_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            if (application.Context.Session != null)
            {
                object token = application.Session[TokenProcessor.TRANSACTION_TOKEN_KEY];

                if (token != null)
                {
                    application.Context.Items.Add(TokenProcessor.TOKEN_KEY, token.ToString());
                }
            }
        }

        public void Dispose()
        {
        }
    }
}