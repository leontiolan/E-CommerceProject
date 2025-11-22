using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using ECommerceAdminClient.Services;

namespace ECommerceAdminClient.Forms
{
    // IMPORTANT: This must match the namespace in the Designer file exactly
    public partial class LoginForm : MaterialForm
    {
        private readonly AdminApiService _apiService;

        public LoginForm()
        {
            InitializeComponent(); // This method is defined in the Designer file!

            _apiService = new AdminApiService();

            // Initialize MaterialSkin Theme
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        // This method matches the "this.btnLogin.Click += ..." line in the Designer
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Disable button to prevent double-clicking
            btnLogin.Enabled = false;
            btnLogin.Text = "LOGGING IN...";

            bool success = await _apiService.LoginAsync(txtUsername.Text, txtPassword.Text);

            if (success)
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open Dashboard
                DashboardForm dashboard = new DashboardForm();
                dashboard.Show();

                // Hide Login Form
                this.Hide();

                // Close app completely when Dashboard is closed
                dashboard.FormClosed += (s, args) => this.Close();
            }
            else
            {
                // Re-enable button on failure
                btnLogin.Enabled = true;
                btnLogin.Text = "LOGIN";
            }
        }
    }
}