using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Claims;

public partial class admin_Controls_ManageUsers : System.Web.UI.UserControl
{
    public long CctID { get; set; }
    public string Role { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindUserAccounts();

            BindFilteringUI();
        }
    }

    private void BindFilteringUI()
    {
        string[] filterOptions = { "Todos", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        FilteringUI.DataSource = filterOptions;
        FilteringUI.DataBind();
    }

    private void BindUserAccounts()
    {
        int totalRecords;
        UserManager um = new UserManager();
        if (CctID > 0)
        {
            var users = um.Users.Where(p => p.UserName.StartsWith(UsernameToMatch) && p.Claims.Where(p1 => p1.ClaimType == ClaimTypes.UserData).FirstOrDefault().ClaimValue == CctID.ToString());
            grd.DataSource = users.ToList();
        }
        else
        {
            var users = um.Users.Where(p => p.UserName.StartsWith(UsernameToMatch));
            grd.DataSource = users.ToList();
        }
         grd.DataBind();
         if (grd.Rows.Count > 0)
         {
             grd.HeaderRow.TableSection = TableRowSection.TableHeader;
             grd.UseAccessibleHeader = true;
             if (grd.ShowFooter)
                 grd.FooterRow.TableSection = TableRowSection.TableFooter;
         }
        // Enable/disable the paging interface
        //bool visitingFirstPage = (this.PageIndex == 0);
        //lnkFirst.Enabled = !visitingFirstPage;
        //lnkPrev.Enabled = !visitingFirstPage;

        //int lastPageIndex = (totalRecords - 1) / this.PageSize;
        //bool visitingLastPage = (this.PageIndex >= lastPageIndex);
        //lnkNext.Enabled = !visitingLastPage;
        //lnkLast.Enabled = !visitingLastPage;
    }

    protected void FilteringUI_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Todos")
            this.UsernameToMatch = string.Empty;
        else
            this.UsernameToMatch = e.CommandName;

        BindUserAccounts();
    }

    #region Paging Interface Click Event Handlers
    protected void lnkFirst_Click(object sender, EventArgs e)
    {
        this.PageIndex = 0;
        BindUserAccounts();
    }

    protected void lnkPrev_Click(object sender, EventArgs e)
    {
        this.PageIndex -= 1;
        BindUserAccounts();
    }

    protected void lnkNext_Click(object sender, EventArgs e)
    {
        this.PageIndex += 1;
        BindUserAccounts();
    }

    protected void lnkLast_Click(object sender, EventArgs e)
    {
        // Determine the total number of records
        //int totalRecords;
        //Membership.FindUsersByName(this.UsernameToMatch + "%", this.PageIndex, this.PageSize, out totalRecords);

        //// Navigate to the last page index
        //this.PageIndex = (totalRecords - 1) / this.PageSize;
        //BindUserAccounts();
    }
    #endregion

    #region Properties
    private string UsernameToMatch
    {
        get
        {
            object o = ViewState["UsernameToMatch"];
            if (o == null)
                return string.Empty;
            else
                return (string)o;
        }
        set
        {
            ViewState["UsernameToMatch"] = value;
        }
    }

    private int PageIndex
    {
        get
        {
            object o = ViewState["PageIndex"];
            if (o == null)
                return 0;
            else
                return (int)o;
        }
        set
        {
            ViewState["PageIndex"] = value;
        }
    }

    private int PageSize
    {
        get
        {
            return 10;
        }
    }
    #endregion
}