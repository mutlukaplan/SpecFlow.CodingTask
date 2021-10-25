using SpecFlow.CodingTask.DummyDatabase;
using SpecFlow.CodingTask.Models;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace SpecFlow.CodingTask.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IDummyDatabase _database;

        public PromotionService(IDummyDatabase database)
        {
            _database = database;
        }

        public double CalculatePromotion()
        {
            var promotions = _database.Promotions;

            var products = _database.Products;

            var basket = _database.MyBasket;

            double discountAmount = 0;

            foreach (var item in basket)
            {
                var product = item.Value.FirstOrDefault();

                var productCount = item.Value.Count;

                var promotionProductGroup = promotions.GroupBy(p => p.Products).Select(group => new { Product = group.Key, Count = group.Key.Count(), ProductId= group.Key.FirstOrDefault().Id }).ToList();
                var promotionProduct = promotions.Where(p => p.Products.Select(p => p.Id).Contains(product.Id));
                var promotionProductCount = promotionProductGroup.Where(g=>g.ProductId==product.Id).Select(p=>p.Count).FirstOrDefault();

                if (promotionProductCount == 0) continue;

                double dividedCount = productCount / promotionProductCount;

                if (dividedCount >= 1)
                {
                    for (int i = 0; i < dividedCount; i++)
                    {
                        var discountedProduct = promotionProduct.Select(p => p.DiscountedProduct).FirstOrDefault();

                        var percentage = promotionProduct.Select(p => p.Percentage).FirstOrDefault();

                        var discountetProductAmountInBasket = basket.Where(p => p.Value.Select(h => h.Id).Contains(discountedProduct.Id)).Count();

                        if (discountetProductAmountInBasket > 0)
                        {
                            var productPrice = products.Where(p => p.Id == discountedProduct.Id).Select(k => k.Price).FirstOrDefault();

                            if (discountetProductAmountInBasket <= dividedCount)
                            {
                                discountAmount = discountAmount + discountetProductAmountInBasket * productPrice * (percentage / 100);
                            }
                            else
                            {
                                discountAmount = discountAmount + dividedCount * productPrice * (percentage / 100);
                            }
                        }
                    }

                }
            }
            return discountAmount;
        }

        public List<Promotion> GetPromotions()
        {
            return _database.Promotions;
        }
    }

    public interface IPromotionService
    {
        double CalculatePromotion();
        List<Promotion> GetPromotions();
    }
}
