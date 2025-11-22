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
            tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            tabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabProducts = new TabPage();
            gridProducts = new DataGridView();
            btnRefreshProd = new MaterialSkin.Controls.MaterialButton();
            btnDeleteProd = new MaterialSkin.Controls.MaterialButton();
            btnEditProd = new MaterialSkin.Controls.MaterialButton();
            btnAddProd = new MaterialSkin.Controls.MaterialButton();
            tabCategory = new TabPage();
            gridCategories = new DataGridView();
            btnRefreshCat = new MaterialSkin.Controls.MaterialButton();
            btnDeleteCat = new MaterialSkin.Controls.MaterialButton();
            btnEditCat = new MaterialSkin.Controls.MaterialButton();
            btnAddCat = new MaterialSkin.Controls.MaterialButton();
            tabUser = new TabPage();
            gridUsers = new DataGridView();
            btnViewUser = new MaterialSkin.Controls.MaterialButton();
            tabControl1.SuspendLayout();
            tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridProducts).BeginInit();
            tabCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCategories).BeginInit();
            tabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
            SuspendLayout();
            // 
            // tabSelector
            // 
            tabSelector.BaseTabControl = tabControl1;
            tabSelector.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            tabSelector.Depth = 0;
            tabSelector.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tabSelector.Location = new Point(0, 64);
            tabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            tabSelector.Name = "tabSelector";
            tabSelector.Size = new Size(900, 48);
            tabSelector.TabIndex = 1;
            tabSelector.Text = "tabSelector";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabProducts);
            tabControl1.Controls.Add(tabCategory);
            tabControl1.Controls.Add(tabUser);
            tabControl1.Depth = 0;
            tabControl1.Location = new Point(0, 112);
            tabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(900, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabProducts
            // 
            tabProducts.BackColor = Color.White;
            tabProducts.Controls.Add(gridProducts);
            tabProducts.Controls.Add(btnRefreshProd);
            tabProducts.Controls.Add(btnDeleteProd);
            tabProducts.Controls.Add(btnEditProd);
            tabProducts.Controls.Add(btnAddProd);
            tabProducts.Location = new Point(4, 29);
            tabProducts.Name = "tabProducts";
            tabProducts.Padding = new Padding(3);
            tabProducts.Size = new Size(892, 417);
            tabProducts.TabIndex = 0;
            tabProducts.Text = "Products";
            // 
            // gridProducts
            // 
            gridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProducts.Location = new Point(20, 20);
            gridProducts.Name = "gridProducts";
            gridProducts.RowHeadersWidth = 51;
            gridProducts.Size = new Size(650, 380);
            gridProducts.TabIndex = 0;
            // 
            // btnRefreshProd
            // 
            btnRefreshProd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRefreshProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRefreshProd.Depth = 0;
            btnRefreshProd.HighEmphasis = true;
            btnRefreshProd.Icon = null;
            btnRefreshProd.Location = new Point(690, 170);
            btnRefreshProd.Margin = new Padding(4, 6, 4, 6);
            btnRefreshProd.MouseState = MaterialSkin.MouseState.HOVER;
            btnRefreshProd.Name = "btnRefreshProd";
            btnRefreshProd.NoAccentTextColor = Color.Empty;
            btnRefreshProd.Size = new Size(84, 36);
            btnRefreshProd.TabIndex = 8;
            btnRefreshProd.Text = "Refresh";
            btnRefreshProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRefreshProd.UseAccentColor = false;
            btnRefreshProd.UseVisualStyleBackColor = true;
            // 
            // btnDeleteProd
            // 
            btnDeleteProd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDeleteProd.Depth = 0;
            btnDeleteProd.HighEmphasis = true;
            btnDeleteProd.Icon = null;
            btnDeleteProd.Location = new Point(690, 120);
            btnDeleteProd.Margin = new Padding(4, 6, 4, 6);
            btnDeleteProd.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteProd.Name = "btnDeleteProd";
            btnDeleteProd.NoAccentTextColor = Color.Empty;
            btnDeleteProd.Size = new Size(144, 36);
            btnDeleteProd.TabIndex = 7;
            btnDeleteProd.Text = "Delete Product";
            btnDeleteProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDeleteProd.UseAccentColor = false;
            btnDeleteProd.UseVisualStyleBackColor = true;
            btnDeleteProd.Click += btnDeleteProd_Click;
            // 
            // btnEditProd
            // 
            btnEditProd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEditProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEditProd.Depth = 0;
            btnEditProd.HighEmphasis = true;
            btnEditProd.Icon = null;
            btnEditProd.Location = new Point(690, 70);
            btnEditProd.Margin = new Padding(4, 6, 4, 6);
            btnEditProd.MouseState = MaterialSkin.MouseState.HOVER;
            btnEditProd.Name = "btnEditProd";
            btnEditProd.NoAccentTextColor = Color.Empty;
            btnEditProd.Size = new Size(123, 36);
            btnEditProd.TabIndex = 6;
            btnEditProd.Text = "Edit Product";
            btnEditProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEditProd.UseAccentColor = false;
            btnEditProd.UseVisualStyleBackColor = true;
            btnEditProd.Click += btnEditProd_Click;
            // 
            // btnAddProd
            // 
            btnAddProd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddProd.Depth = 0;
            btnAddProd.HighEmphasis = true;
            btnAddProd.Icon = null;
            btnAddProd.Location = new Point(690, 20);
            btnAddProd.Margin = new Padding(4, 6, 4, 6);
            btnAddProd.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddProd.Name = "btnAddProd";
            btnAddProd.NoAccentTextColor = Color.Empty;
            btnAddProd.Size = new Size(121, 36);
            btnAddProd.TabIndex = 5;
            btnAddProd.Text = "Add Product";
            btnAddProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddProd.UseAccentColor = false;
            btnAddProd.UseVisualStyleBackColor = true;
            btnAddProd.Click += btnAddProd_Click;
            // 
            // tabCategory
            // 
            tabCategory.BackColor = Color.White;
            tabCategory.Controls.Add(gridCategories);
            tabCategory.Controls.Add(btnRefreshCat);
            tabCategory.Controls.Add(btnDeleteCat);
            tabCategory.Controls.Add(btnEditCat);
            tabCategory.Controls.Add(btnAddCat);
            tabCategory.Location = new Point(4, 29);
            tabCategory.Name = "tabCategory";
            tabCategory.Padding = new Padding(3);
            tabCategory.Size = new Size(892, 417);
            tabCategory.TabIndex = 1;
            tabCategory.Text = "Categories";
            // 
            // gridCategories
            // 
            gridCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCategories.Location = new Point(20, 20);
            gridCategories.Name = "gridCategories";
            gridCategories.RowHeadersWidth = 51;
            gridCategories.Size = new Size(650, 380);
            gridCategories.TabIndex = 0;
            // 
            // btnRefreshCat
            // 
            btnRefreshCat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRefreshCat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRefreshCat.Depth = 0;
            btnRefreshCat.HighEmphasis = true;
            btnRefreshCat.Icon = null;
            btnRefreshCat.Location = new Point(690, 170);
            btnRefreshCat.Margin = new Padding(4, 6, 4, 6);
            btnRefreshCat.MouseState = MaterialSkin.MouseState.HOVER;
            btnRefreshCat.Name = "btnRefreshCat";
            btnRefreshCat.NoAccentTextColor = Color.Empty;
            btnRefreshCat.Size = new Size(84, 36);
            btnRefreshCat.TabIndex = 8;
            btnRefreshCat.Text = "Refresh";
            btnRefreshCat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRefreshCat.UseAccentColor = false;
            btnRefreshCat.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCat
            // 
            btnDeleteCat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteCat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDeleteCat.Depth = 0;
            btnDeleteCat.HighEmphasis = true;
            btnDeleteCat.Icon = null;
            btnDeleteCat.Location = new Point(690, 120);
            btnDeleteCat.Margin = new Padding(4, 6, 4, 6);
            btnDeleteCat.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteCat.Name = "btnDeleteCat";
            btnDeleteCat.NoAccentTextColor = Color.Empty;
            btnDeleteCat.Size = new Size(152, 36);
            btnDeleteCat.TabIndex = 7;
            btnDeleteCat.Text = "Delete Category";
            btnDeleteCat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDeleteCat.UseAccentColor = false;
            btnDeleteCat.UseVisualStyleBackColor = true;
            // 
            // btnEditCat
            // 
            btnEditCat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEditCat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEditCat.Depth = 0;
            btnEditCat.HighEmphasis = true;
            btnEditCat.Icon = null;
            btnEditCat.Location = new Point(690, 70);
            btnEditCat.Margin = new Padding(4, 6, 4, 6);
            btnEditCat.MouseState = MaterialSkin.MouseState.HOVER;
            btnEditCat.Name = "btnEditCat";
            btnEditCat.NoAccentTextColor = Color.Empty;
            btnEditCat.Size = new Size(131, 36);
            btnEditCat.TabIndex = 6;
            btnEditCat.Text = "Edit Category";
            btnEditCat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEditCat.UseAccentColor = false;
            btnEditCat.UseVisualStyleBackColor = true;
            // 
            // btnAddCat
            // 
            btnAddCat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddCat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddCat.Depth = 0;
            btnAddCat.HighEmphasis = true;
            btnAddCat.Icon = null;
            btnAddCat.Location = new Point(690, 20);
            btnAddCat.Margin = new Padding(4, 6, 4, 6);
            btnAddCat.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddCat.Name = "btnAddCat";
            btnAddCat.NoAccentTextColor = Color.Empty;
            btnAddCat.Size = new Size(129, 36);
            btnAddCat.TabIndex = 5;
            btnAddCat.Text = "Add Category";
            btnAddCat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddCat.UseAccentColor = false;
            btnAddCat.UseVisualStyleBackColor = true;
            btnAddCat.Click += btnAddCat_Click;
            // 
            // tabUser
            // 
            tabUser.BackColor = Color.White;
            tabUser.Controls.Add(gridUsers);
            tabUser.Controls.Add(btnViewUser);
            tabUser.Location = new Point(4, 29);
            tabUser.Name = "tabUser";
            tabUser.Padding = new Padding(3);
            tabUser.Size = new Size(892, 417);
            tabUser.TabIndex = 2;
            tabUser.Text = "Users";
            // 
            // gridUsers
            // 
            gridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsers.Location = new Point(20, 20);
            gridUsers.Name = "gridUsers";
            gridUsers.RowHeadersWidth = 51;
            gridUsers.Size = new Size(650, 380);
            gridUsers.TabIndex = 0;
            // 
            // btnViewUser
            // 
            btnViewUser.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnViewUser.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnViewUser.Depth = 0;
            btnViewUser.HighEmphasis = true;
            btnViewUser.Icon = null;
            btnViewUser.Location = new Point(690, 20);
            btnViewUser.Margin = new Padding(4, 6, 4, 6);
            btnViewUser.MouseState = MaterialSkin.MouseState.HOVER;
            btnViewUser.Name = "btnViewUser";
            btnViewUser.NoAccentTextColor = Color.Empty;
            btnViewUser.Size = new Size(118, 36);
            btnViewUser.TabIndex = 1;
            btnViewUser.Text = "View Details";
            btnViewUser.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnViewUser.UseAccentColor = false;
            btnViewUser.UseVisualStyleBackColor = true;
            btnViewUser.Click += btnViewUser_Click;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 570);
            Controls.Add(tabControl1);
            Controls.Add(tabSelector);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            Load += DashboardForm_Load;
            tabControl1.ResumeLayout(false);
            tabProducts.ResumeLayout(false);
            tabProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridProducts).EndInit();
            tabCategory.ResumeLayout(false);
            tabCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridCategories).EndInit();
            tabUser.ResumeLayout(false);
            tabUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridUsers).EndInit();
            ResumeLayout(false);
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