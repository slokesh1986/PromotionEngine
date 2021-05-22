using System.Collections.Generic;

namespace PromotionEngine
{
    public class Promotions
    {
        public IEnumerable<ProductDetails> ProductPromotions { get; set; }
        public decimal Price { get; set; }
    }
}
