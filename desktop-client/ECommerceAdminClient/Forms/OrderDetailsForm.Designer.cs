namespace ECommerceAdminClient.Forms
{
    partial class OrderDetailsForm
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
            this.txtOrderId = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtOrderDate = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtStatus = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtTotal = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtAddress = new MaterialSkin.Controls.MaterialTextBox2();
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.SuspendLayout();
             
            // txtOrderId 
            this.txtOrderId.AnimateReadOnly = true;
            this.txtOrderId.Depth = 0;
            this.txtOrderId.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtOrderId.Hint = "Order ID";
            this.txtOrderId.Location = new System.Drawing.Point(20, 80);
            this.txtOrderId.MouseState = MaterialSkin.MouseState.OUT;
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.ReadOnly = true;
            this.txtOrderId.Size = new System.Drawing.Size(180, 48);
            this.txtOrderId.TabIndex = 0;
             
            // txtOrderDate 
            this.txtOrderDate.AnimateReadOnly = true;
            this.txtOrderDate.Depth = 0;
            this.txtOrderDate.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtOrderDate.Hint = "Date";
            this.txtOrderDate.Location = new System.Drawing.Point(220, 80);
            this.txtOrderDate.MouseState = MaterialSkin.MouseState.OUT;
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(200, 48);
            this.txtOrderDate.TabIndex = 1;
            
            // txtStatus 
            this.txtStatus.AnimateReadOnly = true;
            this.txtStatus.Depth = 0;
            this.txtStatus.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtStatus.Hint = "Status";
            this.txtStatus.Location = new System.Drawing.Point(440, 80);
            this.txtStatus.MouseState = MaterialSkin.MouseState.OUT;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(180, 48);
            this.txtStatus.TabIndex = 2;
             
            // txtTotal
            this.txtTotal.AnimateReadOnly = true;
            this.txtTotal.Depth = 0;
            this.txtTotal.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTotal.Hint = "Total Price";
            this.txtTotal.Location = new System.Drawing.Point(640, 80);
            this.txtTotal.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(140, 48);
            this.txtTotal.TabIndex = 3;
            
            // txtAddress
            this.txtAddress.AnimateReadOnly = true;
            this.txtAddress.Depth = 0;
            this.txtAddress.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAddress.Hint = "Shipping Address";
            this.txtAddress.Location = new System.Drawing.Point(20, 140);
            this.txtAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(760, 48);
            this.txtAddress.TabIndex = 4;
             
            // gridItems 
            this.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItems.Location = new System.Drawing.Point(20, 210);
            this.gridItems.Name = "gridItems";
            this.gridItems.RowHeadersWidth = 51;
            this.gridItems.Size = new System.Drawing.Size(760, 200);
            this.gridItems.TabIndex = 5;
            
            // btnClose 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClose.Depth = 0;
            this.btnClose.HighEmphasis = true;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(360, 420);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClose.Size = new System.Drawing.Size(66, 36);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "CLOSE";
            this.btnClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClose.UseAccentColor = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
             
            // OrderDetailsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridItems);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.txtOrderId);
            this.Name = "OrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.OrderDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 txtOrderId;
        private MaterialSkin.Controls.MaterialTextBox2 txtOrderDate;
        private MaterialSkin.Controls.MaterialTextBox2 txtStatus;
        private MaterialSkin.Controls.MaterialTextBox2 txtTotal;
        private MaterialSkin.Controls.MaterialTextBox2 txtAddress;
        private System.Windows.Forms.DataGridView gridItems;
        private MaterialSkin.Controls.MaterialButton btnClose;
    }
}