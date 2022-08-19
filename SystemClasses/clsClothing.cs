using System;

namespace SystemClasses
{
    public class clsClothing
    {
        private string mItemName;
        private string mItemBrand;
        private string mItemSize;
        private int mItemCondition;
        private int mItemPrice;
        private string mItemDescription;
        private DateTime mItemDateAdded;
        private int mItemNo;


        public int ItemNo { get { return mItemNo; } set { mItemNo = value; } }
        public string ItemName { get { return mItemName; } set { mItemName = value; } }
        public string ItemBrand { get { return mItemBrand; } set { mItemBrand = value; } }
        public string ItemSize { get { return mItemSize; } set { mItemSize = value; } }
        public int ItemCondition { get { return mItemCondition; } set { mItemCondition = value; } }
        public int ItemPrice { get { return mItemPrice; } set { mItemPrice = value; } }
        public string ItemDescription { get { return mItemDescription; } set { mItemDescription = value; } }
        public DateTime ItemDateAdded { get { return mItemDateAdded; } set { mItemDateAdded = value; } }


        public bool Find(int ItemNo)
        {
            clsDataConnection Database = new clsDataConnection();
            Database.AddParameter("@ItemNo", ItemNo);
            Database.Execute("tblClothing_FilterByItemNo");

            if (Database.Count == 1)
            {
                mItemNo = Convert.ToInt32(Database.DataTable.Rows[0]["ItemNo"]);
                mItemName = Convert.ToString(Database.DataTable.Rows[0]["ItemName"]);
                mItemBrand = Convert.ToString(Database.DataTable.Rows[0]["ItemBrand"]);
                mItemSize = Convert.ToString(Database.DataTable.Rows[0]["ItemSize"]);
                mItemCondition = Convert.ToInt32(Database.DataTable.Rows[0]["ItemCondition"]);
                mItemPrice = Convert.ToInt32(Database.DataTable.Rows[0]["ItemPrice"]);
                mItemDescription = Convert.ToString(Database.DataTable.Rows[0]["ItemDescription"]);
                mItemDateAdded = Convert.ToDateTime(Database.DataTable.Rows[0]["ItemDateAdded"]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Validate(string ItemName, string ItemBrand, string ItemSize, string ItemCondition, string ItemPrice, string ItemDescription, string ItemDateAdded)
        {
            string Error = "";
            DateTime TempDate;
            if (ItemName.Length == 0 || ItemName.Length > 30)
            {
                Error = Error + "Item Name must be between 1 and 30 characters. ";
            }
            if (ItemBrand.Length == 0 || ItemBrand.Length > 30)
            {
                Error = Error + "Item Brand must be between 1 and 30 characters. ";
            }
            if (ItemSize.Length == 0 || ItemSize.Length > 10)
            {
                Error = Error + "Item Size must be between 1 and 10 characters. ";
            }
            try
            {
                int.Parse(ItemCondition);
            }
            catch (FormatException)
            {
                Error = Error + " Item Condition must be a number. ";
            }
            if (ItemCondition.Length == 0 || ItemCondition.Length > 30)
            {
                Error = Error + "Item Condition must be between a number between 1 and 10. ";
            }
            if (ItemPrice.Length == 0 || ItemPrice.Length > 10)
            {
                Error = Error + "Item Price must be a valid price between 1 and 10 characters. ";
            }
            try
            {
                decimal.Parse(ItemPrice);
            }
            catch (FormatException)
            {
                Error = Error + " Item Price must be a decimal number. ";
            }
            if (ItemDescription.Length == 0 || ItemDescription.Length > 100)
            {
                Error = Error + "Item Description must be between 1 and 100 characters. ";
            }
            try
            {
                TempDate = Convert.ToDateTime(ItemDateAdded);
                if (TempDate < DateTime.Now.Date)
                {
                    Error = Error + "Date cannot be in the past. ";
                }
                if (TempDate > DateTime.Now.Date)
                {
                    Error = Error + "Date cannot be in the future. ";
                }
            }
            catch
            {
                Error = Error + "The date is not valid. ";
            }
            return Error;
        }
    }
}