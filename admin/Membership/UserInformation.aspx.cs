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

public partial class Admin_Memberhip_UserInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // If querystring value is missing, send the user to ManageUsers.aspx
            string userName = Request.QueryString["user"];
            if (string.IsNullOrEmpty(userName))
                Response.Redirect("ManageUsers.aspx");


            // Get information about this user
            UserManager um = new UserManager();
           var usr = um.Users.Where(p=>p.UserName == userName).SingleOrDefault();
            if (usr == null)
                Response.Redirect("ManageUsers.aspx");

            UserNameLabel.Text = usr.UserName;
            IsApproved.Checked = usr.IsApproved;
            //only the ADCUAdmin users can delete other ADCUAdmins.
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
              var roles = usr.Claims
                .Where(c => c.ClaimType == ClaimTypes.Role)
                .Select(c => c.ClaimValue);
              string[] selectedUsersRoles = roles.ToArray();
            if (!um.IsInRole(usr.Id,"Admini"))
                btEliminar.Enabled = false;
            if (usr.LastLockoutDate.Year < 2000)
                LastLockoutDateLabel.Text = string.Empty;
            else
                LastLockoutDateLabel.Text = usr.LastLockoutDate.ToShortDateString();

            UnlockUserButton.Enabled = usr.IsLockedOut;
            //try
            //{
            //    if (txtUsuariosExtras.Text != "")
            //    {
            //        using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            //        {
            //            Usuario u = context.Usuarios.Where(p => p.Usuario1 == UserNameLabel.Text).SingleOrDefault();
            //            if (u != null && u.UsuariosExtraDisponibles.HasValue)
            //            {
            //                txtUsuariosExtras.Text = u.UsuariosExtraDisponibles.ToString();
            //            }
            //        }
            //    }
            //}
            //catch
            //{
            //    throw;
            //}
        }
    }

    protected void IsApproved_CheckedChanged(object sender, EventArgs e)
    {
        // Toggle the user's approved status
        string userName = Request.QueryString["user"];
        UserManager um = new UserManager();
        var usr = um.Users.Where(p => p.UserName == userName).SingleOrDefault();
        usr.IsApproved = IsApproved.Checked;
        um.Update(usr);

        StatusMessage.Text = "Se ha actualizado el estado a: ";
        if (IsApproved.Checked)
        {
            //StatusMessage.Text += "aprobado.";
            //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            //mail.To.Add(usr.Email);
            //mail.From = new MailAddress("aroqueni0@gmail.com", "Sistema Roqueñi 2010", System.Text.Encoding.UTF8);
            //mail.Subject = "Cuenta Aprobada en Roqueni2010";
            //mail.SubjectEncoding = System.Text.Encoding.UTF8;
            //mail.Body = "¡Hola! Una vez más gracias por registrarte. Tu cuenta ha sido aprobada.<br/><br/>"+
            //    "<a href=\"http://roqueni2010.com/Familia/Default.aspx\">Haz clic aquí para ingresar</a><br/>Roqueni2010";
            //mail.BodyEncoding = System.Text.Encoding.UTF8;
            //mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.High;

            //SmtpClient client = new SmtpClient();
            ////Add the Creddentials- use your own email id and password

            //client.Credentials = new System.Net.NetworkCredential("aroqueni0@gmail.com", "roqueni2010");

            //client.Port = 587; // Gmail works on this port
            //client.Host = "smtp.gmail.com";
            //client.EnableSsl = true; //Gmail works on Server Secured Layer
            //client.Send(mail);
        }
        else
            StatusMessage.Text += "no aprobado.";
    }

    protected void UnlockUserButton_Click(object sender, EventArgs e)
    {
        // Unlock the user account
        string userName = Request.QueryString["user"];
        UserManager um = new UserManager();
        var usr = um.Users.Where(p => p.UserName == userName).SingleOrDefault();
        usr.IsLockedOut = false;
        um.Update(usr);
        UnlockUserButton.Enabled = false;
        StatusMessage.Text = "Se ha desbloqueado esta cuenta.";
    }
    protected void btEliminar_Click(object sender, EventArgs e)
    {
        string userName = Request.QueryString["user"];
        UserManager um = new UserManager();
        var usr = um.Users.Where(p => p.UserName == userName).SingleOrDefault();
        //um.Delete(usr);
        btEliminar.Enabled = false;
        UnlockUserButton.Enabled = false;
        IsApproved.Enabled = false;
        MiEscuelaDataContext context = new MiEscuelaDataContext(); 
        Usuario u = context.Usuarios.Where(p => p.Usuario1 == userName).SingleOrDefault();
        if (u != null)
        {
            context.Usuarios.DeleteOnSubmit(u);
            long id = u.UsuarioID;
            context.SubmitChanges();
            //var fotos = context.Fotografias.Where(p => p.UsuarioID == id);
            //if (fotos != null && fotos.Count() > 0)
            //{
            //    context.Fotografias.DeleteAllOnSubmit(fotos);
            //    context.SubmitChanges();
            //}
            //var videos = context.Videos.Where(p => p.UsuarioID == id);
            //if (videos != null && videos.Count() > 0)
            //{
            //    context.Videos.DeleteAllOnSubmit(videos);
            //    context.SubmitChanges();
            //}
            //var noticias = context.Noticias.Where(p => p.UsuarioID == id);
            //if (noticias != null && noticias.Count() > 0)
            //{
            //    context.Noticias.DeleteAllOnSubmit(noticias);
            //    context.SubmitChanges();
            //}
        }
        StatusMessage.Text = "Se ha eliminado esta cuenta.";
    }
    protected void btnCambiarPAssword_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/Membership/ChangePassword.aspx?u=" + UserNameLabel.Text);
    }
    protected void btnAsignarUsuarios_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    if (txtUsuariosExtras.Text != "")
        //    {
        //        using (MiEscuelaDataContext context = new MiEscuelaDataContext())
        //        {
        //            Usuario u = context.Usuarios.Where(p => p.Usuario1 == UserNameLabel.Text).SingleOrDefault();
        //            if (u != null)
        //            {
        //                u.UsuariosExtraDisponibles = short.Parse(txtUsuariosExtras.Text);
        //                context.SubmitChanges();
        //                StatusMessage.Text = "Se han asignado los usuarios extras disponibles.";
        //            }
        //        } 
        //    }
        //}
        //catch (Exception)
        //{
            
        //    throw;
        //}
    }
}
