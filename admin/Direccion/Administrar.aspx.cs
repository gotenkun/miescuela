using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Direccion_Administrar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Cargar();

    }
    private void Cargar()
    {
        if (!Page.User.IsInRole("EscuelaAdmin"))
        {
            Response.Write(Code.Common.Alert("Acceso no autorizado", "/Admin/Inicio"));
        }
        else
        {
            long id = Code.Common.GetInstitucionID((ClaimsIdentity)Page.User.Identity);
            ManageUsers.CctID = id;
        }
    }
}