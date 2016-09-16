using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Security
/// </summary>
internal class Security
{
    ApplicationDbContext context = new ApplicationDbContext();

    internal void AddUserToRole(string userName, string roleName)
    {
        var UserManager = new UserManager<User>(new UserStore<User>(context));

        try
        {
            var user = UserManager.FindByName(userName);
            UserManager.AddToRole(user.Id, roleName);
            context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

}