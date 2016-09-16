using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

public partial class Admin_Membership_Agregar_Usuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //((HtmlGenericControl)this.Master.FindControl("h3SectionTitle")).InnerHtml = "Agregar Usuario";
        //((HtmlGenericControl)this.Master.FindControl("liMiRed")).Attributes["class"] = "start active open";
        //((HtmlGenericControl)this.Master.FindControl("liMiRedAgregarUsuario")).Attributes["class"] = "start active open";
        //if (Page.User.IsInRole("Admin"))
        //{
            Cargar();
        //}
        //else
        //{
        //    lnkCrearUsuario.Visible = false;
        //    Response.Write(MedikAdmin.Common.Alert("No tiene permisos para crear usuarios", "/Admin/Inicio"));
        //}
    }
    private void Cargar()
    {
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var u = context.Usuarios.Where(p => p.Usuario1 == Page.User.Identity.Name).SingleOrDefault();
                if (u != null)
                {
                    bool continuar = true;

                    if (!continuar)
                    {
                        lnkCrearUsuario.Visible = false;
                        Response.Write(MedikAdmin.Common.Alert("No tiene usuarios disponibles para agregar", "/Admin/Inicio"));
                    }
                    else
                    {
                        //cargar roles
                        //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                        //string[] roles = roleManager.Roles.Select(p => p.Name).ToArray();
                        //cmbRoles.DataSource = roles;
                        //cmbRoles.DataBind();
                    }
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    private bool Validar()
    {
        bool valido = true;
        try
        {
            lblErrorApellidos.Visible = false;

            this.lblErrorContrasenaNueva.Visible = false;
            this.lblErrorUsuario.Visible = false;
            lblErrorUsuario.InnerText = "*Indique nombre de usuario de al menos 5 caracteres";
            ; lblErrorContrasenaNueva.Visible = false;

            lblErrorEmail.Visible = false;
            lblErrorEmail.InnerText = "*Indique el email";
            lblErrorNombre.Visible = false;

            //contraseña

            if (this.txtPassword.Text.Length > 5)
            {
                if (this.txtConfirmarPassword.Text.Length > 5)
                {
                    if (txtPassword.Text != txtConfirmarPassword.Text)
                    {
                        valido = false;
                        this.lblErrorContrasenaNueva.Visible = true;
                        lblErrorContrasenaNueva.InnerText = "No coincide la contraseña.";
                    }
                }
                else
                {
                    valido = false;
                    lblErrorContrasenaNueva.InnerText = "Indique al menos 6 caracteres.";
                    lblErrorContrasenaNueva.Visible = true;
                }
            }
            else
            {
                valido = false;
                lblErrorContrasenaNueva.InnerText = "Indique una contraseña nueva de al menos 6 caracteres.";
                lblErrorContrasenaNueva.Visible = true;
            }



            //contacto
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                valido = false;
                lblErrorNombre.Visible = true;
            }
         
            if (string.IsNullOrEmpty(this.txtUsuario.Text) || txtUsuario.Text.Length < 5)
            {
                valido = false;
                lblErrorUsuario.Visible = true;
            }
            else
            {
                var um = new UserManager();
                var u = um.FindByName(txtUsuario.Text);
                if (u != null)
                {
                    valido = false;
                    lblErrorUsuario.Visible = true;
                    lblErrorUsuario.InnerText = "Este usuario ya existe en el sistema";
                }
            }
            if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                valido = false;
                this.lblErrorApellidos.Visible = true;
            }

            if (string.IsNullOrEmpty(this.txtEmail.Text))
            {
                valido = false;
                this.lblErrorEmail.Visible = true;
            }
            else
            {
                if (!MedikAdmin.Common.isEmail(txtEmail.Text))
                {
                    valido = false;
                    this.lblErrorEmail.Visible = true;
                }
                else
                {
                    var um = new UserManager();
                    var u = um.FindByEmail(this.txtEmail.Text);
                    if (u != null)
                    {
                        valido = false;
                        this.lblErrorEmail.Visible = true;
                        lblErrorEmail.InnerText = "Este email ya existe en el sistema";
                    }
                }
            }


        }
        catch (Exception)
        {

            throw;
        }
        return valido;
    }
    protected void lnkCrearUsuario_Click(object sender, EventArgs e)
    {
        if (Validar())
        {
            bool redir = false;
            try
            {

                using (MiEscuelaDataContext context = new MiEscuelaDataContext())
                {
                    //crear un nuevo usuario indicando su "parent".
                    var manager = new UserManager();
                    UserStore<IdentityUser> store = new UserStore<IdentityUser>(new ApplicationDbContext());
                    var user = new User() { UserName = txtUsuario.Text, Email = txtEmail.Text, IsApproved = true, EmailConfirmed = true };
                    IdentityResult result = manager.Create(user, txtPassword.Text);

                    if (result.Succeeded)
                    {
                        manager.AddToRole(user.Id, cmbRoles.SelectedItem.Text);
                        //crear institucion
                        long instid = 0;
                       
                        //crear en tabla de usuario.
                        Usuario u = new Usuario();
                        u.Nombre = txtNombre.Text;
                        u.Apellidos = txtApellidos.Text;
                       
                        u.Usuario1 = txtUsuario.Text;
                      
                        u.Fecha = DateTime.Now;
                      
                        u.UniqueId = Guid.Parse(user.Id);
                       
                        context.Usuarios.InsertOnSubmit(u);
                        context.SubmitChanges();
                        //crear clínica
                     

                    }
                    redir = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (redir)
                Response.Redirect("/Admin/Membership/ManageUsers");
        }
    }
}