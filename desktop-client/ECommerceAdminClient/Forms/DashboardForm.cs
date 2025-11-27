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
        public bool IsLogout { get; private set; } = false;

        public DashboardForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            _apiService = new AdminApiService();
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
            grid.RowHeadersVisible = false;
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            await LoadAllData();
        }

        private async Task LoadAllData()
        {
            try
            {
                var products = await _apiService.GetAllProductsAsync();
                gridProducts.DataSource = products;
                if (gridProducts.Columns["Category"] != null) gridProducts.Columns["Category"].Visible = false;

                var categories = await _apiService.GetCategoriesAsync();
                gridCategories.DataSource = categories;

                var users = await _apiService.GetAllUsersAsync();
                gridUsers.DataSource = users;
                if (gridUsers.Columns["Orders"] != null) gridUsers.Columns["Orders"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            IsLogout = true;
            Close();
        }

        private async void btnRefreshUser_Click(object sender, EventArgs e) => await LoadAllData();

        private async void btnViewUser_Click(object sender, EventArgs e)
        {
            if (gridUsers.SelectedRows.Count == 0) return;
            var user = (UserDTO)gridUsers.SelectedRows[0].DataBoundItem;
            try
            {
                var userDetails = await _apiService.GetUserDetailsAsync(user.Id);
                using (var form = new UserDetailsForm(userDetails)) form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load details: " + ex.Message);
            }
        }

        private async void btnBanUser_Click(object sender, EventArgs e)
        {
            if (gridUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user to ban.");
                return;
            }

            var user = (UserDTO)gridUsers.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Are you sure you want to ban {user.Username}?", "Confirm Ban", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var form = new BanUserForm())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        bool success = await _apiService.BanUserAsync(user.Id, form.BanReason);
                        if (success)
                        {
                            MessageBox.Show("User has been banned.");
                            await LoadAllData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to ban user.");
                        }
                    }
                }
            }
        }

        private async void btnRefreshProd_Click(object sender, EventArgs e) => await LoadAllData();
        private async void btnAddProd_Click(object sender, EventArgs e) { using (var f = new ProductEditorForm(null)) if (f.ShowDialog() == DialogResult.OK) if (await _apiService.CreateProductAsync(f.ProductResult)) await LoadAllData(); }
        private async void btnEditProd_Click(object sender, EventArgs e) { if (gridProducts.SelectedRows.Count > 0) using (var f = new ProductEditorForm((ProductDTO)gridProducts.SelectedRows[0].DataBoundItem)) if (f.ShowDialog() == DialogResult.OK) if (await _apiService.UpdateProductAsync(((ProductDTO)gridProducts.SelectedRows[0].DataBoundItem).Id.Value, f.ProductResult)) await LoadAllData(); }
        private async void btnDeleteProd_Click(object sender, EventArgs e) { if (gridProducts.SelectedRows.Count > 0 && MessageBox.Show("Delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes) if (await _apiService.DeleteProductAsync(((ProductDTO)gridProducts.SelectedRows[0].DataBoundItem).Id.Value)) await LoadAllData(); }
        private async void btnRefreshCat_Click(object sender, EventArgs e) => await LoadAllData();
        private async void btnAddCat_Click(object sender, EventArgs e) { string name = Microsoft.VisualBasic.Interaction.InputBox("Name:", "New Category"); if (!string.IsNullOrWhiteSpace(name)) if (await _apiService.CreateCategoryAsync(name)) await LoadAllData(); }
        private async void btnEditCat_Click(object sender, EventArgs e) { if (gridCategories.SelectedRows.Count > 0) { var c = (CategoryDTO)gridCategories.SelectedRows[0].DataBoundItem; string name = Microsoft.VisualBasic.Interaction.InputBox("Name:", "Edit", c.Name); if (!string.IsNullOrWhiteSpace(name)) if (await _apiService.UpdateCategoryAsync(c.Id.Value, name)) await LoadAllData(); } }
        private async void btnDeleteCat_Click(object sender, EventArgs e) { if (gridCategories.SelectedRows.Count > 0 && MessageBox.Show("Delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes) if (await _apiService.DeleteCategoryAsync(((CategoryDTO)gridCategories.SelectedRows[0].DataBoundItem).Id.Value)) await LoadAllData(); }
    }
}