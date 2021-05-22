using System.Collections.Generic;

namespace PromotionEngine
{
    public class PromotionData
    {
        public static IEnumerable<Promotions> Promotions = new List<Promotions>() { new Promotions() { ProductPromotions = new List<ProductDetails>() {
        new ProductDetails(){ ProductName='A', Quantity =3 } }, Price =130 },
                    new Promotions() { ProductPromotions = new List<ProductDetails>() {
        new ProductDetails(){ ProductName='B', Quantity =2 } }, Price =45 },
        new Promotions() { ProductPromotions = new List<ProductDetails>() {
        new ProductDetails(){ ProductName='C', Quantity =1 } ,new ProductDetails(){ ProductName='D', Quantity =1 }} ,
        Price = 30}};

    }
}
