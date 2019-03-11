using System;
using System.Web.UI;

namespace Shop.WebForms
{
    public partial class SiteMaster : MasterPage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            txtFilter.Attributes.Add(
                "onkeypress", "button_click(this,'" + lnkSearch.ClientID + "')");

            txtFilter.Focus();
        }

        protected void lnkSearch_OnClick(object sender, EventArgs e)
        {
            if (txtFilter.Value.Trim() != string.Empty)
            {
                Page.Response.Redirect("~/Pages/Search.aspx?q=" + txtFilter.Value);
            }
        }

        #endregion
    }
}