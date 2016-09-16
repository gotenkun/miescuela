using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using System.Security.Claims;

public partial class Areas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Cargar();
        }
    }
    private void Cargar()
    {
        using (MiEscuelaDataContext context = new MiEscuelaDataContext())
        {
            long escuelaId = 0;
            if (Request.GetFriendlyUrlSegments().Count > 0)
            {
                escuelaId = long.Parse(Request.GetFriendlyUrlSegments()[0]);
            }
            else
            {
                escuelaId = Code.Common.GetInstitucionID((ClaimsIdentity)Page.User.Identity);
            }
            var c = context.CctActivos.Where(p => p.CctID == escuelaId).SingleOrDefault();
            if (c != null)
            {
                var areas = context.Areas.Where(p => p.CctID == c.CctID);
                string lit = "";
                foreach (Area a in areas)
                {
                    lit += "<div class='col-md-6'>" +
                "<!-- BEGIN Portlet PORTLET-->" +
                "<div class='portlet light'>" +
            "		<div class='portlet-title'>" +
            "			<div class='caption'>" +
            "				<i class='icon-speech'></i>" +
            "				<span class='caption-subject bold uppercase'> " + a.Nombre + "</span>" +
            "				<span class='caption-helper'></span>" +
            "			</div>" +

            "		</div>" +
            "		<div class='portlet-body'>" +
            "			<div class='slimScrollDiv' style='position: relative; overflow: hidden; width: auto; height: 200px;'><div class='scroller' style='height: 200px; overflow: hidden; width: auto;' data-rail-visible='1' data-rail-color='yellow' data-handle-color='#a1b2bd' data-initialized='1'>" +
                "			<h4>Calificación: " + a.Calificacion.ToString() + "</h4>" +
                        "<a href='/Ver-Area/" + a.AreaID + "' class='btn blue'>Ver Área</a>" +
                "		</div><div class='slimScrollBar' style='width: 7px; position: absolute; top: 0px; opacity: 0.4; display: none; border-radius: 7px; z-index: 99; right: 1px; height: 115.607px; background: rgb(161, 178, 189);'></div><div class='slimScrollRail' style='width: 7px; height: 100%; position: absolute; top: 0px; border-radius: 7px; opacity: 0.2; z-index: 90; right: 1px; display: none; background: yellow;'></div></div>" +
                "	</div>" +
                "</div>" +
                "<!-- END Portlet PORTLET-->" +
            "</div>";
                }
                litAreas.Text = lit;
            }

        }
    }
}