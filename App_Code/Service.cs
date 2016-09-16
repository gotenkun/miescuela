using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService {

    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public string InfoEscuela(string _clave)
    {
        string info = "";
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var c = from a in context.CctActivos
                            select a;
                if (_clave != "")
                    c = c.Where(p => p.Clave == _clave);
                foreach (CctActivo a in c)
                {
                    info += a.Clave + "," + a.Nombre + "," + a.Nivel + "," + a.Domicilio + "," + a.EntreCalle + "," + a.YCalle + "," + a.NombreColonia + "," + a.NombreLocalidad + "," + a.NombreMunicipio + "," + a.NombreSostenimiento
                        + "," + a.CodigoPostal + "," + a.Correo + "," + a.Director +
                        Environment.NewLine;
                }
            }
        }
        catch (Exception)
        {
            
            throw;
        }
        return info;
    }
}
