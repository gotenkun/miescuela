using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;

public partial class Ver_Idea : System.Web.UI.Page
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
                long escuelaId = 0;
                if (Request.GetFriendlyUrlSegments().Count > 0)
                {
                    var a = context.Ideas.Where(p => p.IdeaID == long.Parse(Request.GetFriendlyUrlSegments()[0])).SingleOrDefault();
                    if (a != null)
                    {
                        lblTitulo.Text = a.Titulo;
                        lblTitulo2.Text = a.Titulo;
                        lblVotos.Text = a.IdeaVotos.Count.ToString();
                        Rating1.CurrentRating = (int)Math.Round(a.Promedio.HasValue ? a.Promedio.Value: 0);
                        
                        hlCalificarArea.HRef = "/Admin/Calificar-Idea/" + a.IdeaID;
                        string img = "";
                        string comments = "<ul class='media-list'>";
                        if (a.ImagenID.HasValue)
                        {
                            //img += "<div class='col-md-3 col-sm-4 mix category_1 mix_all' style='display: block; opacity: 1;'><div class='mix-inner'>" +
                            //            "<img class='img-responsive' src='/image.aspx?resize=1&crop=1&w=257&cw=257&ch=194&center=1&id=" + av.ImagenID.Value + "' alt=''>" +
                            //           " <div class='mix-details'><h5>" + av.Comentario + "</h5><a class='mix-link'><i class='fa fa-link'></i></a>" +
                            //                "<a class='mix-preview fancybox-button  fancybox.image' href='/image.aspx?id=" + av.ImagenID.Value + "' title='" + a.Nombre + " (" +
                            //                av.Usuario.Nombre + " " + av.Usuario.Apellidos + ")' data-rel='fancybox-button'>" +
                            //                    "<i class='fa fa-search'></i></a></div></div></div>";

                        }
                        img += "<a class='pull-left' href='javascript:;'>" +
                                   "<img class='media-object' src='/image.aspx?resize=1&w=200&id=" + (a.ImagenID.HasValue ? a.ImagenID.Value : -1) + "' alt='64x64' data-src='holder.js/64x64' style='width: 200px; '>" +
                            "</a><div class='media-body' ><h4 class='media-heading'>" + a.Titulo +
                            "</h4><p style='height:70px;'>" + a.Texto + "</p><small>Propuesta por: " + a.Usuario.Nombre + " " + a.Usuario.Apellidos + "</small>" +

                            "<div class='clear:both'></div>";
                        foreach (IdeaVoto av in a.IdeaVotos)
                        {
                           
                           
                            comments += "<li class='media'><a class='pull-left' href='javascript:;'>" +
                                   "<img class='media-object' src='/image.aspx?resize=1&w=64&id=" + (av.Usuario.ImagenID.HasValue ? av.Usuario.ImagenID.Value : -1) + "' alt='64x64' data-src='holder.js/64x64' style='width: 64px; height: 64px;'>" +
                            "</a><div class='media-body' ><img src='/img/star" + av.Calificacion + ".png' /><br><h4 class='media-heading'>" + av.Usuario.Nombre + " " + av.Usuario.Apellidos +
                            "</h4><p style='height:70px;'>" + av.Comentario + "</p>" +

                            "<div class='clear:both'></div></li>";
                        }
                        if (a.IdeaVotos.Count == 0)
                            comments = "No hay comentarios.";
                        litComments.Text = comments + "</ul>"; ;
                        litImgs.Text = img;
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