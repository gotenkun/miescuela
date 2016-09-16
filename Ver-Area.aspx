<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Ver-Area.aspx.cs" Inherits="Ver_Area" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" runat="Server">
    <link href="/assets/global/plugins/fancybox/source/jquery.fancybox.css" rel="stylesheet" type="text/css">
    <link href="/assets/admin/pages/css/portfolio.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="/css/styles.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" runat="Server">
    <h1>Área:
        <asp:Label Text="" ID="lblTitulo" runat="server" /></h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="row">
        <div class="col-md-12">

            <div class="portlet light bg-inverse">
                <div class="portlet-title">
                    <div class="caption font-red-sunglo">
                        <i class="icon-share font-red-sunglo"></i>
                        <span class="caption-subject bold uppercase">
                            <asp:Label Text="" ID="lblTitulo2" runat="server" /></span>
                        <span class="caption-helper"></span>
                        <div style="float: right; padding-left: 10px;">
                            <asp:Rating ID="Rating1" AutoPostBack="true" runat="server"
                                StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star" ReadOnly="true"
                                FilledStarCssClass="FilledStar">
                            </asp:Rating>
                            (<asp:Label Text="" ID="lblVotos" runat="server" />
                            votos)
                        </div>
                    </div>
                    <% if (Page.User.Identity.IsAuthenticated)
                       { %>
                    <div class="actions">
                        <a href="" id="hlCalificarArea" runat="server" class="btn green">Califica esta área</a>

                    </div>
                    <% } %>
                </div>
                <div class="portlet-body">
                    <div class="scroller" style="height: 400px" data-always-visible="1" data-rail-visible="1" data-rail-color="red" data-handle-color="green">

                        <div class="margin-top-10">

                            <div class="row mix-grid">
                                <asp:Literal Text="" ID="litImgs" runat="server" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="portlet light bg-inverse">
                <div class="portlet-title">
                    <div class="caption font-red-sunglo">
                        <i class="icon-share font-red-sunglo"></i>
                        <span class="caption-subject bold uppercase">Comentarios</span>
                        <span class="caption-helper">más recientes</span>
                    </div>
                  
                </div>
                <div class="portlet-body">
                    <div class="scroller" style="height: 500px" data-always-visible="1" data-rail-visible="1" data-rail-color="red" data-handle-color="green">
                        <asp:Literal Text="" ID="litComments" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" runat="Server">
    <script type="text/javascript" src="/assets/global/plugins/jquery-mixitup/jquery.mixitup.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/fancybox/source/jquery.fancybox.pack.js"></script>
    <script src="/assets/admin/pages/scripts/portfolio.js"></script>
    <script>

        </script>
</asp:Content>

