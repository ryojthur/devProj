using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemClasses;

namespace SystemTesting
{
    [TestClass]
    public class UnitTest1
    {
        private clsClothing clsClothing;
        private clsClothing AnItem;

        [TestMethod]
        public void TestMethod1()
        {
            clsClothing = AnItem = new clsClothing();
            Assert.IsNotNull(AnItem);
        }
        [TestMethod]
        public void ItemBrandOK()
        {
            clsClothing AnItem = new clsClothing();
            String TestData = "hello";
            AnItem.ItemBrand = TestData;
            Assert.AreEqual(AnItem.ItemBrand, TestData);
        }
        [TestMethod]
        public void DeleteMethodTest()
        {
            clsClothingCollection AllItems = new clsClothingCollection();
            clsClothing TestItem = new clsClothing();
            Int32 Primary = 0;
            TestItem.ItemNo = 1;
            TestItem.ItemBrand = "aaa";
            TestItem.ItemName = "aaa";
            TestItem.ItemSize = "a";
            TestItem.ItemCondition = 1;
            TestItem.ItemPrice = 1;
            TestItem.ItemDescription = "a";
            TestItem.ItemDateAdded = DateTime.Now.Date;
            AllItems.ThisItem = TestItem;
            Primary = AllItems.Add();
            TestItem.ItemNo = Primary;
            AllItems.ThisItem.Find(Primary);
            AllItems.Delete();
            Boolean Found = AllItems.ThisItem.Find(Primary);
            Assert.IsFalse(Found);
        }
    }
}
