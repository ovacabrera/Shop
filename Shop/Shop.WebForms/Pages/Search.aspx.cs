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

        private ISearchModel _model;
        private int _itemsPerPage = 50;
        private string filterParamName = "q";
        private string _pageNumberParamName = "p";
        public string PageNumberParamName
        {
            get { return _pageNumberParamName; }
        }

        #endregion

        #region Metods

        private void Find()
        {
            string filter;
            int pageNumber;
            GetParameters(out filter, out pageNumber);

            //Set hidden field to help Paginator Item on Aspx page.
            hfCurrentPage.Value = pageNumber.ToString();

            _model = new SearchModel();
            SearchResult searchResult = _model.SearchItems(filter, (pageNumber - 1)*_itemsPerPage, _itemsPerPage);

            BindResults(searchResult);
        }

        private void GetParameters(out string filter, out int pageNumberInside)
        {
            filter = ((Page.Request.Params[filterParamName]) == null)
                ? string.Empty
                : Convert.ToString(Page.Request.Params[filterParamName].ToString());

            string pageNumber = ((Page.Request.Params[PageNumberParamName]) == null)
                ? string.Empty
                : Convert.ToString(Page.Request.Params[PageNumberParamName].ToString());

            pageNumberInside = 1;
            if (pageNumber != string.Empty)
            {
                pageNumberInside = Convert.ToInt32(pageNumber);
            }
        }

        private void BindResults(SearchResult searchResult)
        {
            if (searchResult != null && searchResult.results.Count > 0)
            {
                rpItems.Visible = true;
                divNoResults.Visible = false;

                rpItems.DataSource = searchResult.results;
                rpItems.DataBind();

                //PagingManager
                int totalPages =
                    Convert.ToInt32(Decimal.Ceiling(Convert.ToDecimal(searchResult.paging.total) /
                                                    Convert.ToDecimal(_itemsPerPage)));
                //Set hidden field to help Paginator Item on Aspx page.
                hfTotalPages.Value = totalPages.ToString();
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

        #endregion
    }
}