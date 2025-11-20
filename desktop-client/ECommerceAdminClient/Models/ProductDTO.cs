namespace ECommerceAdminClient.Models
{
    public class ProductDTO
    {
        public long? id { get; set; } // Nullable because Create doesn't have an ID yet
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int stockQuantity { get; set; }
        public long categoryId { get; set; }
        public CategoryDTO category { get; set; }
    }
}