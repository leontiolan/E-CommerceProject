using System.Text.Json.Serialization;

namespace ECommerceAdminClient.Models
{
    public class AuthResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}