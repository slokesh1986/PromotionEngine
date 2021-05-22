using System.Collections.Generic;

namespace PromotionEngine
{
    public interface IPromotionEngine
    {
        decimal CalculatePrice(List<ProductDetails> orders, Dictionary<char, decimal> ProductDetails, IEnumerable<Promotions> Promotions);
    }
}
