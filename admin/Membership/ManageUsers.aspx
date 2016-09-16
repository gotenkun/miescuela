<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="Admin_Membership_ManageUsers" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="/css/responsiveDataTable.css" />

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" Runat="Server">
    <h2>
        Administrar Usuarios</h2>
    <p>
        <asp:Repeater ID="FilteringUI" runat="server" 
            onitemcommand="FilteringUI_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="lnkFilter" 
                                Text='<%# Container.DataItem %>' 
                                CommandName='<%# Container.DataItem %>'></asp:LinkButton>
            </ItemTemplate>
            
            <SeparatorTemplate>|</SeparatorTemplate>
        </asp:Repeater>
    </p>
    <p>
        <asp:GridView ID="grd" runat="server" ClientIDMode="Static"  CssClass="table table-striped table-bordered table-hover" 
            AutoGenerateColumns="False">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="UserName" 
                    DataNavigateUrlFormatString="UserInformation.aspx?user={0}" 
                    Text="Editar..." />
                <asp:BoundField DataField="UserName" HeaderText="Usuario" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:CheckBoxField DataField="IsApproved" HeaderText="Aprobado" />
                <asp:CheckBoxField DataField="IsLockedOut" HeaderText="Bloqueado" />
              <%--  <asp:CheckBoxField DataField="IsOnline" HeaderText="Conectado" />--%>
                <asp:BoundField DataField="Comment" HeaderText="Comentario" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
      <%--  <asp:LinkButton ID="lnkFirst" runat="server" onclick="lnkFirst_Click">&lt;&lt; Primera</asp:LinkButton> |
        <asp:LinkButton ID="lnkPrev" runat="server" onclick="lnkPrev_Click">&lt; Anterior</asp:LinkButton> |
        <asp:LinkButton ID="lnkNext" runat="server" onclick="lnkNext_Click">Siguiente &gt;</asp:LinkButton> |
        <asp:LinkButton ID="lnkLast" runat="server" onclick="lnkLast_Click">Última &gt;&gt;</asp:LinkButton>--%>
    </p>
</asp:Content>
<asp:Content ID="contentStyles" ContentPlaceHolderID="contentStyles" runat="server">
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/datatables/extensions/Scroller/css/dataTables.scroller.min.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/datatables/extensions/ColReorder/css/dataTables.colReorder.min.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css" />
</asp:Content>
<asp:Content ContentPlaceHolderID="contentScript" runat="server">
    <script type="text/javascript" src="/assets/global/plugins/select2/select2.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/media/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/extensions/TableTools/js/dataTables.tableTools.min.js"></script>
    <%--  <script type="text/javascript" src="/assets/global/plugins/datatables/extensions/ColReorder/js/dataTables.colReorder.min.js"></script>--%>
    <script type="text/javascript" src="/assets/global/plugins/datatables/extensions/Scroller/js/dataTables.scroller.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js"></script>
    <script src="/assets/admin/pages/scripts/table-advanced.js"></script>
     <script>
        $(document).ready(function () {
            TableAdvanced.init();

        });
         </script>
</asp:Content>
