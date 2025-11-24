using System;
using System.Windows.Forms;
using ECommerceAdminClient.Models;
using ECommerceAdminClient.Services;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ECommerceAdminClient.Forms
{
    public partial class UserDetailsForm : MaterialForm
    {
        private readonly UserDTO _user;
        private readonly AdminApiService _apiService;

        public UserDetailsForm(UserDTO user)
        {
            InitializeComponent();

            // Ensure Theme is applied to this form instance
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );

            _apiService = new AdminApiService();
            _user = user;
        }

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {
            if (_user != null)
            {
                // Populate MaterialTextBox2 fields
                txtUsername.Text = _user.Username;
                txtEmail.Text = _user.Email;
                txtRole.Text = _user.Role;

                SetupOrdersGrid();
            }
            else
            {
                MessageBox.Show("No user data available.");
            }
        }

        private void SetupOrdersGrid()
        {
            if (_user.Orders != null && _user.Orders.Count > 0)
            {
                gridOrders.DataSource = _user.Orders;

                // Grid Styling for consistency
                gridOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridOrders.MultiSelect = false;
                gridOrders.ReadOnly = true;
                gridOrders.BackgroundColor = System.Drawing.Color.White;
                gridOrders.BorderStyle = BorderStyle.None;
                gridOrders.RowHeadersVisible = false;
            }
            else
            {
                gridOrders.DataSource = null;
            }
        }

        private async void btnMarkShipped_Click(object sender, EventArgs e)
        {
            if (gridOrders.SelectedRows.Count > 0)
            {
                var order = (OrderSummaryDTO)gridOrders.SelectedRows[0].DataBoundItem;

                var confirm = MessageBox.Show(
                    $"Mark Order #{order.Id} as SHIPPED?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    bool success = await _apiService.UpdateOrderStatusAsync(order.Id, "SHIPPED");

                    if (success)
                    {
                        MessageBox.Show("Order status updated!");
                        order.Status = "SHIPPED";
                        gridOrders.Refresh(); // Refresh grid to show new status
                    }
                    else
                    {
                        MessageBox.Show("Failed to update order. Check server connection.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order from the list first.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}