<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Administrar.aspx.cs" Inherits="admin_Direccion_Administrar" %>
<%@ Register Src="~/admin/Controls/ManageUsers.ascx" TagPrefix="uc1" TagName="ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-cogs font-green-sharp"></i>
                        <span class="caption-subject font-green-sharp bold uppercase">Administración General</span>
                    </div>
                  
                </div>
                <div class="portlet-body">
                    <div class="tabbable-custom nav-justified">
                        <ul class="nav nav-tabs nav-justified">
                            <li class="active">
                                <a href="#tab_1_1_1" data-toggle="tab">Usuarios</a>
                            </li>
                            <li>
                                <a href="#tab_1_1_2" data-toggle="tab">Alumnos </a>
                            </li>
                            <li>
                                <a href="#tab_1_1_3" data-toggle="tab">Grupos </a>
                            </li>
                            <li>
                                <a href="#tab_1_1_4" data-toggle="tab">Docentes </a>
                            </li>
                             <li>
                                <a href="#tab_1_1_5" data-toggle="tab">Personal </a>
                            </li>
                             <li>
                                <a href="#tab_1_1_6" data-toggle="tab">Noticias </a>
                            </li>
                             <li>
                                <a href="#tab_1_1_7" data-toggle="tab">Eventos </a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_1_1_1">
                                <uc1:ManageUsers runat="server" ID="ManageUsers" />
                            </div>
                            <div class="tab-pane" id="tab_1_1_2">
                               Alumnos
                            </div>
                            <div class="tab-pane" id="tab_1_1_3">
                               Grupos
                            </div>
                             <div class="tab-pane" id="tab_1_1_4">
                               Docentes
                            </div>
                             <div class="tab-pane" id="tab_1_1_5">
                               Personal
                            </div>
                             <div class="tab-pane" id="tab_1_1_6">
                               Noticias
                            </div>
                             <div class="tab-pane" id="tab_1_1_6">
                               Eventos
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" Runat="Server">
</asp:Content>

