using System.Text.Json.Serialization;

namespace ECommerceAdminClient.Models
{
    public class OrderItemDTO
    {
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("purchasePrice")]
        public double PurchasePrice { get; set; }
    }
}