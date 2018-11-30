using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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

        public static bool EnviarCorreo(string De, string Contraseña, string Para, string Asunto, string Mensaje, bool banArchivo, string Archivo, bool Html, string Host, int Port, bool Ssl, List<string>ArchivosEnviar = null)
        {
            try
            {
                //GMAIL
                //Habilitar las siguientes opciones en correo de gmail
                //https://www.google.com/settings/security/lesssecureapps
                //https://accounts.google.com/DisplayUnlockCaptcha
                //HOTMAIL
                //Enviara las primeras veces despues nos llegara un correo para reconocer el inicio de sesion 
                //ya que depende del servidor donde esta alojado y se tiene que reconocer el inicio de sesion 
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new System.Net.Mail.MailAddress(De);
                mailMessage.To.Add(Para);
                mailMessage.Subject = Asunto;
                if (banArchivo)
                    if (ArchivosEnviar != null)
                    {
                        //agregado de archivo
                        foreach (string archivo in ArchivosEnviar)
                        {
                            //comprobamos si existe el archivo y lo agregamos a los adjuntos
                            if (System.IO.File.Exists(@archivo))
                            {
                                Attachment data = new Attachment(@archivo, MediaTypeNames.Application.Octet);
                                data.Name = "Prueba 1.txt";
                                mailMessage.Attachments.Add(data);
                            }
                                


                        }
                    }

                //mailMessage.Attachments.Add(new System.Net.Mail.Attachment(Archivo));
                mailMessage.Body = Mensaje;
                mailMessage.IsBodyHtml = Html;
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(Host);
                smtpClient.Port = Port;
                smtpClient.EnableSsl = Ssl;
                smtpClient.Credentials = new NetworkCredential(De, Contraseña);
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}