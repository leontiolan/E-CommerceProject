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
            this.txtUsername = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtRole = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblOrdersHeader = new MaterialSkin.Controls.MaterialLabel();
            this.gridOrders = new System.Windows.Forms.DataGridView();
            this.btnMarkShipped = new MaterialSkin.Controls.MaterialButton();
            this.btnViewOrder = new MaterialSkin.Controls.MaterialButton();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).BeginInit();
            this.SuspendLayout();
            
            // txtUsername
            this.txtUsername.AnimateReadOnly = true;
            this.txtUsername.Depth = 0;
            this.txtUsername.Hint = "Username";
            this.txtUsername.Location = new System.Drawing.Point(20, 80);
            this.txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(250, 48);
            this.txtUsername.TabIndex = 0;
            
            // txtEmail
            this.txtEmail.AnimateReadOnly = true;
            this.txtEmail.Depth = 0;
            this.txtEmail.Hint = "Email Address";
            this.txtEmail.Location = new System.Drawing.Point(290, 80);
            this.txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(300, 48);
            this.txtEmail.TabIndex = 1;
            
            // txtRole 
            this.txtRole.AnimateReadOnly = true;
            this.txtRole.Depth = 0;
            this.txtRole.Hint = "Role";
            this.txtRole.Location = new System.Drawing.Point(610, 80);
            this.txtRole.MouseState = MaterialSkin.MouseState.OUT;
            this.txtRole.Name = "txtRole";
            this.txtRole.ReadOnly = true;
            this.txtRole.Size = new System.Drawing.Size(150, 48);
            this.txtRole.TabIndex = 2;
            
            // lblOrdersHeader
            this.lblOrdersHeader.AutoSize = true;
            this.lblOrdersHeader.Depth = 0;
            this.lblOrdersHeader.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOrdersHeader.Location = new System.Drawing.Point(20, 150);
            this.lblOrdersHeader.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblOrdersHeader.Name = "lblOrdersHeader";
            this.lblOrdersHeader.Size = new System.Drawing.Size(93, 19);
            this.lblOrdersHeader.TabIndex = 3;
            this.lblOrdersHeader.Text = "Order History";
            
            // gridOrders
            this.gridOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOrders.Location = new System.Drawing.Point(20, 180);
            this.gridOrders.Name = "gridOrders";
            this.gridOrders.RowHeadersWidth = 51;
            this.gridOrders.Size = new System.Drawing.Size(760, 200);
            this.gridOrders.TabIndex = 4;
            
            // btnMarkShipped 
            this.btnMarkShipped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMarkShipped.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMarkShipped.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMarkShipped.Depth = 0;
            this.btnMarkShipped.HighEmphasis = true;
            this.btnMarkShipped.Icon = null;
            this.btnMarkShipped.Location = new System.Drawing.Point(557, 400);
            this.btnMarkShipped.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMarkShipped.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMarkShipped.Name = "btnMarkShipped";
            this.btnMarkShipped.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMarkShipped.Size = new System.Drawing.Size(223, 36);
            this.btnMarkShipped.TabIndex = 5;
            this.btnMarkShipped.Text = "Mark Selected as Shipped";
            this.btnMarkShipped.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMarkShipped.UseAccentColor = false;
            this.btnMarkShipped.UseVisualStyleBackColor = true;
            this.btnMarkShipped.Click += new System.EventHandler(this.btnMarkShipped_Click);
            
            // btnViewOrder 
            this.btnViewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnViewOrder.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnViewOrder.Depth = 0;
            this.btnViewOrder.HighEmphasis = false;
            this.btnViewOrder.Icon = null;
            this.btnViewOrder.Location = new System.Drawing.Point(380, 400);
            this.btnViewOrder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnViewOrder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnViewOrder.Size = new System.Drawing.Size(160, 36);
            this.btnViewOrder.TabIndex = 7;
            this.btnViewOrder.Text = "View Order Details";
            this.btnViewOrder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnViewOrder.UseAccentColor = false;
            this.btnViewOrder.UseVisualStyleBackColor = true;
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);

            // btnClose
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClose.Depth = 0;
            this.btnClose.HighEmphasis = false;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(20, 400);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClose.Size = new System.Drawing.Size(66, 36);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClose.UseAccentColor = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            // UserDetailsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnViewOrder); 
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMarkShipped);
            this.Controls.Add(this.gridOrders);
            this.Controls.Add(this.lblOrdersHeader);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUsername);
            this.Name = "UserDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Details";
            this.Load += new System.EventHandler(this.UserDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 txtUsername;
        private MaterialSkin.Controls.MaterialTextBox2 txtEmail;
        private MaterialSkin.Controls.MaterialTextBox2 txtRole;
        private MaterialSkin.Controls.MaterialLabel lblOrdersHeader;
        private System.Windows.Forms.DataGridView gridOrders;
        private MaterialSkin.Controls.MaterialButton btnMarkShipped;
        private MaterialSkin.Controls.MaterialButton btnViewOrder;
        private MaterialSkin.Controls.MaterialButton btnClose;
    }
}