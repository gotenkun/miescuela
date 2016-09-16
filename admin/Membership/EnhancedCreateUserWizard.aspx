<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="EnhancedCreateUserWizard.aspx.cs" Inherits="Membership_EnhancedCreateUserWizard" Title="Untitled Page" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" Runat="Server">
    <h2>Crear Usuario</h2>
    <p>
        <asp:Label ID="lblError" runat="server" CssClass="Important"></asp:Label>
    </p>
    <!--onsendingmail="NewUserWizard_SendingMail"
        <MailDefinition BodyFileName="~/EmailTemplates/CreateUserWizard.txt" 
            Subject="Welcome to My Website! Please activate your account.">
        </MailDefinition>-->
    <asp:CreateUserWizard ID="NewUserWizard" runat="server" 
        ContinueDestinationPageUrl="~/Admin/Membership/AdditionalUserInfo.aspx"
        AnswerLabelText="Respuesta de Seguridad" 
            AnswerRequiredErrorMessage="Se requiere la respuesta de seguridad" 
            CancelButtonText="Cancelar" CompleteSuccessText="La cuenta ha sido creada." 
            ConfirmPasswordCompareErrorMessage="El password y su confirmación deben coincidir." 
            ConfirmPasswordLabelText="Confirmar Password:" 
            ConfirmPasswordRequiredErrorMessage="Se requiere la confirmación de password." 
            CreateUserButtonText="Crear Usuario" 
            DuplicateEmailErrorMessage="La dirección de email que indicó ya está en uso, indique otra." 
            DuplicateUserNameErrorMessage="Ingrese otro nombre de usuario." 
            EmailRegularExpressionErrorMessage="Por favor ingrese otro email." 
            EmailRequiredErrorMessage="Se requiere el email." 
            FinishCompleteButtonText="Finalizar" FinishPreviousButtonText="Anterior" 
            InvalidAnswerErrorMessage="Ingrese una pregunta de seguridad distinta." 
            InvalidEmailErrorMessage="Por favor ingrese un email correcto." 
            InvalidPasswordErrorMessage="Longitud mínima de password: {0}. Caracteres NO-alfanuméricos requeridos: {1}." 
            InvalidQuestionErrorMessage="Ingrese una pregunta de seguridad diferente." 
            PasswordRegularExpressionErrorMessage="Ingrese un password distinto." 
            PasswordRequiredErrorMessage="Se requiere el password" 
            QuestionLabelText="Pregunta de Seguridad" 
            QuestionRequiredErrorMessage="Se requiere la pregunta de seguridad" 
            UnknownErrorMessage="Su cuenta NO fue creada, intente más tarde." 
            UserNameLabelText="Nombre de Usuario:" 
            UserNameRequiredErrorMessage="Se requiere el nombre de Usuario" 
        oncreateduser="NewUserWizard_CreatedUser" 
        onactivestepchanged="NewUserWizard_ActiveStepChanged" 
        onfinishbuttonclick="NewUserWizard_FinishButtonClick" 
        onnextbuttonclick="NewUserWizard_NextButtonClick" 
        oncontinuebuttonclick="NewUserWizard_ContinueButtonClick">
        
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" 
                Title="Crear cuenta">
            </asp:CreateUserWizardStep>
            <asp:WizardStep ID="stDatos" runat="server" StepType="Step" 
                Title="Datos Generales">
                <p>
                    Indique datos generales del usuario:</p>
                <p>
                    Nombre:
                    <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
                </p>
                <p>
                    Fecha de Nacimiento:<asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaNacimiento_CalendarExtender" runat="server" 
                        Enabled="True" Format="yyyy-MM-dd" TargetControlID="txtFechaNacimiento">
                    </asp:CalendarExtender>
                </p>
                <p>
                    
                   
                </p>
            </asp:WizardStep>
             <asp:WizardStep ID="SpecifyRolesStep" runat="server" StepType="Step" 
                Title="Especificar Roles" AllowReturn="False">
                <asp:CheckBoxList ID="RoleList" runat="server">
                </asp:CheckBoxList>
                </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Perfil" ID="stPerfil">
                Seleccione la Fotografía del usuario (opcional):<br />
                <br />
                Archivo:<asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <br />
                Escriba un texto descriptivo del usuario. (opcional)<br />
                <asp:TextBox ID="txtPerfil" runat="server" Height="147px" MaxLength="255" 
                    Width="536px"></asp:TextBox>
                <br />
            </asp:WizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" 
                Title="Completo">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    
</asp:Content>
