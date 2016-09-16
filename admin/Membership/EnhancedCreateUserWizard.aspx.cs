using System;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Membership_EnhancedCreateUserWizard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Reference the SpecifyRolesStep WizardStep
            WizardStep SpecifyRolesStep = this.NewUserWizard.FindControl("SpecifyRolesStep") as WizardStep;

            // Reference the RoleList CheckBoxList
            CheckBoxList RoleList = SpecifyRolesStep.FindControl("RoleList") as CheckBoxList;

            // Bind the set of roles to RoleList
            RoleList.DataSource = Roles.GetAllRoles();
            RoleList.DataBind();
            foreach (ListItem li in RoleList.Items)
            {
                if (li.Text == "ADCUAdmin")
                {
                    if (!User.IsInRole("ADCUAdmin"))
                        li.Enabled = false;
                }
            }
        }
    }

    protected void NewUserWizard_CreatedUser(object sender, EventArgs e)
    {
       
    }

    protected void NewUserWizard_ActiveStepChanged(object sender, EventArgs e)
    {
        
    }

    protected void NewUserWizard_SendingMail(object sender, MailMessageEventArgs e)
    {
        // Get the UserId of the just-added user
        MembershipUser newUser = Membership.GetUser(NewUserWizard.UserName);
        Guid newUserId = (Guid)newUser.ProviderUserKey;

        // Determine the full verification URL (i.e., http://yoursite.com/Verification.aspx?ID=...)
        string urlBase = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
        string verifyUrl = "/Verification.aspx?ID=" + newUserId.ToString();
        string fullUrl = urlBase + verifyUrl;

        // Replace <%VerificationUrl%> with the appropriate URL and querystring
        e.Message.Body = e.Message.Body.Replace("<%VerificationUrl%>", fullUrl);
    }
    protected void NewUserWizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
    {
        bool continuar = true;
        switch (NewUserWizard.ActiveStep.ID)
        {
            case "stDatos":
                //validar detalles 1
                
                if (txtNombre.Text.Length < 3)
                {
                    lblError.Text = "El nombre debe ser al menos de 3 letras.";
                    continuar = false;
                }
                if (txtFechaNacimiento.Text.Length != 10)
                {
                    lblError.Text = "Confirme la fecha de nacimiento, siga el formato indicado.";
                    continuar = false;
                }
                else
                {
                    int ano = 0;
                    int mes = 0;
                    int dia = 0;//1980-05-11
                    if (!(int.TryParse(txtFechaNacimiento.Text.Substring(0, 4), out ano) &&
                        int.TryParse(txtFechaNacimiento.Text.Substring(5, 2), out mes) &&
                        int.TryParse(txtFechaNacimiento.Text.Substring(8, 2), out dia)))
                    {

                        lblError.Text = "Confirme la fecha de nacimiento, siga el formato indicado.";
                        continuar = false;
                    }
                    else
                    {
                        try
                        {
                            DateTime test = new DateTime(ano, mes, dia);
                        }
                        catch (Exception)
                        {
                            lblError.Text = "Seleccione una fecha válida, siga el formato indicado.";
                            continuar = false;

                        }
                    }
                }
                break;
        }
        if (!continuar)
            e.Cancel = true;
        else
            lblError.Text = "";

    }
    protected void NewUserWizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        //add roles
        // Reference the SpecifyRolesStep WizardStep
        WizardStep SpecifyRolesStep = this.NewUserWizard.FindControl("SpecifyRolesStep") as WizardStep;

        // Reference the RoleList CheckBoxList
        CheckBoxList RoleList = SpecifyRolesStep.FindControl("RoleList") as CheckBoxList;

        // Add the checked roles to the just-added user
        foreach (ListItem li in RoleList.Items)
        {
            if (li.Enabled && li.Selected)
                Roles.AddUserToRole(NewUserWizard.UserName, li.Text);
        }
        // Get the UserId of the just-added user
        MembershipUser newUser = Membership.GetUser(NewUserWizard.UserName);
        Guid newUserId = (Guid)newUser.ProviderUserKey;
        // Insert a new record into UserProfiles
        string connectionString = ConfigurationManager.ConnectionStrings["KuyuConnectionString"].ConnectionString;
        string insertSql = "INSERT INTO Usuario(UserId,UserName, FechaNacimiento," +
        " Nombre, Perfil) VALUES(@UserId,@UserName, @FechaNacimiento, @Nombre,@Perfil)";
         int ano = 0;
        int mes = 0;
        int dia = 0;//1980-05-11
        DateTime fecha = new DateTime();
        if ((int.TryParse(txtFechaNacimiento.Text.Substring(0, 4), out ano) &&
            int.TryParse(txtFechaNacimiento.Text.Substring(5, 2), out mes) &&
            int.TryParse(txtFechaNacimiento.Text.Substring(8, 2), out dia)))
        {
            fecha = new DateTime(ano, mes, dia);
        }
        using (SqlConnection myConnection = new SqlConnection(connectionString))
        {
            myConnection.Open();
            long? familia = -1;
            SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
            myCommand.Parameters.AddWithValue("@UserId", newUserId);
            myCommand.Parameters.AddWithValue("@UserName", newUser.UserName);
           // myCommand.Parameters.AddWithValue("@InstitucionID", familia);
            myCommand.Parameters.AddWithValue("@FechaNacimiento", fecha);
            myCommand.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            myCommand.Parameters.AddWithValue("@Perfil", this.txtPerfil.Text);
            myCommand.ExecuteNonQuery();

            myConnection.Close();
        }
    }
    protected void NewUserWizard_ContinueButtonClick(object sender, EventArgs e)
    {
        Response.Redirect("../Users/ManageUsers.aspx");
    }
}
