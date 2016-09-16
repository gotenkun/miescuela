using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;

public partial class admin_Direccion_Inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Cargar();

    }
    private void Cargar()
    {
        if (Page.User.IsInRole("EscuelaAdmin") || Page.User.IsInRole("SuperAdmin"))
        {

            try
            {
                var id = (ClaimsIdentity)Page.User.Identity;
                long uid = Code.Common.GetUserID((ClaimsIdentity)Page.User.Identity);
               
                long imgID = Code.Common.GetUserImageID((ClaimsIdentity)Page.User.Identity);
                
                using (MiEscuelaDataContext context = new MiEscuelaDataContext())
                {
                    var u = context.Usuarios.Where(p => p.UsuarioID == uid).SingleOrDefault();
                    long cctID = 0;
                    if (Page.User.IsInRole("EscuelaAdmin"))
                        cctID = u.CctID.Value;
                    else
                        cctID = long.Parse(Request.GetFriendlyUrlSegments()[0]);
                    var c = context.CctActivos.Where(p=> p.CctID == cctID).FirstOrDefault();
                    if (u != null && c != null)
                    {
                        lblNombreEscuela.Text = c.Nombre;
                        hlCalificarEscuela.HRef = "/Areas/" + c.CctID;
                        hlEditarEscuela.HRef = "/Admin/Direccion/Editar/" + c.CctID;
                        this.hlVerEscuela.HRef = "/Escuela/" + c.CctID;
                        if (c.ImagenID.HasValue)
                            imgEscuela.Src = "/image.aspx?resize=1&w=200&id=" + c.ImagenID.Value;
                        MejoresIdeas.CctID = c.CctID;
                        MejoresIdeas.NumeroIdeas = 5;
                        UltimasIdeas.CctID = c.CctID;
                        UltimasIdeas.NumeroIdeas = 5;
                        ManageUsers.CctID = c.CctID;
                        //alumnos
                        var alumnos = from a in context.Usuarios
                                      where a.EsAlumno && a.CctID == c.CctID
                                      select new
                                      {
                                          UsuarioID = a.UsuarioID,
                                          Nombre = a.Apellidos + " " + a.Nombre,
                                          Grupo = a.UsuarioGrupos.First().Grupo.Grado + "-" + a.UsuarioGrupos.First().Grupo.Grupo1
                                      };
                                          
                        grd.DataSource = alumnos;
                        grd.DataBind();
                        if (alumnos.Count() > 0)
                        {
                            grd.HeaderRow.TableSection = TableRowSection.TableHeader;
                            grd.UseAccessibleHeader = true;
                            if (grd.ShowFooter)
                                grd.FooterRow.TableSection = TableRowSection.TableFooter;
                        }
                        //grupos
                        var gs = from a in context.Grupos
                                      where  a.CctID == c.CctID
                                      select new
                                      {
                                          GrupoID = a.GrupoID,
                                          Grado = a.Grado,
                                          Grupo = a.Grupo1
                                      };

                        grdGrupos.DataSource = gs;
                        grdGrupos.DataBind();
                        if (gs.Count() > 0)
                        {
                            grdGrupos.HeaderRow.TableSection = TableRowSection.TableHeader;
                            grdGrupos.UseAccessibleHeader = true;
                            if (grdGrupos.ShowFooter)
                                grdGrupos.FooterRow.TableSection = TableRowSection.TableFooter;
                        }
                        //docentes
                        var docentes = from a in context.Usuarios
                                      where a.EsDocente && a.CctID == c.CctID
                                      select new
                                      {
                                          UsuarioID = a.UsuarioID,
                                          Nombre = a.Apellidos + " " + a.Nombre,
                                          Grupo = a.UsuarioGrupos.First().Grupo.Grado + "-" + a.UsuarioGrupos.First().Grupo.Grupo1
                                      };

                        grdDocente.DataSource = docentes;
                        grdDocente.DataBind();
                        if (docentes.Count() > 0)
                        {
                            grdDocente.HeaderRow.TableSection = TableRowSection.TableHeader;
                            grdDocente.UseAccessibleHeader = true;
                            if (grdDocente.ShowFooter)
                                grdDocente.FooterRow.TableSection = TableRowSection.TableFooter;
                        }
                        //docentes
                        var tutores = from a in context.Usuarios
                                       where a.EsPadreFamilia && a.CctID == c.CctID
                                       select new
                                       {
                                           UsuarioID = a.UsuarioID,
                                           Nombre = a.Apellidos + " " + a.Nombre,
                                           
                                       };

                        grdTutor.DataSource = tutores;
                        grdTutor.DataBind();
                        if (tutores.Count() > 0)
                        {
                            grdTutor.HeaderRow.TableSection = TableRowSection.TableHeader;
                            grdTutor.UseAccessibleHeader = true;
                            if (grdTutor.ShowFooter)
                                grdTutor.FooterRow.TableSection = TableRowSection.TableFooter;
                        }
                        //noticias
                        var not = from a in context.Posts
                                      where  a.CctID == c.CctID
                                      select new
                                      {
                                          ID = a.PostID,
                                          Titulo = a.Titulo,
                                          Fecha = a.Fecha.ToShortDateString(),
                                          PublicadoPor = a.PublicadoPor

                                      };

                       this.grdNoticia.DataSource = not;
                       grdNoticia.DataBind();
                       if (not.Count() > 0)
                       {
                           grdNoticia.HeaderRow.TableSection = TableRowSection.TableHeader;
                           grdNoticia.UseAccessibleHeader = true;
                           if (grdNoticia.ShowFooter)
                               grdNoticia.FooterRow.TableSection = TableRowSection.TableFooter;
                       }
                       //area
                       var area = from a in context.Areas
                                 where a.CctID == c.CctID
                                 select new
                                 {
                                     ID = a.AreaID,
                                     Titulo = a.Nombre,
                                     Tipo = a.Cat_TipoArea.Nombre

                                 };

                       this.grdArea.DataSource = area;
                       grdArea.DataBind();
                       if (area.Count() > 0)
                       {
                           grdArea.HeaderRow.TableSection = TableRowSection.TableHeader;
                           grdArea.UseAccessibleHeader = true;
                           if (grdArea.ShowFooter)
                               grdArea.FooterRow.TableSection = TableRowSection.TableFooter;
                       }

                       //idea
                       var idea = from a in context.Ideas
                                  where a.CctID == c.CctID
                                  select new
                                  {
                                      ID = a.IdeaID,
                                      Titulo = a.Titulo,
                                      Calificacion = a.Promedio

                                  };

                       this.grdIdea.DataSource = idea;
                       grdIdea.DataBind();
                       if (idea.Count() > 0)
                       {
                           grdIdea.HeaderRow.TableSection = TableRowSection.TableHeader;
                           grdIdea.UseAccessibleHeader = true;
                           if (grdIdea.ShowFooter)
                               grdIdea.FooterRow.TableSection = TableRowSection.TableFooter;
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
}