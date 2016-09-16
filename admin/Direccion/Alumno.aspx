<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Alumno.aspx.cs" Inherits="admin_Direccion_Alumno" %>

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
                                            <label>Nombre(s) del Alumno:</label><span class="required">
										* </span>
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-hospital-o"></i>
                                                </span>
                                                <div class="input-icon right">
                                                    <i class="fa"></i>
                                                    <asp:TextBox runat="server" ID="txtNombre" minlength="2" required type="text" class="form-control input-large" placeholder="Ingrese el nombre" MaxLength="100" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group input-large">
                                            <label>Apellido Paterno:</label><span class="required">
										* </span>
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-rocket"></i>
                                                </span>
                                                <div class="input-icon right">
                                                    <i class="fa"></i>
                                                    <asp:TextBox runat="server" ID="txtPaterno" required ClientIDMode="Static" minlength="2" type="text" class="form-control input-large" placeholder="Apellido Paterno del Paciente" />
                                                </div>
                                            </div>
                                        </div>
                                          <div class="form-group input-large">
                                            <label>Apellido Materno:</label><span class="required">
										 </span>
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-rocket"></i>
                                                </span>
                                                <div class="input-icon right">
                                                    <i class="fa"></i>
                                                    <asp:TextBox runat="server" ID="txtMaterno" ClientIDMode="Static" minlength="2" type="text" class="form-control input-large" placeholder="Apellido Materno del Paciente" />
                                                </div>
                                            </div>
                                        </div>
                                          <div class="form-group input-large">
                                            <label>Género:</label><span class="required">
										 </span>
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-rocket"></i>
                                                </span>
                                                <div class="input-icon right">
                                                    <i class="fa"></i>
                                                    <asp:DropDownList runat="server" ID="cmbGenero" CssClass="form-control input-large select2me inline" >
                                                        <asp:ListItem Text="Hombre" Value="H" />
                                                        <asp:ListItem Text="Mujer" Value="M" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group input-large">
                                            <label>Fecha de Nacimiento:</label><span class="required">
										* </span>
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                                <div class="input-icon right">
                                                    <i class="fa"></i>
                                                    <asp:TextBox runat="server" ID="txtFechaNacimiento" style="cursor:pointer" required ClientIDMode="Static" minlength="10" MaxLength="10" type="text" class="form-control form-control-inline input-large date-picker" placeholder="Fecha de Nacimiento"  />
                                                </div>
                                            </div>
                                        </div>
                                    
                                        <h3>Datos de Localización</h3>
                                            <br />
                                            <div class="form-group">
                                                <label>Domicilio</label><span class="required">
										 </span>
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-road"></i>
                                                    </span>
                                                    <div class="input-icon right">
                                                        <i class="fa"></i>
                                                        <asp:TextBox runat="server" ID="txtDomicilio" minlength="2" type="text" class="form-control input-lg" placeholder="Calle, número y colonia" MaxLength="255" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group input-large">
                                                <label>Correo Electrónico</label><span class="required">
										 </span>
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-envelope"></i>
                                                    </span>
                                                    <div class="input-icon right">
                                                        <i class="fa"></i>
                                                        <asp:TextBox runat="server" ID="txtEmail" name="email" type="email" class="form-control input-large" placeholder="Ingrese el Email de la Institución" MaxLength="100" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group input-large">
                                                <label>Teléfono de casa</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-phone"></i>
                                                    </span>
                                                    <div class="input-icon right">
                                                        <i class="fa"></i>
                                                        <asp:TextBox runat="server" ID="txtTelefono" name="email" type="text" minlength="8" class="form-control input-large" placeholder="Teléfono de Casa" MaxLength="100" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group input-large">
                                                <label>Teléfono celular</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-mobile-phone"></i>
                                                    </span>
                                                    <div class="input-icon right">
                                                        <i class="fa"></i>
                                                        <asp:TextBox runat="server" ID="txtTelefonoCelular" name="email" type="text" minlength="10" class="form-control input-large" placeholder="10 dígitos" MaxLength="100" />
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
        <div class="col-md-6">
            <div class="portlet gren">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-camera"></i>Fotografía del Alumno
                    </div>

                </div>
                <div class="portlet-body">
                    <div class="form-group input-xlarge">
                        <label>Indique la foto</label>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <i class="fa fa-picture-o"></i>
                            </span>
                            <div class="input-icon right">
                                <i class="fa"></i>
                                &nbsp;<input type="file" id="fuImagen" runat="server" name="fuImagen" accept="image/*" />
                            </div>
                        </div>
                        <br />
                        <div class="col-sm-12 col-md-12">
                            <a href="#" class="thumbnail">
                                <asp:Image ImageUrl='' runat="server" ID="imgActual" style="max-height:355px;" />

                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" Runat="Server">
</asp:Content>

