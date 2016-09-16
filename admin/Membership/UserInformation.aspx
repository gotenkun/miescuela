<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserInformation.aspx.cs" Inherits="Admin_Memberhip_UserInformation" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" Runat="Server">
    <h2>Información del Usuario</h2>
    <p>
        <asp:HyperLink ID="BackLink" runat="server" 
            NavigateUrl="~/Admin/Users/ManageUsers.aspx">&lt;&lt; Volver a lista de Usuarios</asp:HyperLink>
    </p>
    <table>
        <tr>
            <td class="tdLabel">Usuario:</td>
            <td><asp:Label runat="server" ID="UserNameLabel"></asp:Label></td>
        </tr>
        <tr>
            <td class="tdLabel">Aprobado:</td>
            <td>
                <asp:CheckBox ID="IsApproved" runat="server" AutoPostBack="true" 
                    oncheckedchanged="IsApproved_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td class="tdLabel">Bloqueado:</td>
            <td>
                <asp:Label runat="server" ID="LastLockoutDateLabel"></asp:Label>
                <br />
                <asp:Button runat="server" ID="UnlockUserButton" Text="Desbloquear" 
                    onclick="UnlockUserButton_Click" />
            </td>
        </tr>
        <tr>
            <td class="tdLabel">Eliminar:</td>
            <td>
                <asp:Button ID="btEliminar" runat="server" Height="26px" 
                    onclick="btEliminar_Click" 
                    onclientclick="return confirm('¿Desea Eliminar a este usuario del sistema?')" 
                    Text="Eliminar" Width="105px" />
            </td>
        </tr>
         <tr>
            <td class="tdLabel">Cambiar Password:</td>
            <td>
                <asp:Button ID="btnCambiarPAssword" runat="server" Height="26px" 
                    OnClick="btnCambiarPAssword_Click"
                   
                    Text="Cambiar" Width="105px" />
            </td>
        </tr>
       <%-- <tr>
            <td class="tdLabel">Usuarios disponibles:</td>
            <td>
                <asp:TextBox runat="server" ID="txtUsuariosExtras" />
                <asp:Button ID="btnAsignarUsuarios" runat="server" Height="26px" 
                    OnClick="btnAsignarUsuarios_Click"
                   
                    Text="Cambiar" Width="105px" />
            </td>
        </tr>--%>
    </table>
    <p>
        <asp:Label ID="StatusMessage" CssClass="Important" runat="server"></asp:Label>
    </p>
</asp:Content>
