using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Tutor : System.Web.UI.Page
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
            //claims.
            var id = (ClaimsIdentity)Page.User.Identity;
            long userId = Code.Common.GetUserID((ClaimsIdentity)Page.User.Identity);
            this.lblTitulo.Text = Code.Common.GetUserFullName(id);
            long imgID = Code.Common.GetUserImageID((ClaimsIdentity)Page.User.Identity);
            long instID = Code.Common.GetInstitucionID((ClaimsIdentity)Page.User.Identity);
            lblNombre.Text = lblTitulo.Text;
            if (imgID > 0)
                this.imgUser.Src = "/image.aspx?resize=1&w=125&id=" + imgID;
            //hijos
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var hs = context.TutorUsuarioIDs.Where(p => p.UsuarioTutorID == userId);
                string hijos = "";
                foreach (var h in hs)
                {
                    string resumen = "ras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis.";
                    var grupo = h.Usuario1.UsuarioGrupos.SingleOrDefault();
                    long grupoID = grupo != null ? grupo.GrupoID : -1;
                    long imageID = h.Usuario1.ImagenID.HasValue ? h.Usuario1.ImagenID.Value : -1;
                    long escuelaID = grupo != null ? grupo.Grupo.CctID : -1;
                    string nombre = h.Usuario1.Nombre + " " + h.Usuario1.Apellidos;
                    hijos += " <div class='panel panel-info'><div class='panel-heading'><h3 class='panel-title'>" + nombre + "</h3>" +
                            "</div>	<div class='panel-body'>" +

                            "<ul class='media-list'><li class='media'><a class='pull-left' href='javascript:;'>" +
                            "<img class='media-object' src='/image.aspx?resize=1&w=100&id=" + imageID + "' alt='64x64' data-src='holder.js/64x64' style='width: 100px; height: 100px;'>" +
                            "</a><div class='media-body'><h4 class='media-heading'>" + (grupo != null ? (grupo.Grupo.Grado.ToString() + "°" + grupo.Grupo.Grupo1) : "") +
                            "</h4><p>" + resumen + "</p>" + 
                             "<a href='/Escuela/" + escuelaID + "' class='btn green'>Ver Escuela</a>&nbsp;" +
                    "<a href='/Admin/Grupo/" + grupoID + "' class='btn blue'>Ver Grupo</a>&nbsp;" +
                    "<a href='/Admin/Tareas/" + h.Usuario1.UsuarioID + "' class='btn red'>Ver Tareas</a>"+                            
                            "</li></ul></div></div>";


                         
										
                                        //<h3>GRUPO</h3><p>" +resumen +"</p><p>" +
                   
                }
               
                MejoresIdeas1.CctID = instID;
                MejoresIdeas1.NumeroIdeas = 5;
                UltimasIdeas.CctID = instID;
                UltimasIdeas.NumeroIdeas = 5;
                UsuariosMasActivos.CctID = instID;
                UsuariosMasActivos.NumeroResultados = 5;
                UsuariosMenosActivos.CctID = instID;
                UsuariosMenosActivos.NumeroResultados = 5;
                litHijos.Text = hijos;
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}