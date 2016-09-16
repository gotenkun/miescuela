<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Estadisticas-Jalisco.aspx.cs" Inherits="Estadisticas_Jalisco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" runat="Server">
    <link href="/css/select2.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/select2/select2.css"/>
<link rel="stylesheet" type="text/css" href="/assets/global/plugins/datatables/extensions/Scroller/css/dataTables.scroller.min.css"/>
<link rel="stylesheet" type="text/css" href="/assets/global/plugins/datatables/extensions/ColReorder/css/dataTables.colReorder.min.css"/>
<link rel="stylesheet" type="text/css" href="/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" runat="Server">
    <h1>Estadísticas Escuelas de Jalisco</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="portlet light">
        <div class="portlet-body">
            <div class="row">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <h4>Seleccione el grado escolar:</h4>
                        <asp:DropDownList runat="server" ID="cmbNivel" CssClass="form-control cmb" AppendDataBoundItems="true">
                            <asp:ListItem Text="Seleccione..." />
                        </asp:DropDownList>
                        <h4>Seleccione un Municipio</h4>
                        <asp:DropDownList runat="server" ID="cmbMunicipio" CssClass="form-control cmb">
                            <asp:ListItem Text="Seleccione..." />
                        </asp:DropDownList>
                        <h4>Seleccione un Turno</h4>
                        <asp:DropDownList runat="server" ID="cmbTurno" CssClass="form-control input-lg cmb">
                            <asp:ListItem Text="Seleccione..." />
                            <asp:ListItem Text="MATUTINO" />
                            <asp:ListItem Text="DISCONTINUO" />
                            <asp:ListItem Text="CONTINUO (JORNADA AMPLIADA)" />
                            <asp:ListItem Text="VESPERTINO" />
                            <asp:ListItem Text="CONTINUO (TIEMPO COMPLETO)" />
                            <asp:ListItem Text="NOCTURNO" />
                        </asp:DropDownList>
                        <br />
                        <br />
                        <br />
                        <h4>Seleccione la estadística que desea consultar:</h4>
                        <asp:Button Text="Mayor Deserción" ID="btnDesercion" OnClick="btnDesercion_Click" runat="server" CssClass="btn btn-lg blue" />&nbsp;&nbsp;&nbsp;
                <asp:Button Text="Mayor Reprobación" ID="btnReprobacion" OnClick="btnReprobacion_Click" runat="server" CssClass="btn btn-lg blue" />&nbsp;&nbsp;&nbsp;
                <asp:Button Text="Mejor Eficiencia" ID="btnEficiencia" OnClick="btnEficiencia_Click" runat="server" CssClass="btn btn-lg blue" />&nbsp;&nbsp;&nbsp;

                <hr />
                        <asp:GridView runat="server" CssClass="table table-striped table-bordered table-hover" ID="grd" ClientIDMode="Static" ShowFooter="true">
                            <EmptyDataTemplate>
                                No hay resultados. Use los filtros y seleccione su estadística.
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
                var table = $('#grd');
                var table1 = document.getElementById("grd");
                var rows = table1.getElementsByTagName("tr");
                var continuar = true;
                if (rows.length > 0 && rows[0].getElementsByTagName("td")[0] != null && rows[0].getElementsByTagName("td")[0].innerText.startsWith('No ')) {
                    continuar = false;
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

                    var oTable = table.dataTable({

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
                //var tableWrapper = $('#sample_1_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

                //tableWrapper.find('.dataTables_length select').select2(); // initialize select2 dropdown
            }
            initTable1();

        });
    </script>
    
      
</asp:Content>

