using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

[assembly: OwinStartup(typeof(Startup))]

public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        app.UseKentorOwinCookieSaver();
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            ExpireTimeSpan = TimeSpan.FromHours(4),
            LoginPath = new PathString("/Ingresar")
        });
    }
}
