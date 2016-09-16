using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using System.Security.Claims;
using System.IO;

public partial class admin_Dejar_Tarea_Grupal : System.Web.UI.Page
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
                    var grupo = context.Grupos.Where(p => p.GrupoID == long.Parse(Request.GetFriendlyUrlSegments()[0])).SingleOrDefault();
                    if (grupo != null)
                    {
                        this.lblGrupo.Text = grupo.Nivel + " " + grupo.Grado + "°-." + grupo.Grupo1;
                        // lblTitulo.Text = area.Nombre;
                        lblTitulo1.Text = lblGrupo.Text;
                        hdID.Value = grupo.GrupoID.ToString();
                        hlCancelar.HRef = "/Admin/Grupo/" + hdID.Value;
                        lblNumeroAlumnos.Text = "Se enviará esta tarea a " + grupo.UsuarioGrupos.Count + " usuarios";
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

            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var grupo = context.Grupos.Where(p => p.GrupoID == long.Parse(hdID.Value)).SingleOrDefault();
                if (grupo != null)
                {
                    Tarea i = new Tarea();
                    i.CctID = Code.Common.GetInstitucionID((ClaimsIdentity)Page.User.Identity);
                    i.Fecha = DateTime.Now;
                    i.GrupoID = long.Parse(hdID.Value);
                    i.Texto = txtComentarios.Text;
                    i.DocenteID = Code.Common.GetUserID((ClaimsIdentity)Page.User.Identity);
                    DateTime nacimiento = new DateTime();
                    int ano = 0;
                    int mes = 0;
                    int dia = 0;//1980-05-11
                    if ((int.TryParse(this.txtFecha.Text.Substring(0, 4), out ano) &&
                        int.TryParse(txtFecha.Text.Substring(5, 2), out mes) &&
                        int.TryParse(txtFecha.Text.Substring(8, 2), out dia)))
                    {
                        nacimiento = new DateTime(ano, mes, dia);
                        if (nacimiento > DateTime.Today)
                        {
                            Response.Write(Code.Common.Alert("La fecha de nacimiento debe ser menor o igual al día de hoy.", ""));
                        }
                    }
                    else
                    {
                        throw new Exception("Error al fabricar fecha: " + txtFecha.Text);
                    }
                    i.FechaEntrega = nacimiento;
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
                    context.Tareas.InsertOnSubmit(i);
                    context.SubmitChanges();
                    //promedios
                }

            }
            Response.Redirect("/Admin/Inicio");

        }
        catch (Exception)
        {

            throw;
        }
    }
}