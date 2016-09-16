<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UsersAndRoles.aspx.cs" Inherits="Admin_Membership_UsersAndRoles" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="Server">

    <h2>Administrar Roles de Usuarios</h2>
    <p align="center">
        <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label>
    </p>
    <h3>Administrar Roles por Usuario</h3>
    <p>
        <b>Seleccione un Usuario:</b>
        <asp:DropDownList ID="UserList" runat="server" AutoPostBack="True"
            
            OnSelectedIndexChanged="UserList_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Repeater ID="UsersRoleList" runat="server">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="RoleCheckBox" AutoPostBack="true" Text='<%# Container.DataItem %>' OnCheckedChanged="RoleCheckBox_CheckChanged" />
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </p>
    <div style="visibility: hidden;">
        <h3>Administrar Usuarios por Roles</h3>
        <p>
            <b>Select a Role:</b>
            <asp:DropDownList ID="RoleList" runat="server" AutoPostBack="true"
                OnSelectedIndexChanged="RoleList_SelectedIndexChanged">
            </asp:DropDownList>
        </p>
        <p>
            <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="False"
                EmptyDataText="No users belong to this role."
                OnRowDeleting="RolesUserList_RowDeleting">
                <Columns>
                    <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
                    <asp:TemplateField HeaderText="Users">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="UserNameLabel" Text='<%# Container.DataItem %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </p>
        <p>
            <b>UserName:</b>
            <asp:TextBox ID="UserNameToAddToRole" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="AddUserToRoleButton" runat="server" Text="Add User to Role"
                OnClick="AddUserToRoleButton_Click" />
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/responsiveDataTable.css" />

</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="BreadCrumb" runat="Server">
    <ul class="page-breadcrumb">
        <li>
            <i class="fa fa-home"></i>
            <a href="/Admin/Seguridad">Seguridad</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Roles</a>
        </li>
    </ul>
</asp:Content>--%>
<asp:Content ID="contentStyles" ContentPlaceHolderID="contentStyles" runat="server">
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/datatables/extensions/Scroller/css/dataTables.scroller.min.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/datatables/extensions/ColReorder/css/dataTables.colReorder.min.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css" />
</asp:Content>
<asp:Content ID="contentScripts" ContentPlaceHolderID="contentScript" runat="server">
    <script type="text/javascript" src="/assets/global/plugins/select2/select2.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/media/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/extensions/TableTools/js/dataTables.tableTools.min.js"></script>
    <%--  <script type="text/javascript" src="/assets/global/plugins/datatables/extensions/ColReorder/js/dataTables.colReorder.min.js"></script>--%>
    <script type="text/javascript" src="/assets/global/plugins/datatables/extensions/Scroller/js/dataTables.scroller.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js"></script>
    <script src="/assets/admin/pages/scripts/table-advanced.js"></script>
</asp:Content>


