using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Threading;
using System.Globalization;


/// <summary>
/// Custom base page used for all web forms.
/// </summary>
public class BasePage : Page
{
    private const string m_DefaultCulture = "es-MX";

    protected override void InitializeCulture()
    {
        //retrieve culture information from session
        string culture = Convert.ToString(Session["MyCulture"]);

        //check whether a culture is stored in the session
        if (!string.IsNullOrEmpty(culture)) Culture = culture;
        else
        {
            Culture = m_DefaultCulture;
            Session["MyCulture"] = m_DefaultCulture;
        }

        //set culture to current thread
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

        //call base class
        base.InitializeCulture();
    }
}