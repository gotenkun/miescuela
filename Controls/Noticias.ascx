<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Noticias.ascx.cs" Inherits="Controls_Noticias" %>
<ul class="list-group">
<asp:DataList ID="DataList1" runat="server" 
                                Width="290px" style="text-align: left">
                                <ItemStyle CssClass="NoticiaReciente"/>
                                <ItemTemplate>
                                    <li class="list-group-item"><asp:HyperLink ID="TituloLabel" runat="server" Font-Size="Smaller" 
                                        NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"PostID") %>' 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Titulo") %>' 
                                        ></asp:HyperLink>
                                    </li>
                                </ItemTemplate>
                            </asp:DataList>
    </ul>   
                           <table width="290"><tr><td align="right" >
                               <asp:HyperLink ID="hlMasNoticias" runat="server" CssClass="lnkMasNoticias" 
                                   NavigateUrl='<%= ResolveUrl("~/Noticias/Noticias.aspx")%>'>MÁS NOTICIAS</asp:HyperLink>
                               </td></tr></table> 