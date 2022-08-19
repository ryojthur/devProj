using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemClasses;

public partial class AnItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsClothing AnItem = new clsClothing();
        AnItem = (clsClothing)Session["AnItem"];
        lblError.Text = "";
        
    }

    protected void BtnConfirm_Click(object sender, EventArgs e)
    {
        clsClothing AnItem = new clsClothing();
        string ItemName = txtItemName.Text;
        string ItemBrand = txtItemBrand.Text;
        string ItemCondition = txtItemCondition.Text;
        string ItemSize = txtItemSize.Text;
        string ItemPrice = txtItemPrice.Text;
        string ItemDescription = txtItemDescription.Text;
        string ItemDateAdded = txtItemDateAdded.Text;
        string Error = "";

        Error = AnItem.Validate(ItemName, ItemBrand, ItemSize, ItemCondition, ItemPrice, ItemDescription, ItemDateAdded);

        if (Error == "")
        {
            AnItem.ItemName = ItemName;
            AnItem.ItemBrand = ItemBrand;
            AnItem.ItemCondition = Int32.Parse(ItemCondition);
            AnItem.ItemSize = (ItemSize);
            AnItem.ItemPrice = Int32.Parse(ItemPrice);
            AnItem.ItemDescription = ItemDescription;
            AnItem.ItemDateAdded = Convert.ToDateTime(ItemDateAdded);

            clsClothingCollection ClothingList = new clsClothingCollection();
            ClothingList.ThisItem = AnItem;
            ClothingList.Add();
            Response.Redirect("ClothingList.aspx");
        }
        else
        {
            lblError.Text = Error;
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClothingList.aspx");
    }

    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {

    }
}