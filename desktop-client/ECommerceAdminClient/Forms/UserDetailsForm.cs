using System;
using System.Windows.Forms;
using ECommerceAdminClient.Models;
using ECommerceAdminClient.Services;
using MaterialSkin.Controls;
using MaterialSkin;

namespace ECommerceAdminClient.Forms
{
    public partial class UserDetailsForm : MaterialForm
    {
        private readonly UserDTO _user; // Store the user data
        private readonly AdminApiService _apiService;

        public UserDetailsForm(UserDTO user)
        {
            InitializeComponent();
            _apiService = new AdminApiService();
            _user = user;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtRole.Text = user.Role;

            SetupOrdersGrid();
        }

        private void SetupOrdersGrid()
        {
            if (_user.Orders != null && _user.Orders.Count > 0)
            {
                gridOrders.DataSource = _user.Orders;
                gridOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridOrders.MultiSelect = false;
                gridOrders.ReadOnly = true;
            }
            else
            {
                // If no orders, maybe hide the grid or show a message? 
                // For now, we leave it empty.
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

                        // Update the UI locally to reflect the change immediately
                        order.Status = "SHIPPED";
                        gridOrders.Refresh();
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

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {


        }
    }
}