using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace ECommerceAdminClient.Models
{
    public class UserDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("orders")]
        public List<OrderSummaryDTO> Orders { get; set; }
    }
}