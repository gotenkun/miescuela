<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Agregar-Usuario.aspx.cs" Inherits="Admin_Membership_Agregar_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="BreadCrumb" Runat="Server">
     <ul class="page-breadcrumb">
        <li>
            <i class="fa fa-home"></i>
            <a href="/Admin/Inicio">Inicio</a>
            <i class="fa fa-angle-right"></i>
            <a href="/Red/Agregar-Usuario">Agregar Usuario</a>
          
        </li>

    </ul>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="row ">
        <div class="col-md-12">
            <div role="form">
                <div class="form-group">
                    <label class="control-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" placeholder="John" CssClass="form-control" MaxLength="100" />
                    <h5 class="text-red" runat="server" id="lblErrorNombre" visible="false">*Indique el nombre</h5>
                </div>
                <div class="form-group">
                    <label class="control-label">Apellidos</label>
                    <asp:TextBox runat="server" ID="txtApellidos" placeholder="Doe" CssClass="form-control" MaxLength="100" />
                    <h5 class="text-red" runat="server" id="lblErrorApellidos" visible="false">Indique los apellidos</h5>
                </div>
              
                 <div class="form-group">
                    <label class="control-label">Email</label>
                    <asp:TextBox runat="server" ID="txtEmail" placeholder="correo@dominio.com" CssClass="form-control" MaxLength="50" />
                    <h5 class="text-red" runat="server" id="lblErrorEmail" visible="false">*Indique el Email</h5>
                </div>
                <div class="form-group">
                    <label class="control-label">Usuario</label>
                    <asp:TextBox runat="server" ID="txtUsuario" placeholder="miusuario" CssClass="form-control" MaxLength="50" />
                    <h5 class="text-red" runat="server" id="lblErrorUsuario" visible="false">*Indique nombre de usuario de al menos 5 caracteres</h5>
                </div>
                <div class="form-group">
                    <label class="control-label">Contraseña</label>
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="Indique al menos 6 caracteres" CssClass="form-control" MaxLength="50" />

                </div>
                <div class="form-group">
                    <label class="control-label">Confirmar Contraseña</label>
                    <asp:TextBox runat="server" ID="txtConfirmarPassword" TextMode="Password"  placeholder="Indique al menos 6 caracteres" CssClass="form-control" MaxLength="100" />
                     <h5 class="text-red" runat="server" visible="false" id="lblErrorContrasenaNueva">*Falta capturar nueva contraseña / No coincide la contraseña</h5>
                </div>
                <div class="form-group">
                    <label class="control-label">Indique el rol que desempeñará el usuario</label>
                    <asp:DropDownList runat="server" ID="cmbRoles" CssClass="form-control input-small">
                        <asp:ListItem Text="SuperAdmin" />
                        <asp:ListItem Text="EscuelaAdmin" />
                        <asp:ListItem Text="Docente" />
                        <asp:ListItem Text="Personal" />
                        <asp:ListItem Text="Tutor" />
                        <asp:ListItem Text="Alumno" />

                    </asp:DropDownList>
                </div>
              <div class="form-group">
                  <asp:LinkButton Text="Crear Usuario" ID="lnkCrearUsuario" CssClass="btn green" OnClick="lnkCrearUsuario_Click" OnClientClick="return confirm('¿Desea guardar a este usuario?')"  runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

