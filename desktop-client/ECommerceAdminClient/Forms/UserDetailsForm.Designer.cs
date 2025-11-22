namespace ECommerceAdminClient.Forms
{
    partial class UserDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtUsername = new MaterialSkin.Controls.MaterialTextBox();
            txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            txtRole = new MaterialSkin.Controls.MaterialTextBox();
            lblOrdersHeader = new MaterialSkin.Controls.MaterialLabel();
            gridOrders = new DataGridView();
            btnMarkShipped = new MaterialSkin.Controls.MaterialButton();
            btnClose = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)gridOrders).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.AnimateReadOnly = false;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Depth = 0;
            txtUsername.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUsername.Hint = "Username";
            txtUsername.LeadingIcon = null;
            txtUsername.Location = new Point(20, 80);
            txtUsername.MaxLength = 50;
            txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            txtUsername.Multiline = false;
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(250, 50);
            txtUsername.TabIndex = 0;
            txtUsername.Text = "";
            txtUsername.TrailingIcon = null;
            // 
            // txtEmail
            // 
            txtEmail.AnimateReadOnly = false;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Depth = 0;
            txtEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmail.Hint = "Email Address";
            txtEmail.LeadingIcon = null;
            txtEmail.Location = new Point(290, 80);
            txtEmail.MaxLength = 50;
            txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtEmail.Multiline = false;
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(300, 50);
            txtEmail.TabIndex = 1;
            txtEmail.Text = "";
            txtEmail.TrailingIcon = null;
            // 
            // txtRole
            // 
            txtRole.AnimateReadOnly = false;
            txtRole.BorderStyle = BorderStyle.None;
            txtRole.Depth = 0;
            txtRole.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtRole.Hint = "Role";
            txtRole.LeadingIcon = null;
            txtRole.Location = new Point(610, 80);
            txtRole.MaxLength = 50;
            txtRole.MouseState = MaterialSkin.MouseState.OUT;
            txtRole.Multiline = false;
            txtRole.Name = "txtRole";
            txtRole.ReadOnly = true;
            txtRole.Size = new Size(150, 50);
            txtRole.TabIndex = 2;
            txtRole.Text = "";
            txtRole.TrailingIcon = null;
            // 
            // lblOrdersHeader
            // 
            lblOrdersHeader.AutoSize = true;
            lblOrdersHeader.Depth = 0;
            lblOrdersHeader.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblOrdersHeader.Location = new Point(20, 150);
            lblOrdersHeader.MouseState = MaterialSkin.MouseState.HOVER;
            lblOrdersHeader.Name = "lblOrdersHeader";
            lblOrdersHeader.Size = new Size(93, 19);
            lblOrdersHeader.TabIndex = 3;
            lblOrdersHeader.Text = "Order History";
            // 
            // gridOrders
            // 
            gridOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridOrders.Location = new Point(20, 180);
            gridOrders.Name = "gridOrders";
            gridOrders.RowHeadersWidth = 51;
            gridOrders.Size = new Size(760, 200);
            gridOrders.TabIndex = 4;
            // 
            // btnMarkShipped
            // 
            btnMarkShipped.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnMarkShipped.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMarkShipped.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMarkShipped.Depth = 0;
            btnMarkShipped.HighEmphasis = true;
            btnMarkShipped.Icon = null;
            btnMarkShipped.Location = new Point(557, 400);
            btnMarkShipped.Margin = new Padding(4, 6, 4, 6);
            btnMarkShipped.MouseState = MaterialSkin.MouseState.HOVER;
            btnMarkShipped.Name = "btnMarkShipped";
            btnMarkShipped.NoAccentTextColor = Color.Empty;
            btnMarkShipped.Size = new Size(223, 36);
            btnMarkShipped.TabIndex = 5;
            btnMarkShipped.Text = "Mark Selected as Shipped";
            btnMarkShipped.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMarkShipped.UseAccentColor = false;
            btnMarkShipped.UseVisualStyleBackColor = true;
            btnMarkShipped.Click += btnMarkShipped_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClose.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClose.Depth = 0;
            btnClose.HighEmphasis = false;
            btnClose.Icon = null;
            btnClose.Location = new Point(20, 400);
            btnClose.Margin = new Padding(4, 6, 4, 6);
            btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            btnClose.Name = "btnClose";
            btnClose.NoAccentTextColor = Color.Empty;
            btnClose.Size = new Size(66, 36);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnClose.UseAccentColor = false;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // UserDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(btnMarkShipped);
            Controls.Add(gridOrders);
            Controls.Add(lblOrdersHeader);
            Controls.Add(txtRole);
            Controls.Add(txtEmail);
            Controls.Add(txtUsername);
            Name = "UserDetailsForm";
            Text = "User Details";
            Load += UserDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtUsername;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtRole;
        private MaterialSkin.Controls.MaterialLabel lblOrdersHeader;
        private System.Windows.Forms.DataGridView gridOrders;
        private MaterialSkin.Controls.MaterialButton btnMarkShipped;
        private MaterialSkin.Controls.MaterialButton btnClose;
    }
}