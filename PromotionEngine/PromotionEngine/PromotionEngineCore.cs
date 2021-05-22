using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class PromotionEngineCore : IPromotionEngine
    {
        public decimal CalculatePrice()
        {
            IEnumerable<Promotions> Promotions = PromotionData.Promotions;
            var ProductDetails = Products.ProductDetails;
            var orders = Orders.OrderDetails.ToList();
            decimal totalPrice = 0;
            int quantity = 0;
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Quantity > 0)
                {
                    var promotions = Promotions.Where(t => t.ProductPromotions.Any(p => p.ProductName == orders[i].ProductName)).OrderBy(t => t.ProductPromotions.Count()).ToList();
                    List<RemainingProductData> data = new List<RemainingProductData>();
                    foreach (var item in promotions)
                    {
                        if (item.ProductPromotions.Count() == 1)
                        {
                            quantity = item.ProductPromotions.Sum(t => t.Quantity);
                            if (quantity <= orders[i].Quantity)
                            {
                                var remainingitems = orders[i].Quantity % quantity;
                                totalPrice = totalPrice + (item.Price * (orders[i].Quantity / quantity)) + (remainingitems * ProductDetails[orders[i].ProductName]);
                            }
                            else
                            {
                                totalPrice += orders[i].Quantity * ProductDetails[orders[i].ProductName];
                            }
                        }
                        else
                        {

                            foreach (var pPromotions in item.ProductPromotions)
                            {
                                var order = orders.FirstOrDefault(t => t.ProductName == pPromotions.ProductName);
                                if (order != null)
                                {
                                    if (order.Quantity >= pPromotions.Quantity)
                                    {
                                        data.Add(new RemainingProductData() { ProductName = pPromotions.ProductName, PromotionItems = pPromotions.Quantity, Items = (order.Quantity / pPromotions.Quantity), RemainingItems = (order.Quantity % pPromotions.Quantity) });
                                    }
                                    else
                                    {
                                        data.Add(new RemainingProductData() { ProductName = pPromotions.ProductName, PromotionItems = pPromotions.Quantity, Items = 0, RemainingItems = 0 });
                                    }
                                }
                                else
                                {
                                    data.Add(new RemainingProductData() { ProductName = pPromotions.ProductName, Items = 0, RemainingItems = 0, PromotionItems = pPromotions.Quantity, });
                                }

                            }

                        }
                        if (data.Count > 0)
                        {
                            if (data.Any(t => t.Items == 0))
                            {
                                totalPrice += (orders[i].Quantity * ProductDetails[orders[i].ProductName]);
                            }
                            else
                            {
                                var firstItem = data.OrderBy(t => t.Items).First();
                                totalPrice += (item.Price * firstItem.Items);
                                foreach (var tItem in data)
                                {
                                    totalPrice = totalPrice + (tItem.RemainingItems * ProductDetails[tItem.ProductName]) + ((tItem.Items - firstItem.Items) * tItem.PromotionItems * ProductDetails[tItem.ProductName]);
                                    var order = orders.First(t => t.ProductName == tItem.ProductName);
                                    order.Quantity = 0;
                                }
                            }
                        }
                    }
                }
            }
            return totalPrice;
        }
    }
}
