<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Escuela.aspx.cs" Inherits="Escuela" %>

<%@ Register Src="~/Controls/Noticias.ascx" TagPrefix="uc1" TagName="Noticias" %>
<%@ Register Src="~/Controls/Sharer.ascx" TagPrefix="uc1" TagName="Sharer" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" runat="Server">
   <link rel="stylesheet" href="/css/styles.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="Server">
   
           <uc1:Sharer runat="server" ID="Sharer" />
    <div class="row">
        <div class="col-md-12">
            "
            <div style="width: 100%; height: 250px; overflow: hidden">
                <img runat="server" id="imgPrincipal" style="width: 100%;" alt="" />
            </div>
            <br />
            <h1>
                <asp:Label Text="" ID="lblNombre" runat="server" /></h1>
            <hr />
        </div>
    </div>
    <asp:Label Text="" ID="lblEstadisticas" runat="server" />
    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN Portlet PORTLET-->
            <div class="portlet box red-sunglo">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-gift"></i>CONOCE LA ESCUELA
                    </div>

                </div>
                <div class="portlet-body">
                    <p>Navega en las secciones de abajo para que puedas conocer cada detalle de esta escuela</p>
                    <div class="row">
                        <div class="col-md-4">

                            <!-- BEGIN Portlet PORTLET-->
                            <div class="portlet solid purple">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-gift"></i>Personal
                                    </div>
                                    <div class="actions">
                                        <a href="javascript:;" runat="server" id="hlVerPersonal" class="btn blue btn-sm">
                                            <i class="fa fa-users"></i> Ver Todos </a>

                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto; height: 200px;">
                                        <div class="scroller" style="height: 200px; overflow: hidden; width: auto;" data-initialized="1">
                                            <asp:Literal Text="" ID="litPersonal" runat="server" />
                                        </div>
                                        <div class="slimScrollBar" style="width: 7px; position: absolute; top: 0px; opacity: 0.4; display: block; border-radius: 7px; z-index: 99; right: 1px; height: 64.1026px; background: rgb(187, 187, 187);"></div>
                                        <div class="slimScrollRail" style="width: 7px; height: 100%; position: absolute; top: 0px; display: none; border-radius: 7px; opacity: 0.2; z-index: 90; right: 1px; background: rgb(234, 234, 234);"></div>
                                    </div>
                                </div>
                            </div>
                            <!-- END Portlet PORTLET-->
                        </div>
                        <div class="col-md-4">
                            <!-- BEGIN Portlet PORTLET-->
                            <div class="portlet gren">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-gift"></i>Áreas
                                    </div>
                                    <div class="actions">
                                        <a href="" runat="server" id="hlVerAreas" class="btn blue btn-sm">
                                            <i class="fa fa-building"></i> Ver Todas </a>

                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto; height: 200px;">
                                        <div class="scroller" style="height: 200px; overflow: hidden; width: auto;" data-initialized="1">
                                            <p>Conoce y califica las áreas de tu escuela. </p>
                                            <asp:Label Text="" ID="lblAreas" runat="server" />
                                            <asp:Panel ID="pnlAreas" runat="server">
                                            </asp:Panel>
                                        </div>
                                        <div class="slimScrollBar" style="width: 7px; position: absolute; top: 0px; opacity: 0.4; display: none; border-radius: 7px; z-index: 99; right: 1px; height: 64.1026px; background: rgb(187, 187, 187);"></div>
                                        <div class="slimScrollRail" style="width: 7px; height: 100%; position: absolute; top: 0px; display: none; border-radius: 7px; opacity: 0.2; z-index: 90; right: 1px; background: rgb(234, 234, 234);"></div>
                                    </div>
                                </div>
                            </div>
                            <!-- END Portlet PORTLET-->
                        </div>
                        <div class="col-md-4">
                            <!-- BEGIN Portlet PORTLET-->
                            <div class="portlet box yellow">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-gift"></i>Noticias
                                    </div>
                                    <div class="actions">
                                        <a href="javascript:;" class="btn blue btn-sm">
                                            <i class="fa fa-newspaper-o"></i> Ver Todas </a>

                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto; height: 200px;">
                                        <div class="scroller" style="height: 200px; overflow: hidden; width: auto;" data-initialized="1">
                                            <uc1:Noticias runat="server" ID="Noticias" />
                                        </div>
                                        <div class="slimScrollBar" style="width: 7px; position: absolute; top: 0px; opacity: 0.4; display: block; border-radius: 7px; z-index: 99; right: 1px; height: 58.9971px; background: rgb(187, 187, 187);"></div>
                                        <div class="slimScrollRail" style="width: 7px; height: 100%; position: absolute; top: 0px; display: none; border-radius: 7px; opacity: 0.2; z-index: 90; right: 1px; background: rgb(234, 234, 234);"></div>
                                    </div>
                                </div>
                            </div>
                            <!-- END Portlet PORTLET-->
                        </div>
                    </div>

                </div>
            </div>
            <!-- END Portlet PORTLET-->
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="portlet box blue-hoki">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-gift"></i>Información General
                    </div>

                </div>
                <div class="portlet-body">
                    <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto; height: 340px;">
                        <div class="scroller" style="height: 100%; overflow: hidden; width: auto;" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd" data-initialized="1">
                            <asp:Label Text="" ID="lblInformacionGeneral" runat="server" />
                        </div>
                        <div class="slimScrollBar" style="width: 7px; position: absolute; top: 0px; opacity: 0.4; display: block; border-radius: 7px; z-index: 99; right: 1px; height: 138.889px; background: rgb(161, 178, 189);"></div>
                        <div class="slimScrollRail" style="width: 7px; height: 100%; position: absolute; top: 0px; display: none; border-radius: 7px; opacity: 0.2; z-index: 90; right: 1px; background: yellow;"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-gift"></i>Ubicación
                    </div>

                </div>
                <div class="portlet-body">
                    <asp:HiddenField runat="server" ID="hdLat" />
                    <asp:HiddenField runat="server" ID="hdLon" />
                    <div id="map" class="gmaps" style="position: relative; overflow: hidden; background-color: rgb(229, 227, 223);">
                        <div class="gm-err-container">
                            <div class="gm-err-content">
                                <div class="gm-err-icon">
                                    <img src="http://maps.gstatic.com/mapfiles/api-3/images/icon_error.png" draggable="false" style="-webkit-user-select: none;"></div>
                                <div class="gm-err-title">Se ha producido un error.</div>
                                <div class="gm-err-message">Esta página no ha cargado Google Maps correctamente. Descubre los detalles técnicos del problema en la consola de JavaScript.</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" runat="Server">
    <script>
        function initMap() {
            var mapDiv = document.getElementById('map');
            var map = new google.maps.Map(mapDiv, {
                center: {lat: <%= hdLat.Value %>, lng: <%= hdLon.Value %>},
            zoom: 15
        });
        var marker = new google.maps.Marker({
            position: { lat: <%= hdLat.Value %>, lng: <%= hdLon.Value %> },
            map: map,
            title: 'Hello World!'
        });
    }
    </script>
    <script async defer
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD9EdL9LFmx1dygwt7TOjpwsQJVH9s6F24&callback=initMap">
    </script>
</asp:Content>

