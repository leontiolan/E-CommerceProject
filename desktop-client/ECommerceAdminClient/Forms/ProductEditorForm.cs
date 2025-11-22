using System;
using System.Windows.Forms;
using ECommerceAdminClient.Models;
using ECommerceAdminClient.Services;

namespace ECommerceAdminClient.Forms
{
    public partial class ProductEditorForm : Form
    {
        public ProductDTO ProductResult { get; private set; }
        private readonly AdminApiService _apiService;

        public ProductEditorForm(ProductDTO existingProduct = null)
        {
            InitializeComponent();
            _apiService = new AdminApiService();
            LoadCategories(); // Essential: Fill the dropdown

            if (existingProduct != null)
            {
                // EDIT MODE: Fill fields
                ProductResult = existingProduct;
                txtName.Text = existingProduct.Name;
                txtDescription.Text = existingProduct.Description;
                txtPrice.Text = existingProduct.Price.ToString();
                txtStock.Text = existingProduct.StockQuantity.ToString();
                // Category selection logic handles itself in LoadCategories if ID matches
            }
            else
            {
                // CREATE MODE
                ProductResult = new ProductDTO();
            }
        }

        private async void LoadCategories()
        {
            var categories = await _apiService.GetCategoriesAsync();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";

            // If editing, select the current category
            if (ProductResult?.CategoryId != 0)
            {
                cmbCategory.SelectedValue = ProductResult.CategoryId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Name required"); return; }

            ProductResult.Name = txtName.Text;
            ProductResult.Description = txtDescription.Text;
            ProductResult.Price = double.TryParse(txtPrice.Text, out double p) ? p : 0;
            ProductResult.StockQuantity = int.TryParse(txtStock.Text, out int s) ? s : 0;

            // Get Selected Category ID
            if (cmbCategory.SelectedValue != null)
            {
                ProductResult.CategoryId = (long)cmbCategory.SelectedValue;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}