using SpecFlow.CodingTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecFlow.CodingTask.DummyDatabase
{
    public class Dummy2Database : IDummyDatabase
    {
        public List<Product> Products { get { return _products; } }

        public List<Promotion> Promotions => promotions;

        public Dictionary<int, List<Product>> MyBasket => _myBasket;


        static private List<Product> _products = new List<Product> {
                new Product { Id = 1, Name = "Butter", Price = 0.80 },
                new Product { Id =2, Name = "Milk ", Price = 1.15},
                new Product { Id = 3, Name = "Bread ", Price = 1.00}
            };

        static private List<Promotion> promotions = new List<Promotion>
        {
            new Promotion {   Products= new List<Product>{
                                                        new Product { Id=1, Name= "Butter" },
                                                        new Product { Id = 1, Name = "Butterr" } }, /// Firts promotion
                              DiscountedProduct= new Product{ Id=3,Name="Bread"},
                              Percentage=50 },


            new Promotion {   Products= new List<Product>{
                                                        new Product { Id=2, Name= "Milk" },
                                                        new Product { Id = 2, Name = "Milk" },   /// Second promotion
                                                        new Product { Id=2, Name= "Milk" }  },
                              DiscountedProduct= new Product{ Id=2,Name="Milk"},
                              Percentage=100 },
        };

        static int i = 0;
        static Dictionary<int, List<Product>> _myBasket; 


        public void AddBasket(List<Product> products)
        {
            if (_myBasket == null)
                _myBasket = new Dictionary<int, List<Product>>();
                
            var productId = products.Select(p=>p.Id).FirstOrDefault();
            _myBasket.Add(productId, products);
        }

        public void EmptyBasket()
        {
            _myBasket = new Dictionary<int, List<Product>>();
        }
    }

    public interface IDummyDatabase
    {
        List<Product> Products
        {
            get;
        }

        List<Promotion> Promotions
        {
            get;
        }

        Dictionary<int, List<Product>> MyBasket
        {
            get;
        }

        void AddBasket(List<Product> products);

        void EmptyBasket();

    }

}
