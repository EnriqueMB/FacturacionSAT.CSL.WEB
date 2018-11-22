using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.App_Start
{
    public sealed class TokenProcessor
    {
        public const string TRANSACTION_TOKEN_KEY = "TRANSACTION-TOKEN-KEY";
        public const string TOKEN_KEY = "TOKEN-KEY";

        private static TokenProcessor instance = new TokenProcessor();

        public static TokenProcessor GetInstance()
        {
            return TokenProcessor.instance;
        }

        public bool IsTokenValid()
        {
            lock (this)
            {
                return this.IsTokenValid(false);
            }
        }

        public bool IsTokenValid(bool reset)
        {
            lock (this)
            {
                object saved = HttpContext.Current.Session[TRANSACTION_TOKEN_KEY];

                if (saved == null)
                {
                    return false;
                }

                if (reset)
                {
                    this.ResetToken();
                }

                object token = HttpContext.Current.Items[TOKEN_KEY];
                if (token == null)
                {
                    return false;
                }

                return saved.Equals(token);
            }
        }

        public void ResetToken()
        {
            lock (this)
            {
                HttpContext.Current.Session.Remove(TRANSACTION_TOKEN_KEY);
            }
        }

        public void SaveToken()
        {
            lock (this)
            {
                String token = GenerateToken();
                if (token != null)
                {
                    HttpContext.Current.Session[TRANSACTION_TOKEN_KEY] = token;
                }
            }
        }

        private String GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }

        private TokenProcessor()
        {
        }
    }
}