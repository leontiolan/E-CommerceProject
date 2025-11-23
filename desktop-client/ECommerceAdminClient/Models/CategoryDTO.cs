using System.Text.Json.Serialization;

namespace ECommerceAdminClient.Models
{
    public class CategoryDTO
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}