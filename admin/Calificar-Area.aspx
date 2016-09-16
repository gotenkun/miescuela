<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Calificar-Area.aspx.cs" Inherits="admin_Calificar_Area" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" runat="Server">
    <h1>Calificar Área
        <asp:Label Text="" ID="lblArea" runat="server" /></h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="col-md-12">
        <div class="portlet light bg-inverse">
            <div class="portlet-title">
                <div class="caption font-red-sunglo">
                    <i class="icon-share font-red-sunglo"></i>
                    <span class="caption-subject bold uppercase">Calificar área 
                        <asp:Label Text="" ID="lblTitulo1" runat="server" /></span>
                    <span class="caption-helper"></span>
                </div>

            </div>
            <div class="portlet-body">
                <h4>Califica esta área y escribe algunos comentarios (opcional).
                </h4>
                <asp:HiddenField runat="server" ID="hdID" />
                <div class="form-group">
                    <label>¿Cómo calificas esta área?</label>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="fa fa-star"></i>
                        </span>
                        <asp:DropDownList runat="server" CssClass="form-control input-small" ID="cmbCalificacion">
                            <asp:ListItem Text="Selecciona..." />
                            <asp:ListItem Text="Muy mal" />
                            <asp:ListItem Text="Mal" />
                            <asp:ListItem Text="Regular" />
                            <asp:ListItem Text="Bien" />
                            <asp:ListItem Text="Excelente" />

                        </asp:DropDownList>

                    </div>
                </div>
                <div class="form-group">
                    <label>Escribe tus comentarios (opcional)</label>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="fa fa-envelope"></i>
                        </span>
                        <asp:TextBox runat="server" ID="txtComentarios" TextMode="MultiLine" CssClass="form-control input-medium" />

                    </div>
                </div>
                <div class="form-group">
                    <label for="exampleInputFile1">Seleccionar Foto:</label>
                    <asp:FileUpload runat="server" ID="fuFoto" accept="image/*" />
                    <p class="help-block">
                        Indica solo imágenes.
                    </p>
                </div>
            </div>
            <hr />
            <div class="form-actions">
                <asp:Label Text="" ForeColor="Red" ID="lblError" runat="server" />
                <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn blue" runat="server" OnClick="btnGuardar_Click" OnClientClick="return confirm('¿Deseas guardar tu calificación?')" />
                <a href="" class="btn default" runat="server" id="hlCancelar">Cancelar</a>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" runat="Server">
</asp:Content>

