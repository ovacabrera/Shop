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

        private ISearchModel model;
        private SearchResult searchResult;
        private int limit = 3;

        #endregion

        #region Metods

        private void Find()
        {
            //GetParameters
            string filter = ((Page.Request.Params["q"]) == null)
                ? string.Empty
                : Convert.ToString(Page.Request.Params["q"].ToString());

            string p = ((Page.Request.Params["p"]) == null)
                ? string.Empty
                : Convert.ToString(Page.Request.Params["p"].ToString());

            int pageNumberInside = 1;
            if (p != string.Empty)
            {
                pageNumberInside = Convert.ToInt32(p);
            }

            hfCurrentPage.Value = pageNumberInside.ToString();
            //Current Method
            model = new SearchModel();
            searchResult = model.SearchItems(filter, (pageNumberInside-1)*limit, limit);

            //BindResults
            if (searchResult != null && searchResult.results.Count > 0)
            {
                rpItems.Visible = true;
                divNoResults.Visible = false;

                rpItems.DataSource = searchResult.results;
                rpItems.DataBind();

                //PagingManager
                int totalPages = Convert.ToInt32(Decimal.Ceiling(Convert.ToDecimal(searchResult.paging.total) / Convert.ToDecimal(limit)));

                hfTotalPages.Value = totalPages.ToString();
                //List<Tuple<int,bool>> pageItems = new List<Tuple<int, bool>>();

                //int startRangePage = 1; //pageNumber < pageButtonsQuantity ? 1 : pageNumber;
                //int endRangePage = totalPages; //(pageNumber + pageButtonsQuantity - 1) <= totalPages ? (pageNumber + pageButtonsQuantity - 1) : totalPages;

                //for (int i = startRangePage; i <= endRangePage; i++)
                //{
                //    pageItems.Add(new Tuple<int, bool>(i, i == pageNumber));
                //}

                //rpPager.DataSource = pageItems;
                //rpPager.DataBind();

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
            if (!Page.IsPostBack)
            {
                Find();
            }
        }

        protected void lnkPager_OnClick(object sender, EventArgs e)
        {
            //string pageNumberParameter = ((System.Web.UI.HtmlControls.HtmlAnchor) sender).Name;
            //int pageNumber = 0;
            //if (int.TryParse(pageNumberParameter, out pageNumber))
            //{
            //    Find(pageNumber);
            //}
        }

        #endregion

        protected void btnGoToPage_OnClick(object sender, EventArgs e)
        {
            //string pageNumberParameter = hfCurrentPage.Value;
            //int pageNumber = 0;
            //if (int.TryParse(pageNumberParameter, out pageNumber))
            //{
            //    Find(pageNumber);
            //}
        }
    }
}