using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class OrderTest
    {
        public static IEnumerable<ProductDetails> OrderDetails { get; set; }= new List<ProductDetails>() { new ProductDetails() { ProductName = 'A', Quantity = 1 }, new ProductDetails() { ProductName = 'B', Quantity = 2 },
            new ProductDetails() { ProductName = 'C', Quantity = 3 },new ProductDetails() { ProductName = 'D', Quantity = 4 }};
        [TestMethod]
        public void ChangeRatesforProducts()
        {
            Orders.OrderDetails = OrderDetails;
            Assert.AreEqual(1, Orders.OrderDetails.First(t=>t.ProductName=='A').Quantity);
            Assert.AreEqual(2, Orders.OrderDetails.First(t => t.ProductName == 'B').Quantity);
            Assert.AreEqual(3, Orders.OrderDetails.First(t => t.ProductName == 'C').Quantity);
            Assert.AreEqual(4, Orders.OrderDetails.First(t => t.ProductName == 'D').Quantity);
        }
    }
}
