using System.Text.Json.Serialization;

namespace ECommerceAdminClient.Models
{
    public class OrderSummaryDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("orderPrice")]
        public double OrderPrice { get; set; }
    }
}