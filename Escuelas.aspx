<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Escuelas.aspx.cs" Inherits="Escuelas" %>

<%@ Register Src="~/Controls/Sharer.ascx" TagPrefix="uc1" TagName="Sharer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" runat="Server">
    <link href="/css/select2.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" runat="Server">
    <h2>Escuelas</h2>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="Server">
    <uc1:Sharer runat="server" ID="Sharer" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="alert alert-info">
                    <p>Utiliza los filtros de la derecha para encontrar tu escuela. Podrás usar el mapa o también ver los resultados en la parte de abajo.</p>
                </div>

                <div class="col-md-3">
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-speech"></i>
                                <span class="caption-subject bold uppercase">Filtros</span>
                                <span class="caption-helper">Presiona Buscar</span>
                            </div>

                        </div>
                        <div class="portlet-body">
                            <div class="scroller" style="height: 360px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                <div class="form-group">
                                    <label>Nombre de Escuela</label>
                                    <div class="input-group">

                                        <asp:TextBox runat="server" ID="txtNombre" MaxLength="50" CssClass="form-control" />

                                    </div>
                                </div>
                                <div class="form-group" style="display:none">
                                    <label>Clave de Escuela</label>
                                    <div class="input-group">

                                        <asp:TextBox runat="server" ID="txtClave" MaxLength="50" CssClass="form-control" />

                                    </div>
                                </div>
                                <div class="form-group">
                                    <label>Municipio</label>
                                    <div class="input-group">

                                        <asp:DropDownList runat="server" ID="cmbMunicipio" CssClass="form-control cmb">
                                            <asp:ListItem Text="Seleccione..." />
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label>Nivel</label>
                                    <div class="input-group">

                                        <asp:DropDownList runat="server" ID="cmbNivel" CssClass="form-control cmb" AppendDataBoundItems="true">
                                          <asp:ListItem Text="Seleccione..." />
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <label>Turno</label>
                                    <div class="input-group">

                                        <asp:DropDownList runat="server" ID="cmbTurno" CssClass="form-control">
                                            <asp:ListItem Text="Seleccione..." />
                                            <asp:ListItem Text="MATUTINO" />
                                            <asp:ListItem Text="DISCONTINUO" />
                                            <asp:ListItem Text="CONTINUO (JORNADA AMPLIADA)" />
                                            <asp:ListItem Text="VESPERTINO" />
                                            <asp:ListItem Text="CONTINUO (TIEMPO COMPLETO)" />
                                            <asp:ListItem Text="NOCTURNO" />
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <asp:Button Text="Buscar" CssClass="btn green" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-9">
                    <div id="map" class="gmaps" style="position: relative; overflow: hidden; height: 450px; background-color: rgb(229, 227, 223);">
                        <div class="gm-err-container">
                            <div class="gm-err-content">
                                <div class="gm-err-icon">
                                    <img src="http://maps.gstatic.com/mapfiles/api-3/images/icon_error.png" draggable="false" style="-webkit-user-select: none;">
                                </div>
                                <div class="gm-err-title">Se ha producido un error.</div>
                                <div class="gm-err-message">Esta página no ha cargado Google Maps correctamente. Descubre los detalles técnicos del problema en la consola de JavaScript.</div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption font-green-sharp">
                                <i class="icon-speech font-green-sharp"></i>
                                <span class="caption-subject">Resultados</span>
                                <span class="caption-helper"></span>
                            </div>

                        </div>
                        <div class="portlet-body">
                            <div class="scroller" style="height: 500px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                
                                <asp:Literal Text="" ID="litResultados" runat="server" />



                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" runat="Server">
    <script src="/Scripts/select2.js"></script>
    <script>
        var map;
        var markers = [];
        $('.cmb').select2();
        function initMap() {
            var mapDiv = document.getElementById('map');
            map = new google.maps.Map(mapDiv, {
                center: { lat: 20.6667, lng: -103.333 },
                zoom: 8
            });
        <%--var marker = new google.maps.Marker({
            position: { lat: <%= hdLat.Value %>, lng: <%= hdLon.Value %> },
            map: map,
            title: 'Hello World!'
        });--%>
        }
        function setMapOnAll(map) {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(map);
            }
        }
        // Removes the markers from the map, but keeps them in the array.
        function clearMarkers() {
            setMapOnAll(null);
        }

        // Shows any markers currently in the array.
        function showMarkers() {
            setMapOnAll(map);
        }

        // Deletes all markers in the array by removing references to them.
        function deleteMarkers() {
            clearMarkers();
            markers = [];
        }
        function fitBounds() {
            var bounds = new google.maps.LatLngBounds();
            for (var i = 0; i < markers.length; i++) {
                bounds.extend(markers[i].getPosition());
            }

            map.fitBounds(bounds);
        }
        $(document).ready(function () {
            Page = Sys.WebForms.PageRequestManager.getInstance();
            Page.add_beginRequest(OnBeginRequest);
            Page.add_endRequest(endRequest);

            function OnBeginRequest(sender, args) {
                $.blockUI({ message: '<h1><img src="/img/loading.gif" /> Cargando...</h1>' });
            }
            function endRequest(sender, args) {
                $.unblockUI();
                $('.cmb').select2();
                Metronic.init();
            }

        });
    </script>
    <script async defer
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD9EdL9LFmx1dygwt7TOjpwsQJVH9s6F24&callback=initMap">
    </script>
</asp:Content>

