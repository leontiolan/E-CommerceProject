using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ECommerceAdminClient.Forms
{
    public partial class BanUserForm : MaterialForm
    {
        public string BanReason { get; private set; }

        public BanUserForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Reason is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BanReason = txtReason.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}