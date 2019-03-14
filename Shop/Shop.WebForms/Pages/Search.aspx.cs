using System;
using Shop.Application.Interfaces;
using Shop.CrossCutting;
using Shop.DTOs;

namespace Shop.WebForms.Pages
{
    public partial class Search : System.Web.UI.Page
    {
        #region Attributes

        private IItemApplication _application;
        private ILoggerService _logger;

        private int _itemsPerPage = 50;
        private string filterParamName = "q";
        private string _pageNumberParamName = "p";
        public string PageNumberParamName
        {
            get { return _pageNumberParamName; }
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

        #region Metods

        public Search(IItemApplication application, ILoggerService logger)
        {
            _application = application;
            _logger = logger;
        }

        private void Find()
        {
            try
            {
                _logger.Action("UserX", Request.Url.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name,
                    DateTime.Now);

                string filter;
                int pageNumber;
                GetParameters(out filter, out pageNumber);

                //Set hidden field to help Paginator Item on Aspx page.
                hfCurrentPage.Value = pageNumber.ToString();                

                SearchResultDTO searchResult = _application.SearchItems(filter, (pageNumber - 1) * _itemsPerPage, _itemsPerPage);

                BindResults(searchResult);
            }
            catch (Exception ex)
            {
                rpItems.Visible = false;
                divNoResults.Visible = true;
                _logger.Error(ex);
            }
        }

        private void GetParameters(out string filter, out int pageNumberInside)
        {
            filter = ((Page.Request.Params[filterParamName]) == null)
                ? string.Empty
                : Convert.ToString(Page.Request.Params[filterParamName]);

            string pageNumber = ((Page.Request.Params[PageNumberParamName]) == null)
                ? string.Empty
                : Convert.ToString(Page.Request.Params[PageNumberParamName]);

            pageNumberInside = 1;
            if (pageNumber != string.Empty)
            {
                pageNumberInside = Convert.ToInt32(pageNumber);
            }
        }

        private void BindResults(SearchResultDTO searchResult)
        {
            if (searchResult != null && searchResult.results.Count > 0)
            {
                rpItems.Visible = true;
                divNoResults.Visible = false;

                rpItems.DataSource = searchResult.results;
                rpItems.DataBind();

                //PagingManager
                int totalPages =
                    Convert.ToInt32(Decimal.Ceiling(Convert.ToDecimal(searchResult.totalItemCount) /
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

    }
}