using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;

public partial class admin_Direccion_Docente : System.Web.UI.Page
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
                    var a = context.Usuarios.Where(p => p.UsuarioID == long.Parse(Request.GetFriendlyUrlSegments()[0]) && p.EsDocente).SingleOrDefault();
                    if (a == null)
                        Response.Redirect("/Admin/Direccion/Inicio");
                    else
                    {
                        txtNombre.Text = a.Nombre;
                        txtPaterno.Text = a.Apellidos;
                        lblTitulo.Text = "Editar: " + a.Nombre + " " + a.Apellidos;
                        if (a.ImagenID.HasValue)
                            imgActual.ImageUrl = "/image.aspx?id=" + a.ImagenID.Value;
                        var grupos = from g in context.Grupos
                                     where g.CctID == a.CctID.Value
                                     select new
                                     {
                                         ID = g.GrupoID,
                                         Grupo = g.Grado + "°-" + g.Grupo1
                                     };
                        lstGrupos.DataTextField = "Grupo";
                        lstGrupos.DataValueField = "ID";
                        lstGrupos.DataSource = grupos;
                        lstGrupos.DataBind();
                       
                        foreach (DocenteGrupo ug in a.DocenteGrupos)
                        {
                            foreach (ListItem item in lstGrupos.Items)
                            {
                                if (item.Text == ug.Grupo.Grado + "°-" + ug.Grupo.Grupo1)
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    lblTitulo.Text = "Crear Docente";
                }
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}