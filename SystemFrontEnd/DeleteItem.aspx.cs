using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemClasses;

public partial class DeleteItem : System.Web.UI.Page
{
    Int32 ItemNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        ItemNo = Convert.ToInt32(Session["ItemNo"]);
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClothingList.aspx");
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        clsClothingCollection Clothing = new clsClothingCollection();
        Clothing.ThisItem.Find(ItemNo);
        Clothing.Delete();
        Response.Redirect("ClothingList.aspx");
    }
}