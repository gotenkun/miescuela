using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Estadisticas_Jalisco : System.Web.UI.Page
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
                var m = context.CctActivos.Select(p => p.NombreMunicipio).Distinct();
                cmbMunicipio.AppendDataBoundItems = true;
                var n = context.CctActivos.Select(p => p.Nivel).Distinct();
                cmbNivel.DataSource = n;
                cmbNivel.DataBind();
                cmbMunicipio.DataSource = m;
                cmbMunicipio.DataBind();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnDesercion_Click(object sender, EventArgs e)
    {
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var s = (from c in context.CctIndicadores
                         join a in context.CctActivos on c.Clave equals a.Clave
                         where c.DesercionIntracurricular != null
                         orderby c.DesercionIntracurricular descending
                         select new
                         {
                             Escuela = c.Nombre + " (" + c.Nivel + ")",
                             Desercion = c.DesercionIntracurricular,
                             Municipio = c.NombreMunicipio,
                             Nivel = c.Nivel,
                             Turno = c.Turno

                         });
                if (cmbMunicipio.SelectedIndex > 0)
                    s = s.Where(p => p.Municipio == cmbMunicipio.SelectedItem.Text);
                if (cmbNivel.SelectedIndex > 0)
                    s = s.Where(p => p.Nivel == cmbNivel.SelectedItem.Text);
                if (cmbTurno.SelectedIndex > 0)
                    s = s.Where(p => p.Turno == cmbTurno.SelectedItem.Text);
                this.grd.DataSource = s;
                grd.DataBind();
                if (s.Count() > 0)
                {
                    grd.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grd.UseAccessibleHeader = true;
                    if (grd.ShowFooter)
                        grd.FooterRow.TableSection = TableRowSection.TableFooter;
                }
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnReprobacion_Click(object sender, EventArgs e)
    {
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var s = (from c in context.CctIndicadores
                         join a in context.CctActivos on c.Clave equals a.Clave
                         where c.Reprobacion != null
                         orderby c.Reprobacion descending
                         select new
                         {
                             Escuela = c.Nombre + " (" + c.Nivel + ")",
                             Reprobacion = c.Reprobacion,
                             Municipio = c.NombreMunicipio,
                             Nivel = c.Nivel,
                             Turno = c.Turno

                         });
                if (cmbMunicipio.SelectedIndex > 0)
                    s = s.Where(p => p.Municipio == cmbMunicipio.SelectedItem.Text);
                if (cmbNivel.SelectedIndex > 0)
                    s = s.Where(p => p.Nivel == cmbNivel.SelectedItem.Text);
                if (cmbTurno.SelectedIndex > 0)
                    s = s.Where(p => p.Turno == cmbTurno.SelectedItem.Text);
                this.grd.DataSource = s;
                grd.DataBind();
                if (s.Count() > 0)
                {
                    grd.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grd.UseAccessibleHeader = true;
                    if (grd.ShowFooter)
                        grd.FooterRow.TableSection = TableRowSection.TableFooter;
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnEficiencia_Click(object sender, EventArgs e)
    {
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var s = (from c in context.CctIndicadores
                         join a in context.CctActivos on c.Clave equals a.Clave
                         where c.EficienciaTerminal != null
                         orderby c.EficienciaTerminal descending
                         select new
                         {
                             Escuela = c.Nombre + " (" + c.Nivel + ")",
                             Eficiencia = c.EficienciaTerminal,
                             Municipio = c.NombreMunicipio,
                             Nivel = c.Nivel,
                             Turno = c.Turno

                         });
                if (cmbMunicipio.SelectedIndex > 0)
                    s = s.Where(p => p.Municipio == cmbMunicipio.SelectedItem.Text);
                if (cmbNivel.SelectedIndex > 0)
                    s = s.Where(p => p.Nivel == cmbNivel.SelectedItem.Text);
                if (cmbTurno.SelectedIndex > 0)
                    s = s.Where(p => p.Turno == cmbTurno.SelectedItem.Text);
                this.grd.DataSource = s;
                grd.DataBind();
                if (s.Count() > 0)
                {
                    grd.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grd.UseAccessibleHeader = true;
                    if (grd.ShowFooter)
                        grd.FooterRow.TableSection = TableRowSection.TableFooter;
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}