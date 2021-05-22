using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using System.Collections.Generic;

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

            Orders.OrderDetails = new List<ProductDetails>() { new ProductDetails() { ProductName = 'A', Quantity = 5 }, new ProductDetails() { ProductName = 'B', Quantity = 2 },
            new ProductDetails() { ProductName = 'C', Quantity = 5 },new ProductDetails() { ProductName = 'D', Quantity = 8 }};
            var finalPrice = promotionEngine.CalculatePrice();
            Assert.AreEqual(finalPrice, 470);

        }
        [TestMethod]
        [Description("Overiding the order quantity")]
        public void CalculatePriceOverridingOrderDetails()
        {

            Orders.OrderDetails = new List<ProductDetails>() { new ProductDetails() { ProductName = 'A', Quantity = 2 }, new ProductDetails() { ProductName = 'B', Quantity = 3 },
            new ProductDetails() { ProductName = 'C', Quantity = 1 },new ProductDetails() { ProductName = 'D', Quantity = 1 }};
            var finalPrice = promotionEngine.CalculatePrice();
            Assert.AreEqual(finalPrice, 205);

        }
        [TestMethod]
        [Description("Overiding the order quantity")]
        public void CalculatePriceOverridingProductDetails()
        {
            PromotionData.Promotions = new List<Promotions>() { new Promotions() { ProductPromotions = new List<ProductDetails>() {
        new ProductDetails(){ ProductName='A', Quantity =3 } }, Price =100 },
                    new Promotions() { ProductPromotions = new List<ProductDetails>() {
        new ProductDetails(){ ProductName='B', Quantity =2 } }, Price =30 },
        new Promotions() { ProductPromotions = new List<ProductDetails>() {
        new ProductDetails(){ ProductName='C', Quantity =1 } ,new ProductDetails(){ ProductName='D', Quantity =1 }} ,
        Price = 20}};
            var finalPrice = promotionEngine.CalculatePrice();
            Assert.AreEqual(finalPrice, 375);

        }
    }
}
