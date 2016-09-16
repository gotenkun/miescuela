using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Noticias : System.Web.UI.UserControl
{
    public long CctID { get; set; }
  
    public int NumeroNoticias { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            CargarNoticias();
    }
    private void CargarNoticias()
    {
        using (MiEscuelaDataContext context = new MiEscuelaDataContext())
        {
            try
            {
                hlMasNoticias.NavigateUrl = "/Noticias/" + CctID;
              
                var noticias = (from not in context.Posts
                                orderby not.PostID descending
                                select new
                                {
                                    Titulo = not.Titulo.Length > 40 ? (not.Titulo.Substring(0, 39).ToUpper() + "...") : not.Titulo.ToUpper(),
                                  
                                    PostID = "/Noticia/" + not.PostID,
                                    CctID = CctID
                                    //EquipoID = not.EquipoID,
                                    //DeporteID = not.DeporteID,
                                    //GeneroID = not.GeneroID
                                });
                if (noticias != null && noticias.Count() > 0)
                {

                  
                    if (CctID > 0)
                        noticias = noticias.Where(p => p.CctID == CctID);
                 
                    int conteo = noticias.Count();
                    //principal, para esta imagen se debe combinar el jpg generado con el png de la barra...
                    var noticiasList = noticias.Take((NumeroNoticias > 0 ? NumeroNoticias : 10)).ToList();
                    DataList1.DataSource = noticiasList;
                    DataList1.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            } 
        }

    }
}