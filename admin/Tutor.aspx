<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master"  CodeFile="Tutor.aspx.cs" Inherits="admin_Tutor" %>

<%@ Register Src="~/Controls/MejoresIdeas.ascx" TagPrefix="uc1" TagName="MejoresIdeas" %>
<%@ Register Src="~/Controls/UltimasIdeas.ascx" TagPrefix="uc1" TagName="UltimasIdeas" %>
<%@ Register Src="~/Controls/UsuariosMasActivos.ascx" TagPrefix="uc1" TagName="UsuariosMasActivos" %>
<%@ Register Src="~/Controls/UsuariosMenosActivos.ascx" TagPrefix="uc1" TagName="UsuariosMenosActivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentStyles" runat="server">
    <link href="/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css" rel="stylesheet" type="text/css"/>
<link href="/assets/admin/pages/css/profile.css" rel="stylesheet" type="text/css"/>
<link href="/assets/admin/pages/css/tasks.css" rel="stylesheet" type="text/css"/>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" Runat="Server">
    <h1>
        <asp:Label Text="" ID="lblTitulo" runat="server" /> <small>¡Qué bueno tenerte de vuelta!</small></h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" Runat="Server">
<!-- BEGIN PAGE CONTENT INNER -->
			<div class="row margin-top-10">
               
				<div class="col-md-12">

					<!-- BEGIN PROFILE SIDEBAR -->
					<div class="profile-sidebar" style="width: 250px;height:400px;">
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
                                    <asp:Label Text="Adrian Miranda" ID="lblNombre"  runat="server" />
								</div>
								<div class="profile-usertitle-job">
                                    <asp:Label Text="2 Alumnos" ID="lblHijos" runat="server" />
								</div>
							</div>
							<!-- END SIDEBAR USER TITLE -->
							<!-- SIDEBAR BUTTONS -->
							<%--<div class="profile-userbuttons">
								<button type="button" class="btn btn-circle green-haze btn-sm">Follow</button>
								<button type="button" class="btn btn-circle btn-danger btn-sm">Message</button>
							</div>--%>
							<!-- END SIDEBAR BUTTONS -->
							<!-- SIDEBAR MENU -->
							<div class="profile-usermenu">
								<ul class="nav">
									<li>
										<a href="/Admin/Mis-Escuelas">
										<i class="icon-check"></i>
										Mis Escuelas </a>
									</li>
									<li>
										<a href="/Admin/Tareas">
										<i class="icon-check"></i>
										Tareas </a>
									</li>
									<li>
										<a href="/Admin/Asistencia-Escolar">
										<i class="icon-info"></i>
										Asistencia Escolar </a>
									</li>
								</ul>
							</div>
							<!-- END MENU -->
						</div>
						<!-- END PORTLET MAIN -->

					
					</div>
					<!-- END BEGIN PROFILE SIDEBAR -->
					<!-- BEGIN PROFILE CONTENT -->

					<div class="profile-content">
						<div class="row">

							<div class="col-md-12">

								<!-- BEGIN PORTLET -->
								<div class="portlet light">
									<div class="portlet-title tabbable-line">
										<div class="caption caption-md">
											<i class="icon-globe theme-font hide"></i>
											<span class="caption-subject font-blue-madison bold uppercase">Mis Hijos(as)</span>
										</div>
										
									</div>
									<div class="portlet-body">
										<!--BEGIN TABS-->
										<div class="tab-content">
											<div class="tab-pane active" id="tab_1_1">
												<div class="scroller" style="height: 400px;" data-always-visible="1" data-rail-visible1="0" data-handle-color="#D7DCE2">
													
                                                    <asp:Literal runat="server" ID="litHijos"></asp:Literal>
												</div>
											</div>
											
										</div>
										<!--END TABS-->
									</div>
								</div>
								<!-- END PORTLET -->
							</div>

                           
						</div>
						
					</div>
					<!-- END PROFILE CONTENT -->
				</div>
			</div>
    <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN Portlet PORTLET-->
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-paper-plane font-yellow-casablanca"></i>
                                <span class="caption-subject bold font-yellow-casablanca uppercase">Actividad Escolar </span>
                                <span class="caption-helper"></span>
                            </div>

                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <!-- BEGIN Portlet PORTLET-->
                                    <div class="portlet box green-meadow">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Últimas Ideas
                                            </div>
                                           
                                        </div>
                                        <div class="portlet-body">
                                            <uc1:UltimasIdeas runat="server" ID="UltimasIdeas" />
                                        </div>
                                    </div>
                                    <!-- END Portlet PORTLET-->
                                </div>
                                <div class="col-md-3 ">
                                    <!-- BEGIN Portlet PORTLET-->
                                    <div class="portlet box yellow">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Ideas Más Votadas
                                            </div>
                                          
                                        </div>
                                        <div class="portlet-body">
                                            <uc1:MejoresIdeas runat="server" ID="MejoresIdeas1" />
                                        </div>
                                    </div>
                                    <!-- END Portlet PORTLET-->
                                </div>
                                <div class="col-md-3 ">
                                    <!-- BEGIN Portlet PORTLET-->
                                    <div class="portlet box red">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Usuarios Más Activos
                                            </div>
                                           
                                        </div>
                                        <div class="portlet-body">
                                            <uc1:UsuariosMasActivos runat="server" ID="UsuariosMasActivos" />
                                        </div>
                                    </div>
                                    <!-- END Portlet PORTLET-->
                                </div>
                                <div class="col-md-3 ">
                                    <!-- BEGIN Portlet PORTLET-->
                                    <div class="portlet box green">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Usuarios Menos Activos
                                            </div>
                                           
                                        </div>
                                        <div class="portlet-body">
                                            <uc1:UsuariosMenosActivos runat="server" ID="UsuariosMenosActivos" />
                                        </div>
                                    </div>
                                    <!-- END Portlet PORTLET-->
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END Portlet PORTLET-->
                </div>
            </div>
			<!-- END PAGE CONTENT INNER -->
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="contentScript">
    <script src="/assets/global/scripts/metronic.js" type="text/javascript"></script>
<script src="/assets/admin/layout3/scripts/layout.js" type="text/javascript"></script>
<script src="/assets/admin/layout3/scripts/demo.js" type="text/javascript"></script>
<script src="/assets/admin/pages/scripts/profile.js" type="text/javascript"></script>
</asp:Content>
