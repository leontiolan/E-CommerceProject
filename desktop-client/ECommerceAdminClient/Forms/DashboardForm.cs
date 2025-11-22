using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ECommerceAdminClient.Models;
using ECommerceAdminClient.Services;
using MaterialSkin.Controls;
using MaterialSkin;

namespace ECommerceAdminClient.Forms
{
    public partial class DashboardForm : MaterialForm
    {
        private readonly AdminApiService _apiService;

        public DashboardForm()
        {
            InitializeComponent();

            // --- MATERIAL SKIN SETUP ---
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            // Initialize the API Service
            _apiService = new AdminApiService();

            // Configure Grids for better UX
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
            grid.BackgroundColor = System.Drawing.Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.RowHeadersVisible = false; // Cleaner look
        }

        // --- LOAD DATA (Form Load) ---
        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            await LoadAllData();
        }

        // Helper method to refresh all grids
        private async Task LoadAllData()
        {
            try
            {
                // 1. Load Products
                var products = await _apiService.GetAllProductsAsync();
                gridProducts.DataSource = products;
                // Hide nested object columns if they exist to prevent clutter
                if (gridProducts.Columns["Category"] != null)
                    gridProducts.Columns["Category"].Visible = false;

                // 2. Load Categories
                var categories = await _apiService.GetCategoriesAsync();
                gridCategories.DataSource = categories;

                // 3. Load Users
                var users = await _apiService.GetAllUsersAsync();
                gridUsers.DataSource = users;
                if (gridUsers.Columns["Orders"] != null)
                    gridUsers.Columns["Orders"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        // PRODUCT ACTIONS
        // =========================

        // 1. REFRESH PRODUCTS (The logic you were missing)
        private async void btnRefreshProd_Click(object sender, EventArgs e)
        {
            await LoadAllData();
        }

        // 2. ADD PRODUCT
        private async void btnAddProd_Click(object sender, EventArgs e)
        {
            using (var form = new ProductEditorForm(null))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool success = await _apiService.CreateProductAsync(form.ProductResult);
                    if (success)
                    {
                        MessageBox.Show("Product Created Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadAllData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 3. EDIT PRODUCT
        private async void btnEditProd_Click(object sender, EventArgs e)
        {
            if (gridProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selected = (ProductDTO)gridProducts.SelectedRows[0].DataBoundItem;

            using (var form = new ProductEditorForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool success = await _apiService.UpdateProductAsync(selected.Id.Value, form.ProductResult);
                    if (success)
                    {
                        await LoadAllData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 4. DELETE PRODUCT
        private async void btnDeleteProd_Click(object sender, EventArgs e)
        {
            if (gridProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selected = (ProductDTO)gridProducts.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Are you sure you want to delete '{selected.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool success = await _apiService.DeleteProductAsync(selected.Id.Value);
                if (success)
                {
                    await LoadAllData();
                }
                else
                {
                    MessageBox.Show("Failed to delete product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================
        // CATEGORY ACTIONS
        // =========================

        private async void btnRefreshCat_Click(object sender, EventArgs e)
        {
            await LoadAllData();
        }

        private async void btnAddCat_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter Category Name:", "New Category", "");

            if (!string.IsNullOrWhiteSpace(name))
            {
                bool success = await _apiService.CreateCategoryAsync(name);
                if (success) await LoadAllData();
                else MessageBox.Show("Failed to create category.");
            }
        }

        private async void btnEditCat_Click(object sender, EventArgs e)
        {
            if (gridCategories.SelectedRows.Count == 0) return;
            var selected = (CategoryDTO)gridCategories.SelectedRows[0].DataBoundItem;

            string name = Microsoft.VisualBasic.Interaction.InputBox("Edit Category Name:", "Edit Category", selected.Name);

            if (!string.IsNullOrWhiteSpace(name) && name != selected.Name)
            {
                bool success = await _apiService.UpdateCategoryAsync(selected.Id.Value, name);
                if (success) await LoadAllData();
                else MessageBox.Show("Failed to update category.");
            }
        }

        private async void btnDeleteCat_Click(object sender, EventArgs e)
        {
            if (gridCategories.SelectedRows.Count == 0) return;
            var selected = (CategoryDTO)gridCategories.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Delete Category '{selected.Name}'?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool success = await _apiService.DeleteCategoryAsync(selected.Id.Value);
                if (success) await LoadAllData();
                else MessageBox.Show("Failed to delete category.");
            }
        }

        // =========================
        // USER ACTIONS
        // =========================

        private async void btnViewUser_Click(object sender, EventArgs e)
        {
            if (gridUsers.SelectedRows.Count == 0) return;

            var user = (UserDTO)gridUsers.SelectedRows[0].DataBoundItem;

            try
            {
                // 1. Fetch full details (including orders)
                var userDetails = await _apiService.GetUserDetailsAsync(user.Id);

                // 2. Open the Details Form (Ensure you have created UserDetailsForm!)
                   using (var form = new UserDetailsForm(userDetails))
                   {
                       form.ShowDialog();
                   }
                
                MessageBox.Show($"Details fetched for {userDetails.Username}. (UserDetailsForm not yet implemented)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load user details: " + ex.Message);
            }
        }

    }
}