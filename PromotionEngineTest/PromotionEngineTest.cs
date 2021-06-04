using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Models;
using PromotionEngine.RulesEngine;
using System.Collections.Generic;

namespace PromotionEngineTest
{
    [TestClass]
    public class PromotionEngineTest
    {
        private static readonly IEnumerable<SkuPrice> PriceList =
            new List<SkuPrice>
            {
                new SkuPrice {Id = 'A', UnitPrice = 50},
                new SkuPrice {Id = 'B', UnitPrice = 30},
                new SkuPrice {Id = 'C', UnitPrice = 20},
                new SkuPrice {Id = 'D', UnitPrice = 15}
            };

        private static readonly IEnumerable<Promotion> Promotions =
            new List<Promotion>
            {
                new Promotion
                {
                    Items = new List<Item>
                    {
                        new Item {Id = 'A', Quantity = 3}
                    },
                    TotalAmount = 130
                },
                new Promotion
                {
                    Items = new List<Item>
                    {
                        new Item {Id = 'B', Quantity = 2}
                    },
                    TotalAmount = 45
                },
                new Promotion
                {
                    Items = new List<Item>
                    {
                        new Item {Id = 'C', Quantity = 1},
                        new Item {Id = 'D', Quantity = 1}
                    },
                    TotalAmount = 30
                }
            };

        private static readonly Engine PromotionEngine = new Engine(PriceList, Promotions);

        [TestMethod]
        public void Test_Scenario_A()
        {
            var cart =
                new Cart
                {
                    Items = new List<Item>
                    {
                        new Item {Id = 'A', Quantity = 1},
                        new Item {Id = 'B', Quantity = 1},
                        new Item {Id = 'C', Quantity = 1}
                    }
                };

            PromotionEngine.AddToCart(cart);
            Assert.AreEqual(100, cart.TotalAmount);
        }

        [TestMethod]
        public void Test_Scenario_B()
        {
            var cart =
                new Cart
                {
                    Items = new List<Item>
                    {
                        new Item {Id = 'A', Quantity = 5},
                        new Item {Id = 'B', Quantity = 5},
                        new Item {Id = 'C', Quantity = 1}
                    }
                };

            PromotionEngine.AddToCart(cart);
            Assert.AreEqual(370, cart.TotalAmount);
        }

        [TestMethod]
        public void Test_Scenario_C()
        {
            var cart =
                new Cart
                {
                    Items = new List<Item>
                    {
                        new Item {Id = 'A', Quantity = 3},
                        new Item {Id = 'B', Quantity = 5},
                        new Item {Id = 'C', Quantity = 1},
                        new Item {Id = 'D', Quantity = 1}
                    }
                };

            PromotionEngine.AddToCart(cart);
            Assert.AreEqual(280, cart.TotalAmount);
        }
    }
}