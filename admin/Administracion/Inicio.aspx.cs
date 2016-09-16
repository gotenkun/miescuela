using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
}