<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="admin_Direccion_Inicio" %>

<%@ Register Src="~/admin/Controls/ManageUsers.ascx" TagPrefix="uc1" TagName="ManageUsers" %>
<%@ Register Src="~/Controls/UltimasIdeas.ascx" TagPrefix="uc1" TagName="UltimasIdeas" %>
<%@ Register Src="~/Controls/MejoresIdeas.ascx" TagPrefix="uc1" TagName="MejoresIdeas" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" runat="Server">
    <link href="/css/select2.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/datatables/extensions/Scroller/css/dataTables.scroller.min.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/datatables/extensions/ColReorder/css/dataTables.colReorder.min.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" runat="Server">
    <h1>Dirección Escolar</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="row">
        <div class="col-md-3">
            <ul class="ver-inline-menu tabbable margin-bottom-10">
                <li class="active">
                    <a data-toggle="tab" href="#tab_1">
                        <i class="fa fa-info"></i>Escuela</a>
                    <span class="after"></span>
                </li>
                <li>
                    <a data-toggle="tab" href="#tab_2">
                        <i class="fa fa-group"></i>Usuarios </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#tab_3">
                        <i class="fa fa-user"></i>Alumnos </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#tab_4">
                        <i class="fa fa-group"></i>Grupos </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#tab_5">
                        <i class="fa fa-user"></i>Docentes </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#tab_6">
                        <i class="fa fa-group"></i>Tutores </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#tab_7">
                        <i class="fa fa-plus"></i>Eventos </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#tab_8">
                       <i class="fa fa-soccer-ball-o "></i>Áreas </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#tab_9">
                        <i class="fa fa-lightbulb-o"></i>Ideas </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#tab_10">
                        <i class="fa fa-laptop"></i>Conexión Sistemas externos </a>
                </li>
            </ul>
        </div>
        <div class="col-md-9">
            <div class="tab-content">
                <div id="tab_1" class="tab-pane active">

                    <div class="panel panel-default">
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-speech"></i>
                                    <span class="caption-subject bold uppercase">Escuela</span>
                                    <span class="caption-helper"></span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="scroller" style="height: 200px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                    <div class="col-md-3">
                                        <a class='pull-left' href='javascript:;'>
                                            <img class='media-object' src='' runat="server" id="imgEscuela" alt='64x64' data-src='holder.js/64x64' style='width: 100%; height: 100%;'>
                                        </a>
                                    </div>
                                    <div class="col-md-9">
                                        <h4>
                                            <asp:Label Text="" ID="lblNombreEscuela" runat="server" /></h4>
                                        <p>Bienvenido, use las secciones de arriba para administrar la información de su escuela.</p>
                                        <a href='#' runat="server" id="hlVerEscuela" class='btn blue'>VER PÁGINA PRINCIPAL</a>
                                        <a href='#' runat="server" id="hlCalificarEscuela" class='btn green'>VER CALIFICACIONES</a>
                                        <a href='#' runat="server" id="hlEditarEscuela" class='btn red'>EDITAR ESCUELA</a>
                                    </div>
                                </div>
                                <hr />
                                <uc1:UltimasIdeas runat="server" ID="UltimasIdeas" />
                                <uc1:MejoresIdeas runat="server" ID="MejoresIdeas" />
                            </div>
                        </div>


                    </div>

                </div>
                <div id="tab_2" class="tab-pane active">

                    <div class="panel panel-default">
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-speech"></i>
                                    <span class="caption-subject bold uppercase">Usuarios</span>
                                    <span class="caption-helper"></span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="scroller" style="height: 700px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                    <br />
                                    <br />
                                    <uc1:ManageUsers runat="server" ID="ManageUsers" />
                                </div>
                                <hr />

                            </div>
                        </div>


                    </div>

                </div>
                <div id="tab_3" class="tab-pane active">

                    <div class="panel panel-default">
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-speech"></i>
                                    <span class="caption-subject bold uppercase">Alumnos</span>
                                    <span class="caption-helper"></span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="float:right;"><a href="/Admin/Direccion/Alumno" class="btn green">Crear Alumno</a> <a href="/Admin/Direccion/Importar-Alumnos" class="btn blue">Importar de Excel</a></div>
                                <div class="scroller" style="height: 700px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                    <br />
                                    <br />
                                    <asp:GridView ShowFooter="true" ID="grd" runat="server" ClientIDMode="Static" CssClass="table table-striped table-bordered table-hover grd"
                                        AutoGenerateColumns="True">
                                        <EmptyDataTemplate>
                                            No hay datos
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="UsuarioID"
                                                DataNavigateUrlFormatString="/Admin/Direccion/Alumno/{0}"
                                                Text="Editar..." />
                                          
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <hr />

                            </div>
                        </div>


                    </div>

                </div>
                 <div id="tab_4" class="tab-pane active">

                    <div class="panel panel-default">
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-speech"></i>
                                    <span class="caption-subject bold uppercase">Grupos</span>
                                    <span class="caption-helper"></span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="float:right;"><a href="/Admin/Direccion/Grupo" class="btn green">Crear Grupo</a></div>
                                <div class="scroller" style="height: 700px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                    <br />
                                    <br />
                                    <asp:GridView ShowFooter="true" ID="grdGrupos" runat="server" ClientIDMode="Static" CssClass="table table-striped table-bordered table-hover grd"
                                        AutoGenerateColumns="True">
                                        <EmptyDataTemplate>
                                            No hay datos
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="GrupoID"
                                                DataNavigateUrlFormatString="/Admin/Direccion/Grupo/{0}"
                                                Text="Editar..." />
                                          
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <hr />

                            </div>
                        </div>


                    </div>

                </div>
                 <div id="tab_5" class="tab-pane active">

                    <div class="panel panel-default">
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-speech"></i>
                                    <span class="caption-subject bold uppercase">Docentes</span>
                                    <span class="caption-helper"></span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="float:right;"><a href="/Admin/Direccion/Docente" class="btn green">Crear Docente</a> <a href="/Admin/Direccion/Importar-Alumnos" class="btn blue">Importar de Excel</a></div>
                                <div class="scroller" style="height: 700px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                    <br />
                                    <br />
                                    <asp:GridView ShowFooter="true" ID="grdDocente" runat="server" ClientIDMode="Static" CssClass="table table-striped table-bordered table-hover grd"
                                        AutoGenerateColumns="True">
                                        <EmptyDataTemplate>
                                            No hay datos
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="UsuarioID"
                                                DataNavigateUrlFormatString="/Admin/Direccion/Docente/{0}"
                                                Text="Editar..." />
                                          
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <hr />

                            </div>
                        </div>


                    </div>

                </div>
                <div id="tab_6" class="tab-pane active">

                    <div class="panel panel-default">
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-speech"></i>
                                    <span class="caption-subject bold uppercase">Tutores</span>
                                    <span class="caption-helper"></span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="float:right;"><a href="/Admin/Direccion/Tutor" class="btn green">Crear Tutor</a> <a href="/Admin/Direccion/Importar-Alumnos" class="btn blue">Importar de Excel</a></div>
                                <div class="scroller" style="height: 700px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                    <br />
                                    <br />
                                    <asp:GridView ShowFooter="true" ID="grdTutor" runat="server" ClientIDMode="Static" CssClass="table table-striped table-bordered table-hover grd"
                                        AutoGenerateColumns="True">
                                        <EmptyDataTemplate>
                                            No hay datos
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="UsuarioID"
                                                DataNavigateUrlFormatString="/Admin/Direccion/Tutor/{0}"
                                                Text="Editar..." />
                                          
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <hr />

                            </div>
                        </div>


                    </div>

                </div>
                 <div id="tab_7" class="tab-pane active">

                    <div class="panel panel-default">
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-speech"></i>
                                    <span class="caption-subject bold uppercase">Eventos</span>
                                    <span class="caption-helper"></span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="float:right;"><a href="/Admin/Direccion/Tutor" class="btn green">Crear Noticia/Evento</a></div>
                                <div class="scroller" style="height: 700px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                    <br />
                                    <br />
                                    <asp:GridView ShowFooter="true" ID="grdNoticia" runat="server" ClientIDMode="Static" CssClass="table table-striped table-bordered table-hover grd"
                                        AutoGenerateColumns="True">
                                        <EmptyDataTemplate>
                                            No hay datos
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="ID"
                                                DataNavigateUrlFormatString="/Admin/Direccion/Noticia/{0}"
                                                Text="Editar..." />
                                          
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <hr />

                            </div>
                        </div>


                    </div>

                </div>
                <div id="tab_8" class="tab-pane active">

                    <div class="panel panel-default">
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-speech"></i>
                                    <span class="caption-subject bold uppercase">Areas</span>
                                    <span class="caption-helper"></span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="float:right;"><a href="/Admin/Direccion/Area" class="btn green">Crear Area</a></div>
                                <div class="scroller" style="height: 700px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                    <br />
                                    <br />
                                    <asp:GridView ShowFooter="true" ID="grdArea" runat="server" ClientIDMode="Static" CssClass="table table-striped table-bordered table-hover grd"
                                        AutoGenerateColumns="True">
                                        <EmptyDataTemplate>
                                            No hay datos
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="ID"
                                                DataNavigateUrlFormatString="/Admin/Direccion/Area/{0}"
                                                Text="Editar..." />
                                          
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <hr />

                            </div>
                        </div>


                    </div>

                </div>
                  <div id="tab_9" class="tab-pane active">

                    <div class="panel panel-default">
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-speech"></i>
                                    <span class="caption-subject bold uppercase">Ideas</span>
                                    <span class="caption-helper"></span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="float:right;"><a href="/Admin/Crear-Idea" class="btn green">Crear Idea</a></div>
                                <div class="scroller" style="height: 700px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                    <br />
                                    <br />
                                    <asp:GridView ShowFooter="true" ID="grdIdea" runat="server" ClientIDMode="Static" CssClass="table table-striped table-bordered table-hover grd"
                                        AutoGenerateColumns="True">
                                        <EmptyDataTemplate>
                                            No hay datos
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="ID"
                                                DataNavigateUrlFormatString="/Admin/Direccion/Idea/{0}"
                                                Text="Editar..." />
                                          
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <hr />

                            </div>
                        </div>


                    </div>

                </div>
                <div id="tab_10" class="tab-pane active">

                    <div class="panel panel-default">
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-speech"></i>
                                    <span class="caption-subject bold uppercase">Conexión con Sistemas Externos</span>
                                    <span class="caption-helper"></span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="float:right;"><a href="/Service.asmx" class="btn green" target="_blank">Probar Servicios Web</a></div>
                                <div class="scroller" style="height: 700px" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                                    <br />
                                    <br />
                                   Descripción de Servicios Externos (Web Services)<br />
                                    <table class="table table-striped table-bordered table-hover grd"> <tr>
                                        <td>InfoEscuela(string _clave):</td>
                                        <td> Obtiene la información básica de la escuela indicada por clave.</td>
                                            </tr></table>
                                   
                                    
                                </div>
                                <hr />

                            </div>
                        </div>


                    </div>

                </div>
            </div>
            </div>
        </div>
 
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" runat="Server">
    <script src="/Scripts/select2.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/media/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/extensions/TableTools/js/dataTables.tableTools.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/extensions/ColReorder/js/dataTables.colReorder.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/extensions/Scroller/js/dataTables.scroller.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js"></script>
    <script src="/assets/admin/pages/scripts/table-advanced.js"></script>
    <script>
        $('.cmb').select2();
        TableAdvanced.init();
        $(document).ready(function () {
            Page = Sys.WebForms.PageRequestManager.getInstance();
            Page.add_beginRequest(OnBeginRequest);
            Page.add_endRequest(endRequest);

            function OnBeginRequest(sender, args) {
                $.blockUI({ message: '<h1><img src="/img/loading.gif" /> Cargando...</h1>' });
            }
            function endRequest(sender, args) {
                $.unblockUI();
                $('.cmb').select2();
                initTable1();
            }
            var initTable1 = function () {
                var table = $('.grd');
                var table1 = document.getElementById("grd");
                $('.grd').each(function () {
                    var t = $(this);
                    var continuar = true;
                    try{
                        var rows = t.getElementsByTagName("tr");
                    
                        if (rows.length > 0 && rows[0].getElementsByTagName("td")[0] != null && rows[0].getElementsByTagName("td")[0].innerText.startsWith('No ')) {
                            continuar = false;
                        }
                    } catch (err) {

                    }
                    /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

                    /* Set tabletools buttons and button container */
                    if (continuar) {
                        $.extend(true, $.fn.DataTable.TableTools.classes, {
                            "container": "btn-group tabletools-dropdown-on-portlet",
                            "buttons": {
                                "normal": "btn btn-sm default",
                                "disabled": "btn btn-sm default disabled"
                            },
                            "collection": {
                                "container": "DTTT_dropdown dropdown-menu tabletools-dropdown-menu"
                            }
                        });

                        var oTable = t.dataTable({

                            // Internationalisation. For more info refer to http://datatables.net/manual/i18n
                            "language": {
                                "aria": {
                                    "sortAscending": ": Activar para ordenar columna de forma ascendente",
                                    "sortDescending": ": Activar para ordenar columna de forma descendente"
                                },
                                "emptyTable": "No hay datos en esta tabla",
                                "info": "Mostrando _START_ to _END_ de _TOTAL_ registros",
                                "infoEmpty": "No se encontraron registros",
                                "infoFiltered": "(filtrados de _MAX_ registros totales)",
                                "lengthMenu": "Mostrar _MENU_ registros",
                                "search": "Buscar:",
                                "zeroRecords": "No se encontraron registros"
                            },

                            "order": [
                    [1, 'desc']
                            ],

                            "lengthMenu": [
                                [5, 15, 20, -1],
                                [5, 15, 20, "All"] // change per page values here
                            ],
                            // set the initial value
                            "pageLength": 10,
                            "autoWidth": false,

                            "dom": "<'row' <'col-md-12'T>><'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r><''t><'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>", // horizobtal scrollable datatable

                            // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
                            // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js). 
                            // So when dropdowns used the scrollable div should be removed. 
                            //"dom": "<'row' <'col-md-12'T>><'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>t<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",

                            "tableTools": {
                                "sSwfPath": "/assets/global/plugins/datatables/extensions/TableTools/swf/copy_csv_xls_pdf.swf",
                                "aButtons": [{
                                    "sExtends": "pdf",
                                    "sButtonText": "PDF"
                                }, {
                                    "sExtends": "csv",
                                    "sButtonText": "CSV"
                                }, {
                                    "sExtends": "xls",
                                    "sButtonText": "Excel"
                                }, {
                                    "sExtends": "print",
                                    "sButtonText": "Imprimir",
                                    "sInfo": 'Presione "CTR+P" para imprimir o "ESC" para volver',
                                    "sMessage": "Generated by DataTables",
                                    "fnComplete": function (nButton, oConfig, oFlash) {
                                        //$('.table').dataTable().fnSetColumnVis(0, false);
                                        //$('.table').dataTable().fnSetColumnVis(7, false);
                                        //$('.table').dataTable().fnSetColumnVis(8, false);
                                        //$(window).keyup(closePrintView);
                                    }

                                }]
                            }
                        });
                    }
                });
                //var tableWrapper = $('#sample_1_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

                //tableWrapper.find('.dataTables_length select').select2(); // initialize select2 dropdown
            }
            initTable1();

        });
    </script>
</asp:Content>

