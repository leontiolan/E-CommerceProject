using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using ECommerceAdminClient.Models;

namespace ECommerceAdminClient.Services
{
    public class AdminApiService
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "http://localhost:8083/api/"; // Your Java Port
        private static string _jwtToken;

        public AdminApiService()
        {
            _client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // If we already have a token (from a previous login), attach it
            if (!string.IsNullOrEmpty(_jwtToken))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwtToken);
            }
        }

        // --- AUTH ---
        public async Task<bool> LoginAsync(string username, string password)
        {
            var loginData = new { username, password };
            try
            {
                var response = await _client.PostAsJsonAsync("auth/login", loginData);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
                    if (result.role == "ADMIN") // Enforce Admin Check
                    {
                        _jwtToken = result.token;
                        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwtToken);
                        return true;
                    }
                    MessageBox.Show("Access Denied: User is not an Admin.");
                }
                return false;
            }
            catch (Exception ex) { MessageBox.Show("Server Error: " + ex.Message); return false; }
        }

        // --- PRODUCT OPERATIONS ---
        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            // Admins can use the public endpoint to search/view
            return await _client.GetFromJsonAsync<List<ProductDTO>>("products") ?? new List<ProductDTO>();
        }

        public async Task<bool> CreateProductAsync(ProductDTO product)
        {
            var response = await _client.PostAsJsonAsync("admin/products", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(long id)
        {
            var response = await _client.DeleteAsync($"admin/products/{id}");
            return response.IsSuccessStatusCode;
        }

        // --- CATEGORY OPERATIONS ---
        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            return await _client.GetFromJsonAsync<List<CategoryDTO>>("categories") ?? new List<CategoryDTO>();
        }

        public async Task<bool> CreateCategoryAsync(string name)
        {
            var response = await _client.PostAsJsonAsync("admin/categories", new { name });
            return response.IsSuccessStatusCode;
        }

        // --- USER & ORDER OPERATIONS ---
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            return await _client.GetFromJsonAsync<List<UserDTO>>("admin/users") ?? new List<UserDTO>();
        }

        public async Task<UserDTO> GetUserDetailsAsync(long id)
        {
            return await _client.GetFromJsonAsync<UserDTO>($"admin/users/{id}");
        }
    }
}