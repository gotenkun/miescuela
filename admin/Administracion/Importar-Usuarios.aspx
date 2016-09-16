<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Importar-Usuarios.aspx.cs" Inherits="admin_Administracion_Importar_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" Runat="Server">
    <h1>Importar Usuarios de Excel</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">
    <div style="float:right;"><a href="/Admin/Direccion/Inicio" class="btn green">Volver</a></div>
    <p>Desde esta sección puede importar sus usuarios desde un archivo de excel. </p>
     
    <div class="note note-info">
        <h4 class="block">1-. Descargue el Formato</h4>
        <p>
            Hemos creado un formato en Excel para que pueda llenar fácil y rápidamente la información básica de sus pacientes.<br />
            <br />
            <a href="/Admin/Formatos/Usuarios.xls" class="btn btn-circle btn-sm green">Descargar Formato <i class="fa fa-arrow-down"></i>
            </a>
        </p>
    </div>
    <div class="note note-warning">
        <h4 class="block">2-. Llene el formato</h4>
        <p>
            Tenga en cuenta las siguientes instrucciones:
        </p>
        <ul>
            <li>Las columnas marcadas con asterisco son requeridas.</li>
            <li>Llene la mayor cantidad de datos posibles.</li>
            <li>Una vez importados, podrá editar sus pacientes en MedikAdmin.</li>
        </ul>

    </div>
    
    <div class="note note-info">
        <h4 class="block">3-. Proporcione el archivo xls lleno</h4>
        <p>
            Indique el archivo con los datos de pacientes:
            <br />
            <br />
            <asp:FileUpload ID="fuArchivo" runat="server" accept=".xls" />
        </p>
    </div>

    <p>
        Al haber completado los pasos, presione el botón Continuar. <b>Podrá confirmar los datos en la siguiente pantalla</b><br />
    </p>



    <asp:Button ID="btnContinuar" runat="server" class="btn blue" type="submit" Text="Continuar" OnClick="btnContinuar_Click" UseSubmitBehavior="true" OnClientClick="this.style.display='none';Metronic.blockUI();" />
    <br />
    <br />
    <br />
    <asp:UpdateProgress runat="server">
        <ProgressTemplate>
            <img src="../../img/loading.gif" alt="Cargando" />
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" Runat="Server">
</asp:Content>

