<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Grupo.aspx.cs" Inherits="admin_Direccion_Grupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" Runat="Server">
    <h1>
        <asp:Label Text="" ID="lblTitulo" runat="server" /></h1>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">
    <div class="row">
        <div style="float:right;"><a href="/Admin/Direccion/Inicio" class="btn green">Volver</a></div>
        <div class="col-md-6">
            <!-- BEGIN Portlet PORTLET-->
            <div class="portlet box purple">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-gift"></i>Información General
                    </div>
                </div>
                <div class="portlet-body form">
                    <div class="row">
                        <div class="form-body">
                            <div class="alert alert-danger display-hide">
                                <button class="close" data-close="alert"></button>
                                Por favor corrija los errores señalados
                            </div>
                            <br />
                            <div class="col-md-12">
                                <div class="row"></div>
                                <div class="portlet gren">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="fa fa-user"></i>Datos Generales
                                        </div>

                                    </div>
                                    <div class="portlet-body">
                                        <div class="form-group input-large">
                                            <label>Grado:</label><span class="required">
										* </span>
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-hospital-o"></i>
                                                </span>
                                                <div class="input-icon right">
                                                    <i class="fa"></i>
                                                    <asp:DropDownList ID="cmbGrado" runat="server" CssClass="form-control input-lg">
                                                        <asp:ListItem Text="1" />
                                                        <asp:ListItem Text="2" />
                                                        <asp:ListItem Text="3" />
                                                        <asp:ListItem Text="4" />
                                                        <asp:ListItem Text="5" />
                                                        <asp:ListItem Text="6" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group input-large">
                                            <label>Grupo:</label><span class="required">
										* </span>
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-rocket"></i>
                                                </span>
                                                <div class="input-icon right">
                                                    <i class="fa"></i>
                                                     <asp:DropDownList ID="cmbGrupo" runat="server" CssClass="form-control input-lg">

                                                        <asp:ListItem Text="A" />
                                                        <asp:ListItem Text="B" />
                                                        <asp:ListItem Text="C" />
                                                        <asp:ListItem Text="D" />
                                                        <asp:ListItem Text="E" />
                                                        <asp:ListItem Text="F" />
                                                        <asp:ListItem Text="G" />
                                                        <asp:ListItem Text="H" />
                                                        <asp:ListItem Text="I" />
                                                        <asp:ListItem Text="J" />
                                                        <asp:ListItem Text="K" />
                                                        <asp:ListItem Text="L" />
                                                        <asp:ListItem Text="M" />
                                                        <asp:ListItem Text="N" />
                                                        <asp:ListItem Text="O" />
                                                        <asp:ListItem Text="P" />
                                                        <asp:ListItem Text="Q" />
                                                        <asp:ListItem Text="R" />
                                                        <asp:ListItem Text="S" />
                                                        <asp:ListItem Text="T" />
                                                        <asp:ListItem Text="U" />
                                                        <asp:ListItem Text="V" />
                                                        <asp:ListItem Text="W" />
                                                        <asp:ListItem Text="X" />
                                                        <asp:ListItem Text="Y" />
                                                        <asp:ListItem Text="Z" />
                                                      
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                          
                                    
                                     
                                        
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
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" Runat="Server">
</asp:Content>

