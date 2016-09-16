using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{

    public Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string GetAreas(long id)
    {
        string info = "";
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {

                if (id > 0)
                {
                    var c = (from a in context.CctActivos
                             where a.CctID == id
                             select a).SingleOrDefault();
                    if (c != null)
                    {
                        var a1 = context.Areas.Where(p => p.CctID == c.CctID);
                        foreach (Area a in a1)
                        {
                            info += a.Nombre + "," + a.Cat_TipoArea.Nombre + "," + a.Descripcion + "," + a.AreaVotos.Count + "," + (a.Calificacion.HasValue ? a.Calificacion.Value.ToString() : "-") + Environment.NewLine;
                        }
                    }
                }
                else
                {
                    info = "Error - Especifique escuela";
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
        return info;
    }
    [WebMethod]
    public string GetAreaVotos(long id)
    {
        string info = "";
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {

                if (id > 0)
                {
                    var c = (from a in context.AreaVotos
                             where a.AreaID == id
                             select a);


                    foreach (AreaVoto a in c)
                    {
                        info += a.Usuario.Nombre + " " + a.Usuario.Apellidos + "," + a.Fecha.ToShortDateString() + "," + a.Calificacion.ToString() + "," + a.Comentario + "," + (a.ImagenID.HasValue? (System.Configuration.ConfigurationManager.AppSettings["baseURL"] + "image.aspx?id" + a.ImagenID.Value) : "-1") + Environment.NewLine;
                    }

                }
                else
                {
                    info = "Error - Especifique escuela";
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
        return info;
    }

    [WebMethod]
    public string GetIdeas(long id)
    {
        string info = "";
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {

                if (id > 0)
                {
                    var c = (from a in context.CctActivos
                             where a.CctID == id
                             select a).SingleOrDefault();
                    if (c != null)
                    {
                        var a1 = context.Ideas.Where(p => p.CctID == c.CctID);
                        foreach (Idea a in a1)
                        {
                            info += a.Titulo + "," + a.Texto + "," + a.Fecha.ToShortDateString() + "," + a.Usuario.Nombre + " " + a.Usuario.Apellidos + "," + a.IdeaVotos.Count + "," + (a.Promedio.HasValue ? a.Promedio.Value.ToString() : "-") + Environment.NewLine;
                        }
                    }
                }
                else
                {
                    info = "Error - Especifique escuela";
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
        return info;
    }

    [WebMethod]
    public string GetIdeaVotos(long id)
    {
        string info = "";
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {

                if (id > 0)
                {
                    var c = (from a in context.IdeaVotos
                             where a.IdeaID == id
                             select a);

                 
                    foreach (IdeaVoto a in c)
                    {
                        info += a.Usuario.Nombre + " " + a.Usuario.Apellidos + "," + a.Fecha.ToShortDateString() + "," + a.Calificacion.ToString() + "," + a.Comentario + "," + Environment.NewLine;
                    }

                }
                else
                {
                    info = "Error - Especifique escuela";
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
        return info;
    }
    [WebMethod]
    public string InfoEscuela(string clave)
    {
        string info = "";
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var c = from a in context.CctActivos
                        select a;
                if (clave != "")
                    c = c.Where(p => p.Clave == clave);
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
    [WebMethod ]
    public string InfoEscuelaId(long id)
    {
        string info = "";
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var c = from a in context.CctActivos
                        select a;
                if (id > 0)
                    c = c.Where(p => p.CctID == id);
                foreach (CctActivo a in c)
                {
                    //info += a.Clave + "," + a.Nombre + "," + a.Nivel + "," + a.Domicilio + "," + a.EntreCalle + "," + a.YCalle + "," + a.NombreColonia + "," + a.NombreLocalidad + "," + a.NombreMunicipio + "," + a.NombreSostenimiento
                    //    + "," + a.CodigoPostal + "," + a.Correo + "," + a.Director +
                    //    Environment.NewLine;
                    info += generateCsvFromLinqQueryable(c, ",", " ");
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
        return info;
    }

    [WebMethod]
    public string IndicadoresEscuelaId(long id)
    {
        string info = "";
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var c = from a in context.CctActivos
                        select a;
                if (id > 0)
                    c = c.Where(p => p.CctID == id);
                foreach (CctActivo a in c)
                {
                    var indicadores = context.CctIndicadores.Where(p => p.Clave == a.Clave);
                    //info += a.Clave + "," + a.Nombre + "," + a.Nivel + "," + a.Domicilio + "," + a.EntreCalle + "," + a.YCalle + "," + a.NombreColonia + "," + a.NombreLocalidad + "," + a.NombreMunicipio + "," + a.NombreSostenimiento
                    //    + "," + a.CodigoPostal + "," + a.Correo + "," + a.Director +
                    //    Environment.NewLine;
                    info += generateCsvFromLinqQueryable(indicadores, ",", " ");
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
        return info;
    }
    [WebMethod]
    public string EstadisticaEscuelaId(long id)
    {
        string info = "";
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var c = from a in context.CctActivos
                        select a;
                if (id > 0)
                    c = c.Where(p => p.CctID == id);
                foreach (CctActivo a in c)
                {
                    var indicadores = context.CctEstadisticas.Where(p => p.Clave == a.Clave);
                    //info += a.Clave + "," + a.Nombre + "," + a.Nivel + "," + a.Domicilio + "," + a.EntreCalle + "," + a.YCalle + "," + a.NombreColonia + "," + a.NombreLocalidad + "," + a.NombreMunicipio + "," + a.NombreSostenimiento
                    //    + "," + a.CodigoPostal + "," + a.Correo + "," + a.Director +
                    //    Environment.NewLine;
                    info += generateCsvFromLinqQueryable(indicadores, ",", " ");
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
        return info;
    }

    public string generateCsvFromLinqQueryable(IQueryable query, string delimiter, string replaceDelimiterInDataWith)
    {
        PropertyInfo[] rowPropertyInfos = null;
        rowPropertyInfos = query.ElementType.GetProperties();

        string result = "";
        foreach (var myObject in query)
        {
            foreach (PropertyInfo info in rowPropertyInfos)
            {
                if (info.CanRead)
                {
                    string tmp = Convert.ToString(info.GetValue(myObject, null));
                    if (!tmp.StartsWith("System."))
                    {
                        if (!String.IsNullOrEmpty(tmp))
                        {
                            tmp.Replace(delimiter, replaceDelimiterInDataWith);
                        }
                        result += tmp + delimiter; 
                    }
                }
            }
            result += "\r\n";
        }
        return result;
    }
}

