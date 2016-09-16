using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.IO;
/// <summary>
/// Summary description for MailHelper
/// </summary>
public class MailHelper
{
	public MailHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /// <summary>
    /// Envía un correo electrónico a las direcciones señaladas, usando la cuenta de sistema.
    /// </summary>
    /// <param name="_para">Arreglo de string con las direcciones a quien se desea mandar el correo.</param>
    /// <param name="_enviarASistema">True para mandar una copia del correo a la direcciónd de sistema.</param>
    /// <param name="_asunto">Asunto del correo.</param>
    /// <param name="_replacements">ListDictionary que contiene los reemplazos que se harán en la plantilla de correo. Si body filename es null o vacío, este parámetro se omitirá.</param>
    /// <param name="_body">Texto específico a incluir en el correo electrónico. Se incluye cuando BodyFileName está indicado como nullo o texto vacío.</param>
    /// <param name="_BodyFileName">Ruta de la plantilla del correo que se usará para enviar este correo.</param>
    /// <param name="_attachmentPath">Ruta del archivo adjunto que se enviará.</param>
    /// <returns>True si el correo se procesó y se puso en espera de envío de manera correcta.</returns>
    public bool EnviarMail(string[] _para, bool _enviarASistema, string _asunto, ListDictionary _replacements, string _body, string _BodyFileName, string _attachmentPath)
    {
        MailMessage msg =null;
        SmtpClient client = null;
        try
        {
            string contents = "";
            if (_BodyFileName != null && _BodyFileName != "")
            {
                String FILENAME =  System.Web.Hosting.HostingEnvironment.MapPath(_BodyFileName);
                StreamReader objStreamReader = File.OpenText(FILENAME);
                contents = objStreamReader.ReadToEnd();


                foreach (string k in _replacements.Keys)
                {
                    contents = contents.Replace(k, _replacements[k].ToString());
                }
            }
            else
            {
                contents = _body;
            }
            msg = new MailMessage();
            msg.Body = contents;
            msg.Subject = _asunto;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["MailSistema"], "Sistema MedikAdmin");
            msg.Priority = MailPriority.High;      
            client = new SmtpClient();
            //Add the Creddentials- use your own email id and password
            client.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["MailSistema"], System.Configuration.ConfigurationManager.AppSettings["PasswordMailSistema"]);
            client.Port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["PuertoSMTP"]);
            client.Host = System.Configuration.ConfigurationManager.AppSettings["ServidorSMTP"]; //mail.pusa.com.mx
            client.EnableSsl = System.Configuration.ConfigurationManager.AppSettings["RequiereSSL"] == "1" ? true : false;
            string to = "";
            foreach (string s in _para)
            {
                to += s + ",";
            }
            to= to.Remove(to.LastIndexOf(","));
            msg.To.Add(to);
            if (!string.IsNullOrEmpty(_attachmentPath))
            {
                //adjuntar
                if(File.Exists(_attachmentPath))
                {
                    Attachment a = new Attachment(_attachmentPath);
                    msg.Attachments.Add(a);
                   
                }
            }
            client.Send(msg);
            
            if (_enviarASistema)
            {
                msg.To.Clear();
                msg.To.Add("sistema@sportiak.com");

                client.Send(msg);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        finally
        {
            msg.Dispose();
            client = null;
        }
    }
}