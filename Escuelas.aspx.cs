using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Escuelas : System.Web.UI.Page
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
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var c = from ca in context.CctActivos select ca;
                if (txtNombre.Text != "")
                    c = c.Where(p => p.Nombre.Contains(txtNombre.Text));
                if (txtClave.Text != "")
                    c = c.Where(p => p.Clave.Contains(txtClave.Text));
                if (cmbNivel.SelectedIndex > 0)
                {
                    c = c.Where(p => p.Nivel == cmbNivel.SelectedItem.Text);
                }
                if (cmbMunicipio.SelectedIndex > 0)
                    c = c.Where(p => p.NombreMunicipio == cmbMunicipio.SelectedItem.Text);
                if (cmbTurno.SelectedIndex > 0)
                    c = c.Where(p => p.Turno == cmbTurno.SelectedItem.Text);
                if(c.Count() > 100)
                    c = c.Take(100);

                string script = "initMap();deleteMarkers();";
                string litres = "";
                int i = 0;
                foreach (var a in c)
                {
                    litres += (i+1).ToString() +"-. <a href='/Escuela/" + a.CctID + "'>" + a.Nombre + "</a><br><small>" + a.Domicilio + ", " + a.NombreColonia + ", " +
                        a.NombreLocalidad + ", " + a.NombreMunicipio + ", Tel: " + a.Telefono + "</small>" +  (Page.User.IsInRole("SuperAdmin") ? "<a href=\"/Admin/Direccion/Inicio/" + a.CctID + "\" style='float:right' class=\"btn red\">Administrar</a>" : "") + "<br><hr/>";
                    string info = "<h5>Domicilio</h5>" + a.Domicilio + ", entre " + a.EntreCalle + " y " + a.YCalle + "<br />" +
                        a.NombreColonia + ", " + a.NombreLocalidad + ", " + a.NombreMunicipio + ". CP: " + a.CodigoPostal + "<br/><h5>Contacto</h5>" +
                        "Director: " + a.Director + "<br/> Teléfono: " + a.Telefono + ", email: " + a.Correo + "<br/><h5>Tipo de Escuela</h5>" +
                        "Nivel: " + a.Nivel + " Programa: " + a.Programa + " Sostenimiento: " + a.NombreSostenimiento;
                    script += "var marker" + i + " = new google.maps.Marker({ position: { lat: " + a.Latitud + ", lng: " + a.Longitud + "}, map: map,  title: 'Hello World!' });"+
                        " var infowindow"+i+" = new google.maps.InfoWindow({ content: '<h4>" + a.Nombre + "</h4>" + info + "<br><br><a href=\"/Escuela/" + a.CctID + "\" class=\"btn blue\">Ver Escuela</a>" +
                        (Page.User.IsInRole("SuperAdmin") ? "&nbsp;<a href=\"/Admin/Direccion/Inicio/" + a.CctID + "\" class=\"btn red\">Administrar</a>" : "") + "'  });"
                        +"markers.push(marker" + i + ");marker" + i + ".addListener('click', function() {infowindow"+i+".open(map, marker"+i +");});";
                    i++;
                }
                litResultados.Text = litres;
                script += "setMapOnAll(map);fitBounds();";
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "onloadMap",script, true);
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}