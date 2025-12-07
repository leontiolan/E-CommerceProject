using System;
using System.Collections.Generic;
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

        public ProductEditorForm(ProductDTO existingProduct = null)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            _apiService = new AdminApiService();

            LoadCategories();

            if (existingProduct != null)
            {
                this.Text = "Edit Product";
                ProductResult = existingProduct;

                txtName.Text = existingProduct.Name;
                txtDescription.Text = existingProduct.Description;
                txtPrice.Text = existingProduct.Price.ToString();
                txtStock.Text = existingProduct.StockQuantity.ToString();

                if (existingProduct.ImageUrls != null)
                {
                    txtImages.Text = string.Join(Environment.NewLine, existingProduct.ImageUrls);
                }
            }
            else
            {
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

        private async void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Product Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    btnUploadImage.Enabled = false;
                    btnUploadImage.Text = "Uploading...";

                    string uploadedFilename = await _apiService.UploadImageAsync(openFileDialog.FileName);

                    if (!string.IsNullOrEmpty(uploadedFilename))
                    {
                        if (!string.IsNullOrWhiteSpace(txtImages.Text))
                        {
                            txtImages.Text += Environment.NewLine + uploadedFilename;
                        }
                        else
                        {
                            txtImages.Text = uploadedFilename;
                        }
                        MessageBox.Show("Image uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    btnUploadImage.Enabled = true;
                    btnUploadImage.Text = "UPLOAD PHOTO";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Name and Price are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            if (!string.IsNullOrWhiteSpace(txtImages.Text))
            {
                ProductResult.ImageUrls = new List<string>(
                    txtImages.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                );
            }
            else
            {
                ProductResult.ImageUrls = new List<string>();
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