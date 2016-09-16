<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Tareas.aspx.cs" Inherits="admin_Tareas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" runat="Server">
        <link href="/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css" rel="stylesheet" type="text/css"/>
<link href="/assets/admin/pages/css/profile.css" rel="stylesheet" type="text/css"/>
<link href="/assets/admin/pages/css/tasks.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" runat="Server">
    <h1>Tareas de <asp:Label Text="" ID="lblNombreTarea" runat="server" /></h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="row margin-top-10">

        <div class="col-md-12">

            <!-- BEGIN PROFILE SIDEBAR -->
            <div class="profile-sidebar" style="width: 250px; height: 400px;">
                <!-- PORTLET MAIN -->
                <div class="portlet light profile-sidebar-portlet">
                    <!-- SIDEBAR USERPIC -->
                    <div class="profile-userpic">
                        <img src="/assets/admin/pages/media/profile/profile_user.jpg" runat="server" id="imgUser" class="img-responsive" alt="">
                    </div>
                    <!-- END SIDEBAR USERPIC -->
                    <!-- SIDEBAR USER TITLE -->
                    <div class="profile-usertitle">
                        <div class="profile-usertitle-name">
                            <asp:Label Text="Adrian Miranda" ID="lblNombre" runat="server" />
                        </div>
                        <div class="profile-usertitle-job">
                            Docente
                        </div>
                    </div>
                    <!-- END SIDEBAR USER TITLE -->
                    <!-- SIDEBAR BUTTONS -->
                    <div class="profile-userbuttons">
								<button type="button" class="btn btn-circle btn-danger btn-sm">Mensaje</button>
							</div>
                    <!-- END SIDEBAR BUTTONS -->
                    <!-- SIDEBAR MENU -->
                   
                    <!-- END MENU -->
                </div>
                <!-- END PORTLET MAIN -->


            </div>
            <!-- END BEGIN PROFILE SIDEBAR -->
            <!-- BEGIN PROFILE CONTENT -->

            <div class="profile-content">
                <div class="row">

                    <div class="col-md-9">
                        <asp:Literal Text="" ID="litTareas" runat="server" />
                    </div>


                </div>

            </div>
            <!-- END PROFILE CONTENT -->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" runat="Server">
</asp:Content>

