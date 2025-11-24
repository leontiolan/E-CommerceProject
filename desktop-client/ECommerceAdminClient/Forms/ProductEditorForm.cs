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
                cmbCategory.DisplayMember = "Name"; 
                cmbCategory.ValueMember = "Id";    


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
            // 1. Validation: Check for empty text fields
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Name and Price are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validation: Check if a category is actually selected
            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a category. If none exist, create one first in the Categories tab.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Map Input to DTO
            ProductResult.Name = txtName.Text;
            ProductResult.Description = txtDescription.Text;

            if (double.TryParse(txtPrice.Text, out double price))
                ProductResult.Price = price;
            else
                ProductResult.Price = 0; 

            if (int.TryParse(txtStock.Text, out int stock))
                ProductResult.StockQuantity = stock;
            else
                ProductResult.StockQuantity = 0;


            try
            {
                ProductResult.CategoryId = Convert.ToInt64(cmbCategory.SelectedValue);
            }
            catch
            {
                MessageBox.Show("Error reading Category selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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