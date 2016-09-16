using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Linq;
using System.IO;

public partial class _image : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (true)//Request.Url.AbsoluteUri.ToUpper().StartsWith(System.Configuration.ConfigurationManager.AppSettings["baseURL"].ToUpper()))
        {
            int h = 0;
            int w = 100;
            int ch = 0;
            int cw = 100;
            int cx = 0;
            int cy = 0;
            bool resize = false;
            if (Request.QueryString["h"] != null)
            {
                try
                {
                    h = int.Parse(Request.QueryString["h"]);
                }
                catch
                {
                }
            }
            if (Request.QueryString["w"] != null)
            {
                try
                {
                    w = int.Parse(Request.QueryString["w"]);
                }
                catch
                {
                }
            }
            if (Request.QueryString["ch"] != null)
            {
                try
                {
                    ch = int.Parse(Request.QueryString["ch"]);
                }
                catch
                {
                }
            }
            if (Request.QueryString["cw"] != null)
            {
                try
                {
                    cw = int.Parse(Request.QueryString["cw"]);
                }
                catch
                {
                }
            }
            if (Request.QueryString["cx"] != null)
            {
                try
                {
                    cx = int.Parse(Request.QueryString["cx"]);
                }
                catch
                {
                }
            }
            if (Request.QueryString["cy"] != null)
            {
                try
                {
                    cy = int.Parse(Request.QueryString["cy"]);
                }
                catch
                {
                }
            }
            //bool previa = false;
            bool combinar = false;
            bool purpura = false;
            bool crop = false;
            bool center = false;
            bool paciente = false;
            if (Request.QueryString["pac"] != null && Request.QueryString["pac"] == "1")
            {
                paciente = true;
            }
            if (Request.QueryString["previa"] != null && Request.QueryString["previa"] == "1")
            {
                //previa = true;
            }
            if (Request.QueryString["center"] != null && Request.QueryString["center"] == "1")
            {
                center = true;
            }
            if (Request.QueryString["resize"] != null && Request.QueryString["resize"] == "1")
            {
                resize = true;
            }
            if (Request.QueryString["crop"] != null && Request.QueryString["crop"] == "1")
            {
                crop = true;
            }
            if (Request.QueryString["combinar"] != null && Request.QueryString["combinar"] == "1")
            {
                combinar = true;
            }
            if (Request.QueryString["purpura"] != null && Request.QueryString["purpura"] == "1")
            {
                purpura = true;
            }
            byte[] byteArray = null;
            System.IO.MemoryStream mstream = null;
            System.Drawing.Image dbImage = null;
            System.Drawing.Image thumbnailImage = null;
            System.Drawing.Image bmp = null;
            System.Drawing.Image resized = null;
            if (combinar)
            {
                if (Request.QueryString["id"] != null)
                {
                   
                }
            }
            else
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = 0;
                    if (int.TryParse(Request.QueryString["id"], out id))
                    {
                        if (id > 0)
                        {
                            MiEscuelaDataContext context = new MiEscuelaDataContext();
                            if (!paciente)
                            {
                                string ruta = context.Imagens.SingleOrDefault(
                                                                                     i => i.ImagenID == id).Ruta;
                                Imagen img = new Imagen();
                                if (ruta == null || ruta == "")
                                {
                                    img = context.Imagens.SingleOrDefault(
                                                                 i => i.ImagenID == id);

                                    if (img.imagen1 != null && img.imagen1.Length > 0)
                                    {
                                        byteArray = img.imagen1.ToArray();

                                        mstream = new System.IO.MemoryStream(byteArray, 0, byteArray.Length);
                                        dbImage =
                                             System.Drawing.Image.FromStream(mstream);
                                    }
                                }
                                else
                                {
                                    if (!File.Exists(Server.MapPath(ruta)))
                                    {
                                        //cargar de db. agregar registro
                                        MedikAdmin.Common.AgregarLog(5, "imagen.aspx", id, "", "", "", User.Identity.Name, "No se encontro la imagen en disco.", false);
                                        img = context.Imagens.SingleOrDefault(
                                                                 i => i.ImagenID == id);

                                        if (img.imagen1 != null && img.imagen1.Length > 0)
                                        {
                                            byteArray = img.imagen1.ToArray();

                                            mstream = new System.IO.MemoryStream(byteArray, 0, byteArray.Length);
                                            dbImage =
                                                 System.Drawing.Image.FromStream(mstream);
                                            dbImage.Save(Server.MapPath(ruta));
                                        }
                                    }
                                    else
                                        dbImage = System.Drawing.Image.FromFile(Server.MapPath(ruta));
                                }
                            }
                            else
                            {
                               
                            }
                            if (dbImage != null)
                            {
                                int upWidth = dbImage.Width;
                                int upHeigth = dbImage.Height;
                                thumbnailImage = dbImage;
                                decimal reDuce = 1;
                              
                                mstream = new System.IO.MemoryStream();
                                thumbnailImage.Save(mstream, dbImage.RawFormat);
                                Byte[] thumbnailByteArray = new Byte[mstream.Length];
                                mstream.Position = 0;
                                mstream.Read(thumbnailByteArray, 0, Convert.ToInt32(mstream.Length));
                                Response.ContentType = "image/jpeg";
                                Response.BinaryWrite(thumbnailByteArray);

                            }
                            else
                            {
                                //poner default.
                                try
                                {
                                    bmp = Bitmap.FromFile(Server.MapPath("~/img/none.jpg"));

                                    if (bmp != null)
                                    {
                                       
                                            thumbnailImage = bmp.GetThumbnailImage(100, 100, null, System.IntPtr.Zero);
                                       
                                        Response.ContentType = "image/jpeg";
                                        thumbnailImage.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        bmp.Dispose();
                                        thumbnailImage.Dispose();
                                    }
                                }
                                catch
                                {
                                    Response.Write("Error al recuperar imagen!!");
                                }
                            }

                        }
                        else
                        {
                            //poner default.
                            try
                            {
                                bmp = Bitmap.FromFile(Server.MapPath("~/img/none.png"));

                                if (bmp != null)
                                {
                                  
                                        thumbnailImage = bmp.GetThumbnailImage(100, 100, null, System.IntPtr.Zero);
                                  
                                    Response.ContentType = "image/jpeg";
                                    thumbnailImage.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    bmp.Dispose();
                                    thumbnailImage.Dispose();
                                }
                            }
                            catch
                            {
                                Response.Write("Error al recuperar imagen!!");
                            }
                        }

                    }
                }
                else
                {
                    if (Request.QueryString["path"] != null)
                    {
                        try
                        {
                            bmp = Bitmap.FromFile(Request.QueryString["path"]);

                            if (bmp != null)
                            {
                                if (Request.QueryString["resize"] != null && Request.QueryString["resize"] == "0")
                                {
                                    w = bmp.Width;
                                    h = bmp.Height;
                                }

                                resized = new Bitmap(bmp, w, h);
                                Response.ContentType = "image/jpeg";
                                resized.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                bmp.Dispose();
                                resized.Dispose();
                            }
                        }
                        catch
                        {
                            Response.Write("Error al recuperar imagen!!");
                        }
                    }
                }
            }
            if (bmp != null)
            {
                bmp.Dispose();
                bmp = null;
            }
            if (byteArray != null)
            {
                byteArray = null;
            }
            if (mstream != null)
            {
                mstream.Close();
                mstream.Dispose();

                mstream = null;
            }
            if (dbImage != null)
            {
                dbImage.Dispose();
                dbImage = null;
            }
            if (thumbnailImage != null)
            {
                thumbnailImage.Dispose();
                thumbnailImage = null;
            }
            if (resized != null)
            {
                resized.Dispose();
                resized = null;
            }
        }

    }


}

