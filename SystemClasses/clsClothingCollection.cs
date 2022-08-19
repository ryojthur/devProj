using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemClasses;

namespace SystemClasses
{ 
    public class clsClothingCollection
{
    List<clsClothing> mClothingList = new List<clsClothing>();
    clsClothing mThisItem = new clsClothing();

    public List<clsClothing> ClothingList
    { get { return mClothingList; } set { mClothingList = value; } }

    public int Count { get { return mClothingList.Count; } set { } }
    
    public clsClothing ThisItem
        {
            get { return mThisItem; }
            set { mThisItem = value; }
        }

    public int Add()
        {
            clsDataConnection Database = new clsDataConnection();
            Database.AddParameter("@ItemName", mThisItem.ItemName);
            Database.AddParameter("@ItemBrand", mThisItem.ItemBrand);
            Database.AddParameter("@ItemSize", mThisItem.ItemSize);
            Database.AddParameter("@ItemCondition", mThisItem.ItemCondition);
            Database.AddParameter("@ItemDescription", mThisItem.ItemDescription);
            Database.AddParameter("@ItemDateAdded", mThisItem.ItemDateAdded);
            Database.AddParameter("@ItemPrice", mThisItem.ItemPrice);
            return Database.Execute("tblClothing_Insert");
        }
    
    

    public void Delete()
        {
            clsDataConnection Database = new clsDataConnection();
            Database.AddParameter("@ItemNo", mThisItem.ItemNo);
            Database.Execute("tblClothing_Delete");
        }

    public clsClothingCollection()
    {
        Int32 Index = 0;
        Int32 RCount = 0;
        clsDataConnection Database = new clsDataConnection();
        Database.Execute("sproc_tblClothing_SelectAll");
        RCount = Database.Count;
        while (Index < RCount)
        {
            clsClothing AnItem = new clsClothing();
            AnItem.ItemName = Convert.ToString(Database.DataTable.Rows[Index]["ItemName"]);
            AnItem.ItemBrand = Convert.ToString(Database.DataTable.Rows[Index]["ItemBrand"]);
            AnItem.ItemSize = Convert.ToString(Database.DataTable.Rows[Index]["ItemSize"]);
            AnItem.ItemCondition = Convert.ToInt32(Database.DataTable.Rows[Index]["ItemCondition"]);
            AnItem.ItemPrice = Convert.ToInt32(Database.DataTable.Rows[Index]["ItemPrice"]);
            AnItem.ItemDescription = Convert.ToString(Database.DataTable.Rows[Index]["ItemDescription"]);
            AnItem.ItemDateAdded = Convert.ToDateTime(Database.DataTable.Rows[Index]["ItemDateAdded"]);
            mClothingList.Add(AnItem);
            Index++;
        }
    }
}
}

