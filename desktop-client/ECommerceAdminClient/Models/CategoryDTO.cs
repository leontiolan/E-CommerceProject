using System.Text.Json.Serialization;

namespace ECommerceAdminClient.Models
{
    public class CategoryDTO
    {
        [JsonPropertyName("email")]
        public long? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}