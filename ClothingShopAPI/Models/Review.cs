namespace ClothingShopAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public User User { get; set; } = new User();
        public Item Item { get; set; } = new Item();
        public string Value { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
    }
}
