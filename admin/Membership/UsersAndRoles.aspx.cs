using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Security.Claims;
using System.Collections.Generic;
public partial class Admin_Membership_UsersAndRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Bind the users and roles
            BindUsersToUserList();
            BindRolesToList();

            // Check the selected user's roles
            CheckRolesForSelectedUser();

            // Display those users belonging to the currently selected role
            DisplayUsersBelongingToRole();
        }
    }

    private void BindRolesToList()
    {
        // Get all of the roles
        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        string[] roles = roleManager.Roles.Select(p => p.Name).ToArray();
        UsersRoleList.DataSource = roles;
        UsersRoleList.DataBind();

        RoleList.DataSource = roles;
        RoleList.DataBind();
    }

    #region 'By User' Interface-Specific Methods
    private void BindUsersToUserList()
    {
        // Get all of the user accounts
        var manager = new UserManager();
        UserList.DataSource = manager.Users.Select(p=>p.UserName).ToArray();
        UserList.DataBind();
    }

    protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckRolesForSelectedUser(); 
    }

    private void CheckRolesForSelectedUser()
    {
        // Determine what roles the selected user belongs to
        var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        var db = new ApplicationDbContext();
        var u = db.Users.Where(p=>p.UserName == UserList.SelectedItem.Text).SingleOrDefault();
        string selectedUserName = UserList.SelectedValue;
       //var roles = u.Claims
       //         .Where(c => c.ClaimType == ClaimTypes.Role)
       //         .Select(c => c.ClaimValue);
        List<string> lstRoles = new List<string>();
        foreach (var r in u.Roles)
        {
            lstRoles.Add(rm.FindById(r.RoleId).Name);
        }
        // Loop through the Repeater's Items and check or uncheck the checkbox as needed
        foreach (RepeaterItem ri in UsersRoleList.Items)
        {
            // Programmatically reference the CheckBox
            CheckBox RoleCheckBox = ri.FindControl("RoleCheckBox") as CheckBox;

            // See if RoleCheckBox.Text is in selectedUsersRoles
            if (lstRoles.Contains<string>(RoleCheckBox.Text))
                RoleCheckBox.Checked = true;
            else
                RoleCheckBox.Checked = false;
            if (RoleCheckBox.Text == "ADCUAdmin")
            {
                if (!User.IsInRole("ADCUAdmin"))
                    RoleCheckBox.Enabled = false;
            }
        }
    }

    protected void RoleCheckBox_CheckChanged(object sender, EventArgs e)
    {
        // Reference the CheckBox that raised this event
        CheckBox RoleCheckBox = sender as CheckBox;

        // Get the currently selected user and role
        string selectedUserName = UserList.SelectedValue;
        string roleName = RoleCheckBox.Text;
        // Determine if we need to add or remove the user from this role
        var userStore = new UserStore<IdentityUser>();
        var manager = new UserManager<IdentityUser>(userStore);
        if (RoleCheckBox.Checked)
        {
            // Add the user to the role
            manager.AddToRole(manager.FindByName(selectedUserName).Id, roleName);
            //Roles.AddUserToRole(selectedUserName, roleName);
            manager.Update(manager.FindByName(selectedUserName));
            // Display a status message
            ActionStatus.Text = string.Format("El Usuario {0} se añadió al rol {1}.", selectedUserName, roleName);
        }
        else
        {
            // Remove the user from the role
            //Roles.RemoveUserFromRole(selectedUserName, roleName);
            manager.RemoveFromRole(manager.FindByName(selectedUserName).Id, roleName);
            // Display a status message
            ActionStatus.Text = string.Format("El usuario {0} ha sido quitado del rol {1}.", selectedUserName, roleName);
        }

        // Refresh the "by role" interfaces
        DisplayUsersBelongingToRole();
    }
    #endregion

    #region 'By Role' Interface-Specific Methods
    protected void RoleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayUsersBelongingToRole();
    }

    private void DisplayUsersBelongingToRole()
    {
        var userStore = new UserStore<IdentityUser>();
        var manager = new UserManager<IdentityUser>(userStore);
        // Get the selected role
        string selectedRoleName = RoleList.SelectedValue;

        // Get the list of usernames that belong to the role
        var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        
         var selectedUserIds = from role in rm.Roles
                          where role.Name == selectedRoleName
                          from user in role.Users
                          select user.UserId;
        var us = rm.FindByName(RoleList.SelectedValue).Users.Select(p=>p.UserId);
         string[] usersBelongingToRole = manager.Users.Where(p => us.Contains(p.Id)).Select(p=>p.UserName).ToArray();

        // Bind the list of users to the GridView
        RolesUserList.DataSource = usersBelongingToRole;
        RolesUserList.DataBind();
    }

    protected void RolesUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the selected role
        string selectedRoleName = RoleList.SelectedValue;

        // Reference the UserNameLabel
        Label UserNameLabel = RolesUserList.Rows[e.RowIndex].FindControl("UserNameLabel") as Label;
        var userStore = new UserStore<IdentityUser>();
        var manager = new UserManager<IdentityUser>(userStore);
        // Remove the user from the role
        manager.RemoveFromRole(UserNameLabel.Text, selectedRoleName);

        // Refresh the GridView
        DisplayUsersBelongingToRole();

        // Display a status message
        ActionStatus.Text = string.Format("User {0} was removed from role {1}.", UserNameLabel.Text, selectedRoleName);

        // Refresh the "by user" interface
        CheckRolesForSelectedUser();
    }

    protected void AddUserToRoleButton_Click(object sender, EventArgs e)
    {
        // Get the selected role and username
        //string selectedRoleName = RoleList.SelectedValue;
        //string userNameToAddToRole = UserNameToAddToRole.Text;

        //// Make sure that a value was entered
        //if (userNameToAddToRole.Trim().Length == 0)
        //{
        //    ActionStatus.Text = "You must enter a username in the textbox.";
        //    return;
        //}

        //// Make sure that the user exists in the system
        //MembershipUser userInfo = Membership.GetUser(userNameToAddToRole);
        //if (userInfo == null)
        //{
        //    ActionStatus.Text = string.Format("The user {0} does not exist in the system.", userNameToAddToRole);
        //    return;
        //}

        //// Make sure that the user doesn't already belong to this role
        //if (Roles.IsUserInRole(userNameToAddToRole, selectedRoleName))
        //{
        //    ActionStatus.Text = string.Format("User {0} already is a member of role {1}.", userNameToAddToRole, selectedRoleName);
        //    return;
        //}

        //// If we reach here, we need to add the user to the role
        //Roles.AddUserToRole(userNameToAddToRole, selectedRoleName);

        //// Clear out the TextBox
        //UserNameToAddToRole.Text = string.Empty;

        //// Refresh the GridView
        //DisplayUsersBelongingToRole();

        //// Display a status message
        //ActionStatus.Text = string.Format("User {0} was added to role {1}.", userNameToAddToRole, selectedRoleName);

        //// Refresh the "by user" interface
        //CheckRolesForSelectedUser();
    }
    #endregion
}