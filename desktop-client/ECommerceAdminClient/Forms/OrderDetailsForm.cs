using System;
using System.Windows.Forms;
using ECommerceAdminClient.Models;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ECommerceAdminClient.Forms
{
    public partial class OrderDetailsForm : MaterialForm
    {
        private readonly OrderDetailDTO _order;

        public OrderDetailsForm(OrderDetailDTO order)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            _order = order;
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            if (_order != null)
            {
                txtOrderId.Text = _order.Id.ToString();
                txtOrderDate.Text = _order.OrderDate.ToString("g");
                txtStatus.Text = _order.Status;
                txtTotal.Text = $"${_order.OrderPrice:F2}";
                txtAddress.Text = _order.ShippingAddress;

                gridItems.DataSource = _order.OrderItems;
                gridItems.BackgroundColor = System.Drawing.Color.White;
                gridItems.BorderStyle = BorderStyle.None;
                gridItems.RowHeadersVisible = false;
                gridItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}