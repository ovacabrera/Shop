using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop.WebForms
{
    public partial class SiteMaster : MasterPage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtFilter.Attributes.Add(
                "onkeypress", "button_click(this,'" + this.lnkSearch.ClientID + "')");

            this.txtFilter.Focus();
        }

        protected void lnkSearch_OnClick(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Pages/Search.aspx?q=" + txtFilter.Text);
        }

        #endregion
    }
}