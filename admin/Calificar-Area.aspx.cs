using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using System.Security.Claims;
using System.IO;

public partial class admin_Calificar_Area : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Cargar();
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
            if (cmbCalificacion.SelectedIndex == 0)
            {
                lblError.Text = "Debes seleccionar tu calificación";
                
            }else
            {
                using (MiEscuelaDataContext context = new MiEscuelaDataContext())
                {
                    AreaVoto av = new AreaVoto();
                    av.AreaID = long.Parse(hdID.Value);
                    av.Calificacion = (short)(cmbCalificacion.SelectedIndex );
                    av.Comentario = txtComentarios.Text;
                    av.Fecha = DateTime.Now;
                    av.UsuarioID = Code.Common.GetUserID((ClaimsIdentity)Page.User.Identity);
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
                        rutaFoto = "~/img/user/area" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + DateTime.Now.Millisecond.ToString() + ra.Next(1000).ToString() + ".jpg";
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
                            av.ImagenID = img.ImagenID;
                        
                    }
                    context.SubmitChanges();
                    #endregion  
                    context.AreaVotos.InsertOnSubmit(av);
                    context.SubmitChanges();
                    //promedios
                    var avs = context.AreaVotos.Where(p => p.AreaID == av.AreaID);
                    int calificacion = (int)(Math.Round((decimal)avs.Sum(p => p.Calificacion) / avs.Count()));
                    av.Area.Calificacion = (short)calificacion;
                    context.SubmitChanges();
                }
                Response.Redirect("/Ver-Area/" + hdID.Value);
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}