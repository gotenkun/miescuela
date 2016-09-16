using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using System.Security.Claims;

public partial class admin_Tareas : System.Web.UI.Page
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
                if (Page.User.IsInRole("Alumno") || Page.User.IsInRole("Tutor"))
                {
                    long id = 0;
                    if (Page.User.IsInRole("Alumno"))
                        id = Code.Common.GetUserID((ClaimsIdentity)Page.User.Identity);
                    else
                        id = long.Parse(Request.GetFriendlyUrlSegments()[0]);
                    var usuario = context.Usuarios.Where(p=>p.UsuarioID ==id ).SingleOrDefault();
                    var docente = usuario.UsuarioGrupos.First().Grupo.DocenteGrupos.First().Usuario;
                    lblNombre.Text = docente.Nombre + " " + docente.Apellidos;
                    lblNombreTarea.Text = usuario.Nombre + " " + usuario.Apellidos;
                    long imgID = usuario.UsuarioGrupos.First().Grupo.DocenteGrupos.First().Usuario.ImagenID.HasValue ? usuario.UsuarioGrupos.First().Grupo.DocenteGrupos.First().Usuario.ImagenID.Value : -1;
                    imgUser.Src = "/image.aspx?resize=1&w=150&id=" + imgID;
                    var tareas = context.Tareas.Where(p => p.UsuarioID == usuario.UsuarioID || p.GrupoID == usuario.UsuarioGrupos.First().GrupoID).Where(p=>p.FechaEntrega>=DateTime.Now);
                    foreach (Tarea t in tareas)
                    {
                        litTareas.Text += "<div class='portlet light'>"+
						"<div class='portlet-title'>"+
						"	<div class='caption'>"+
							"	<i class='icon-puzzle font-grey-gallery'></i>"+
						"		<span class='caption-subject bold font-grey-gallery uppercase'>"+
						"		Tareas a Entregar </span>"+
							"	<span class='caption-helper'></span>"+
						"	</div>"+
						"	<div class='tools'>"+
						"		<a href='' class='collapse'>"+
						"		</a>"+
						"</div>"+
						"</div>"+
						"<div class='portlet-body'>"+
						"	<h4>Para: " + t.FechaEntrega.ToLongDateString() + ", Tipo: " + (t.GrupoID.HasValue ? "Grupal" : "Individual") + "</h4>"+
						"	<p>"+
						        t.Texto +
						"	</p>"+
                        "</div>" +
					"</div>";
                     
                    }
                    var tareasP = context.Tareas.Where(p => p.UsuarioID == usuario.UsuarioID || p.GrupoID == usuario.UsuarioGrupos.First().GrupoID).Where(p => p.FechaEntrega < DateTime.Now).Take(10);
                    foreach (Tarea t in tareasP)
                    {
                        litTareas.Text += "<div class='portlet light'>" +
                        "<div class='portlet-title'>" +
                        "	<div class='caption'>" +
                            "	<i class='icon-puzzle font-grey-gallery'></i>" +
                        "		<span class='caption-subject bold font-grey-gallery uppercase'>" +
                        "		Últimas 10 Tareas </span>" +
                            "	<span class='caption-helper'></span>" +
                        "	</div>" +
                        "	<div class='tools'>" +
                        "		<a href='' class='collapse'>" +
                        "		</a>" +
                        "</div>" +
                        "</div>" +
                        "<div class='portlet-body'>" +
                        "	<h4>Para: " + t.FechaEntrega.ToLongDateString() + ", Tipo: " + (t.GrupoID.HasValue ? "Grupal" : "Individual") + "</h4>" +
                        "	<p>" +
                                t.Texto +
                        "	</p>" +
                        "</div>" +
                    "</div>";

                    }
                }
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}