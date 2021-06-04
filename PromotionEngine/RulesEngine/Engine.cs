using PromotionEngine.Models;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.RulesEngine
{
    public class Engine
    {
        private readonly IEnumerable<SkuPrice> _priceList;
        private readonly IEnumerable<Promotion> _promotions;

        public Engine(IEnumerable<SkuPrice> priceList, IEnumerable<Promotion> promotions)
        {
            _priceList = priceList;
            _promotions = promotions;
        }

        public void AddToCart(Cart cart)
        {
            var itemsExist = new List<Item>();
            if (_promotions != null && _promotions.Any())
                foreach (var promotion in _promotions)
                {
                    var itemsVerified = promotion.Validate(cart, itemsExist);
                    UpdateVerifiedItems(itemsExist, itemsVerified);
                }

            CalculatePrice(cart, itemsExist);
        }

        private void CalculatePrice(Cart cart, List<Item> itemsExist)
        {
            foreach (var item in cart.Items)
            {
                var validateItem = itemsExist.FirstOrDefault(x => x.Id == item.Id) ?? item;
                var quantity = validateItem.Quantity;
                if (quantity > 0)
                    cart.TotalAmount += quantity * _priceList.First(x => x.Id == item.Id).UnitPrice;
            }
        }

        private static void UpdateVerifiedItems(ICollection<Item> itemsExist, IReadOnlyCollection<Item> itemsVerified)
        {
            if (itemsVerified == null || !itemsVerified.Any())
                return;

            foreach (var item in itemsVerified.Where(item => itemsExist.All(x => x.Id != item.Id)))
                itemsExist.Add(item);
        }
    }
}