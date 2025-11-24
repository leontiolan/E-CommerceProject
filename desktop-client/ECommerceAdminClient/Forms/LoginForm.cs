using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using ECommerceAdminClient.Services;

namespace ECommerceAdminClient.Forms
{
    public partial class LoginForm : MaterialForm
    {
        private readonly AdminApiService _apiService;

        public LoginForm()
        {
            InitializeComponent();
            _apiService = new AdminApiService();

            // --- MATERIAL SKIN INITIALIZATION ---
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );

            // --- NEW FEATURE: Enable "Enter" key to trigger Login ---
            this.AcceptButton = btnLogin;
            // --------------------------------------------------------
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "LOGGING IN...";

            bool success = await _apiService.LoginAsync(txtUsername.Text, txtPassword.Text);

            if (success)
            {
                DashboardForm dashboard = new DashboardForm();

                // --- Handle Dashboard Closing Logic ---
                dashboard.FormClosed += (s, args) =>
                {
                    if (dashboard.IsLogout)
                    {
                        // User clicked Logout: Show Login form again
                        this.Show();
                        txtPassword.Text = ""; // Clear password for security
                        btnLogin.Enabled = true;
                        btnLogin.Text = "LOGIN";
                        txtUsername.Focus(); // Set focus back to username
                    }
                    else
                    {
                        // User clicked X (Close): Exit entire application
                        Application.Exit();
                    }
                };

                dashboard.Show();
                this.Hide(); // Hide Login window
            }
            else
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "LOGIN";
            }
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (var registerForm = new RegisterForm())
            {
                var result = registerForm.ShowDialog();

                // Show Login form again immediately after closing register
                this.Show();
                this.WindowState = FormWindowState.Normal;

                if (result == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(registerForm.RegisteredUsername))
                    {
                        txtUsername.Text = registerForm.RegisteredUsername;
                        txtPassword.Focus();
                    }
                }
            }
        }
    }
}