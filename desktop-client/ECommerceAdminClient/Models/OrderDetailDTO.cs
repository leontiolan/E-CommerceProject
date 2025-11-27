using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ECommerceAdminClient.Models
{
    public class OrderDetailDTO : OrderSummaryDTO
    {
        [JsonPropertyName("shippingAddress")]
        public string ShippingAddress { get; set; }

        [JsonPropertyName("orderItems")]
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}