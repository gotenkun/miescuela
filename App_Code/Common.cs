using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Code
{
    static public class Common
    {
        static public string StripHTML(string source, out bool errors)
        {
            errors = false;
            try
            {
                string result;
              
                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);

                result = result.Replace("<tr>", "");
                result = result.Replace("</tr>", "<br/>");

                result = result.Replace("&ntilde;", "ñ");
                result = result.Replace("&Ntilde;", "Ñ");
                result = result.Replace("&aacute;", "á");
                result = result.Replace("&eacute;", "é");
                result = result.Replace("&iacute;", "í");
                result = result.Replace("&oacute;", "ó");
                result = result.Replace("&uacute;", "ú");
                result = result.Replace("&Aacute;", "Á");
                result = result.Replace("&Eacute;", "É");
                result = result.Replace("&Iacute;", "Í");
                result = result.Replace("&Oacute;", "Ó");
                result = result.Replace("&Uacute;", "Ú");

                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {
                errors = true;
                return source;
            }
        }
        static public bool IsUserInRole(string _userName, string _role)
        {
              UserManager um = new UserManager();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var u = um.FindByName(_userName);
            if (u != null)
            {
                if (um.IsInRole(u.Id, _role))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        static public string GetUserFullName(ClaimsIdentity id)
        {
            string uid = id.Claims.Where(p => p.Type == ClaimTypes.GivenName).SingleOrDefault().Value;
            if (uid != null)
                return uid;
            else
                return "";
        }
        static public long GetUserImageID(ClaimsIdentity id)
        {
            long uid = -1;
            if (long.TryParse(id.Claims.Where(p => p.Type == ClaimTypes.Thumbprint).SingleOrDefault().Value, out uid))
                return uid;
            else
                return -1;
        }
        static public long GetUserID(ClaimsIdentity id)
        {
            long uid = 0;
            if (long.TryParse(id.Claims.Where(p => p.Type == ClaimTypes.Sid).SingleOrDefault().Value, out uid))
                return uid;
            else
                return -1;
        }
        /// <summary>
        /// Obtiene la institución del usuario, si es clínica compartida. Si no, regresa -1 indicando que el usuario gestiona sus pacientes individualmente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public long GetInstitucionID(ClaimsIdentity id)
        {
            long uid = 0;
            if (long.TryParse(id.Claims.Where(p => p.Type == ClaimTypes.UserData).SingleOrDefault().Value, out uid))
            {
               
                return uid;
            }
            else
                return -1;
        }
        /// <summary>
        /// Obtiene la institución a la cual pertenece el usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public long GetInstitucionRealID(ClaimsIdentity id)
        {
            long uid = 0;
            if (long.TryParse(id.Claims.Where(p => p.Type == ClaimTypes.UserData).SingleOrDefault().Value, out uid))
            {
                try
                {
                    //using (MiEscuelaDataContext context = new MiEscuelaDataContext())
                    //{
                    //    var inst = context.Institucions.Where(p => p.InstitucionID == uid).SingleOrDefault();
                    //    if (inst != null)
                    //    {
                    //        uid = inst.InstitucionID;
                    //    }
                    //}
                }
                catch (Exception)
                {

                    throw;
                }
                return uid;
            }
            else
                return -1;
        }
        static public bool IsInMobile(string _httpUserAgent)
        {
            string u = _httpUserAgent;
            Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if ((b.IsMatch(u) || v.IsMatch(u.Substring(0, 4))))
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Regresa el script de alert con el mensaje proporcionado, y si _redireccion no es null o vacio, redirecciona el navegador a la dirección proporcionada.
        /// 
        /// </summary>
        /// <param name="_mensaje">Mensaje para mostrar en el alert.</param>
        /// <param name="_redireccion">Dirección a donde se redireccionaría, relativa al directorio actual. Se ignora si es null o vacío.</param>
        /// <returns></returns>
        static public string Alert(string _mensaje, string _redireccion)
        {
            string script = "<script language='javascript'>alert('";
            if (_mensaje != null)
            {
                script += _mensaje + "');";
            }
            else
            {
                script += "');";
            }
            if (_redireccion != null && _redireccion != "")
            {
                script += "window.location=" + _redireccion + ";";
            }
            script += "</script>";
            return script;
        }
        /// <summary>
        /// Agrega una entrada al registro de eventos del sistema ADCU.
        /// </summary>
        /// <param name="_tipoLogID">ID del Tipo de evento, 1:error, 2:Inserción de datos, 3:Actualización, 4:Eliminación, 5:Información</param>
        /// <param name="_url">URL que generó el evento (si aplica)</param>
        /// <param name="_error">Mensaje del error.</param>
        /// /// <param name="_innerException">Mensaje del error interno.</param>
        /// <param name="_usuario">Login del usuario actual.</param>
        /// /// <param name="_comentario">Comentario de este evento.</param>
        static public long AgregarLog(long _tipoLogID, string _url, long _elementoID, string _error, string _innerException, string _stack, string _usuario, string _comentario, bool _esCritico)
        {
            MiEscuelaDataContext context = new MiEscuelaDataContext();
            try
            {
                if (_tipoLogID < 0)
                    throw new Exception("Debe indicar el tipo de Evento");
                Log log = new Log();
                if (_error != null && _error != "")
                    log.Error = _error;
                if (_stack != null && _stack != "")
                    log.Stack = _stack;
                if (_innerException != null && _innerException != "")
                    log.ErrorInterno = _innerException;
                if (_url != null && _url != "")
                    log.Pagina = _url;
                if (_usuario != null && _usuario != "")
                    log.Usuario = _usuario;
                if (_elementoID > 0)
                    log.ElementoID = _elementoID;
                if (_comentario != null && _comentario != "")
                    log.Comentario = _comentario;
                log.TipoLogID = _tipoLogID;
                log.Fecha = DateTime.Now;
                context.Logs.InsertOnSubmit(log);
                context.SubmitChanges();
                if (_esCritico)
                {
                    //mandar mail.
                    string mail = "Ingreso de bitácora crítico en la aplicación.<br/>&nbsp;<br/>" +
                        "El usuario " + _usuario + " intentó una acción calificada como crítica en el sistema.<br/>&nbsp;<br/>Datos de la bitácora:<br/>";
                    mail += "Fecha: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString() + "<br/>" +
                        "Página: " + _url + "<br/>Error: " + _error + "<br/>Stack: " + (_stack != null ? _stack : "-") + "<br/>InnerException: " +
                        (_innerException != null ? _innerException : "-") + "<br/>Comentario: " + _comentario;

                    MailHelper mh = new MailHelper();
                    mh.EnviarMail(new string[] { System.Configuration.ConfigurationManager.AppSettings["MailSoporteTecnico"] }, true, "Log Crítico en Sportiak", null, mail, null,null);
                }
                return log.LogID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar entrada al registro de eventos" + ": " + ex.Message);
            }
        }

        //static public bool AgendarCita(DateTime _fecha, DateTime _horaInicio, DateTime _horaFin, string _startPath, string _paciente, string _observaciones, out string _mensaje)
        //{
        //    bool valor = true;
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(Path.Combine(_startPath, "items.xml"));
        //        XmlDocumentFragment frag = doc.CreateDocumentFragment();
        //        frag.InnerXml = "<ItemInfo><StartTime>" + string.Format("{0:yyyy-MM-dd}", _fecha) + "T" +
        //            string.Format("{0:HH:mm:ss}", _horaInicio) + "</StartTime>" +
        //                        "<EndTime>" + string.Format("{0:yyyy-MM-dd}", _fecha) + "T" +
        //                        string.Format("{0:HH:mm:ss}", _horaFin) + "</EndTime>" +
        //                        "<Text>Cita con " + _paciente + ". " + _observaciones + "</Text>" +
        //                        "<A>255</A>" +
        //                        "<R>255</R>" +
        //                        "<G>0</G>" +
        //                        "<B>0</B></ItemInfo>";
        //        doc.DocumentElement.AppendChild(frag);
        //        doc.Save(Path.Combine(_startPath, "items.xml"));
        //        if (Code.Common.CheckForInternetConnection() && LoginInfo.TieneDatosGoogle)
        //        {
        //            ItemInfo item = new ItemInfo();
        //            item.EndTime = new DateTime(_fecha.Year, _fecha.Month, _fecha.Day, _horaFin.Hour, _horaFin.Minute, _horaFin.Second);
        //            item.StartTime = new DateTime(_fecha.Year, _fecha.Month, _fecha.Day, _horaInicio.Hour, _horaInicio.Minute, _horaInicio.Second);
        //            item.Text = "Cita con " + _paciente + ". " + _observaciones;
        //            item.A = 255;
        //            item.B = 0;
        //            item.G = 0;
        //            item.R = 255;
        //            //Code.GCalendarUtils cal = new Code.GCalendarUtils();
        //            //cal.InsertEntry(item);
        //            Code.GoogleInterface cal = new Code.GoogleInterface();
        //            if (cal.connectCalendar())
        //            {
        //                cal.InsertEntry(item);
        //            }
        //        }
        //        else
        //        {
        //            if (!Code.Common.CheckForInternetConnection() && LoginInfo.TieneDatosGoogle)
        //            {
        //                _mensaje = "Advertencia: No se ha sincronizado la cita en google calendar debido a que no hay conexión a internet.";
        //            }
        //        }
        //        _mensaje = "Se ha agendado la cita";
        //        return valor;
        //    }
        //    catch (Exception ex)
        //    {
        //        _mensaje = "Error al agendar cita: " + ex.Message;
        //        return false;
        //    }
        //}
        /// <summary>
        /// Confirma si la cadena tiene estructura válida de email.
        /// </summary>
        /// <param name="inputEmail">Cadena de Email</param>
        /// <returns></returns>
        static public string GetProximaCita(DateTime _startDate, long _pacienteID)
        {
            DateTime cita = new DateTime(1900, 1, 1);
            try
            {
                using (MiEscuelaDataContext context = new MiEscuelaDataContext())
                {
                    //var citas = context.Citas.Where(p => p.PacienteID == _pacienteID && p.Fecha >= _startDate).OrderBy(p => p.Fecha).FirstOrDefault() ;
                    //if (citas != null)
                    //    cita = citas.Fecha;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
            if (cita.Year > 1900)
                return cita.ToShortDateString();
            else return "N/A";
        }
        static public bool isEmail(string inputEmail)
        {
            if (inputEmail == null)
                inputEmail = "";
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public static string DoFormat(double myNumber)
        {
            var s = string.Format("{0:0.00}", myNumber);

            if (s.EndsWith("00"))
            {
                return ((int)myNumber).ToString();
            }
            else
            {
                return s;
            }
        }
        public static int MonthDifference(this DateTime lValue, DateTime rValue)
        {
            return Math.Abs((lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year));
        }
        public static void EncryptConnectionString(bool encrypt, string fileName)
        {
            Configuration configuration = null;
            try
            {
                // Open the configuration file and retrieve the connectionStrings section.
                configuration = ConfigurationManager.OpenExeConfiguration(fileName);
                ConnectionStringsSection configSection =
                configuration.GetSection("connectionStrings") as ConnectionStringsSection;
                if ((!(configSection.ElementInformation.IsLocked)) &&
                    (!(configSection.SectionInformation.IsLocked)))
                {
                    if (encrypt && !configSection.SectionInformation.IsProtected)
                    {
                        //this line will encrypt the file
                        configSection.SectionInformation.ProtectSection
                            ("DataProtectionConfigurationProvider");
                    }

                    if (!encrypt &&
                    configSection.SectionInformation.IsProtected)//encrypt is true so encrypt
                    {
                        //this line will decrypt the file. 
                        configSection.SectionInformation.UnprotectSection();
                    }
                    //re-save the configuration file section
                    configSection.SectionInformation.ForceSave = true;
                    // Save the current configuration

                    configuration.Save();
                    Process.Start("notepad.exe", configuration.FilePath);
                    //configFile.FilePath 
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
     
        public static byte[] GetFileBytes(string filename)
        {
            if (File.Exists(filename))
            {
                FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read);

                byte[] fileBytes = new byte[fs.Length];

                fs.Read(fileBytes, 0, (int)fs.Length);

                fs.Close();

                return fileBytes;
            }

            return null;
        }
        public static string HashCode(string str)
        {
            string rethash = "";
            try
            {

                System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1.Create();
                System.Text.ASCIIEncoding encoder = new System.Text.ASCIIEncoding();
                byte[] combined = encoder.GetBytes(str);
                hash.ComputeHash(combined);
                rethash = Convert.ToBase64String(hash.Hash);
            }
            catch (Exception ex)
            {
                string strerr = "Error in HashCode : " + ex.Message;
            }
            return rethash;
        }  
        static public string Encode(string _password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] data = System.Text.Encoding.ASCII.GetBytes(_password);

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(data[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        static public int GetAgeInt(DateTime _fechaNacimiento)
        {
            DateTime hoy = DateTime.Now;
            if (hoy < _fechaNacimiento)
                throw new ArgumentException("La fecha de nacimiento debe ser antes del día de hoy.");
            int totalAnos = hoy.Year - _fechaNacimiento.Year;
            if (hoy.Month < _fechaNacimiento.Month || (hoy.Month == _fechaNacimiento.Month
                && hoy.Day < _fechaNacimiento.Day))
            {
                //quitar un día ya que no ha pasado un año completo desde el último cumpleaños.
                totalAnos -= 1;
            }
            return totalAnos;
        }
        public static string ToAgeString(this DateTime dob)
        {
            int edad = GetAgeInt(dob);
            if (edad < 3)
            {
                DateTime dt = DateTime.Today;

                int days = dt.Day - dob.Day;
                if (days < 0)
                {
                    dt = dt.AddMonths(-1);
                    days += DateTime.DaysInMonth(dt.Year, dt.Month);
                }

                int months = dt.Month - dob.Month;
                if (months < 0)
                {
                    dt = dt.AddYears(-1);
                    months += 12;
                }

                int years = dt.Year - dob.Year;
                if (years > 0)
                {
                    return string.Format("{0} año{1}, {2} mes{3} y {4} día{5}",
                                         years, (years == 1) ? "" : "s",
                                         months, (months == 1) ? "" : "es",
                                         days, (days == 1) ? "" : "s");
                }
                else
                {
                    return string.Format("{0} mes{1} y {2} día{3}",
                                       months, (months == 1) ? "" : "es",
                                       days, (days == 1) ? "" : "s");
                }
            }
            else
            {
                return edad.ToString() + " años";
            }
        }

    }
}
