-<%@ WebHandler Language="C#" Class="CKHandler" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Linq;
using System.Data.Linq;

public class CKHandler : IHttpHandler {
    
   /* public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";//"application/json";
        var r = new System.Collections.Generic.List<ViewDataUploadFilesResult>();
        string CKEditorFuncNum = context.Request["CKEditorFuncNum"];
        string savedFileName = "";
        JavaScriptSerializer js = new JavaScriptSerializer();
        foreach (string file in context.Request.Files)
        {
            HttpPostedFile hpf = context.Request.Files[file] as HttpPostedFile;
            string FileName = string.Empty;
            if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
            {
                string[] files = hpf.FileName.Split(new char[] { '\\' });
                FileName = files[files.Length - 1];
            }
            else
            {
                FileName = hpf.FileName;
            }
            if (hpf.ContentLength == 0)
                continue;
            Random ra = new Random();
            string nombre = "not" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + DateTime.Now.Millisecond.ToString() + ra.Next(10000).ToString() + ".jpg";
            savedFileName = "~/img/institucion/Gallery/" + nombre;
            Stream fs = null;
            System.Drawing.Image dbImage = null;
            System.Drawing.Image thumb = null;
            MemoryStream mstream = null;
           
            //hpf.SaveAs(context.Server.MapPath(savedFileName));
            try
            {
                byte[] img = null;

                fs = hpf.InputStream;
                img = new byte[hpf.ContentLength];
                fs.Read(img, 0, (int)fs.Length);
                dbImage = System.Drawing.Image.FromStream(fs);
                //resize.
                int upHeight = dbImage.Height;
                decimal reDuce = 1;
                if (upHeight > 600)
                {
                    reDuce = 600 / (decimal)upHeight;
                    thumb =
                        Resize(dbImage, reDuce);
                    mstream = new System.IO.MemoryStream();
                    thumb.Save(context.Server.MapPath(savedFileName), System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    dbImage.Save(context.Server.MapPath(savedFileName), System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                
            }
            finally
            {
              
                if (mstream != null)
                {
                    mstream.Close();
                    mstream.Dispose();

                    mstream = null;
                }
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();

                    fs = null;
                }
                if (dbImage != null)
                {
                    dbImage.Dispose();
                    dbImage = null;
                }
                if (thumb != null)
                {
                    thumb.Dispose();
                    thumb = null;
                }
               
            }
            //savedFileName = savedFileName.Replace("~", "");
            context.Response.Write("<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + savedFileName + "\");</script></body></html>");
            //context.Response.End();     
        }
    }*/

    public void ProcessRequest(HttpContext context)
    {
        string CKEditorFuncNum = context.Request["CKEditorFuncNum"];
        string CKEditor = context.Request["CKEditor"];
        string langCode = context.Request["langCode"];
        string url; // url to return
        string message; // message to display (optional)
        Random ra = new Random();
        Stream fs = null;
        System.Drawing.Image dbImage = null;
        System.Drawing.Image thumb = null;
        MemoryStream mstream = null;
        //save the upload
        byte[] img = null;
        try
        {


            //no files upload just send an alert script
            if (context.Request.Files.Count == 0)
            {
                context.Response.Write("<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"\", \"No file upload. Upload cancelled\");</script></body></html>");
                context.Response.End();
            }

            //get our file from the context.
            HttpPostedFile upload = context.Request.Files[0];

            // here logic to upload image
            // and get file path of the image
            // path of the image
            string path = upload.FileName.ToLower();
            if (!path.ToLower().EndsWith(".jpg") && !path.ToLower().EndsWith(".jpeg"))
                context.Response.Write("<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"\", \"Sólo se permiten imágenes de tipo JPG.\");</script></body></html>");
            else
            {
                string fileNam = "blog" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + DateTime.Now.Millisecond.ToString() + ra.Next(10000).ToString();
                //create your URL path
                path = path.Replace(" ", "_");
                if (path.ToLower().EndsWith(".jpeg"))
                    path = path.Replace(".jpeg", ".jpg");
                url = System.Configuration.ConfigurationManager.AppSettings["baseURL"] + "images/blog/" + fileNam + path;
                //create our absolute store path
                var savePath = context.Server.MapPath(string.Format("~/images/blog/{0}", (fileNam + path)));


                fs = upload.InputStream;
                img = new byte[upload.ContentLength];
                fs.Read(img, 0, (int)fs.Length);
                dbImage = System.Drawing.Image.FromStream(fs);
                //resize.
                int upHeight = dbImage.Height;
                int upWidth = dbImage.Width;
                decimal reDuce = 1;
                if (upWidth > 1170)
                {
                    reDuce = 1170 / (decimal)upWidth;
                    thumb =
                        Resize(dbImage, reDuce);
                    mstream = new System.IO.MemoryStream();
                    thumb.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    if (upWidth < 1170)
                    {
                        reDuce = (decimal)upWidth / 1170;
                        thumb =
                            Resize(dbImage, reDuce);
                        mstream = new System.IO.MemoryStream();
                        thumb.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //thumbnailByteArray = new Byte[mstream.Length];
                    }
                    else
                        dbImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                // passing message success/failure
                message = "Imagen grabada correctamente";
                // since it is an ajax request it requires this string
                string output = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\", \"" + message + "\");</script></body></html>";

                //write out our output
                context.Response.Write(output);
            }
        }
        catch
        {
            context.Response.Write("<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"\", \"Ocurrió un error al guardar la imagen. Intente más tarde, o reportelo a un administrador.\");</script></body></html>");

        }
        finally
        {

            if (mstream != null)
            {
                mstream.Close();
                mstream.Dispose();

                mstream = null;
            }
            if (fs != null)
            {
                fs.Close();
                fs.Dispose();

                fs = null;
            }
            if (dbImage != null)
            {
                dbImage.Dispose();
                dbImage = null;
            }
            if (thumb != null)
            {
                thumb.Dispose();
                thumb = null;
            }

        }
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }
    public System.Drawing.Image Resize(System.Drawing.Image img, decimal percentage)
    {
        //get the height and width of the image
        int originalW = img.Width;
        int originalH = img.Height;

        //get the new size based on the percentage change
        int resizedW = (int)(originalW * percentage);
        int resizedH = (int)(originalH * percentage);

        //create a new Bitmap the size of the new image
        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(resizedW, resizedH);
        //bmp = (Bitmap)img.GetThumbnailImage(resizedW, resizedH, null, System.IntPtr.Zero);
        //bmp.SetResolution(72, 72);
        //create a new graphic from the Bitmap
        System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage((System.Drawing.Image)bmp);
        graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
        //draw the newly resized image
        graphic.DrawImage(img, 0, 0, resizedW, resizedH);
        //dispose and free up the resources
        graphic.Dispose();
        //return the image
        return (System.Drawing.Image)bmp;
    }
}

public class ViewDataUploadFilesResult
{
    public string Thumbnail_url { get; set; }
    public string Name { get; set; }
    public string Length { get; set; }
    public string Type { get; set; }
}