using System.Collections.Generic;

namespace PromotionEngine
{
    public class Orders
    {
        public static IEnumerable<ProductDetails> OrderDetails { get; set; }
        public int MyProperty { get; set; }
        static Orders()
        {
            OrderDetails = new List<ProductDetails>() { new ProductDetails() { ProductName = 'A', Quantity = 5 }, new ProductDetails() { ProductName = 'B', Quantity = 2 },
            new ProductDetails() { ProductName = 'C', Quantity = 5 },new ProductDetails() { ProductName = 'D', Quantity = 8 }};
        }

    }
}
