using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class Cart
    {
        public List<Item> Items { get; set; }
        public double TotalAmount { get; set; }
    }
}