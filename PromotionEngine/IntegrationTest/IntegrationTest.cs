using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationTest
{
    [TestClass]
    public class IntegrationTest
    {
        private IPromotionEngine promotionEngine;
        [TestInitialize]
        public void TestInitialize()
        {
            promotionEngine = new PromotionEngineCore();
        }
        [TestMethod]
        public void CalculatePrice()
        {

            var orders = new List<ProductDetails>() { new ProductDetails() { ProductName = 'A', Quantity = 5 }, new ProductDetails() { ProductName = 'B', Quantity = 2 },
            new ProductDetails() { ProductName = 'C', Quantity = 5 },new ProductDetails() { ProductName = 'D', Quantity = 8 }};
            var finalPrice = promotionEngine.CalculatePrice(orders, Products.ProductDetails, PromotionData.Promotions);
            Assert.AreEqual(finalPrice, 470);

        }

        [TestMethod]
        [Description("Test case given in the PDF -1")]
        public void CalculatePriceTestCase1()
        {

            var orders = new List<ProductDetails>() { new ProductDetails() { ProductName = 'A', Quantity = 1 }, new ProductDetails() { ProductName = 'B', Quantity = 1 },
            new ProductDetails() { ProductName = 'C', Quantity = 1 },new ProductDetails() { ProductName = 'D', Quantity = 0 }};
            var finalPrice = promotionEngine.CalculatePrice(orders, Products.ProductDetails, PromotionData.Promotions);
            Assert.AreEqual(finalPrice, 100);

        }



        [TestMethod]
        [Description("Test case given in the PDF -2")]
        public void CalculatePriceTestCase2()
        {

            var orders = new List<ProductDetails>() { new ProductDetails() { ProductName = 'A', Quantity = 5 }, new ProductDetails() { ProductName = 'B', Quantity = 5 },
            new ProductDetails() { ProductName = 'C', Quantity = 1 },new ProductDetails() { ProductName = 'D', Quantity = 0 }};
            var finalPrice = promotionEngine.CalculatePrice(orders, Products.ProductDetails, PromotionData.Promotions);
            Assert.AreEqual(finalPrice, 370);

        }

        [TestMethod]
        [Description("Test case given in the PDF -3")]
        public void CalculatePriceTestCase3()
        {

            var orders = new List<ProductDetails>() { new ProductDetails() { ProductName = 'A', Quantity = 3 }, new ProductDetails() { ProductName = 'B', Quantity = 5 },
            new ProductDetails() { ProductName = 'C', Quantity = 1 },new ProductDetails() { ProductName = 'D', Quantity = 1 }};
            var finalPrice = promotionEngine.CalculatePrice(orders, Products.ProductDetails, PromotionData.Promotions);
            Assert.AreEqual(finalPrice, 280);

        }



        [TestMethod]
        [Description("Overiding the order quantity")]
        public void CalculatePriceOverridingOrderDetails()
        {

            var orders = new List<ProductDetails>() { new ProductDetails() { ProductName = 'A', Quantity = 2 }, new ProductDetails() { ProductName = 'B', Quantity = 3 },
            new ProductDetails() { ProductName = 'C', Quantity = 1 },new ProductDetails() { ProductName = 'D', Quantity = 1 }};
            var finalPrice = promotionEngine.CalculatePrice(orders, Products.ProductDetails, PromotionData.Promotions);
            Assert.AreEqual(finalPrice, 205);

        }
        [TestMethod]
        [Description("Overiding the order quantity")]
        public void CalculatePriceOverridingProductDetails()
        {
            var promotions = new List<Promotions>() { new Promotions() { ProductPromotions = new List<ProductDetails>() {
        new ProductDetails(){ ProductName='A', Quantity =3 } }, Price =100 },
                    new Promotions() { ProductPromotions = new List<ProductDetails>() {
        new ProductDetails(){ ProductName='B', Quantity =2 } }, Price =30 },
        new Promotions() { ProductPromotions = new List<ProductDetails>() {
        new ProductDetails(){ ProductName='C', Quantity =1 } ,new ProductDetails(){ ProductName='D', Quantity =1 }} ,
        Price = 20}};
            var finalPrice = promotionEngine.CalculatePrice(Orders.OrderDetails.ToList(), Products.ProductDetails, promotions);
            Assert.AreEqual(finalPrice, 375);

        }
    }
}
