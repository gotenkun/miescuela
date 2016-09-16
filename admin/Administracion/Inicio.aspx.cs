using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using NReco.PdfGenerator;

public partial class admin_Administracion_Inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Cargar();
    }
    private void Cargar()
    {
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var i = from c in context.CctActivos
                           select c;
                string info = "Total Escuelas: " + i.Count() + "<br/><br/>" +
                    "Escuelas Preescolar: " + i.Where(p => p.Nivel == "PREESCOLAR").Count() + "<br/><br/>" +
                    "Escuelas Primaria: " + i.Where(p => p.Nivel == "PRIMARIA").Count() + "<br/><br/>" +
                    "Escuelas Secundaria: " + i.Where(p => p.Nivel == "SECUNDARIA").Count() + "<br/><br/>" +
                    "Escuelas Bachillerato: " + i.Where(p => p.Nivel == "BACHILLERATO").Count() + "<br/><br/>";
                lblGlobal.Text = info;
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnMasActivos_Click(object sender, EventArgs e)
    {
        string formato = "<table border='1'><tr><td>Nombre</td><td>ClaveEscuela</td><td>Acciones</td></tr>";
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var usuarios = (from u in context.Usuarios
                                where u.CctID.HasValue
                                select new
                                {
                                    UsuarioID = u.UsuarioID,
                                    Nombre = u.Nombre + " " + u.Apellidos,
                                    Escuela = context.CctActivos.Where(p=>p.CctID == u.CctID).Single().Clave,
                                    ImagenID = u.ImagenID.HasValue ? u.ImagenID : -1,
                                    Acciones = u.Ideas.Count + u.IdeaVotos.Count + u.AreaVotos.Count
                                }).OrderByDescending(p => p.Acciones).Take(1000);

                foreach (var u in usuarios)
                {
                    formato += "<tr><td>" + u.Nombre + "</td><td>" + u.Escuela + "</td><td>" + u.Acciones + "</td></tr>";
                }
               

            }
        }
        catch (Exception)
        {

            throw;
        }
        formato += "</table>";
        Response.Charset = Encoding.UTF8.EncodingName;
        Response.ContentEncoding = Encoding.Unicode;
        var htmlToPdf = new HtmlToPdfConverter();
        Response.ContentType = "application/pdf";
        htmlToPdf.GeneratePdf(formato, null, Response.OutputStream);
        Response.End();
    }
}