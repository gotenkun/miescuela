using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using System.Security.Claims;
using System.IO;

public partial class admin_Calificar_Idea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Cargar();
        }
    }
    private void Cargar()
    {
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                if (Request.GetFriendlyUrlSegments().Count > 0)
                {
                    var idea = context.Ideas.Where(p => p.IdeaID == long.Parse(Request.GetFriendlyUrlSegments()[0])).SingleOrDefault();
                    if (idea != null)
                    {
                        lblArea.Text = idea.Titulo;
                        lblNombre.Text = idea.Titulo;
                        lblTexto.Text = idea.Texto + "<br /><br/><small>Propuesta por: " + idea.Usuario.Nombre + " " + idea.Usuario.Apellidos + "</small>";
                       // lblTitulo.Text = area.Nombre;
                        lblTitulo1.Text = idea.Titulo;
                        hdID.Value = idea.IdeaID.ToString();
                        hlCancelar.HRef = "/Ver-Idea/" + hdID.Value;
                    }
                }
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            if (cmbCalificacion.SelectedIndex == 0)
            {
                lblError.Text = "Debes seleccionar tu calificación";
                
            }else
            {
                using (MiEscuelaDataContext context = new MiEscuelaDataContext())
                {
                    IdeaVoto av = new IdeaVoto();
                    av.IdeaID = long.Parse(hdID.Value);
                    av.Calificacion = (short)(cmbCalificacion.SelectedIndex);
                    av.Comentario = txtComentarios.Text;
                    av.Fecha = DateTime.Now;
                    av.UsuarioID = Code.Common.GetUserID((ClaimsIdentity)Page.User.Identity);
                    //imagen
                 
                    context.IdeaVotos.InsertOnSubmit(av);
                    context.SubmitChanges();
                    //promedios
                    var avs = context.IdeaVotos.Where(p => p.IdeaID == av.IdeaID);
                    int calificacion = (int)(Math.Round((decimal)avs.Sum(p => p.Calificacion) / avs.Count()));
                    av.Idea.Promedio= (short)calificacion;
                    context.SubmitChanges();
                }
                Response.Redirect("/Ver-Idea/" + hdID.Value);
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}