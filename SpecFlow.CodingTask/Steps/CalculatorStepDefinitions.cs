using FluentAssertions;
using SpecFlow.CodingTask.DummyDatabase;
using SpecFlow.CodingTask.Models;
using SpecFlow.CodingTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlow.CodingTask.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly IDummyDatabase _dummyDatabase;

        private readonly IProductService _productService;

        private readonly IPromotionService _promotionService;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _dummyDatabase = new Dummy2Database();
            _promotionService = new PromotionService(_dummyDatabase);
            _productService = new ProductService(_dummyDatabase, _promotionService);
            _scenarioContext = scenarioContext;
        }

        [Given(@"Given the basket has (.*) bread, (.*) butter and (.*) milk")]
        public void GivenGivenTheBasketHasBreadButterAndMilk(int p0, int p1, int p2)
        {
            var products = _dummyDatabase.Products;

            var butter = products.Where(p => p.Name.Contains("Butter")).FirstOrDefault();
            var bread = products.Where(p => p.Name.Contains("Bread")).FirstOrDefault();
            var milk = products.Where(p => p.Name.Contains("Milk")).FirstOrDefault();

            var buttersInBasket = new List<Product> { butter };
            var breadsInBasket = new List<Product> { bread };
            var milksInBasket = new List<Product> { milk };

            _dummyDatabase.EmptyBasket();

            _dummyDatabase.AddBasket(buttersInBasket);
            _dummyDatabase.AddBasket(breadsInBasket);
            _dummyDatabase.AddBasket(milksInBasket);
        }

        [When(@"When I total the basket")]
        public void WhenWhenITotalTheBasket()
        {
            var basketCost = Math.Round( _productService.CalculateBasket(),2);
            _scenarioContext["Result"] = basketCost;
        }

        [Then(@"the total should be £(.*)")]
        public void ThenTheTotalShouldBe(Decimal p0)
        {
            var result = (double)_scenarioContext["Result"];
            ((double)p0).Should().Be(result);
        }

        [Given(@"Given the basket has (.*) butter and (.*) bread")]
        public void GivenGivenTheBasketHasButterAndBread(int p0, int p1)
        {
            var products = _dummyDatabase.Products;

            var butter = products.Where(p => p.Name.Contains("Butter")).FirstOrDefault();
            var bread = products.Where(p => p.Name.Contains("Bread")).FirstOrDefault();

            var buttersInBasket = new List<Product> { butter, butter };
            var breadsInBasket = new List<Product> { bread, bread };

            _dummyDatabase.EmptyBasket();

            _dummyDatabase.AddBasket(buttersInBasket);
            _dummyDatabase.AddBasket(breadsInBasket);
        }


        [Given(@"Given the basket has (.*) milk")]
        public void GivenGivenTheBasketHasMilk(int p0)
        {
            var products = _dummyDatabase.Products;

            var milk = products.Where(p => p.Name.Contains("Milk")).FirstOrDefault();


            var milksInBasket = new List<Product> { milk, milk, milk, milk };

            _dummyDatabase.EmptyBasket();
            _dummyDatabase.AddBasket(milksInBasket);
        }



        [Given(@"the basket has (.*) butter, (.*) bread and (.*) milk")]
        public void GivenTheBasketHasButterBreadAndMilk(int p0, int p1, int p2)
        {
            var products = _dummyDatabase.Products;

            var butter = products.Where(p => p.Name.Contains("Butter")).FirstOrDefault();
            var bread = products.Where(p => p.Name.Contains("Bread")).FirstOrDefault();
            var milk = products.Where(p => p.Name.Contains("Milk")).FirstOrDefault();

            var buttersInBasket = new List<Product> { butter, butter };
            var breadsInBasket = new List<Product> { bread };
            var milksInBasket = new List<Product> { milk, milk, milk, milk, milk, milk, milk, milk };

            _dummyDatabase.EmptyBasket();

            _dummyDatabase.AddBasket(buttersInBasket);
            _dummyDatabase.AddBasket(breadsInBasket);
            _dummyDatabase.AddBasket(milksInBasket);
        }

    }
}
