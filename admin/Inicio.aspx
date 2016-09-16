<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" CodeFile="Inicio.aspx.cs" Inherits="admin_Inicio" %>

<%@ Register Src="~/Controls/MejoresIdeas.ascx" TagPrefix="uc1" TagName="MejoresIdeas" %>
<%@ Register Src="~/Controls/UltimasIdeas.ascx" TagPrefix="uc1" TagName="UltimasIdeas" %>
<%@ Register Src="~/Controls/UsuariosMasActivos.ascx" TagPrefix="uc1" TagName="UsuariosMasActivos" %>
<%@ Register Src="~/Controls/UsuariosMenosActivos.ascx" TagPrefix="uc1" TagName="UsuariosMenosActivos" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentStyles" runat="server">
    <link href="/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css" rel="stylesheet" type="text/css" />
    <link href="/assets/admin/pages/css/profile.css" rel="stylesheet" type="text/css" />
    <link href="/assets/admin/pages/css/tasks.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" runat="Server">
    <h1>
        <asp:Label Text="" ID="lblTitulo" runat="server" />
        <small>¡Qué bueno tenerte de vuelta!</small></h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="Server">
    <!-- BEGIN PAGE CONTENT INNER -->
    <div class="row margin-top-10">
        <div class="col-md-12">
            <!-- BEGIN PROFILE SIDEBAR -->
            <div class="profile-sidebar" style="width: 250px;">
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
                            <asp:Label Text="5-A" ID="lblGrupo" runat="server" />
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
                    <div class="col-md-6">
                        <!-- BEGIN PORTLET -->
                        <div class="portlet light">
                            <div class="portlet-title tabbable-line">
                                <div class="caption caption-md">
                                    <i class="icon-globe theme-font hide"></i>
                                    <span class="caption-subject font-blue-madison bold uppercase">NOTICIAS</span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <!--BEGIN TABS-->
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab_1_1">
                                        <div class="scroller" style="height: 300px;" data-always-visible="1" data-rail-visible1="0" data-handle-color="#D7DCE2">
                                            <ul class="feeds" runat="server" id="ulNoticias">
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-success">
                                                                    <i class="fa fa-bell-o"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    You have 4 pending tasks. <span class="label label-sm label-info">Take action <i class="fa fa-share"></i>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            Just now
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <a href="#">
                                                        <div class="col1">
                                                            <div class="cont">
                                                                <div class="cont-col1">
                                                                    <div class="label label-sm label-success">
                                                                        <i class="fa fa-bell-o"></i>
                                                                    </div>
                                                                </div>
                                                                <div class="cont-col2">
                                                                    <div class="desc">
                                                                        New version v1.4 just lunched!
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col2">
                                                            <div class="date">
                                                                20 mins
                                                            </div>
                                                        </div>
                                                    </a>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-danger">
                                                                    <i class="fa fa-bolt"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    Database server #12 overloaded. Please fix the issue.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            24 mins
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-info">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received and pending for process.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            30 mins
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-success">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New payment refund and pending approval.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            40 mins
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-warning">
                                                                    <i class="fa fa-plus"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New member registered. Pending approval.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            1.5 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-success">
                                                                    <i class="fa fa-bell-o"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    Web server hardware needs to be upgraded. <span class="label label-sm label-default ">Overdue </span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            2 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-default">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    Prod01 database server is overloaded 90%.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            3 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-warning">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New group created. Pending manager review.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            5 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-info">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    Order payment failed.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            18 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-default">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New application received.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            21 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-info">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    Dev90 web server restarted. Pending overall system check.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            22 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-default">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New member registered. Pending approval
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            21 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-info">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    L45 Network failure. Schedule maintenance.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            22 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-default">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    Order canceled with failed payment.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            21 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-info">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    Web-A2 clound instance created. Schedule full scan.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            22 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-default">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    Member canceled. Schedule account review.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            21 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-info">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            22 hours
                                                        </div>
                                                    </div>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                </div>
                                <!--END TABS-->
                            </div>
                        </div>
                        <!-- END PORTLET -->
                    </div>

                    <div class="col-md-6">
                        <!-- BEGIN PORTLET -->
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption caption-md">
                                    <i class="icon-bar-chart theme-font hide"></i>
                                    <span class="caption-subject font-blue-madison bold uppercase">Mensajes</span>
                                    <%--<span class="caption-helper">45 pending</span>--%>
                                </div>
                                <div class="inputs">
                                    <div class="portlet-input input-inline input-small ">
                                        <%--<div class="input-icon right">
													<i class="icon-magnifier"></i>
													<input type="text" class="form-control form-control-solid" placeholder="search...">
												</div>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="scroller" style="height: 300px;" data-always-visible="1" data-rail-visible1="0" data-handle-color="#D7DCE2">
                                    <div class="general-item-list" runat="server" id="divMensajes">
                                        <div class="item">
                                            <div class="item-head">
                                                <div class="item-details">
                                                    <img class="item-pic" src="/assets/admin/layout3/img/avatar4.jpg">
                                                    <a href="" class="item-name primary-link">Nick Larson</a>
                                                    <span class="item-label">3 hrs ago</span>
                                                </div>
                                                <span class="item-status"><span class="badge badge-empty badge-success"></span>Open</span>
                                            </div>
                                            <div class="item-body">
                                                Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="item-head">
                                                <div class="item-details">
                                                    <img class="item-pic" src="/assets/admin/layout3/img/avatar3.jpg">
                                                    <a href="" class="item-name primary-link">Mark</a>
                                                    <span class="item-label">5 hrs ago</span>
                                                </div>
                                                <span class="item-status"><span class="badge badge-empty badge-warning"></span>Pending</span>
                                            </div>
                                            <div class="item-body">
                                                Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat tincidunt ut laoreet.
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="item-head">
                                                <div class="item-details">
                                                    <img class="item-pic" src="/assets/admin/layout3/img/avatar6.jpg">
                                                    <a href="" class="item-name primary-link">Nick Larson</a>
                                                    <span class="item-label">8 hrs ago</span>
                                                </div>
                                                <span class="item-status"><span class="badge badge-empty badge-primary"></span>Closed</span>
                                            </div>
                                            <div class="item-body">
                                                Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh.
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="item-head">
                                                <div class="item-details">
                                                    <img class="item-pic" src="/assets/admin/layout3/img/avatar7.jpg">
                                                    <a href="" class="item-name primary-link">Nick Larson</a>
                                                    <span class="item-label">12 hrs ago</span>
                                                </div>
                                                <span class="item-status"><span class="badge badge-empty badge-danger"></span>Pending</span>
                                            </div>
                                            <div class="item-body">
                                                Consectetuer adipiscing elit Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="item-head">
                                                <div class="item-details">
                                                    <img class="item-pic" src="/assets/admin/layout3/img/avatar9.jpg">
                                                    <a href="" class="item-name primary-link">Richard Stone</a>
                                                    <span class="item-label">2 days ago</span>
                                                </div>
                                                <span class="item-status"><span class="badge badge-empty badge-danger"></span>Open</span>
                                            </div>
                                            <div class="item-body">
                                                Lorem ipsum dolor sit amet, consectetuer adipiscing elit, ut laoreet dolore magna aliquam erat volutpat.
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="item-head">
                                                <div class="item-details">
                                                    <img class="item-pic" src="/assets/admin/layout3/img/avatar8.jpg">
                                                    <a href="" class="item-name primary-link">Dan</a>
                                                    <span class="item-label">3 days ago</span>
                                                </div>
                                                <span class="item-status"><span class="badge badge-empty badge-warning"></span>Pending</span>
                                            </div>
                                            <div class="item-body">
                                                Lorem ipsum dolor sit amet, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="item-head">
                                                <div class="item-details">
                                                    <img class="item-pic" src="/assets/admin/layout3/img/avatar2.jpg">
                                                    <a href="" class="item-name primary-link">Larry</a>
                                                    <span class="item-label">4 hrs ago</span>
                                                </div>
                                                <span class="item-status"><span class="badge badge-empty badge-success"></span>Open</span>
                                            </div>
                                            <div class="item-body">
                                                Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END PORTLET -->
                    </div>
                </div>

            </div>
            <!-- END PROFILE CONTENT -->

            <div class="row">
                <div class="portlet light">
                    <div class="portlet-title tabbable-line">
                        <div class="caption">
                            <i class="icon-pin font-yellow-crusta"></i>
                            <span class="caption-subject bold font-yellow-crusta uppercase">
                                <asp:Label Text="" ID="lblNombreEscuela" runat="server" />
                            </span>
                            <span class="caption-helper"></span>
                        </div>
                        <%--<ul class="nav nav-tabs">
								<li>
									<a href="#portlet_tab3" data-toggle="tab">
									Ubicación </a>
								</li>
								<li>
									<a href="#portlet_tab2" data-toggle="tab">
									Personal</a>
								</li>
								<li class="active">
									<a href="#portlet_tab1" data-toggle="tab">
									Fotos </a>
								</li>
							</ul>--%>
                    </div>

                    <div class="portlet-body">
                        <div class="tab-content">
                            <div class="tab-pane active" id="portlet_tab1">
                                <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto; height: 520px;">
                                    <div class="scroller" style="height: 520px; overflow: hidden; width: auto;" data-initialized="1">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <a class='pull-left' href='javascript:;'>
                                                    <img class='media-object' src='' runat="server" id="imgEscuela" alt='64x64' data-src='holder.js/64x64' style='width: 100%; height: 100%;'>
                                                </a>
                                            </div>
                                            <div class="col-md-9">
                                                <h4>¡Ayúdanos a mejorar tu escuela!</h4>
                                                <p>Conoce más a fondo los detalles de tu escuela. Ingresa a ver las áreas de tu escuela y califícalas, ¡tu opinión es esencial para nosotros!</p>
                                                <a href='#' runat="server" id="hlVerEscuela" class='btn blue'>INFORMACIÓN DE MI ESCUELA</a>
                                                <a href='#' runat="server" id="hlCalificarEscuela" class='btn green'>CALIFICAR MI ESCUELA</a>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <!-- BEGIN Portlet PORTLET-->
                                                <br />
                                                <div class="portlet light bg-inverse">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="icon-paper-plane font-green-haze"></i>
                                                            <span class="caption-subject bold font-green-haze uppercase">Mejora tu escuela </span>
                                                            <span class="caption-helper">comparte tus ideas</span>
                                                        </div>

                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row">
                                                            <div class="col-md-8">
                                                                <h3>¿Tienes una idea para mejorar tu escuela?</h3>
                                                                <p>
                                                                    Tus ideas son valiosas, y ahora pueden llegar hasta lo más alto! Crea una idea para que todas las personas de tu escuela la puedan votar.
                                                                </p>
                                                                <p>
                                                                    ¡Si es la mejor, se llevará a cabo!
                                                                </p>
                                                                <a href="/Admin/Crear-Idea" class="btn red">¡Crea una idea ahora!</a>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="portlet box green-meadow">
                                                                    <div class="portlet-title">
                                                                        <div class="caption">
                                                                            <i class="fa fa-gift"></i>Ideas Más Votadas
                                                                        </div>

                                                                    </div>
                                                                    <div class="portlet-body">
                                                                       <div class="scroller" style="height:200px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                                                        <uc1:MejoresIdeas runat="server" ID="MejoresIdeas" />
                                                                            </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                                <!-- END Portlet PORTLET-->
                                            </div>
                                        </div>
                                    </div>
                                    <div class="slimScrollBar" style="width: 7px; position: absolute; top: 0px; opacity: 0.4; display: none; border-radius: 7px; z-index: 99; right: 1px; height: 129.032px; background: rgb(187, 187, 187);"></div>
                                    <div class="slimScrollRail" style="width: 7px; height: 100%; position: absolute; top: 0px; display: none; border-radius: 7px; opacity: 0.2; z-index: 90; right: 1px; background: rgb(234, 234, 234);"></div>
                                </div>
                            </div>

                        </div>
                    </div>
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
