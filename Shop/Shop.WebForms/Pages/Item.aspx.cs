using System;
using Shop.CrossCutting;
using Shop.Models.Interfaces;

namespace Shop.WebForms.Pages
{
    public partial class Item : System.Web.UI.Page
    {
        #region Attributes
        private IItemModel _model;
        private ILoggerService _logger;
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

        public Item(IItemModel model, ILoggerService logger)
        {
            _model = model;
            _logger = logger;
        }

        private void ShowItem()
        {
            try
            {
                _logger.Action("UserX", Request.Url.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, DateTime.Now);

                string id = (Page.Request.Params["id"]) == null ? string.Empty : Convert.ToString(Page.Request.Params["id"]);

                Entities.Item item = _model.GetItem(id);
                if (item != null)
                {
                    divNoItem.Visible = false;
                    divItem.Visible = true;

                    txtSoldQuantity.InnerText = item.sold_quantity > 0 ? item.sold_quantity.ToString() + " Vendidos" : "";
                    txtTitulo.InnerText = item.title;
                    txtPrecio.InnerText = "$ " + item.price.ToString("N");

                    txtAvailableQuantity.InnerText = "(" + item.available_quantity.ToString() +
                                                     (item.available_quantity == 1 ? " Disponible" : " Disponibles") + ")";

                    txtQuantity.Attributes.Add("max", item.available_quantity.ToString());

                    Entities.LargeDescription description = _model.GetLargeDescription(id);
                    if (description != null)
                    {
                        txtDescription.InnerHtml = description.plain_text.Replace("\n", "<br />");
                    }

                    rpCharacterists.DataSource = item.attributes;
                    rpCharacterists.DataBind();

                    rpCarouselControls.DataSource = item.pictures;
                    rpCarouselControls.DataBind();
                    rpImages.DataSource = item.pictures;
                    rpImages.DataBind();
                }
                else
                {
                    divNoItem.Visible = true;
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