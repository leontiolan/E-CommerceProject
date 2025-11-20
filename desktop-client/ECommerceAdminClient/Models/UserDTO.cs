using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace ECommerceAdminClient.Models
{
    public class UserDTO
    {
        public long id { get; set; }
        public string username { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }
        public string role { get; set; }
        public List<OrderSummaryDTO> orders { get; set; }
    }
}