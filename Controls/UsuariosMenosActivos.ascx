<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UsuariosMenosActivos.ascx.cs" Inherits="Controls_UsuariosMenosActivos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

        <asp:DataList ID="DataList1" runat="server"
            Width="100%" Style="text-align: left">
            <ItemStyle CssClass="NoticiaReciente" />
            <ItemTemplate>
                <img src='<%# "/image.aspx?resize=1&w=40&id=" + DataBinder.Eval(Container.DataItem,"ImagenID") %>' />
                    <asp:HyperLink ID="TituloLabel" runat="server" Font-Size="Small"
                        NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"UsuarioID") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem,"Nombre") %>'></asp:HyperLink><br />
                          

                    <hr />
            </ItemTemplate>
        </asp:DataList>

