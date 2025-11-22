using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using ECommerceAdminClient.Models;
using ECommerceAdminClient.Services;

namespace ECommerceAdminClient.Forms
{
    public partial class ProductEditorForm : MaterialForm
    {
        public ProductDTO ProductResult { get; private set; }
        private readonly AdminApiService _apiService;

        // Constructor accepts a product (for edit) or null (for create)
        public ProductEditorForm(ProductDTO existingProduct = null)
        {
            InitializeComponent();

            // Add to Material Manager so it gets the theme
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            _apiService = new AdminApiService();

            // Load Categories immediately
            LoadCategories();

            if (existingProduct != null)
            {
                // EDIT MODE
                this.Text = "Edit Product";
                ProductResult = existingProduct;

                // Populate fields
                txtName.Text = existingProduct.Name;
                txtDescription.Text = existingProduct.Description;
                txtPrice.Text = existingProduct.Price.ToString();
                txtStock.Text = existingProduct.StockQuantity.ToString();
            }
            else
            {
                // CREATE MODE
                this.Text = "New Product";
                ProductResult = new ProductDTO();
            }
        }

        private async void LoadCategories()
        {
            try
            {
                var categories = await _apiService.GetCategoriesAsync();
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "Name"; // Show the name
                cmbCategory.ValueMember = "Id";    // Store the ID

                // If editing, select the correct category
                if (ProductResult?.CategoryId != 0)
                {
                    cmbCategory.SelectedValue = ProductResult.CategoryId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load categories: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Name and Price are required.");
                return;
            }

            // 2. Map Input to DTO
            ProductResult.Name = txtName.Text;
            ProductResult.Description = txtDescription.Text;

            if (double.TryParse(txtPrice.Text, out double price))
                ProductResult.Price = price;

            if (int.TryParse(txtStock.Text, out int stock))
                ProductResult.StockQuantity = stock;

            // 3. Get Category ID from Dropdown
            if (cmbCategory.SelectedValue != null)
            {
                ProductResult.CategoryId = (long)cmbCategory.SelectedValue;
            }
            else
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            // 4. Close with success
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}