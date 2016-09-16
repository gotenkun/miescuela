using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using System.Security.Claims;
using System.IO;

public partial class admin_Crear_Idea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }
    private void Cargar()
    {
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                if (Request.GetFriendlyUrlSegments().Count > 0)
                {
                    var area = context.Areas.Where(p => p.AreaID == long.Parse(Request.GetFriendlyUrlSegments()[0])).SingleOrDefault();
                    if (area != null)
                    {
                        lblArea.Text = area.Nombre;
                        // lblTitulo.Text = area.Nombre;
                        lblTitulo1.Text = area.Nombre;
                        hdID.Value = area.AreaID.ToString();
                        hlCancelar.HRef = "/Ver-Area/" + hdID.Value;
                    }
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            if (cmbTipo.SelectedIndex == 0)
            {
                lblError.Text = "Debes seleccionar el tipo de idea";

            }
            else
            {
                using (MiEscuelaDataContext context = new MiEscuelaDataContext())
                {

                    Idea i = new Idea();
                    i.CctID = Code.Common.GetInstitucionID((ClaimsIdentity)Page.User.Identity);
                    i.Fecha = DateTime.Now;
                    i.Promedio = 0;
                    i.Texto = txtComentarios.Text;
                    i.Titulo = txtNombre.Text;
                    i.UsuarioID = Code.Common.GetUserID((ClaimsIdentity)Page.User.Identity);
                    
                    //imagen
                    #region  imagen
                    byte[] image = null;
                    string rutaFoto = "";
                    Random ra = new Random();
                    if (fuFoto.PostedFile != null && fuFoto.PostedFile.ContentLength > 0)
                    {
                        Stream fs = fuFoto.PostedFile.InputStream;
                        image = new byte[fuFoto.PostedFile.ContentLength];
                        fs.Read(image, 0, (int)fs.Length);
                        rutaFoto = "~/img/user/idea" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + DateTime.Now.Millisecond.ToString() + ra.Next(1000).ToString() + ".jpg";
                        fuFoto.PostedFile.SaveAs(Server.MapPath(rutaFoto));
                        //agregar imagen.

                        //crear imagen.
                        Imagen img = new Imagen();
                        img.Fecha = DateTime.Now;
                        img.Ruta = rutaFoto;
                        img.imagen1 = new System.Data.Linq.Binary(image);
                        img.Mime = this.fuFoto.PostedFile.ContentType;
                        context.Imagens.InsertOnSubmit(img);
                        context.SubmitChanges();
                        i.ImagenID = img.ImagenID;

                    }
                    context.SubmitChanges();
                    #endregion
                    context.Ideas.InsertOnSubmit(i);
                    context.SubmitChanges();
                    //promedios
                    
                }
                Response.Redirect("/Ver-Idea/" + hdID.Value);
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}