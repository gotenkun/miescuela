<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Grupo.aspx.cs" Inherits="admin_Grupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" runat="Server">
    <link href="/assets/admin/pages/css/about-us.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" runat="Server">
    <h1>
        <asp:Label Text="" ID="lblGrupo" runat="server" /></h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="portlet light">
        <div class="portlet-body">
            <div class="row margin-bottom-30">
                <div class="col-md-12">
                    <p>
                        
                    </p>
                   

                </div>
                
            </div>
            <!--/row-->
            <!-- Meer Our Team -->
            <div class="headline">
                <h3>Docente:</h3>
            </div>
             <asp:Label Text="" ID="lblDocente" runat="server" />
           
            <div class="row thumbnails">
                <asp:Literal Text="" ID="litGrupo" runat="server" />
                
            </div>
            <!--/thumbnails-->
            <!-- //End Meer Our Team -->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" runat="Server">
</asp:Content>

