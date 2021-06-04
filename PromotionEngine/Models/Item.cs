namespace PromotionEngine.Models
{
    public class Item
    {
        public Item(Item item)
        {
            Id = item.Id;
            Quantity = item.Quantity;
        }

        public Item()
        {
        }

        public char Id { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Id} {Quantity}";
        }
    }
}