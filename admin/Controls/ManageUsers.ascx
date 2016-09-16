<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManageUsers.ascx.cs" Inherits="admin_Controls_ManageUsers" %>
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
                    DataNavigateUrlFormatString="/Admin/Membership/UserInformation.aspx?user={0}" 
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