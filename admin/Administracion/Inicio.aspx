<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="admin_Administracion_Inicio" %>

<%@ Register Src="~/admin/Controls/ManageUsers.ascx" TagPrefix="uc1" TagName="ManageUsers" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" runat="Server">
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/clockface/css/clockface.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/bootstrap-datepicker/css/datepicker3.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.min.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/bootstrap-colorpicker/css/colorpicker.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" />
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
                                <br />
                                <br />
                                <br />
                                <a href="/Admin/Administracion/Agregar-Usuario" class="btn green">Crear Usuario</a> <a href="/Admin/Administracion/Importar-Usuarios" class="btn blue">Importar de Excel</a><br />
                                <br />
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>

                                        <uc1:ManageUsers runat="server" ID="ManageUsers" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="tab-pane" id="tab_1_1_3">
                                <h2>Seleccione el reporte que desea generar</h2>
                                Fecha Inicio:
                                <asp:TextBox runat="server" CssClass="form-control input-medium date-picker" />
                                Fecha Fin:<asp:TextBox runat="server" CssClass="form-control input-medium date-picker" />
                                <hr />
                                <table class="table table-condensed table-hover grd">
                                    <tr>
                                        <td align="center">
                                            <asp:Button Text="Usuarios Más Activos" ID="btnMasActivos" CssClass=" btn btn-lg blue" runat="server" OnClick="btnMasActivos_Click" />
                                        </td>
                                        <td>Corresponde a los usuarios que más ideas, mensajes, comentarios y calificaciones han dado en el sistema.</td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button Text="Mejores Ideas" ID="Button1" CssClass=" btn btn-lg blue" runat="server" OnClick="btnMasActivos_Click" />
                                        </td>
                                        <td>Muestra las ideas ordenadas por su calificación</td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button Text="Número de Áreas" ID="Button2" CssClass=" btn btn-lg blue" runat="server" OnClick="btnMasActivos_Click" />
                                        </td>
                                        <td>Muestra las escuelas y el número de áreas que han dado de alta en el sistema.</td>
                                    </tr>
                                </table>
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
    <script src="/Scripts/select2.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/media/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/extensions/TableTools/js/dataTables.tableTools.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/extensions/ColReorder/js/dataTables.colReorder.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/extensions/Scroller/js/dataTables.scroller.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js"></script>
    <script src="/assets/admin/pages/scripts/table-advanced.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/jquery-validation/js/jquery.validate.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/jquery-validation/js/additional-methods.js"></script>
    <script src="/assets/admin/pages/scripts/form-validation.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/clockface/js/clockface.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/bootstrap-daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.js"></script>
    <script type="text/javascript" src="/assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script src="/assets/admin/pages/scripts/components-pickers.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            ComponentsPickers.init();
            $("#txtFechaNacimiento").datepicker({ maxDate: '0' });
            //alert('');
        });

    </script>
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
                    try {
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

