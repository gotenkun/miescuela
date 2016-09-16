<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MejoresIdeas.ascx.cs" Inherits="Controls_MejoresIdeas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

        <asp:DataList ID="DataList1" runat="server"
            Width="290px" Style="text-align: left">
            <ItemStyle CssClass="NoticiaReciente" />
            <ItemTemplate>

                    <asp:HyperLink ID="TituloLabel" runat="server" Font-Size="Medium"
                        NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"IdeaID") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem,"Titulo") %>'></asp:HyperLink><br />
                          <img src='<%# "/img/star" + DataBinder.Eval(Container.DataItem,"Rating") + ".png" %>' />
                            (<asp:Label Text='<%# DataBinder.Eval(Container.DataItem,"Votos") %>' ID="lblVotos" runat="server" />
                            votos)
                    <br /><small>Propuesta por <%# DataBinder.Eval(Container.DataItem,"Usuario") %></small>
                    <hr />
            </ItemTemplate>
        </asp:DataList>

