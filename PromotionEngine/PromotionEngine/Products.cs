using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class Products
    {
        public static Dictionary<char, decimal> ProductDetails = new Dictionary<char, decimal>() {
            { 'A',50 },
            { 'B',30 },
            {'C',20 },
             {'D',15 }
        };

        public Products(Dictionary<char, decimal> productDetails)
        {
            ProductDetails = productDetails;
        }
    }
}
