using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Membership_ManageRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            DisplayRolesInGrid();
    }

    private void DisplayRolesInGrid()
    {
        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        grd.DataSource = roleManager.Roles.Select(p=>p.Name).ToList();
        grd.DataBind(); 
    }

    protected void CreateRoleButton_Click(object sender, EventArgs e)
    {
        string newRoleName = RoleName.Text.Trim();
        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        if (!roleManager.RoleExists(newRoleName))
        {
            // Create the role
            roleManager.Create(new IdentityRole(newRoleName));

            // Refresh the RoleList Grid
            DisplayRolesInGrid();
        }

        RoleName.Text = string.Empty;
    }

    protected void RoleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        // Get the RoleNameLabel
        Label RoleNameLabel = grd.Rows[e.RowIndex].FindControl("RoleNameLabel") as Label;
        var role = roleManager.FindByName(RoleNameLabel.Text);
        if (role != null)
        {
            // Delete the role
            roleManager.Delete(role);
        }
        // Rebind the data to the RoleList grid
        DisplayRolesInGrid();
    }
}
