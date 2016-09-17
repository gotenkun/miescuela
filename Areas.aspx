<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Areas.aspx.cs" Inherits="Areas" %>

<%@ Register Src="~/Controls/Sharer.ascx" TagPrefix="uc1" TagName="Sharer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" Runat="Server">
    <h1>Áreas de la Escuela</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">
    <uc1:Sharer runat="server" ID="Sharer" />
    <p>Selecciona el área que deseas consultar:</p>
    <asp:Literal Text="" ID="litAreas" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" Runat="Server">
</asp:Content>

