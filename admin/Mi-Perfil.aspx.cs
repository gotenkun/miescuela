using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;
using System.Data.Linq;
using System.Web.UI.HtmlControls;

public partial class Admin_Mi_Perfil : System.Web.UI.Page
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
                try
                {
                    var userManager = new UserManager();
                    UserStore<IdentityUser> store = new UserStore<IdentityUser>( new ApplicationDbContext());
                    var us = userManager.FindByName(User.Identity.Name);
                    var u = context.Usuarios.Where(p => p.Usuario1 == Page.User.Identity.Name).SingleOrDefault();
                    if (u != null)
                    {
                        txtApellidos.Text = u.Apellidos;
                    
                        txtNombre.Text = u.Nombre;

                        txtEmail.Text = us.Email;

                      //  txtTelefono.Text = u.Telefono;

                        litEmail.Text = "<a href='mailto:" + us.Email + "'>" + us.Email + "</a>";
                        lblDireccion.Text = "<a href='http://maps.google.com?q=" + u.Domicilio + "' target='_blank'>" + u.Domicilio + "</a>";
                        txtDomicilio.Text = u.Domicilio;
                        litNombre.Text = u.Nombre + " " + u.Apellidos;
                        if (u.ImagenID.HasValue)
                        {
                            imgPerfil.Src = "/image.aspx?id=" + u.ImagenID;
                            imgPerfilDoctor.Src = "/image.aspx?id=" + u.ImagenID;
                        }
                        else
                        {
                            imgPerfil.Visible = false;
                        }

                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void lnkGuardarImagen_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuImagenPerfil.HasFile)
            {
                using (MiEscuelaDataContext context = new MiEscuelaDataContext())
                {
                    var user = context.Usuarios.Where(p => p.Usuario1 == Page.User.Identity.Name).SingleOrDefault();
                    if (user != null)
                    {
                        #region  imagen
                        byte[] image = null;
                        string rutaFoto = "";
                        Random ra = new Random();
                        if (fuImagenPerfil.PostedFile != null && fuImagenPerfil.PostedFile.ContentLength > 0)
                        {
                            Stream fs = fuImagenPerfil.PostedFile.InputStream;
                            image = new byte[fuImagenPerfil.PostedFile.ContentLength];
                            fs.Read(image, 0, (int)fs.Length);
                            rutaFoto = "~/img/user/p" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + DateTime.Now.Millisecond.ToString() + ra.Next(1000).ToString() + ".jpg";
                            fuImagenPerfil.PostedFile.SaveAs(Server.MapPath(rutaFoto));
                            //agregar imagen.
                            bool crearImagen = false;
                            if (user.ImagenID > 0)
                            {
                                //actualizar imagen.
                                Imagen img = (from ims in context.Imagens
                                              where ims.ImagenID == user.ImagenID
                                              select ims).SingleOrDefault();
                                if (img != null)
                                {
                                    //si sí hay imagen, actualizarla
                                    if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(img.Ruta)))
                                    {
                                        try
                                        {
                                            File.Delete(System.Web.HttpContext.Current.Server.MapPath(img.Ruta));
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    img.Fecha = DateTime.Now;
                                    img.Ruta = rutaFoto;
                                    img.imagen1 = new Binary(image);
                                    img.Mime = this.fuImagenPerfil.PostedFile.ContentType;
                                    context.SubmitChanges();
                                }
                                else
                                {
                                    //no se encontró la imagen.
                                    crearImagen = true;
                                }
                            }
                            else
                            {
                                //no tenía imagen, crearla.
                                crearImagen = true;
                            }
                            if (crearImagen)
                            {
                                //crear imagen.
                                Imagen img = new Imagen();
                                img.Fecha = DateTime.Now;
                                img.Ruta = rutaFoto;
                                img.imagen1 = new System.Data.Linq.Binary(image);
                                img.Mime = this.fuImagenPerfil.PostedFile.ContentType;
                                context.Imagens.InsertOnSubmit(img);
                                context.SubmitChanges();
                                user.ImagenID = img.ImagenID;
                            }
                        }
                        context.SubmitChanges();
                        imgPerfil.Visible = true;
                        #endregion  
                    }
                }
                Cargar();
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    private bool ValidarContrasena()
    {
        bool valido = true;
        //contraseña
        if (txtPasswordActual.Text.Length > 0)
        {
            var userManager = new UserManager();
            var u = userManager.Find(Page.User.Identity.Name, txtPasswordActual.Text);
            if (u == null)
            {
                valido = false;
                lblErrorContrasenaActual.Visible = true;
            }
            else
            {
                if (txtNuevoPassword.Text.Length > 5)
                {
                    if (txtConfirmarPassword.Text.Length > 5)
                    {
                        if (txtConfirmarPassword.Text != txtNuevoPassword.Text)
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
            }

        }
        return valido;
    }
    protected void lnkCambiarPassword_Click(object sender, EventArgs e)
    {
        try
        {
            var userManager = new UserManager();
            UserStore<IdentityUser> store = new UserStore<IdentityUser>( new ApplicationDbContext());
            var u = userManager.Find(Page.User.Identity.Name, this.txtPasswordActual.Text);
            if (u != null)
            {
                String hashedNewPassword = userManager.PasswordHasher.HashPassword(this.txtNuevoPassword.Text);
                store.SetPasswordHashAsync(u, hashedNewPassword);
                store.UpdateAsync(u);
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    private bool Validar()
    {
        var userManager = new UserManager();
        UserStore<IdentityUser> store = new UserStore<IdentityUser>(new ApplicationDbContext());
        var us = userManager.FindByName(Page.User.Identity.Name);
        bool valido = true;
        lblErroremail.InnerText = "Indique un Email válido.";
        lblErroremail.Visible = false;
        lblErrorApellidos.Visible = false;
        lblErrorContrasenaActual.Visible = false;
        lblErrorContrasenaConfirmar.Visible = false;
        lblErrorContrasenaNueva.Visible = false;
        lblErrorNombre.Visible = false;
       // lblErrorTelefono.Visible = false;
        if (string.IsNullOrEmpty(txtNombre.Text))
        {
            valido = false;
            lblErrorNombre.Visible = true;
        }
        if (string.IsNullOrEmpty(txtApellidos.Text))
        {
            valido = false;
            this.lblErrorApellidos.Visible = true;
        }
       
        //if (string.IsNullOrEmpty(this.txtTelefono.Text))
        //{
        //    valido = false;
        //    this.lblErrorTelefono.Visible = true;
        //}
        if (string.IsNullOrEmpty(txtEmail.Text) || !Code.Common.isEmail(txtEmail.Text))
        {
            valido = false;
            lblErroremail.Visible = true;
        }
        else
        {
            var use = userManager.FindByEmail(txtEmail.Text);
            if (use != null && use.UserName != User.Identity.Name)
            {
                valido = false;
                lblErroremail.InnerText = "Este email ya está dado de alta en otro usuario.";
            }
        }
        return valido;
    }
    protected void lnkGuardar_Click(object sender, EventArgs e)
    {
        if (Validar())
        {
            try
            {
                using (MiEscuelaDataContext context = new MiEscuelaDataContext())
                {
                    var userManager = new UserManager();
                    UserStore<IdentityUser> store = new UserStore<IdentityUser>(new ApplicationDbContext());
                    var us = userManager.FindByName(Page.User.Identity.Name);
                    var u = context.Usuarios.Where(p => p.Usuario1 == Page.User.Identity.Name).SingleOrDefault();
                    if (u != null)
                    {
                        u.Nombre = txtNombre.Text;
                        u.Apellidos = txtApellidos.Text;
                     //   u.Telefono = txtTelefono.Text;
                        u.Domicilio = txtDomicilio.Text;

                        if (txtEmail.Text.ToLower().Trim() != us.Email)
                        {

                            us.Email = txtEmail.Text;
                            userManager.Update(us);
                        }
                        context.SubmitChanges();

                    }
                }
                Cargar();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        else
        {
            //mostrar tab datos porque hay error.
            ScriptManager.RegisterStartupScript(this,typeof(string), "onloadSetTab", "jQuery(document).ready(function(){ $('#tab13').click();});", true);
        }
    }
}