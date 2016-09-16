<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="admin_Administracion_Inicio" %>

<%@ Register Src="~/admin/Controls/ManageUsers.ascx" TagPrefix="uc1" TagName="ManageUsers" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" runat="Server">
    <h1>Super Administrador</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-cogs font-green-sharp"></i>
                        <span class="caption-subject font-green-sharp bold uppercase">Administración General</span>
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                        <a href="#portlet-config" data-toggle="modal" class="config" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="tabbable-custom nav-justified">
                        <ul class="nav nav-tabs nav-justified">
                            <li class="active">
                                <a href="#tab_1_1_1" data-toggle="tab">Escuelas</a>
                            </li>
                            <li>
                                <a href="#tab_1_1_2" data-toggle="tab">Usuarios </a>
                            </li>
                            <li>
                                <a href="#tab_1_1_3" data-toggle="tab">Reportes </a>
                            </li>
                             <li>
                                <a href="#tab_1_1_4" data-toggle="tab">Estadísticas </a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_1_1_1">
                                <p>Utilice el buscador de escuelas para ver o administrar una escuela</p>
                                <a href="/Escuelas" class="btn blue">Abrir Buscador</a>  <a href="/Admin/Administracion/Escuela" class="btn green">Crear Nueva Escuela</a>
                       
                                    <h3>Información Global</h3>
                                    <asp:Label Text="" ID="lblGlobal" runat="server" />
                            
                                <asp:GridView ShowFooter="true" ID="grdInfo" runat="server" ClientIDMode="Static" CssClass="table table-striped table-bordered table-hover grd"
                                        AutoGenerateColumns="True">
                                        <EmptyDataTemplate>
                                            No hay datos
                                        </EmptyDataTemplate>
                                        <Columns>
                                           
                                          
                                        </Columns>
                                    </asp:GridView>
                            </div>
                            <div class="tab-pane" id="tab_1_1_2">
                                <uc1:ManageUsers runat="server" ID="ManageUsers" />
                            </div>
                            <div class="tab-pane" id="tab_1_1_3">
                               Reportes
                            </div>
                             <div class="tab-pane" id="tab_1_1_4">
                               Reportes
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" runat="Server">
</asp:Content>

