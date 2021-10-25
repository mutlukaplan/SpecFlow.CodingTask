using SpecFlow.CodingTask.DummyDatabase;
using SpecFlow.CodingTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpecFlow.CodingTask.Services
{
    public class ProductService : IProductService
    {
        private readonly IDummyDatabase _database;

        private readonly IPromotionService _promotionService;
        public ProductService(IDummyDatabase database, IPromotionService promotionService)
        {
            _database = database;
            _promotionService = promotionService;
        }

        public double CalculateBasket()
        {
            var basket = _database.MyBasket;
            var products = _database.Products;
            double result = 0;

            foreach (var basketProducts in basket)
            {
                var productCount = basketProducts.Value.Count;

                var productId = basketProducts.Value.Select(p => p.Id).FirstOrDefault();

                var productPrice = products.Where(p => p.Id == productId).Select(k => k.Price).FirstOrDefault();

                result = result + (productPrice * productCount);
            }

            var discount = _promotionService.CalculatePromotion();

            result = result - discount;

            return result;
        }

        public List<Product> GetAllProducts()
        {
            return _database.Products;
        }
    }

    public interface IProductService
    {
        List<Product> GetAllProducts();

        double CalculateBasket();
    }
}
