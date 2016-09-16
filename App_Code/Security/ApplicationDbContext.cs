using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ApplicationDbContext
/// </summary>
public class ApplicationDbContext : IdentityDbContext<User>
{

    public ApplicationDbContext() : base("MiEscuelaJaliscoConnectionString") { }

}