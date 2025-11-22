using ECommerceAdminClient.Forms;
using ECommerceAdminClient.Services;
using MaterialSkin.Controls; 

namespace ECommerceAdminClient

{
   
    public partial class LoginForm : MaterialForm
    {
        private readonly AdminApiService _apiService;
        public LoginForm()
        {
            InitializeComponent();
            _apiService = new AdminApiService();
            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.Blue600, MaterialSkin.Primary.Blue700,
                MaterialSkin.Primary.Blue200, MaterialSkin.Accent.LightBlue200,
                MaterialSkin.TextShade.WHITE);
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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
