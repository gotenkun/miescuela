<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Estadistica.aspx.cs" Inherits="Estadistica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" runat="Server">
    <h2>
        <asp:Label Text="" ID="lblTitulo" runat="server" /></h2>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="Server">
    <asp:Label Text="" ID="lblEstadisticas" runat="server" />
    <div class="row">
        <div class="col-md-6">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-bar-chart font-green-haze"></i>
                        <span class="caption-subject bold uppercase font-green-haze">Composición Personas</span>
                    </div>

                </div>
                <div class="portlet-body">
                    <div id="chartPersonalvsAlumnos" class="chart" style="height: 325px;">
                    </div>
                </div>
            </div>
        </div>

         <div class="col-md-6">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-bar-chart font-green-haze"></i>
                        <span class="caption-subject bold uppercase font-green-haze">Docentes VS Personal</span>
                    </div>

                </div>
                <div class="portlet-body">
                    <div id="chartDocentesGrupo" class="chart" style="height: 325px;">
                    </div>
                </div>
            </div>
        </div>

          <div class="col-md-12">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-bar-chart font-green-haze"></i>
                        <span class="caption-subject bold uppercase font-green-haze">Distribución Alumnos</span>
                    </div>

                </div>
                <div class="portlet-body">
                    <div id="chartAlumnos" class="chart" style="height: 325px;">
                    </div>
                </div>
            </div>
        </div>

         <div class="col-md-4">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-bar-chart font-green-haze"></i>
                        <span class="caption-subject bold uppercase font-green-haze">Primero: Mujeres y Hombres</span>
                    </div>

                </div>
                <div class="portlet-body">
                    <div id="chartPrimero" class="chart" style="height: 325px;">
                    </div>
                </div>
            </div>
        </div>

          <div class="col-md-4">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-bar-chart font-green-haze"></i>
                        <span class="caption-subject bold uppercase font-green-haze">Segundo: Mujeres y Hombres</span>
                    </div>

                </div>
                <div class="portlet-body">
                    <div id="chartSegundo" class="chart" style="height: 325px;">
                    </div>
                </div>
            </div>
        </div>

          <div class="col-md-4">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-bar-chart font-green-haze"></i>
                        <span class="caption-subject bold uppercase font-green-haze">Tercero: Mujeres y Hombres</span>
                    </div>

                </div>
                <div class="portlet-body">
                    <div id="chartTercero" class="chart" style="height: 325px;">
                    </div>
                </div>
            </div>
        </div>

          <div class="col-md-4" runat ="server" id="divCuarto">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-bar-chart font-green-haze"></i>
                        <span class="caption-subject bold uppercase font-green-haze">Cuarto: Mujeres y Hombres</span>
                    </div>

                </div>
                <div class="portlet-body">
                    <div id="chartCuarto" class="chart" style="height: 325px;">
                    </div>
                </div>
            </div>
        </div>

          <div class="col-md-4" runat="server" id="divQuinto">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-bar-chart font-green-haze"></i>
                        <span class="caption-subject bold uppercase font-green-haze">Quinto: Mujeres y Hombres</span>
                    </div>

                </div>
                <div class="portlet-body">
                    <div id="chartQuinto" class="chart" style="height: 325px;">
                    </div>
                </div>
            </div>
        </div>

          <div class="col-md-4" runat="server" id="divSexto">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-bar-chart font-green-haze"></i>
                        <span class="caption-subject bold uppercase font-green-haze">Sexto: Mujeres y Hombres</span>
                    </div>

                </div>
                <div class="portlet-body">
                    <div id="chartSexto" class="chart" style="height: 325px;">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" runat="Server">
    <script src="/assets/global/plugins/amcharts/amcharts/amcharts.js" type="text/javascript"></script>
    <script src="/assets/global/plugins/amcharts/amcharts/serial.js" type="text/javascript"></script>
    <script src="/assets/global/plugins/amcharts/amcharts/pie.js" type="text/javascript"></script>
    <script src="/assets/global/plugins/amcharts/amcharts/radar.js" type="text/javascript"></script>
    <script src="/assets/global/plugins/amcharts/amcharts/themes/light.js" type="text/javascript"></script>
    <script src="/assets/global/plugins/amcharts/amcharts/themes/patterns.js" type="text/javascript"></script>
    <script src="/assets/global/plugins/amcharts/amcharts/themes/chalk.js" type="text/javascript"></script>
    <script src="/assets/global/plugins/amcharts/ammap/ammap.js" type="text/javascript"></script>
    <script src="/assets/global/plugins/amcharts/ammap/maps/js/worldLow.js" type="text/javascript"></script>
    <script src="/assets/global/plugins/amcharts/amstockcharts/amstock.js" type="text/javascript"></script>
 <%-- <script type="text/javascript">
      //<![CDATA[
      var initChartSample6 = function () {
          var chart = AmCharts.makeChart('chart_6',
              {
                  'type': 'pie',
                  'theme': 'light',
                  'fontFamily': 'Open Sans',
                  'color': '#888',
                  'dataProvider': [
                      { 'Personal': 'Alumnos', 'Número': 202 },
                      { 'Personal': 'Docentes', 'Número': 11 },
                      { 'Personal': 'Personal', 'Número': 15 }],
                  'valueField': 'Número',
                  'titleField': 'Personal',
                  'exportConfig': {
                      menuItems: [
                          { icon: Metronic.getGlobalPluginsPath() + 'amcharts/amcharts/images/export.png', format: 'png' }]
                  }
              }
              )
      }; //]]>--%>
    <asp:Literal Text="" ID="litGraphs" runat="server" />
</asp:Content>

