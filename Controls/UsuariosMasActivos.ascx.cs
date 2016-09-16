using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_UsuariosMasActivos : System.Web.UI.UserControl
{
    public long CctID { get; set; }
    public bool EsAlumno { get; set; }
    public bool EsDocente { get; set; }
    public bool EsTutor { get; set; }

    public int NumeroResultados { get; set; }
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
                var usuarios = (from u in context.Usuarios
                               where u.EsAlumno == EsAlumno && u.EsDocente == EsDocente && u.EsPadreFamilia == EsTutor
                               select new
                               {
                                   UsuarioID = u.UsuarioID,
                                   Nombre = u.Nombre + " " + u.Apellidos,
                                   ImagenID = u.ImagenID.HasValue ? u.ImagenID : -1,
                                   Acciones = u.Ideas.Count + u.IdeaVotos.Count + u.AreaVotos.Count
                               }).OrderByDescending(p=>p.Acciones).Take(NumeroResultados);
                DataList1.DataSource = usuarios;
                DataList1.DataBind();

            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}