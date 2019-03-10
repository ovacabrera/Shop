using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.CrossCutting;
using Shop.Models;
using Shop.Models.Interfaces;

namespace Shop.WebForms.Pages
{
    public partial class Item : System.Web.UI.Page
    {
        #region Attributes
        private IItemModel model;
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

        private void ShowItem()
        {
            string id = ((Page.Request.Params["id"]) == null)
                ? string.Empty
                : Convert.ToString(Page.Request.Params["id"]);
            model = IoC.GetObjectModel<IItemModel>();
            Entities.Item item = model.GetItem(id);
            if (item != null)
            {
                divNoItem.Visible = false;
                divItem.Visible = true;

                txtSoldQuantity.InnerText = item.sold_quantity > 0 ? item.sold_quantity.ToString() + " Vendidos" : "";
                txtTitulo.InnerText = item.title;
                txtPrecio.InnerText = "$ "+item.price.ToString("N");

                txtAvailableQuantity.InnerText = "(" + item.available_quantity.ToString() +
                                                 (item.available_quantity == 1 ? " Disponible" : " Disponibles") + ")";

                txtQuantity.Attributes.Add("max", item.available_quantity.ToString());

                Entities.LargeDescription description = model.GetLargeDescription(id);
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

        #endregion
    }
}