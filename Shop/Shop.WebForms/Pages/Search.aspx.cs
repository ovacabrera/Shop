using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Entities;
using Shop.Models;


namespace Shop.WebForms.Pages
{
    public partial class Search : System.Web.UI.Page
    {
        #region Attributes

        private IItemModel model;
        private List<Result> itemsList;

        #endregion

        #region Metods

        private void Find()
        {
            string filter = ((Page.Request.Params["q"]) == null)
                ? string.Empty
                : Convert.ToString(Page.Request.Params["q"].ToString());
            model = new ItemModel();
            itemsList = model.GetItems(filter).results;

            if (itemsList.Count > 0)
            {
                rpItems.Visible = true;
                divNoResults.Visible = false;

                rpItems.DataSource = itemsList;
                rpItems.DataBind();
            }
            else
            {
                rpItems.Visible = false;
                divNoResults.Visible = true;
            }
                    

        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            Find();

            if (!Page.IsPostBack)
            {
            }
        }

        #endregion
    }
}