using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Claims;
using System.Web.Security;

public partial class Ingresar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        var userStore = new UserStore<IdentityUser>(new ApplicationDbContext());
        var userManager = new UserManager();

        divAlert.Attributes["class"] = "alert alert-danger display-hide";
        //Verificar datos.
        var u = userManager.Find(txtUsuario.Text, txtPassword.Text); 
        if (u != null)
        {
            if (u.EmailConfirmed && !u.IsLockedOut)
            {
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUsuario.Text,
                //        DateTime.Now, DateTime.Now.AddMinutes(600), true, "", FormsAuthentication.FormsCookiePath);

                //// In the above parameters 1 is ticket version, username is the username associated with this ticket
                ////time when ticket was issued , time when ticket will expire, remember username is user has chekced it
                ////roles associted with the user, and path of cookie if any

                ////For security reasons we may hash the cookies
                //string hashCookies = FormsAuthentication.Encrypt(ticket);
                //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies);
                //cookie.Expires = DateTime.Now.AddMinutes(600);
                //// add the cookie to user browser

                //Response.Cookies.Add(cookie);

                //Session["usernameonline"] = txtUsuario.Text;
                long uid = 0;
                long instid = 0;
                long imgID = 0;
                string nombreCompleto = "";
                var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                using (MiEscuelaDataContext context = new MiEscuelaDataContext())
                {
                    var user = context.Usuarios.Where(p => p.Usuario1 == txtUsuario.Text).SingleOrDefault();
                    if (user != null)
                    {
                        uid = user.UsuarioID;
                        imgID = user.ImagenID.HasValue ? user.ImagenID.Value : -1;
                        nombreCompleto = user.Nombre + " " + user.Apellidos;
                        if (user.CctID.HasValue)
                            instid = user.CctID.Value;
                    }
                }
                var existingClaims = userManager.GetClaims(u.Id);
                existingClaims.Clear();
                userManager.Update(u);
              
                List<Claim> claims = null;
                if (existingClaims == null || existingClaims.Count == 0)
                {
                    claims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name, txtUsuario.Text),
                   new Claim(ClaimTypes.Sid,uid.ToString()),
                    new Claim(ClaimTypes.Hash, u.Id),
                   new Claim(ClaimTypes.UserData,instid.ToString()),
                   new Claim(ClaimTypes.GivenName, nombreCompleto),
                   new Claim(ClaimTypes.Thumbprint, imgID.ToString()),
                };
                    userManager.AddClaim(u.Id, claims[0]);
                    userManager.AddClaim(u.Id, claims[1]);
                    userManager.AddClaim(u.Id, claims[2]);
                    userManager.AddClaim(u.Id, claims[3]);
                    userManager.AddClaim(u.Id, claims[4]);
                    userManager.AddClaim(u.Id, claims[5]);
                }
                else
                {
                    claims = new List<Claim>();
                    foreach (Claim c in existingClaims)
                    {
                        claims.Add(c);
                    }
                }
                foreach (var r in u.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rm.FindById(r.RoleId).Name));
                }
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                //var userIdentity = userManager.CreateIdentity(u, DefaultAuthenticationTypes.ApplicationCookie);
                //FormsAuthentication.SetAuthCookie(txtUsuario.Text, true);
                var identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimTypes.Name, ClaimTypes.Role);
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = chkRecordar.Checked }, identity);
                //authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                //Response.Redirect("~/Login.aspx");

                string returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl == null)
                    returnUrl = "~/Admin/Inicio";
                Response.Redirect(returnUrl);
            }
            else
            {
                divAlert.Attributes["class"] = "alert alert-danger display";
                lblError.InnerText = "Usuario bloqueado o deshabilitado.";
            }
        }
        else
        {
            divAlert.Attributes["class"] = "alert alert-danger display";
            lblError.InnerText = "Error en usuario/contraseña";
        }
    }
}