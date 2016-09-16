<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_Memberhip_ChangePassword" Title="Cambiar Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>
            <strong>INICIO</strong>
            <small>Cambiar Password</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="/Admin/Inicio"></i> Home</a></li>
            <!-- <li class="active">Progreso</li>-->
        </ol>
    </section>

    <!-- Main content -->
    <!-- Main content -->
    <section class="content">
        <p>
            <asp:HyperLink ID="BackLink" runat="server"
                NavigateUrl="~/Admin/Membership/ManageUsers">&lt;&lt; Volver a lista de Usuarios</asp:HyperLink>
        </p>
        <div class="form-group">
            <label for="">Nueva Contraseña</label>
            <asp:TextBox runat="server" MaxLength="100" CssClass="form-control" ID="txtContrasenaNueva" placeholder="Nueva contraseña" />
            <h5 class="text-red" runat="server" visible="false" id="lblErrorContrasenaNueva">*Falta capturar nueva contraseña / No coincide la contraseña</h5>
        </div>
        <div class="form-group">
            <label for="">Confirmación Nueva Contraseña</label>
            <asp:TextBox runat="server" MaxLength="100" CssClass="form-control" ID="txtContrasenaConfirmar" placeholder="Confirmación Nueva contraseña" />
            <h5 class="text-red" runat="server" visible="false" id="lblErrorContrasenaConfirmar">*Falta capturar confirmación nueva contraseña / No coincide la contraseña</h5>
        </div>
        <p>
            <asp:Label ID="StatusMessage" CssClass="Important" runat="server"></asp:Label>
        </p>
        <div class="box-header with-border">
            <div class="timeline-footer">
                <asp:LinkButton runat="server" ID="lnkGuardar" OnClientClick="return confirm('¿Desea guardar los cambios?');" OnClick="lnkGuardar_Click" class="btn btn-info btn-lg pull-right">GUARDAR CAMBIOS</asp:LinkButton>
            </div>
        </div>
    </section>
</asp:Content>
