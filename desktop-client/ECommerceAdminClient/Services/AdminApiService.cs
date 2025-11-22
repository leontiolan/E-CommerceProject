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
        private const string BaseUrl = "http://localhost:8083/api/"; // Ensure this matches your Spring Boot port
        private static string _jwtToken;

        public AdminApiService()
        {
            _client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // If we have a token from a previous login, attach it automatically
            if (!string.IsNullOrEmpty(_jwtToken))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwtToken);
            }
        }

        // ==========================================
        // 1. AUTHENTICATION
        // ==========================================
        public async Task<bool> LoginAsync(string username, string password)
        {
            var loginData = new { username, password };
            try
            {
                var response = await _client.PostAsJsonAsync("auth/login", loginData);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<AuthResponse>();

                    // SECURITY CHECK: Only allow ADMINs to use this desktop app
                    if (result?.Role == "ADMIN")
                    {
                        _jwtToken = result.Token;
                        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwtToken);
                        return true;
                    }
                    MessageBox.Show("Access Denied: You do not have Administrator privileges.");
                }
                else
                {
                    MessageBox.Show("Login Failed. Please check your username and password.");
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection Error: {ex.Message}. Is the server running?");
                return false;
            }
        }

        // ==========================================
        // 2. PRODUCT MANAGEMENT (CRUD)
        // ==========================================

        // GET ALL (Detailed for Admin)
        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            // We use the ADMIN endpoint we created to get full details like stock & description
            return await _client.GetFromJsonAsync<List<ProductDTO>>("admin/products") ?? new List<ProductDTO>();
        }

        // CREATE
        public async Task<bool> CreateProductAsync(ProductDTO product)
        {
            var response = await _client.PostAsJsonAsync("admin/products", product);
            return response.IsSuccessStatusCode;
        }

        // UPDATE
        public async Task<bool> UpdateProductAsync(long id, ProductDTO product)
        {
            var response = await _client.PutAsJsonAsync($"admin/products/{id}", product);
            return response.IsSuccessStatusCode;
        }

        // DELETE
        public async Task<bool> DeleteProductAsync(long id)
        {
            var response = await _client.DeleteAsync($"admin/products/{id}");
            return response.IsSuccessStatusCode;
        }

        // ==========================================
        // 3. CATEGORY MANAGEMENT (CRUD)
        // ==========================================

        // GET ALL
        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            // Uses the public endpoint since admins just need the list
            return await _client.GetFromJsonAsync<List<CategoryDTO>>("categories") ?? new List<CategoryDTO>();
        }

        // CREATE
        public async Task<bool> CreateCategoryAsync(string name)
        {
            // Sending an anonymous object that matches CategoryCreateUpdateDTO
            var response = await _client.PostAsJsonAsync("admin/categories", new { name });
            return response.IsSuccessStatusCode;
        }

        // UPDATE
        public async Task<bool> UpdateCategoryAsync(long id, string name)
        {
            var response = await _client.PutAsJsonAsync($"admin/categories/{id}", new { name });
            return response.IsSuccessStatusCode;
        }

        // DELETE
        public async Task<bool> DeleteCategoryAsync(long id)
        {
            var response = await _client.DeleteAsync($"admin/categories/{id}");
            return response.IsSuccessStatusCode;
        }

        // ==========================================
        // 4. ORDER MANAGEMENT
        // ==========================================

        // GET ALL ORDERS
        public async Task<List<OrderSummaryDTO>> GetAllOrdersAsync()
        {
            return await _client.GetFromJsonAsync<List<OrderSummaryDTO>>("admin/orders") ?? new List<OrderSummaryDTO>();
        }

        // UPDATE ORDER STATUS (e.g., "SHIPPED")
        public async Task<bool> UpdateOrderStatusAsync(long id, string newStatus)
        {
            // Sending anonymous object matching OrderStatusUpdateDTO
            var response = await _client.PutAsJsonAsync($"admin/orders/{id}/status", new { status = newStatus });
            return response.IsSuccessStatusCode;
        }

        // ==========================================
        // 5. USER MANAGEMENT
        // ==========================================

        // GET ALL USERS
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            return await _client.GetFromJsonAsync<List<UserDTO>>("admin/users") ?? new List<UserDTO>();
        }

        // GET SINGLE USER DETAILS (Including their order history)
        public async Task<UserDTO> GetUserDetailsAsync(long id)
        {
            // This returns the detailed UserDTO which includes the List<OrderSummaryDTO>
            return await _client.GetFromJsonAsync<UserDTO>($"admin/users/{id}");
        }
    }
}