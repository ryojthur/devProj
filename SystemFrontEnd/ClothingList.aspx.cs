using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClothingList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            DisplayClothing();
        }
    }

    void DisplayClothing()
    {
        SystemClasses.clsClothingCollection Clothing = new SystemClasses.clsClothingCollection();
        lstClothingList.DataSource = Clothing.ClothingList;
        lstClothingList.DataValueField = "ItemNo";
        lstClothingList.DataTextField = "ItemName";
        lstClothingList.DataBind();
    }


    protected void lstClothingList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void AddItem_Click(object sender, EventArgs e)
    {
        Session["ItemNo"] = -1;
        Response.Redirect("AnItem.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Int32 ItemNo;
        if(lstClothingList.SelectedIndex != -1)
        {
            ItemNo = Convert.ToInt32(lstClothingList.SelectedValue);
            Session["ItemNo"] = ItemNo;
            Response.Redirect("DeleteItem.aspx");
        }
        else
        {
            lblError.Text = "Select a record to delete from the list above.";
        }
    }
}