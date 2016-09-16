using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace MedikAdmin
{
    /// <summary>
    /// Summary description for BL
    /// </summary>
    public class Common
    {
        
        /// <summary>
        /// Devuelve true si el deporte indicado es individual o de dobles, como por ejemplo Tenis, Natación etc.
        /// </summary>
        /// <param name="_deporteID">ID del deporte a consultar</param>
        /// <returns></returns>
       
        static public string GetFolderName()
        {
            //get current file path 
            string strTempName = System.Web.HttpContext.Current.Request.FilePath; 
            //find the position of the last '/' 
            int intPos = strTempName.LastIndexOf("/");
            //cut off all characters after the last '/' 
            strTempName = strTempName.Substring(1, intPos - 1);
            //find the position of the last '/' in the new string 
            int intPos2 = strTempName.LastIndexOf("/");
            //get the length of the characters between the two '/'
            int intLength = (intPos - 1) - (intPos2 + 1);
            //get the characters between the 2 '/' 
            strTempName = strTempName.Substring(intPos2 + 1, intLength);
            //simply set results name to folder vaiable 
            string folder = strTempName;
            return folder;
        }
        static public int[] FillComboWithNumbers(int _startNumber, int _endNumber)
        {
            List<int> lst = new List<int>();
            for (int i = _startNumber; i <= _endNumber; i++)
            {
                lst.Add(i);
            }
            return lst.ToArray();
        }
        /// <summary>
        /// Obtiene los años del 1950 al año actual más dos.
        /// </summary>
        /// <returns>arreglo de short.</returns>
        static public short[] GetAños()
        {
            List<short> lst = new List<short>();
            for (short i = 1950; i <= (DateTime.Now.Year + 2); i++)
            {
                lst.Add(i);
            }
            return lst.ToArray();
        }
       
        static public string GetImagenInicio(int Tema)
        {
            string returnvalue = "";
            switch (Tema)
            {
                case 41:
                    returnvalue = "~/img/inicio/imagenes_torneos/fucho_1.jpg";

                    break;
                case 42:
                    returnvalue = "~/img/inicio/imagenes_torneos/fucho_2.jpg";
                    break;
                case 43:
                    returnvalue = "~/img/inicio/imagenes_torneos/fucho_3.jpg";
                    break;
                case 44:
                    returnvalue = "~/img/inicio/imagenes_torneos/fucho_4.jpg";
                    break;
                case 45:
                    returnvalue = "~/img/inicio/imagenes_torneos/basket_1.jpg";
                    break;
                case 46:
                    returnvalue = "~/img/inicio/imagenes_torneos/basket_2.jpg";
                    break;
                case 47:
                    returnvalue = "~/img/inicio/imagenes_torneos/beisbol_1.jpg";
                    break;
                //
                case 48:
                    returnvalue = "~/img/inicio/imagenes_torneos/beisbol_2.jpg";
                    break;
                case 49:
                    returnvalue = "~/img/inicio/imagenes_torneos/box_1.jpg";
                    break;
                case 50:
                    returnvalue = "~/img/inicio/imagenes_torneos/natacion_1.jpg";
                    break;
                case 51:
                    returnvalue = "~/img/inicio/imagenes_torneos/ciclismo_1.jpg";
                    break;
                case 52:
                    returnvalue = "~/img/inicio/imagenes_torneos/voleibol_1.jpg";
                    break;
                case 53:
                    returnvalue = "~/img/inicio/imagenes_torneos/voleibol_2.jpg";
                    break;
                case 54:
                    returnvalue = "~/img/inicio/imagenes_torneos/natacion_2.jpg";
                    break;
                case 55:
                    returnvalue = "~/img/inicio/imagenes_torneos/natacion_1.jpg";
                    break;
                case 56:
                    returnvalue = "~/img/inicio/imagenes_torneos/futbol_femenil.jpg";
                    break;
                case 57:
                    returnvalue = "~/img/inicio/imagenes_torneos/futbol_infantil.jpg";
                    break;
                case 58:
                    returnvalue = "~/img/inicio/imagenes_torneos/futbol_juvenil.jpg";
                    break;
                default:
                    returnvalue = "~/img/inicio/bienvenido.jpg";
                    break;

            }
            return returnvalue;
        }
        
       
       
        
        /// <summary>
        /// Confirma si la cadena tiene estructura válida de email.
        /// </summary>
        /// <param name="inputEmail">Cadena de Email</param>
        /// <returns></returns>
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
                script += "window.location='" + _redireccion + "';";
            }
            script += "</script>";
            return script;
        }
        static public int GetAge(DateTime _fechaNacimiento)
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
        /*static public bool EsAdminADCU(string _login)
        {
            bool returnValue = false;
            using (TorneoDataContext context = new TorneoDataContext())
            {
                context.ObjectTrackingEnabled = false;
                var admin = (from us in context.Usuarios
                             where us.login == _login
                             select us.IsAdcuAdmin).SingleOrDefault();
                if (admin != null && admin == 1)
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }*/

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
            
            try
            {
                long id = 0;
                using (MiEscuelaDataContext context = new MiEscuelaDataContext())
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
                    id = log.LogID;
                    if (_esCritico)
                    {
                        //mandar mail.
                        string mail = "Ingreso de bitácora crítico en la aplicación.<br/>&nbsp;<br/>" +
                            "El usuario " + _usuario + " intentó una acción calificada como crítica en el sistema.<br/>&nbsp;<br/>Datos de la bitácora:<br/>";
                        mail += "Fecha: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString() + "<br/>" +
                            "Página: " + _url + "<br/>Error: " + _error + "<br/>Stack: " + (_stack != null ? _stack : "-") + "<br/>InnerException: " +
                            (_innerException != null ? _innerException : "-") + "<br/>Comentario: " + _comentario;

                        MailHelper mh = new MailHelper();
                        mh.EnviarMail(new string[] { "adriancepa@gmail.com" }, true, "Log Crítico en MedikAdmin", null, mail, null,"");
                    } 
                }
                return id;
            }
            catch (System.Data.Linq.ChangeConflictException)
            {
                throw new Exception("No se actualizaron cambios. Error de concurrencia");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar entrada al registro de eventos" + ": " + ex.Message);
            }
        }

        /// <summary>
        /// Regresa una cadena construida con la fecha, hora (hasta milisegundos) y un numero aleatorio.
        /// </summary>
        /// <returns>String, cadena única.</returns>
        static public string GetNombreUnico()
        {
            string nombre = "";
            Random r = new Random();
            nombre += DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() +
                DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + r.Next().ToString();
            return nombre;
        }
        /// <summary>
        /// Regresa la cadena query para añadir a un url si está en modo de consulta remota.
        /// </summary>
        /// <returns></returns>
        static public string IsRemoteStats()
        {
            HttpContext c = HttpContext.Current;
            string ret = "";
            if (!string.IsNullOrEmpty(c.Request.QueryString["remotestats"]) && c.Request.QueryString["remotestats"] == "1")
                ret = "&remotestats=1";
            return ret;

        }
    }
}
