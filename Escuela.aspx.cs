using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using System.Text;
using System.IO;

public partial class Escuela : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request.GetFriendlyUrlSegments().Count() >0 )
                Cargar();
        }
    }
    public string RenderControl(Control ctrl)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter tw = new StringWriter(sb);
        HtmlTextWriter hw = new HtmlTextWriter(tw);

        ctrl.RenderControl(hw);
        return sb.ToString();
    }
    private void Cargar()
    {
    
            string id = Request.GetFriendlyUrlSegments()[0];
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var c = context.CctActivos.Where(p => p.CctID == long.Parse(id)).SingleOrDefault();
                if (c != null)
                {
                    lblNombre.Text = c.Nombre + "(" + c.Nivel + ")";
                    Page.Title = "#MIESCUELA - " + lblNombre.Text;

                    hdLat.Value = c.Latitud.ToString();
                    hdLon.Value = c.Longitud.ToString();
                    if (c.ImagenID.HasValue)
                        imgPrincipal.Src = "/image.aspx?crop=1&cw=800&ch=250&center=1&id=" + c.ImagenID.Value;
                    //general
                    string info = "";
                    info += "<h2>Clave: " + c.Clave + "</h2><h2>Domicilio</h2>" + c.Domicilio + ", entre " + c.EntreCalle + " y " + c.YCalle + "<br />" +
                        c.NombreColonia + ", " + c.NombreLocalidad + ", " + c.NombreMunicipio + ". CP: " + c.CodigoPostal + "<br/><h2>Contacto</h2>" +
                        "Director: " + c.Director + "<br/> Teléfono: " + c.Telefono + ", email: " + c.Correo + "<br/><h2>Tipo de Escuela</h2>" +
                        "Nivel: " + c.Nivel + " Programa: " + c.Programa + " Sostenimiento: " + c.NombreSostenimiento;
                    lblInformacionGeneral.Text = info; 

                    //areas
                    var areas = context.Areas.Where(p => p.CctID == c.CctID);
                    string area = "<h2>" + areas.Count() + " áreas</h2>";
                    foreach(Area a in areas)
                    {
                        AjaxControlToolkit.Rating rating = new AjaxControlToolkit.Rating();
                        rating.ID = "ratingArea" + a.AreaID;
                        rating.MaxRating = 5;
                        rating.ReadOnly = true;
                        rating.CssClass = "ratingStar";
                        rating.StarCssClass = "Star";
                        rating.CurrentRating = (int)Math.Round(a.Calificacion.Value);
                        rating.FilledStarCssClass = "FilledStar";
                        rating.EmptyStarCssClass = "Empty";
                        rating.WaitingStarCssClass = "WaitingStar";
                        pnlAreas.Controls.Add(new LiteralControl("<a href='/Ver-Area/" + a.AreaID + "'>" + a.Nombre + "</a>&nbsp;&nbsp;&nbsp;"));
                        pnlAreas.Controls.Add(rating);
                        pnlAreas.Controls.Add(new LiteralControl("<br/>"));
                    }
                    //personal
                    //director
                    var dir = context.Usuarios.Where(p => p.EsDirector && p.CctID == c.CctID);
                    string dirs = "<ul class='media-list'>";
                    foreach (Usuario u in dir)
                    {
                         long imageID = u.ImagenID.HasValue ? u.ImagenID.Value : -1;
                         dirs += "<li class='media'><a class='pull-left' href='javascript:;'>" +
                             "<img class='media-object' src='/image.aspx?resize=1&w=100&id=" + imageID + "' alt='64x64' data-src='holder.js/64x64' style='width: 100px; height: 100px;'>" +
                             "</a><div class='media-body' ><h4 class='media-heading'>" + u.Nombre + " " + u.Apellidos +
                             "</h4><p style='height:70px;'>Dirección</p>" +

                             "<div class='clear:both'></div></li>";
                    }
                    //Personal
                    var pers = context.Usuarios.Where(p => (p.EsPersonal || p.EsDocente) && p.CctID == c.CctID);
                    foreach (Usuario u in pers)
                    {
                        long imageID = u.ImagenID.HasValue ? u.ImagenID.Value : -1;
                        string puesto = "";
                        if (u.EsDocente)
                            puesto = "Docente";
                        else
                            puesto = "Personal";
                        dirs += "<li class='media'><a class='pull-left' href='javascript:;'>" +
                            "<img class='media-object' src='/image.aspx?resize=1&w=100&id=" + imageID + "' alt='64x64' data-src='holder.js/64x64' style='width: 100px; height: 100px;'>" +
                            "</a><div class='media-body'><h4 class='media-heading'>" + u.Nombre + " " + u.Apellidos +
                            "</h4><p style='height:90px;'>" + puesto + "</p>" +

                            "</li>";
                    }
                    litPersonal.Text = dirs + "</ul>";
                    lblAreas.Text = area;
                    hlVerAreas.HRef = "/Areas/" + c.CctID;
                    //Noticias
                    Noticias.CctID = c.CctID;

                    //stats
                    var stats = context.CctEstadisticas.Where(p => p.Clave == c.Clave).FirstOrDefault();
                    var inds = context.CctIndicadores.Where(p => p.Clave == c.Clave).FirstOrDefault();
                    string stat = "";
                    if (stats != null && inds != null)
                    {
                        stat="<div class='row'><div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'><div class='dashboard-stat red'><div class='visual'><i class='fa fa-users'></i>"+
                                "</div>	<div class='details'><div class='number'>" + stats.MatriculaTotal.Value.ToString() + "</div><div class='desc'>"+
																	 "Alumnos</div></div><a class='more' href='/Estadistica/" + c.CctID + "'>"+
															"Ver más <i class='m-icon-swapright m-icon-white'></i></a></div></div><div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'>"+										"<div class='dashboard-stat red'><div class='visual'><i class='fa fa-shopping-cart'></i></div>"+
															"<div class='details'>"+
																"<div class='number'>"+
																	 stats.Docentes + 
																"</div>"+
																"<div class='desc'>"+
																	 "Docentes"+
																"</div>"+
															"</div>"+
                                                            "<a class='more' href='/Estadistica/" + c.CctID + "'>" +
                                                            "Ver más <i class='m-icon-swapright m-icon-white'></i>" +
															"</a>"+
														"</div>"+
													"</div>"+
													"<div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'>"+
													"	<div class='dashboard-stat red'>"+
													"		<div class='visual'>"+
                                                    "			<i class='fa fa-check-square'></i>" +
													"		</div>"+
													"		<div class='details'>"+
													"			<div class='number'>"+
                                                    (inds.EficienciaTerminal != null ? inds.EficienciaTerminal.Value.ToString() : "-") + 
													"			</div>"+
													"			<div class='desc'>"+
													"				 Eficiencia Terminal"+
													"			</div>"+
													"		</div>"+
                                                    "		<a class='more' href='/Estadistica/" + c.CctID + "'>" +
                                                    "		Ver más  <i class='m-icon-swapright m-icon-white'></i>" +
													"		</a>"+
													"	</div>"+
													"</div>"+
													"<div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'>"+
													"	<div class='dashboard-stat red'>"+
													"		<div class='visual'>"+
													"			<i class='fa fa-arrow-circle-down'></i>"+
													"		</div>"+
													"		<div class='details'>"+
													"			<div class='number'>"+
													            inds.Reprobacion + 
													"			</div>"+
													"			<div class='desc'>"+
													"				 Reprobación"+
													"		</div>"+
													"		</div>"+
                                                    "		<a class='more' href='/Estadistica/" + c.CctID + "'>" +
													"		Ver más <i class='m-icon-swapright m-icon-white'></i>"+
													"		</a>"+
													"	</div>"+
													"</div>"+
												"</div>";
                    }
                    lblEstadisticas.Text = stat;
                }
            }
       
    }
}