using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;

public partial class admin_Direccion_Grupo : System.Web.UI.Page
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
                if (Request.GetFriendlyUrlSegments().Count > 0)
                {
                    var a = context.Grupos.Where(p => p.GrupoID == long.Parse(Request.GetFriendlyUrlSegments()[0])).SingleOrDefault();
                    if (a == null)
                        Response.Redirect("/Admin/Direccion/Inicio");
                    else
                    {
                        cmbGrado.SelectedValue = a.Grado.ToString();
                        cmbGrupo.SelectedValue = a.Grupo1.ToString();
                    }
                }
                else
                {
                    lblTitulo.Text = "Crear Alumno";
                }
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}