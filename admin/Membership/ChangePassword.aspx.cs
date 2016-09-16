using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

public partial class Admin_Memberhip_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    private bool Validar()
    {
        bool valido = true;
        if (txtContrasenaNueva.Text.Length > 5)
        {
            if (txtContrasenaConfirmar.Text.Length > 5)
            {
                if (txtContrasenaConfirmar.Text != txtContrasenaNueva.Text)
                {
                    valido = false;
                    lblErrorContrasenaConfirmar.Visible = true;
                    lblErrorContrasenaConfirmar.InnerText = "No coincide la contraseña.";
                }
            }
            else
            {
                valido = false;
                lblErrorContrasenaConfirmar.InnerText = "Indique al menos 5 caracteres.";
                lblErrorContrasenaConfirmar.Visible = true;
            }
        }
        else
        {
            valido = false;
            lblErrorContrasenaNueva.InnerText = "Indique una contraseña nueva de al menos 6 caracteres.";
            lblErrorContrasenaNueva.Visible = true;
        }
        return valido;
       
    }


    protected void lnkGuardar_Click(object sender, EventArgs e)
    {
        if (Validar())
        {
            var userManager = new UserManager();
            UserStore<IdentityUser> store = new UserStore<IdentityUser>(new ApplicationDbContext());
            var u = userManager.FindByName(Request.QueryString["u"]);
            if (u != null)
            {

                if (txtContrasenaNueva.Text != "" && txtContrasenaNueva.Text != "")
                {
                    //cambiar contraseña.
                    if (txtContrasenaConfirmar.Text != "")
                    {
                        //userManager.RemovePassword(u.Id);
                        String hashedNewPassword = userManager.PasswordHasher.HashPassword(txtContrasenaNueva.Text);
                        //store.SetPasswordHashAsync(u, hashedNewPassword);
                        //store.UpdateAsync(u);
                        //userManager.AddPassword(u.Id, hashedNewPassword);
                        u.PasswordHash = hashedNewPassword;
                        userManager.UpdateSecurityStamp(u.Id);
                        userManager.Update(u);

                    }
                }
            }
        }
    }
}
