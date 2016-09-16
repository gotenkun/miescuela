using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using System.Security.Claims;

public partial class admin_Grupo : System.Web.UI.Page
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
            long grupoID = 0;
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                if (Request.GetFriendlyUrlSegments().Count > 0)
                {
                    grupoID = long.Parse(Request.GetFriendlyUrlSegments()[0]);
                }
                else
                {
                    //obtener
                    long uid = Code.Common.GetUserID((ClaimsIdentity)Page.User.Identity);
                    grupoID = context.UsuarioGrupos.Where(p => p.UsuarioID == uid).Single().GrupoID;
                }

                var grupo = context.Grupos.Where(p => p.GrupoID == grupoID).SingleOrDefault();
                if (grupo != null)
                {
                    string lit = "";
                    lblGrupo.Text = grupo.Nivel + " " + grupo.Grado.ToString() + "°-" + grupo.Grupo1;
                    var docente = grupo.DocenteGrupos.Where(p => p.GrupoID == grupoID).FirstOrDefault();
                    if (docente != null)
                    {
                        lblDocente.Text = " <div class='col-md-3'> <div class='meet-our-team'><h4>" + docente.Usuario.Nombre + " " + docente.Usuario.Apellidos + "</h4>" +
                            "<img src='/image.aspx?resize=1&w=252&id=" + (docente.Usuario.ImagenID.HasValue ? docente.Usuario.ImagenID.Value : -1) + "' alt='' class='img-responsive'>" +
                                "<div class='team-info text-center'><a href='#' class='btn blue'>Enviar Mensaje</a> </div>    </div> </div>";
                    }
                    lblDocente.Text += "<div class='col-md-9'><h4>Escuela: " + grupo.CctActivo.Nombre + " (" + grupo.CctActivo.Nivel + ")<br/><br/>Alumnos: " + grupo.UsuarioGrupos.Count + " </h4>"+
                        (Page.User.IsInRole("Docente") ? "<a href='/Admin/Dejar-Tarea-Grupal/" + grupoID + "' class='btn blue'>Dejar Tarea Grupal</a> <a href='#' class='btn green'>Aviso Padres Familia</a>" : "") + 
                        "</div>";
                    lit+="<div style='clear:both'></div><hr/> <div class='headline'><h3>Alumnos del Grupo</h3></div>";
                    foreach (UsuarioGrupo u in grupo.UsuarioGrupos)
                    {
                        lit += " <div class='col-md-3'> <div class='meet-our-team'><h4>" + u.Usuario.Nombre + " " + u.Usuario.Apellidos + "</h4>" +
                            "<img src='/image.aspx?resize=1&w=252&id=" + (u.Usuario.ImagenID.HasValue ? u.Usuario.ImagenID.Value : -1) + "' alt='' class='img-responsive'>" +
                                "<div class='team-info text-center'><a href='#' class='btn blue'>Enviar Mensaje</a> "+
                                (Page.User.IsInRole("Docente") ? "<br/><a href='#' class='btn blue text-center'>Dejar Tarea</a>" : "") + 
                                "</div>    </div> </div>";
                    }
                    litGrupo.Text = lit;
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}