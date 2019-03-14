using System;
using Shop.Application.Interfaces;
using Shop.CrossCutting;
using Shop.DTOs;
using Shop.Models.Interfaces;

namespace Shop.WebForms.Pages
{
    public partial class Item : System.Web.UI.Page
    {
        #region Attributes
        //private IItemDomain _model;
        private ILoggerService _logger;
        public IItemApplication ItemApplication
        {
            get
            {                
                return (IItemApplication)Application["IItemApplication"]; 
            }
        }

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

        public Item(ILoggerService logger)
        {
            //_model = model;
            _logger = logger;
        }

        private void ShowItem()
        {
            try
            {
                _logger.Action("UserX", Request.Url.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, DateTime.Now);

                string id = (Page.Request.Params["id"]) == null ? string.Empty : Convert.ToString(Page.Request.Params["id"]);

                //Entities.ItemEntity item = _model.GetItem(id);
                ItemDTO itemDTO = ItemApplication.GetItem(id);
                if (itemDTO != null)
                {
                    divNoItem.Visible = false;
                    divItem.Visible = true;

                    txtSoldQuantity.InnerText = itemDTO.sold_quantity > 0 ? itemDTO.sold_quantity.ToString() + " Vendidos" : "";
                    txtTitulo.InnerText = itemDTO.title;
                    txtPrecio.InnerText = "$ " + itemDTO.price.ToString("N");

                    txtAvailableQuantity.InnerText = "(" + itemDTO.available_quantity.ToString() +
                                                     (itemDTO.available_quantity == 1 ? " Disponible" : " Disponibles") + ")";

                    txtQuantity.Attributes.Add("max", itemDTO.available_quantity.ToString());

                    txtDescription.InnerHtml = itemDTO.itemLargeDescription.Replace("\n", "<br />");

                    rpCharacterists.DataSource = itemDTO.attributes;
                    rpCharacterists.DataBind();

                    rpCarouselControls.DataSource = itemDTO.picturesUrl;
                    rpCarouselControls.DataBind();
                    rpImages.DataSource = itemDTO.picturesUrl;
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