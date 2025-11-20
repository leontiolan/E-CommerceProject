using ECommerceAdminClient.Services;

namespace ECommerceAdminClient

{
    public partial class LoginForm : Form
    {
        private readonly AdminApiService _apiService;
        public LoginForm()
        {
            InitializeComponent();
            _apiService = new AdminApiService();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var service = new AdminApiService();
            bool success = await service.LoginAsync(txtUsername.Text, txtPassword.Text);
            if (success)
            {
                // Open the Dashboard
                var dashboard = new DashboardForm();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
        }
    }
}
