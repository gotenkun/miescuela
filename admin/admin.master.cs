using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Admin: System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Cargar();
    }
    private void Cargar()
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            long imgID = Code.Common.GetUserImageID((ClaimsIdentity)Page.User.Identity);
            if (imgID > 0)
                imgPerfil.Src = "/image.aspx?resize=1&w=40&id=" + imgID;
            if (Page.User.IsInRole("Alumno"))
            {
                phMenuDocente.Visible = false;
                phMenuAdmin.Visible = false;
                phMenuAlumno.Visible = true;
                phMenuPersonal.Visible = false;
                phMenuSuperAdmin.Visible = false;
                phMenuTutor.Visible = false;

            }
            if (Page.User.IsInRole("Docente"))
            {
                phMenuDocente.Visible = true;
                phMenuAdmin.Visible = false;
                phMenuAlumno.Visible = false;
                phMenuPersonal.Visible = false;
                phMenuSuperAdmin.Visible = false;
                phMenuTutor.Visible = false;

            }
            if (Page.User.IsInRole("EscuelaAdmin"))
            {
                phMenuDocente.Visible = false;
                phMenuAdmin.Visible = true;
                phMenuAlumno.Visible = false;
                phMenuPersonal.Visible = false;
                phMenuSuperAdmin.Visible = false;
                phMenuTutor.Visible = false;

            }
            if (Page.User.IsInRole("Tutor"))
            {
                phMenuDocente.Visible = false;
                phMenuAdmin.Visible = false;
                phMenuAlumno.Visible = false;
                phMenuPersonal.Visible = false;
                phMenuSuperAdmin.Visible = false;
                phMenuTutor.Visible = true;

            }
            if (Page.User.IsInRole("Personal"))
            {
                phMenuDocente.Visible = false;
                phMenuAdmin.Visible = false;
                phMenuAlumno.Visible = false;
                phMenuPersonal.Visible = true;
                phMenuSuperAdmin.Visible = false;
                phMenuTutor.Visible = false;

            }
        }
        else
        {

        }

    }
}
