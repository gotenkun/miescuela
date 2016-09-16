using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_MejoresIdeas : System.Web.UI.UserControl
{
    public long CctID { get; set; }

    public int NumeroIdeas { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Cargar();
    }
    private void Cargar()
    {
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var ideas = (from i in context.Ideas
                             orderby i.Promedio descending
                             where i.CctID == CctID && i.IdeaVotos.Count > 0
                             select new
                             {
                                 IdeaID = "/Ver-Idea/" + i.IdeaID,
                                 Titulo = i.Titulo,
                                 Texto = i.Texto,
                                 Rating = i.Promedio,
                                 Votos = i.IdeaVotos.Count,
                                 Usuario = i.Usuario.Nombre + " " + i.Usuario.Apellidos
                             }).Take(NumeroIdeas);
                DataList1.DataSource = ideas;
                DataList1.DataBind();

            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}