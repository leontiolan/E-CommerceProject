namespace ECommerceAdminClient.Forms
{
    partial class ProductEditorForm
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
            this.txtName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDescription = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPrice = new MaterialSkin.Controls.MaterialTextBox();
            this.txtStock = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbCategory = new MaterialSkin.Controls.MaterialComboBox();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.txtImages = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.btnUploadImage = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();

            // txtName
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Depth = 0;
            this.txtName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtName.Hint = "Product Name";
            this.txtName.Location = new System.Drawing.Point(20, 80);
            this.txtName.MaxLength = 50;
            this.txtName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(360, 50);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "";

            // txtPrice
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Depth = 0;
            this.txtPrice.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPrice.Hint = "Price (e.g., 99.99)";
            this.txtPrice.Location = new System.Drawing.Point(20, 140);
            this.txtPrice.MaxLength = 50;
            this.txtPrice.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPrice.Multiline = false;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(170, 50);
            this.txtPrice.TabIndex = 1;
            this.txtPrice.Text = "";

            // txtStock 
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStock.Depth = 0;
            this.txtStock.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtStock.Hint = "Stock Quantity";
            this.txtStock.Location = new System.Drawing.Point(210, 140);
            this.txtStock.MaxLength = 50;
            this.txtStock.MouseState = MaterialSkin.MouseState.OUT;
            this.txtStock.Multiline = false;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(170, 50);
            this.txtStock.TabIndex = 2;
            this.txtStock.Text = "";

            // cmbCategory
            this.cmbCategory.AutoResize = false;
            this.cmbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbCategory.Depth = 0;
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbCategory.DropDownHeight = 174;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.DropDownWidth = 121;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Hint = "Category";
            this.cmbCategory.IntegralHeight = false;
            this.cmbCategory.ItemHeight = 43;
            this.cmbCategory.Location = new System.Drawing.Point(20, 200);
            this.cmbCategory.MaxDropDownItems = 4;
            this.cmbCategory.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(360, 49);
            this.cmbCategory.StartIndex = 0;
            this.cmbCategory.TabIndex = 3;

            // txtDescription 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Depth = 0;
            this.txtDescription.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDescription.Hint = "Description";
            this.txtDescription.Location = new System.Drawing.Point(20, 260);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(360, 50);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.Text = "";

            // txtImages 
            this.txtImages.AnimateReadOnly = false;
            this.txtImages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtImages.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtImages.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtImages.Depth = 0;
            this.txtImages.HideSelection = true;
            this.txtImages.Hint = "Image URLs (One per line)";
            this.txtImages.Location = new System.Drawing.Point(20, 320);
            this.txtImages.MaxLength = 32767;
            this.txtImages.MouseState = MaterialSkin.MouseState.OUT;
            this.txtImages.Name = "txtImages";
            this.txtImages.PasswordChar = '\0';
            this.txtImages.ReadOnly = false;
            this.txtImages.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtImages.SelectedText = "";
            this.txtImages.SelectionLength = 0;
            this.txtImages.SelectionStart = 0;
            this.txtImages.ShortcutsEnabled = true;
            this.txtImages.Size = new System.Drawing.Size(260, 100); 
            this.txtImages.TabIndex = 5;
            this.txtImages.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtImages.UseSystemPasswordChar = false;

            // btnUploadImage (New Button)
            this.btnUploadImage.AutoSize = false;
            this.btnUploadImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUploadImage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnUploadImage.Depth = 0;
            this.btnUploadImage.HighEmphasis = true;
            this.btnUploadImage.Icon = null;
            this.btnUploadImage.Location = new System.Drawing.Point(290, 320);
            this.btnUploadImage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUploadImage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnUploadImage.Size = new System.Drawing.Size(90, 100);
            this.btnUploadImage.TabIndex = 8;
            this.btnUploadImage.Text = "UPLOAD PHOTO";
            this.btnUploadImage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUploadImage.UseAccentColor = false;
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);

            // btnSave
            this.btnSave.AutoSize = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(210, 440);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(170, 36);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "SAVE";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = false;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(20, 440);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(170, 36);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ProductEditorForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.btnUploadImage); 
            this.Controls.Add(this.txtImages);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Name = "ProductEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Editor";
            this.ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtName;
        private MaterialSkin.Controls.MaterialTextBox txtPrice;
        private MaterialSkin.Controls.MaterialTextBox txtStock;
        private MaterialSkin.Controls.MaterialTextBox txtDescription;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtImages;
        private MaterialSkin.Controls.MaterialComboBox cmbCategory;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnUploadImage; 
    }
}