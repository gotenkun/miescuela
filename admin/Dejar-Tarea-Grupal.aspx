<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Dejar-Tarea-Grupal.aspx.cs" Inherits="admin_Dejar_Tarea_Grupal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" Runat="Server">
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/clockface/css/clockface.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/bootstrap-datepicker/css/datepicker3.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.min.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/bootstrap-colorpicker/css/colorpicker.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" />
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" Runat="Server">
    <h1>Dejar Tarea: <asp:Label Text="" ID="lblGrupo" runat="server" /></h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">
    <div class="col-md-12">
        <div class="portlet light bg-inverse">
            <div class="portlet-title">
                <div class="caption font-red-sunglo">
                    <i class="icon-share font-red-sunglo"></i>
                    <span class="caption-subject bold uppercase">Dejar Tarea
                        <asp:Label Text="" ID="lblTitulo1" runat="server" /></span>
                    <span class="caption-helper"></span>
                </div>

            </div>
            <div class="portlet-body">
                <h4>Llena los campos y presiona Guardar.
                </h4>
                <div runat="server" id="divInfo" class="alert alert-info">
                    <asp:Label Text="" ID="lblNumeroAlumnos" runat="server" />
                </div>
                <asp:HiddenField runat="server" ID="hdID" />
               <div class="form-group">
                    <label>Fecha Entrega</label>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="fa fa-envelope"></i>
                        </span>
                        <asp:TextBox runat="server" ID="txtFecha" style="cursor:pointer"  ClientIDMode="Static" minlength="10"
                             MaxLength="10" type="text" class="form-control form-control-inline input-large date-picker" placeholder="Fecha de Entrega" />

                    </div>
                </div>
                <div class="form-group">
                    <label>Describir tarea</label>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="fa fa-envelope"></i>
                        </span>
                        <asp:TextBox runat="server" ID="txtComentarios" TextMode="MultiLine" CssClass="form-control input-medium" />

                    </div>
                </div>
                <div class="form-group">
                    <label for="exampleInputFile1">Seleccionar Foto (opcional):</label>
                    <asp:FileUpload runat="server" ID="fuFoto" accept="image/*" />
                    <p class="help-block">
                        Indica solo imágenes.
                    </p>
                </div>
            </div>
            <hr />
            <div class="form-actions">
                <asp:Label Text="" ForeColor="Red" ID="lblError" runat="server" />
                
                <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn blue" runat="server" OnClick="btnGuardar_Click" OnClientClick="return confirm('¿Deseas enviar esta tarea?')" />
                <a href="" class="btn default" runat="server" id="hlCancelar">Cancelar</a>
            </div>
        </div>
          </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" Runat="Server">
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

           // FormValidation.init();
            ComponentsPickers.init();
            $("#txtFechaNacimiento").datepicker({ maxDate: '0' });
            //alert('');
        });
        </script>
</asp:Content>

