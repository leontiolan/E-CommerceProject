namespace ECommerceAdminClient.Forms
{
    partial class ProductEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtStock = new TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(256, 295);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 65);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            txtName.Location = new Point(196, 68);
            txtName.Name = "txtName";
            txtName.Size = new Size(375, 27);
            txtName.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(204, 155);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(333, 27);
            txtPrice.TabIndex = 2;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(203, 234);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(334, 27);
            txtStock.TabIndex = 3;
            // 
            // ProductEditorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtStock);
            Controls.Add(txtPrice);
            Controls.Add(txtName);
            Controls.Add(btnSave);
            Name = "ProductEditorForm";
            Text = "Product Editor";
            Load += ProductEditorForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtStock;
    }
}