using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class ProductsTestCase
    {
        public static Dictionary<char, decimal> ProductDetails = new Dictionary<char, decimal>() {
            { 'A',100 },
            { 'B',80 },
            {'C',15 },
             {'D',25 } };
        [TestMethod]
        public void ChangeRatesforProducts()
        {         
          new Products(ProductDetails);
            Assert.AreEqual(100, Products.ProductDetails['A']);
            Assert.AreEqual(80, Products.ProductDetails['B']);
            Assert.AreEqual(15, Products.ProductDetails['C']);
            Assert.AreEqual(25, Products.ProductDetails['D']);
        }

    }
}

