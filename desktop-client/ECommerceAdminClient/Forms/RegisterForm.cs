using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using ECommerceAdminClient.Services;

namespace ECommerceAdminClient.Forms
{
    public partial class RegisterForm : MaterialForm
    {
        private readonly AdminApiService _apiService;
        public string RegisteredUsername { get; private set; }

        public RegisterForm()
        {
            InitializeComponent();
            _apiService = new AdminApiService();

            // Theme Setup
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Disable button
            btnRegister.Enabled = false;
            btnRegister.Text = "Registering...";

            // Call Service
            bool success = await _apiService.RegisterAdminAsync(txtUsername.Text, txtEmail.Text, txtPassword.Text);

            if (success)
            {
                MessageBox.Show("Admin Account Created! Please login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RegisteredUsername = txtUsername.Text;

                this.DialogResult = DialogResult.OK; // Signal success
                this.Close();
            }
            else
            {
                MessageBox.Show("Registration Failed. Username/Email might be taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRegister.Enabled = true;
                btnRegister.Text = "REGISTER ADMIN";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}