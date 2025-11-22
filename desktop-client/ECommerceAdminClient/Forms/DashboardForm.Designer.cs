namespace ECommerceAdminClient.Forms
{
    partial class DashboardForm
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
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.gridProducts = new System.Windows.Forms.DataGridView();
            this.btnRefreshProd = new MaterialSkin.Controls.MaterialButton();
            this.btnDeleteProd = new MaterialSkin.Controls.MaterialButton();
            this.btnEditProd = new MaterialSkin.Controls.MaterialButton();
            this.btnAddProd = new MaterialSkin.Controls.MaterialButton();
            this.tabCategory = new System.Windows.Forms.TabPage();
            this.gridCategories = new System.Windows.Forms.DataGridView();
            this.btnRefreshCat = new MaterialSkin.Controls.MaterialButton();
            this.btnDeleteCat = new MaterialSkin.Controls.MaterialButton();
            this.btnEditCat = new MaterialSkin.Controls.MaterialButton();
            this.btnAddCat = new MaterialSkin.Controls.MaterialButton();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.gridUsers = new System.Windows.Forms.DataGridView();
            this.btnViewUser = new MaterialSkin.Controls.MaterialButton();
            this.tabControl1.SuspendLayout();
            this.tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            this.tabCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategories)).BeginInit();
            this.tabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSelector (Navigation Bar)
            // 
            this.tabSelector.BaseTabControl = this.tabControl1;
            this.tabSelector.Depth = 0;
            this.tabSelector.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabSelector.Location = new System.Drawing.Point(0, 64); // Places it right below the header
            this.tabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabSelector.Name = "tabSelector";
            this.tabSelector.Size = new System.Drawing.Size(900, 48);
            this.tabSelector.TabIndex = 1;
            this.tabSelector.Text = "tabSelector";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProducts);
            this.tabControl1.Controls.Add(this.tabCategory);
            this.tabControl1.Controls.Add(this.tabUser);
            this.tabControl1.Depth = 0;
            this.tabControl1.Location = new System.Drawing.Point(0, 112); // Below selector
            this.tabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabProducts
            // 
            this.tabProducts.BackColor = System.Drawing.Color.White;
            this.tabProducts.Controls.Add(this.gridProducts);
            this.tabProducts.Controls.Add(this.btnRefreshProd);
            this.tabProducts.Controls.Add(this.btnDeleteProd);
            this.tabProducts.Controls.Add(this.btnEditProd);
            this.tabProducts.Controls.Add(this.btnAddProd);
            this.tabProducts.Location = new System.Drawing.Point(4, 29);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(892, 417);
            this.tabProducts.TabIndex = 0;
            this.tabProducts.Text = "Products";
            // 
            // gridProducts
            // 
            this.gridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProducts.Location = new System.Drawing.Point(20, 20);
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.RowHeadersWidth = 51;
            this.gridProducts.Size = new System.Drawing.Size(650, 380);
            this.gridProducts.TabIndex = 0;
            // 
            // btnAddProd
            // 
            this.btnAddProd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddProd.Depth = 0;
            this.btnAddProd.HighEmphasis = true;
            this.btnAddProd.Icon = null;
            this.btnAddProd.Location = new System.Drawing.Point(690, 20);
            this.btnAddProd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddProd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddProd.Name = "btnAddProd";
            this.btnAddProd.Size = new System.Drawing.Size(180, 36);
            this.btnAddProd.TabIndex = 5;
            this.btnAddProd.Text = "Add Product";
            this.btnAddProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddProd.UseAccentColor = false;
            this.btnAddProd.UseVisualStyleBackColor = true;
            this.btnAddProd.Click += new System.EventHandler(this.btnAddProd_Click);
            // 
            // btnEditProd
            // 
            this.btnEditProd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEditProd.Depth = 0;
            this.btnEditProd.HighEmphasis = true;
            this.btnEditProd.Icon = null;
            this.btnEditProd.Location = new System.Drawing.Point(690, 70);
            this.btnEditProd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEditProd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditProd.Name = "btnEditProd";
            this.btnEditProd.Size = new System.Drawing.Size(180, 36);
            this.btnEditProd.TabIndex = 6;
            this.btnEditProd.Text = "Edit Product";
            this.btnEditProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEditProd.UseAccentColor = false;
            this.btnEditProd.UseVisualStyleBackColor = true;
            this.btnEditProd.Click += new System.EventHandler(this.btnEditProd_Click);
            // 
            // btnDeleteProd
            // 
            this.btnDeleteProd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDeleteProd.Depth = 0;
            this.btnDeleteProd.HighEmphasis = true;
            this.btnDeleteProd.Icon = null;
            this.btnDeleteProd.Location = new System.Drawing.Point(690, 120);
            this.btnDeleteProd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteProd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteProd.Name = "btnDeleteProd";
            this.btnDeleteProd.Size = new System.Drawing.Size(180, 36);
            this.btnDeleteProd.TabIndex = 7;
            this.btnDeleteProd.Text = "Delete Product";
            this.btnDeleteProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeleteProd.UseAccentColor = false;
            this.btnDeleteProd.UseVisualStyleBackColor = true;
            this.btnDeleteProd.Click += new System.EventHandler(this.btnDeleteProd_Click);
            // 
            // btnRefreshProd
            // 
            this.btnRefreshProd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefreshProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRefreshProd.Depth = 0;
            this.btnRefreshProd.HighEmphasis = true;
            this.btnRefreshProd.Icon = null;
            this.btnRefreshProd.Location = new System.Drawing.Point(690, 170);
            this.btnRefreshProd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefreshProd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefreshProd.Name = "btnRefreshProd";
            this.btnRefreshProd.Size = new System.Drawing.Size(180, 36);
            this.btnRefreshProd.TabIndex = 8;
            this.btnRefreshProd.Text = "Refresh";
            this.btnRefreshProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRefreshProd.UseAccentColor = false;
            this.btnRefreshProd.UseVisualStyleBackColor = true;
            // 
            // tabCategory
            // 
            this.tabCategory.BackColor = System.Drawing.Color.White;
            this.tabCategory.Controls.Add(this.gridCategories);
            this.tabCategory.Controls.Add(this.btnRefreshCat);
            this.tabCategory.Controls.Add(this.btnDeleteCat);
            this.tabCategory.Controls.Add(this.btnEditCat);
            this.tabCategory.Controls.Add(this.btnAddCat);
            this.tabCategory.Location = new System.Drawing.Point(4, 29);
            this.tabCategory.Name = "tabCategory";
            this.tabCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategory.Size = new System.Drawing.Size(892, 417);
            this.tabCategory.TabIndex = 1;
            this.tabCategory.Text = "Categories";
            // 
            // gridCategories
            // 
            this.gridCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCategories.Location = new System.Drawing.Point(20, 20);
            this.gridCategories.Name = "gridCategories";
            this.gridCategories.RowHeadersWidth = 51;
            this.gridCategories.Size = new System.Drawing.Size(650, 380);
            this.gridCategories.TabIndex = 0;
            // 
            // btnAddCat
            // 
            this.btnAddCat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddCat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddCat.Depth = 0;
            this.btnAddCat.HighEmphasis = true;
            this.btnAddCat.Icon = null;
            this.btnAddCat.Location = new System.Drawing.Point(690, 20);
            this.btnAddCat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddCat.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddCat.Name = "btnAddCat";
            this.btnAddCat.Size = new System.Drawing.Size(180, 36);
            this.btnAddCat.TabIndex = 5;
            this.btnAddCat.Text = "Add Category";
            this.btnAddCat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddCat.UseAccentColor = false;
            this.btnAddCat.UseVisualStyleBackColor = true;
            this.btnAddCat.Click += new System.EventHandler(this.btnAddCat_Click);
            // 
            // btnEditCat
            // 
            this.btnEditCat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditCat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEditCat.Depth = 0;
            this.btnEditCat.HighEmphasis = true;
            this.btnEditCat.Icon = null;
            this.btnEditCat.Location = new System.Drawing.Point(690, 70);
            this.btnEditCat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEditCat.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditCat.Name = "btnEditCat";
            this.btnEditCat.Size = new System.Drawing.Size(180, 36);
            this.btnEditCat.TabIndex = 6;
            this.btnEditCat.Text = "Edit Category";
            this.btnEditCat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEditCat.UseAccentColor = false;
            this.btnEditCat.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCat
            // 
            this.btnDeleteCat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteCat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDeleteCat.Depth = 0;
            this.btnDeleteCat.HighEmphasis = true;
            this.btnDeleteCat.Icon = null;
            this.btnDeleteCat.Location = new System.Drawing.Point(690, 120);
            this.btnDeleteCat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteCat.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteCat.Name = "btnDeleteCat";
            this.btnDeleteCat.Size = new System.Drawing.Size(180, 36);
            this.btnDeleteCat.TabIndex = 7;
            this.btnDeleteCat.Text = "Delete Category";
            this.btnDeleteCat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeleteCat.UseAccentColor = false;
            this.btnDeleteCat.UseVisualStyleBackColor = true;
            // 
            // btnRefreshCat
            // 
            this.btnRefreshCat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefreshCat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRefreshCat.Depth = 0;
            this.btnRefreshCat.HighEmphasis = true;
            this.btnRefreshCat.Icon = null;
            this.btnRefreshCat.Location = new System.Drawing.Point(690, 170);
            this.btnRefreshCat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefreshCat.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefreshCat.Name = "btnRefreshCat";
            this.btnRefreshCat.Size = new System.Drawing.Size(180, 36);
            this.btnRefreshCat.TabIndex = 8;
            this.btnRefreshCat.Text = "Refresh";
            this.btnRefreshCat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRefreshCat.UseAccentColor = false;
            this.btnRefreshCat.UseVisualStyleBackColor = true;
            // 
            // tabUser
            // 
            this.tabUser.BackColor = System.Drawing.Color.White;
            this.tabUser.Controls.Add(this.gridUsers);
            this.tabUser.Controls.Add(this.btnViewUser);
            this.tabUser.Location = new System.Drawing.Point(4, 29);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(892, 417);
            this.tabUser.TabIndex = 2;
            this.tabUser.Text = "Users";
            // 
            // gridUsers
            // 
            this.gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsers.Location = new System.Drawing.Point(20, 20);
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.RowHeadersWidth = 51;
            this.gridUsers.Size = new System.Drawing.Size(650, 380);
            this.gridUsers.TabIndex = 0;
            // 
            // btnViewUser
            // 
            this.btnViewUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnViewUser.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnViewUser.Depth = 0;
            this.btnViewUser.HighEmphasis = true;
            this.btnViewUser.Icon = null;
            this.btnViewUser.Location = new System.Drawing.Point(690, 20);
            this.btnViewUser.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnViewUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnViewUser.Name = "btnViewUser";
            this.btnViewUser.Size = new System.Drawing.Size(180, 36);
            this.btnViewUser.TabIndex = 1;
            this.btnViewUser.Text = "View Details";
            this.btnViewUser.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnViewUser.UseAccentColor = false;
            this.btnViewUser.UseVisualStyleBackColor = true;
            this.btnViewUser.Click += new System.EventHandler(this.btnViewUser_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 570);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tabSelector);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            this.tabProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            this.tabCategory.ResumeLayout(false);
            this.tabCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategories)).EndInit();
            this.tabUser.ResumeLayout(false);
            this.tabUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector tabSelector;
        private MaterialSkin.Controls.MaterialTabControl tabControl1;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabCategory;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.DataGridView gridProducts;
        private System.Windows.Forms.DataGridView gridCategories;
        private System.Windows.Forms.DataGridView gridUsers;
        private MaterialSkin.Controls.MaterialButton btnDeleteProd;
        private MaterialSkin.Controls.MaterialButton btnEditProd;
        private MaterialSkin.Controls.MaterialButton btnAddProd;
        private MaterialSkin.Controls.MaterialButton btnRefreshProd;
        private MaterialSkin.Controls.MaterialButton btnRefreshCat;
        private MaterialSkin.Controls.MaterialButton btnDeleteCat;
        private MaterialSkin.Controls.MaterialButton btnEditCat;
        private MaterialSkin.Controls.MaterialButton btnAddCat;
        private MaterialSkin.Controls.MaterialButton btnViewUser;
    }
}