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
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            _apiService = new AdminApiService();
            _user = user;
        }

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {
            if (_user != null)
            {
                txtUsername.Text = _user.Username;
                txtEmail.Text = _user.Email;
                txtRole.Text = _user.Role;
                SetupOrdersGrid();
            }
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
                var confirm = MessageBox.Show($"Mark Order #{order.Id} as SHIPPED?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    bool success = await _apiService.UpdateOrderStatusAsync(order.Id, "SHIPPED");
                    if (success)
                    {
                        MessageBox.Show("Order status updated!");
                        order.Status = "SHIPPED";
                        gridOrders.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order first.");
            }
        }

        private async void btnViewOrder_Click(object sender, EventArgs e)
        {
            if (gridOrders.SelectedRows.Count > 0)
            {
                var summary = (OrderSummaryDTO)gridOrders.SelectedRows[0].DataBoundItem;

                try
                {
                    var details = await _apiService.GetOrderDetailsAsync(summary.Id);

                    if (details != null)
                    {
                        using (var form = new OrderDetailsForm(details))
                        {
                            form.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve details.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching details: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select an order first.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}