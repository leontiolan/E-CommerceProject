using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using ECommerceAdminClient.Models;
using ECommerceAdminClient.Services;

namespace ECommerceAdminClient.Forms
{
    public partial class DashboardForm : MaterialForm
    {
        private readonly AdminApiService _apiService;

        public DashboardForm()
        {
            InitializeComponent();

            // Theme Setup
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            _apiService = new AdminApiService();

            // Configure Grids
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
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            await LoadAllData();
        }

        private async Task LoadAllData()
        {
            try
            {
                // 1. Load Products
                var products = await _apiService.GetAllProductsAsync();
                gridProducts.DataSource = products;
                // Hide nested object columns if they exist
                if (gridProducts.Columns["Category"] != null) gridProducts.Columns["Category"].Visible = false;

                // 2. Load Categories
                var categories = await _apiService.GetCategoriesAsync();
                gridCategories.DataSource = categories;

                // 3. Load Users
                var users = await _apiService.GetAllUsersAsync();
                gridUsers.DataSource = users;
                if (gridUsers.Columns["Orders"] != null) gridUsers.Columns["Orders"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // =========================
        // PRODUCT ACTIONS
        // =========================
        private async void btnAddProd_Click(object sender, EventArgs e)
        {
            // Open editor in CREATE mode (null)
            using (var form = new ProductEditorForm(null))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool success = await _apiService.CreateProductAsync(form.ProductResult);
                    if (success)
                    {
                        MessageBox.Show("Product Created");
                        await LoadAllData();
                    }
                    else MessageBox.Show("Failed to create product");
                }
            }
        }

        private async void btnEditProd_Click(object sender, EventArgs e)
        {
            if (gridProducts.SelectedRows.Count == 0) return;
            var selected = (ProductDTO)gridProducts.SelectedRows[0].DataBoundItem;

            // Open editor in EDIT mode
            using (var form = new ProductEditorForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool success = await _apiService.UpdateProductAsync(selected.Id.Value, form.ProductResult);
                    if (success) await LoadAllData();
                }
            }
        }

        private async void btnDeleteProd_Click(object sender, EventArgs e)
        {
            if (gridProducts.SelectedRows.Count == 0) return;
            var selected = (ProductDTO)gridProducts.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Delete {selected.Name}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _apiService.DeleteProductAsync(selected.Id.Value);
                await LoadAllData();
            }
        }

        // =========================
        // CATEGORY ACTIONS
        // =========================
        private async void btnAddCat_Click(object sender, EventArgs e)
        {
            // Simple input box for Category Name
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter Category Name:", "New Category", "");

            if (!string.IsNullOrWhiteSpace(name))
            {
                await _apiService.CreateCategoryAsync(name);
                await LoadAllData();
            }
        }

        // Add logic for Edit/Delete Category similar to Products if needed

        // =========================
        // USER ACTIONS
        // =========================
        private async void btnViewUser_Click(object sender, EventArgs e)
        {
            if (gridUsers.SelectedRows.Count == 0) return;

            var user = (UserDTO)gridUsers.SelectedRows[0].DataBoundItem;

            // 1. Fetch full details (including orders)
            var userDetails = await _apiService.GetUserDetailsAsync(user.Id);

            // 2. Open UserDetailsForm (Make sure this form exists!)
            // using (var form = new UserDetailsForm(userDetails))
            // {
            //     form.ShowDialog();
            // }
            MessageBox.Show("User Details Form not yet created, but data fetched for: " + userDetails.Username);
        }
    }
}