using System.Text.Json.Serialization;

namespace ECommerceAdminClient.Models
{
    public class ProductDTO
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; } // Nullable because Create doesn't have an ID yet

        [JsonPropertyName("name")]
        public string Name { get; set; }

       [JsonPropertyName("description")]   
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("stockQuantity")]
        public int StockQuantity { get; set; }

        private long _categoryId;

        [JsonPropertyName("categoryId")]
        public long CategoryId
        {
            get
            {
                if (Category != null && Category.Id.HasValue)
                    return Category.Id.Value;
                return _categoryId;
            }
            set => _categoryId = value;
        }


        [JsonPropertyName("category")]
        public CategoryDTO Category { get; set; }
    }
}