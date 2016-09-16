<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageRoles.aspx.cs" Inherits="Membership_ManageRoles" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="Server">
    <h2>Administrar Roles</h2>
    <p>
        <b>Crear un nuevo Rol: </b>
        <asp:TextBox ID="RoleName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RoleNameReqField" runat="server"
            ControlToValidate="RoleName" Display="Dynamic"
            ErrorMessage="Debe ingresar el nombre del rol."></asp:RequiredFieldValidator>

        <br />
        <asp:Button ID="CreateRoleButton" runat="server" Text="Crear Rol" CssClass="btn blue inline-block"
            OnClick="CreateRoleButton_Click" />
    </p>
    <br />
    <p>
        <asp:GridView ID="grd"  CssClass="table table-striped table-bordered table-hover"  runat="server" AutoGenerateColumns="False"
            OnRowDeleting="RoleList_RowDeleting">
            <Columns>
                <asp:CommandField DeleteText="Eliminar Rol" ShowDeleteButton="True" ItemStyle-Width="100" />
                <asp:TemplateField HeaderText="Rol">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="RoleNameLabel" Text='<%# Container.DataItem %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/responsiveDataTable.css" />

</asp:Content>

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

