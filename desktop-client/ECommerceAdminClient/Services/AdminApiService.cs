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
        private const string BaseUrl = "http://localhost:8083/api/";
        private static string _jwtToken;

        public AdminApiService()
        {
            _client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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
                    // You could parse the error message here if the backend sends one
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

        public async Task<bool> RegisterAdminAsync(string username, string email, string password)
        {
            var registerData = new { username, email, password };
            try
            {
                // Calling the NEW endpoint we created in the Java backend
                var response = await _client.PostAsJsonAsync("auth/register-admin", registerData);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // If status is 400 or 500 (e.g. Duplicate Username)
                    // Ideally, parse the JSON error response from Spring Boot
                    string errorBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Registration Failed: {errorBody}", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server Error: " + ex.Message);
                return false;
            }
        }

        // ... (The rest of your CRUD methods: GetAllProductsAsync, CreateProductAsync, etc. stay the same) ...

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            return await _client.GetFromJsonAsync<List<ProductDTO>>("admin/products") ?? new List<ProductDTO>();
        }

        public async Task<bool> CreateProductAsync(ProductDTO product)
        {
            var response = await _client.PostAsJsonAsync("admin/products", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProductAsync(long id, ProductDTO product)
        {
            var response = await _client.PutAsJsonAsync($"admin/products/{id}", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(long id)
        {
            var response = await _client.DeleteAsync($"admin/products/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            return await _client.GetFromJsonAsync<List<CategoryDTO>>("categories") ?? new List<CategoryDTO>();
        }

        public async Task<bool> CreateCategoryAsync(string name)
        {
            var response = await _client.PostAsJsonAsync("admin/categories", new { name });
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCategoryAsync(long id, string name)
        {
            var response = await _client.PutAsJsonAsync($"admin/categories/{id}", new { name });
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategoryAsync(long id)
        {
            var response = await _client.DeleteAsync($"admin/categories/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            return await _client.GetFromJsonAsync<List<UserDTO>>("admin/users") ?? new List<UserDTO>();
        }

        public async Task<UserDTO> GetUserDetailsAsync(long id)
        {
            return await _client.GetFromJsonAsync<UserDTO>($"admin/users/{id}");
        }

        public async Task<List<OrderSummaryDTO>> GetAllOrdersAsync()
        {
            return await _client.GetFromJsonAsync<List<OrderSummaryDTO>>("admin/orders") ?? new List<OrderSummaryDTO>();
        }

        public async Task<bool> UpdateOrderStatusAsync(long id, string newStatus)
        {
            var response = await _client.PutAsJsonAsync($"admin/orders/{id}/status", new { status = newStatus });
            return response.IsSuccessStatusCode;
        }
    }
}