using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;

public partial class Estadistica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.GetFriendlyUrlSegments().Count() > 0)
                Cargar();
        }
    }
    private string GetRandomColor()
    {
        var random = new Random();
        var color = String.Format("#{0:X6}", random.Next(0x1000000));
        return color;
    }
    private void Cargar()
    {
        try
        {
            string id = Request.GetFriendlyUrlSegments()[0];
            using (MiEscuelaDataContext context = new MiEscuelaDataContext())
            {
                var c = context.CctActivos.Where(p => p.CctID == long.Parse(id)).SingleOrDefault();
                if (c != null)
                {
                    lblTitulo.Text = c.Nombre + ": Estadísticas";
                    var areas = context.Areas.Where(p => p.CctID == c.CctID);
                    //stats

                    var stats = context.CctEstadisticas.Where(p => p.Clave == c.Clave).FirstOrDefault();
                    var inds = context.CctIndicadores.Where(p => p.Clave == c.Clave).FirstOrDefault();
                    var planea = context.CctPlaneaBasicas.Where(p => p.Clave == c.Clave).FirstOrDefault();
                    string stat = "";
                    if (stats != null && inds != null)
                    {
                        #region Datos
                        stat = "<div class='row'><div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'><div class='dashboard-stat blue'><div class='visual'><i class='fa fa-users'></i>" +
                                                "</div>	<div class='details'><div class='number'>" + stats.MatriculaTotal.Value.ToString() + "</div><div class='desc'>" +
                                                                                     "Alumnos</div></div></div></div><div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'>" + "<div class='dashboard-stat blue'><div class='visual'><i class='fa fa-user'></i></div>" +
                                                                            "<div class='details'>" +
                                                                                "<div class='number'>" +
                                                                                     stats.Docentes +
                                                                                "</div>" +
                                                                                "<div class='desc'>" +
                                                                                     "Docentes" +
                                                                                "</div>" +
                                                                            "</div>" +
                            //"<a class='more' href='/Estadistica/" + c.CctID + "'>" +
                            //"Ver más <i class='m-icon-swapright m-icon-white'></i>" +
                            //"</a>" +
                                                                        "</div>" +
                                                                    "</div>" +
                                                                       "<div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
                                                                    "	<div class='dashboard-stat blue'>" +
                                                                    "		<div class='visual'>" +
                                                                    "			<i class='fa fa-user'></i>" +
                                                                    "		</div>" +
                                                                    "		<div class='details'>" +
                                                                    "			<div class='number'>" +
                                                                     +stats.TotalPersonal +
                                                                    "			</div>" +
                                                                    "			<div class='desc'>" +
                                                                    "				 Personal Administrativo" +
                                                                    "			</div>" +
                                                                    "		</div>" +
                            //"		<a class='more' href='/Estadistica/" + c.CctID + "'>" +
                            //"		Ver más  <i class='m-icon-swapright m-icon-white'></i>" +
                            //"		</a>" +
                                                                    "	</div>" +
                                                                    "</div>" +
                                                                       "<div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
                                                                    "	<div class='dashboard-stat blue'>" +
                                                                    "		<div class='visual'>" +
                                                                    "			<i class='fa fa-building'></i>" +
                                                                    "		</div>" +
                                                                    "		<div class='details'>" +
                                                                    "			<div class='number'>" +
                                                                     +(areas.Count()) +
                                                                    "			</div>" +
                                                                    "			<div class='desc'>" +
                                                                    "				 Áreas" +
                                                                    "			</div>" +
                                                                    "		</div>" +
                            //"		<a class='more' href='/Estadistica/" + c.CctID + "'>" +
                            //"		Ver más  <i class='m-icon-swapright m-icon-white'></i>" +
                            //"		</a>" +
                                                                    "	</div>" +
                                                                    "</div>" +
                                                                    "<div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
                                                                    "	<div class='dashboard-stat green'>" +
                                                                    "		<div class='visual'>" +
                                                                    "			<i class='fa fa-check-square'></i>" +
                                                                    "		</div>" +
                                                                    "		<div class='details'>" +
                                                                    "			<div class='number'>" +
                                                                    (inds.EficienciaTerminal != null ? inds.EficienciaTerminal.Value.ToString() : "-") +
                                                                    "			</div>" +
                                                                    "			<div class='desc'>" +
                                                                    "				 Eficiencia Terminal" +
                                                                    "			</div>" +
                                                                    "		</div>" +
                            //"		<a class='more' href='/Estadistica/" + c.CctID + "'>" +
                            //"		Ver más  <i class='m-icon-swapright m-icon-white'></i>" +
                            //"		</a>" +
                                                                    "	</div>" +
                                                                    "</div>" +
                                                                    "<div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
                                                                    "	<div class='dashboard-stat red'>" +
                                                                    "		<div class='visual'>" +
                                                                    "			<i class='fa fa-arrow-circle-down'></i>" +
                                                                    "		</div>" +
                                                                    "		<div class='details'>" +
                                                                    "			<div class='number'>" +
                                                                                inds.Reprobacion +
                                                                    "			</div>" +
                                                                    "			<div class='desc'>" +
                                                                    "				 Reprobación" +
                                                                    "		</div>" +
                                                                    "		</div>" +
                            //"		<a class='more' href='/Estadistica/" + c.CctID + "'>" +
                            //"		Ver más <i class='m-icon-swapright m-icon-white'></i>" +
                            //"		</a>" +
                                                                    "	</div>" +
                                                                    "</div>" +

                                                                      "<div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
                                                                    "	<div class='dashboard-stat red'>" +
                                                                    "		<div class='visual'>" +
                                                                    "			<i class='fa fa-arrow-circle-down'></i>" +
                                                                    "		</div>" +
                                                                    "		<div class='details'>" +
                                                                    "			<div class='number'>" +
                                                                    (inds.ReprobacionConRegularizados != null ? inds.ReprobacionConRegularizados : "-") +
                                                                    "			</div>" +
                                                                    "			<div class='desc'>" +
                                                                    "				 Reprobación c/ Regularizados" +
                                                                    "			</div>" +
                                                                    "		</div>" +
                            //"		<a class='more' href='/Estadistica/" + c.CctID + "'>" +
                            //"		Ver más  <i class='m-icon-swapright m-icon-white'></i>" +
                            //"		</a>" +
                                                                    "	</div>" +
                                                                    "</div>" +
                                                                       "<div class='col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
                                                                    "	<div class='dashboard-stat red'>" +
                                                                    "		<div class='visual'>" +
                                                                    "			<i class='fa fa-arrow-circle-down'></i>" +
                                                                    "		</div>" +
                                                                    "		<div class='details'>" +
                                                                    "			<div class='number'>" +
                                                                    (inds.DesercionIntracurricular != null ? inds.DesercionIntracurricular.Value.ToString() : "-") +
                                                                    "			</div>" +
                                                                    "			<div class='desc'>" +
                                                                    "				 Deserción" +
                                                                    "			</div>" +
                                                                    "		</div>" +
                            //"		<a class='more' href='/Estadistica/" + c.CctID + "'>" +
                            //"		Ver más  <i class='m-icon-swapright m-icon-white'></i>" +
                            //"		</a>" +

                                                                    "</div>" +
                                                                     "</div>" +




                                                                "</div>"; 
                        #endregion

                        #region piechart1

                        string script1 = "<script> var initChartSample6 = function() { var chart = AmCharts.makeChart('chartPersonalvsAlumnos', { 'type': 'pie', 'theme': 'light', 'fontFamily': 'Open Sans'," +
                               "'color':    '#888','dataProvider': [{" +
                               "'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                               "'Personal': 'Docentes','Número':" + stats.Docentes + "},{" +
                               "'Personal': 'Personal','Número':" + stats.TotalPersonal + "}" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                               "], 'valueField':'Número','titleField':'Personal'," +
                               " 'exportConfig': { menuItems: [{ icon: Metronic.getGlobalPluginsPath() + 'amcharts/amcharts/images/export.png',format: 'png'  }] } })};" +

                               "var initChartSample7 = function() { var chart = AmCharts.makeChart('chartDocentesGrupo', { 'type': 'pie', 'theme': 'light', 'fontFamily': 'Open Sans'," +
                               "'color':    '#888','dataProvider': [{" +
                               "'Personal': 'Personal','Número':" + stats.TotalPersonal + "},{" +
                               "'Personal': 'Docentes','Número':" + stats.Docentes + "}" +
                            // "'Personal': 'Personal','Número':" + stats.TotalPersonal + "}" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                               "], 'valueField':'Número','titleField':'Personal'," +
                               " 'exportConfig': { menuItems: [{ icon: Metronic.getGlobalPluginsPath() + 'amcharts/amcharts/images/export.png',format: 'png'  }] } })};"

                               + "var initChartSample8 = function() { var chart = AmCharts.makeChart('chartAlumnos', { 'type': 'serial', 'theme': 'light', 'fontFamily': 'Open Sans'," +
                               "'color':    '#888','dataProvider': [{" +
                               "'Grado': 'Primero','Alumnos':" + stats.TotalPrimero + ", 'color':'" + GetRandomColor() + "'},{" +
                               "'Grado': 'Segundo','Alumnos':" + stats.TotalSegundo + ", 'color':'" + GetRandomColor() + "'},{" +
                               "'Grado': 'Tercero','Alumnos':" + stats.TotalTercero + ", 'color':'" + GetRandomColor() + "'}";
                        if (c.Nivel != "SECUNDARIA")
                        {
                            script1 += ",{'Grado': 'Cuarto','Alumnos':" + stats.TotalCuarto + ", 'color':'" + GetRandomColor() + "'},{" +
                                "'Grado': 'Quinto','Alumnos':" + stats.TotalQuinto + ", 'color':'" + GetRandomColor() + "'},{" +
                                "'Grado': 'Sexto','Alumnos':" + stats.TotalSexto + ", 'color':'" + GetRandomColor() + "'}";
                        }


                        script1 += "],  'valueAxes': [{  'position': 'left','axisAlpha': 0, 'gridAlpha': 0 }],'graphs': [{ 'balloonText': '[[category]]: <b>[[value]]</b>',  'colorField': 'color', 'fillAlphas': 0.85, 'lineAlpha': 0.1," +
                                "'type': 'column', 'topRadius': 1,  'valueField': 'Alumnos' }], 'depth3D': 40,  'angle': 30, 'chartCursor': {  'categoryBalloonEnabled': false," +
                                "'cursorAlpha': 0, 'zoomable': false },'categoryField': 'Grado', 'categoryAxis': { 'gridPosition': 'start','axisAlpha': 0,  'gridAlpha': 0}," +
                               " 'exportConfig': { menuItems: [{ icon: Metronic.getGlobalPluginsPath() + 'amcharts/amcharts/images/export.png',format: 'png'  }] } })};" +


                               "var initChartSample9 = function() { var chart = AmCharts.makeChart('chartPrimero', { 'type': 'pie', 'theme': 'light', 'fontFamily': 'Open Sans'," +
                               "'color':    '#888','dataProvider': [{" +
                               "'Genero': 'Mujeres','Número':" + stats.MujeresPrimero + "},{" +
                               "'Genero': 'Hombres','Número':" + stats.HombresPrimero + "}" +
                            // "'Personal': 'Personal','Número':" + stats.TotalPersonal + "}" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                               "], 'valueField':'Número','titleField':'Genero'," +
                               " 'exportConfig': { menuItems: [{ icon: Metronic.getGlobalPluginsPath() + 'amcharts/amcharts/images/export.png',format: 'png'  }] } })};" +

                                "var initChartSample10 = function() { var chart = AmCharts.makeChart('chartSegundo', { 'type': 'pie', 'theme': 'light', 'fontFamily': 'Open Sans'," +
                               "'color':    '#888','dataProvider': [{" +
                               "'Genero': 'Mujeres','Número':" + stats.MujeresSegundo + "},{" +
                               "'Genero': 'Hombres','Número':" + stats.HombresSegundo + "}" +
                            // "'Personal': 'Personal','Número':" + stats.TotalPersonal + "}" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                               "], 'valueField':'Número','titleField':'Genero'," +
                               " 'exportConfig': { menuItems: [{ icon: Metronic.getGlobalPluginsPath() + 'amcharts/amcharts/images/export.png',format: 'png'  }] } })};" +

                                   "var initChartSample11 = function() { var chart = AmCharts.makeChart('chartTercero', { 'type': 'pie', 'theme': 'light', 'fontFamily': 'Open Sans'," +
                               "'color':    '#888','dataProvider': [{" +
                               "'Genero': 'Mujeres','Número':" + stats.MujeresTercero + "},{" +
                               "'Genero': 'Hombres','Número':" + stats.HombresTercero + "}" +
                            // "'Personal': 'Personal','Número':" + stats.TotalPersonal + "}" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                            //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                               "], 'valueField':'Número','titleField':'Genero'," +
                               " 'exportConfig': { menuItems: [{ icon: Metronic.getGlobalPluginsPath() + 'amcharts/amcharts/images/export.png',format: 'png'  }] } })};";
                        bool secundaria = true;
                        if (c.Nivel != "SECUNDARIA")
                        {
                           secundaria = false;
                           script1 += "var initChartSample12 = function() { var chart = AmCharts.makeChart('chartCuarto', { 'type': 'pie', 'theme': 'light', 'fontFamily': 'Open Sans'," +
                              "'color':    '#888','dataProvider': [{" +
                              "'Genero': 'Mujeres','Número':" + stats.MujeresCuarto + "},{" +
                              "'Genero': 'Hombres','Número':" + stats.HombresCuarto + "}" +
                               // "'Personal': 'Personal','Número':" + stats.TotalPersonal + "}" +
                               //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                               //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                               //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                              "], 'valueField':'Número','titleField':'Genero'," +
                              " 'exportConfig': { menuItems: [{ icon: Metronic.getGlobalPluginsPath() + 'amcharts/amcharts/images/export.png',format: 'png'  }] } })};" +

                              "var initChartSample13 = function() { var chart = AmCharts.makeChart('chartQuinto', { 'type': 'pie', 'theme': 'light', 'fontFamily': 'Open Sans'," +
                              "'color':    '#888','dataProvider': [{" +
                              "'Genero': 'Mujeres','Número':" + stats.MujeresQuinto + "},{" +
                              "'Genero': 'Hombres','Número':" + stats.HombresQuinto + "}" +
                               // "'Personal': 'Personal','Número':" + stats.TotalPersonal + "}" +
                               //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                               //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                               //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                              "], 'valueField':'Número','titleField':'Genero'," +
                              " 'exportConfig': { menuItems: [{ icon: Metronic.getGlobalPluginsPath() + 'amcharts/amcharts/images/export.png',format: 'png'  }] } })};" +

                              "var initChartSample14 = function() { var chart = AmCharts.makeChart('chartSexto', { 'type': 'pie', 'theme': 'light', 'fontFamily': 'Open Sans'," +
                              "'color':    '#888','dataProvider': [{" +
                              "'Genero': 'Mujeres','Número':" + stats.MujeresSexto + "},{" +
                              "'Genero': 'Hombres','Número':" + stats.HombresSexto + "}" +
                               // "'Personal': 'Personal','Número':" + stats.TotalPersonal + "}" +
                               //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                               //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                               //"'Personal': 'Alumnos','Número':" + stats.MatriculaTotal + "},{" +
                              "], 'valueField':'Número','titleField':'Genero'," +
                              " 'exportConfig': { menuItems: [{ icon: Metronic.getGlobalPluginsPath() + 'amcharts/amcharts/images/export.png',format: 'png'  }] } })};";
                        }

                        script1 += " initChartSample6();initChartSample7();initChartSample8();initChartSample9();initChartSample10();initChartSample11();";
                        if(!secundaria){
                            divCuarto.Visible=true;
                            divQuinto.Visible=true;
                            divSexto.Visible= true;
                            script1+= "initChartSample12();initChartSample13();initChartSample14();";
                        }
                        else
                        {
                            divCuarto.Visible = false;
                            divQuinto.Visible = false;
                            divSexto.Visible = false;
                        }
                            script1+="</script> ";
                        //ScriptManager.RegisterClientScriptBlock(this, typeof(string), "initCharts", script1, true);
                        litGraphs.Text = script1;

                        #endregion
                    }
                    lblEstadisticas.Text = stat;
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}