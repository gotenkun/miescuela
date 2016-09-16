<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Crear-Idea.aspx.cs" Inherits="admin_Crear_Idea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" Runat="Server">
        <h1>Crear Idea
        <asp:Label Text="" ID="lblArea" runat="server" /></h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">
      <div class="col-md-12">
        <div class="portlet light bg-inverse">
            <div class="portlet-title">
                <div class="caption font-red-sunglo">
                    <i class="icon-share font-red-sunglo"></i>
                    <span class="caption-subject bold uppercase">Crear Idea
                        <asp:Label Text="" ID="lblTitulo1" runat="server" /></span>
                    <span class="caption-helper"></span>
                </div>

            </div>
            <div class="portlet-body">
                <h4>Llena los campos de tu idea y presiona Guardar.
                </h4>
                <asp:HiddenField runat="server" ID="hdID" />
                 <div class="form-group">
                    <label>Tu idea es para mejorar:</label>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="fa fa-star"></i>
                        </span>
                        <asp:DropDownList runat="server" CssClass="form-control input-small" ID="cmbTipo">
                            <asp:ListItem Text="Selecciona..." />
                            <asp:ListItem Text="La convivencia escolar" />
                            <asp:ListItem Text="Transparencia" />
                            <asp:ListItem Text="La formación de los maestros" />
                            <asp:ListItem Text="Comunicación con los padres de familia" />
                            <asp:ListItem Text="Mejorar mi escuela" />

                        </asp:DropDownList>

                    </div>
                </div>
               <div class="form-group">
                    <label>Nombre de tu Idea</label>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="fa fa-envelope"></i>
                        </span>
                        <asp:TextBox runat="server" ID="txtNombre" MaxLength="50"  CssClass="form-control input-medium" />

                    </div>
                </div>
                <div class="form-group">
                    <label>Describe tu idea</label>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="fa fa-envelope"></i>
                        </span>
                        <asp:TextBox runat="server" ID="txtComentarios" TextMode="MultiLine" CssClass="form-control input-medium" />

                    </div>
                </div>
                <div class="form-group">
                    <label for="exampleInputFile1">Seleccionar Foto (opcional):</label>
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
          </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" Runat="Server">
</asp:Content>

