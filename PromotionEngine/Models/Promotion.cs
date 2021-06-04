using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Models
{
    public class Promotion : Cart
    {
        public List<Item> Validate(Cart cart, List<Item> itemsVerified)
        {
            var itemsAdded = new List<Item>();
            if (Items == null || Items.Count < 1)
                return itemsAdded;

            foreach (var promotionItem in Items)
            {
                var foundItem = itemsVerified.FirstOrDefault(x => x.Id == promotionItem.Id) ??
                  cart.Items.FirstOrDefault(x => x.Id == promotionItem.Id);
                if (foundItem == null || foundItem.Quantity < promotionItem.Quantity)
                    return null;

                if (itemsAdded.All(x => x.Id != foundItem.Id))
                    itemsAdded.Add(new Item(foundItem));
            }

            CalculatePriceAndQuantityByPromotion(cart, itemsAdded);

            return itemsAdded;
        }

        private void CalculatePriceAndQuantityByPromotion(Cart cart, List<Item> itemsAdded)
        {
            var hasItems = itemsAdded.Any();
            if (hasItems)
            {
                do
                {
                    cart.TotalAmount += TotalAmount;
                    foreach (var promotionItem in Items)
                    {
                        var item = itemsAdded.FirstOrDefault(x => x.Id == promotionItem.Id);
                        if (item != null)
                        {
                            item.Quantity -= promotionItem.Quantity;
                            if (hasItems)
                                hasItems = item.Quantity >= promotionItem.Quantity;
                        }
                    }
                } while (hasItems);
            }
        }
    }
}