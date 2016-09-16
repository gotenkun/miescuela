using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_MiEscuela : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Page.User.IsInRole("Alumno") || Page.User.IsInRole("Director") || Page.User.IsInRole("EscuelaAdmin") || Page.User.IsInRole("Personal"))
            Response.Redirect("/Escuela/" + Code.Common.GetInstitucionID((ClaimsIdentity)Page.User.Identity));
        if (Page.User.IsInRole("SuperAdmin"))
            Response.Redirect("/Admin/Administracion/Inicio");
        if (Page.User.IsInRole("Tutor") || Page.User.IsInRole("Docente") || Page.User.IsInRole("Personal"))
            Response.Redirect("/Admin/Mis-Escuelas");
        
    }
}