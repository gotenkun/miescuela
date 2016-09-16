using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Inicio : System.Web.UI.Page
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
            if (Page.User.IsInRole("Alumno"))
            {
                var id = (ClaimsIdentity)Page.User.Identity;
                long uid= Code.Common.GetUserID((ClaimsIdentity)Page.User.Identity);
                this.lblTitulo.Text = Code.Common.GetUserFullName(id);
                long imgID = Code.Common.GetUserImageID((ClaimsIdentity)Page.User.Identity);
                lblNombre.Text = lblTitulo.Text;
                
                if (imgID > 0)
                    this.imgUser.Src = "/image.aspx?resize=1&w=125&id=" + imgID;
                using (MiEscuelaDataContext context = new MiEscuelaDataContext())
                {
                    var grupo = context.UsuarioGrupos.Where(p => p.UsuarioID == uid).SingleOrDefault();
                    if (grupo != null)
                    {
                        lblNombreEscuela.Text = grupo.Grupo.CctActivo.Nombre;
                        lblGrupo.Text = grupo.Grupo.Nivel +" " + grupo.Grupo.Grado.ToString() + "°-" + grupo.Grupo.Grupo1;
                        hlCalificarEscuela.HRef = "/Areas/" + grupo.Grupo.CctID;
                        this.hlVerEscuela.HRef = "/Escuela/" + grupo.Grupo.CctID;
                        if (grupo.Grupo.CctActivo.ImagenID.HasValue)
                            imgEscuela.Src = "/image.aspx?resize=1&w=200&id=" + grupo.Grupo.CctActivo.ImagenID.Value;
                        MejoresIdeas.CctID = grupo.Grupo.CctID;
                        MejoresIdeas.NumeroIdeas = 5;
                        MejoresIdeas1.CctID = grupo.Grupo.CctID;
                        MejoresIdeas1.NumeroIdeas = 5;
                        UltimasIdeas.CctID = grupo.Grupo.CctID;
                        UltimasIdeas.NumeroIdeas = 5;
                        UsuariosMasActivos.CctID = grupo.Grupo.CctID;
                        UsuariosMasActivos.NumeroResultados = 5;
                        UsuariosMenosActivos.CctID = grupo.Grupo.CctID;
                        UsuariosMenosActivos.NumeroResultados = 5;
                    }
                }
            }
            if (Page.User.IsInRole("Tutor"))
                Response.Redirect("/Admin/Tutor");
            if (Page.User.IsInRole("Docente"))
                Response.Redirect("/Admin/Docente");
            if (Page.User.IsInRole("EscuelaAdmin"))
                Response.Redirect("/Admin/Direccion/Inicio");
            if (Page.User.IsInRole("Personal"))
                Response.Redirect("/Admin/Personal");
            if (Page.User.IsInRole("SuperAdmin"))
                Response.Redirect("/Admin/Administracion/Inicio");
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}