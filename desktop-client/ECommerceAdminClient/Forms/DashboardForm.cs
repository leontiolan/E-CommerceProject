using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ECommerceAdminClient.Models;
using ECommerceAdminClient.Services;
using MaterialSkin.Controls;

namespace ECommerceAdminClient.Forms
{
    public partial class DashboardForm : MaterialForm
    {
        private readonly AdminApiService _apiService;

        public DashboardForm()
        {
            InitializeComponent();
            _apiService = new AdminApiService();

            // Basic Grid Setup (Select full row, not just one cell)
            SetupGrid(gridProducts);
            SetupGrid(gridCategories);
            SetupGrid(gridUsers);
        }

        private void SetupGrid(DataGridView grid)
        {
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ReadOnly = true;
        }

        // --- LOAD DATA ---
        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            await LoadAllData();
        }

        private async Task LoadAllData()
        {
            // Load Products
            var products = await _apiService.GetAllProductsAsync();
            gridProducts.DataSource = products;
            if (gridProducts.Columns["Category"] != null) gridProducts.Columns["Category"].Visible = false; // Hide complex object

            // Load Categories
            var categories = await _apiService.GetCategoriesAsync();
            gridCategories.DataSource = categories;

            // Load Users
            var users = await _apiService.GetAllUsersAsync();
            gridUsers.DataSource = users;
            if (gridUsers.Columns["Orders"] != null) gridUsers.Columns["Orders"].Visible = false; // Hide list
        }

        // --- PRODUCT EVENTS ---
        private async void btnAddProd_Click(object sender, EventArgs e)
        {
            // Pass 'null' to indicate Create Mode
            using (var form = new ProductEditorForm(null))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await _apiService.CreateProductAsync(form.ProductResult);
                    await LoadAllData();
                }
            }
        }

        private async void btnDeleteProd_Click(object sender, EventArgs e)
        {
            if (gridProducts.SelectedRows.Count > 0)
            {
                var product = (ProductDTO)gridProducts.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"Delete {product.Name}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await _apiService.DeleteProductAsync(product.Id.Value);
                    await LoadAllData();
                }
            }
        }

        // --- CATEGORY EVENTS ---
        private async void btnAddCat_Click(object sender, EventArgs e)
        {
            // Reuse a generic simple input form or make a CategoryEditorForm
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter Category Name:", "New Category");
            if (!string.IsNullOrWhiteSpace(name))
            {
                await _apiService.CreateCategoryAsync(name);
                await LoadAllData();
            }
        }

        // --- USER EVENTS ---
        private async void btnViewUser_Click(object sender, EventArgs e)
        {
            if (gridUsers.SelectedRows.Count > 0)
            {
                var user = (UserDTO)gridUsers.SelectedRows[0].DataBoundItem;
                // Fetch full details (including orders)
                var userDetails = await _apiService.GetUserDetailsAsync(user.Id);

                // Open Detail View
                using (var form = new UserDetailsForm(userDetails))
                {
                    form.ShowDialog();
                }
            }
        }
    }
}