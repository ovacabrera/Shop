using System;
using System.Web.UI.HtmlControls;
using Shop.Application.Interfaces;
using Shop.CrossCutting;
using Shop.DTOs;

namespace Shop.WebForms.Pages
{
    public partial class Item : System.Web.UI.Page
    {
        #region Attributes
        private readonly ILoggerService _logger;
        private readonly IItemApplication _itemApplication;
        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowItem();
            }
        }

        #endregion

        #region Methods

        public Item(ILoggerService logger, IItemApplication itemApplication)
        {
            _logger = logger;
            _itemApplication = itemApplication;
        }

        private void ShowItem()
        {
            try
            {
                _logger.Action("UserX", Request.Url.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, DateTime.Now);

                string id = (Page.Request.Params["id"]) == null ? string.Empty : Convert.ToString(Page.Request.Params["id"]);

                string responseMessage = string.Empty;
                ItemDTO itemDTO = _itemApplication.GetItem(id, ref responseMessage);
                if (itemDTO != null)
                {
                    divNoItem.Visible = false;
                    divItem.Visible = true;

                    txtSoldQuantity.InnerText = itemDTO.SoldQuantity > 0 ? itemDTO.SoldQuantity.ToString() + " Vendidos" : "";
                    txtTitulo.InnerText = itemDTO.Title;
                    txtPrecio.InnerText = "$ " + itemDTO.Price.ToString("N");

                    txtAvailableQuantity.InnerText = "(" + itemDTO.AvailableQuantity.ToString() +
                                                     (itemDTO.AvailableQuantity == 1 ? " Disponible" : " Disponibles") + ")";

                    txtQuantity.Attributes.Add("max", itemDTO.AvailableQuantity.ToString());

                    txtDescription.InnerHtml = itemDTO.ItemLargeDescription.Replace("\n", "<br />");

                    rpCharacterists.DataSource = itemDTO.Attributes;
                    rpCharacterists.DataBind();

                    rpCarouselControls.DataSource = itemDTO.PicturesUrl;
                    rpCarouselControls.DataBind();
                    rpImages.DataSource = itemDTO.PicturesUrl;
                    rpImages.DataBind();
                }
                else
                {
                    divNoItem.Visible = true;
                    HtmlGenericControl messageToShow = new HtmlGenericControl();
                    messageToShow.TagName = "h2";
                    messageToShow.InnerHtml = responseMessage;
                    divNoItem.Controls.Add(messageToShow);
                    
                    divItem.Visible = false;
                }
            }
            catch (Exception ex)
            {
                divNoItem.Visible = true;
                divItem.Visible = false;

                _logger.Error(ex);
            }
                    
                    
        }

        #endregion
    }
}