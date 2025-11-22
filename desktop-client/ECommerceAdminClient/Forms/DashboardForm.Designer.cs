namespace ECommerceAdminClient.Forms
{
    partial class DashboardForm
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
            tabControl1 = new TabControl();
            tabProducts = new TabPage();
            btnRefreshProd = new MaterialSkin.Controls.MaterialButton();
            btnDeleteProd = new MaterialSkin.Controls.MaterialButton();
            btnEditProd = new MaterialSkin.Controls.MaterialButton();
            btnAddProd = new MaterialSkin.Controls.MaterialButton();
            gridProducts = new DataGridView();
            tabCategory = new TabPage();
            btnRefreshCat = new MaterialSkin.Controls.MaterialButton();
            btnDeleteCat = new MaterialSkin.Controls.MaterialButton();
            btnEditCat = new MaterialSkin.Controls.MaterialButton();
            btnAddCat = new MaterialSkin.Controls.MaterialButton();
            gridCategories = new DataGridView();
            tabUser = new TabPage();
            btnViewUser = new MaterialSkin.Controls.MaterialButton();
            gridUsers = new DataGridView();
            tabControl1.SuspendLayout();
            tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridProducts).BeginInit();
            tabCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCategories).BeginInit();
            tabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabProducts);
            tabControl1.Controls.Add(tabCategory);
            tabControl1.Controls.Add(tabUser);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 64);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(855, 405);
            tabControl1.TabIndex = 0;
            // 
            // tabProducts
            // 
            tabProducts.Controls.Add(btnRefreshProd);
            tabProducts.Controls.Add(btnDeleteProd);
            tabProducts.Controls.Add(btnEditProd);
            tabProducts.Controls.Add(btnAddProd);
            tabProducts.Controls.Add(gridProducts);
            tabProducts.Location = new Point(4, 29);
            tabProducts.Name = "tabProducts";
            tabProducts.Padding = new Padding(3);
            tabProducts.Size = new Size(847, 372);
            tabProducts.TabIndex = 0;
            tabProducts.Text = "Products";
            tabProducts.UseVisualStyleBackColor = true;
            tabProducts.Click += tabPage1_Click;
            // 
            // btnRefreshProd
            // 
            btnRefreshProd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRefreshProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRefreshProd.Depth = 0;
            btnRefreshProd.Dock = DockStyle.Top;
            btnRefreshProd.HighEmphasis = true;
            btnRefreshProd.Icon = null;
            btnRefreshProd.Location = new Point(603, 111);
            btnRefreshProd.Margin = new Padding(4, 6, 4, 6);
            btnRefreshProd.MouseState = MaterialSkin.MouseState.HOVER;
            btnRefreshProd.Name = "btnRefreshProd";
            btnRefreshProd.NoAccentTextColor = Color.Empty;
            btnRefreshProd.Size = new Size(241, 36);
            btnRefreshProd.TabIndex = 8;
            btnRefreshProd.Text = "Refresh Product(s)";
            btnRefreshProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRefreshProd.UseAccentColor = false;
            btnRefreshProd.UseVisualStyleBackColor = true;
            // 
            // btnDeleteProd
            // 
            btnDeleteProd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDeleteProd.Depth = 0;
            btnDeleteProd.Dock = DockStyle.Top;
            btnDeleteProd.HighEmphasis = true;
            btnDeleteProd.Icon = null;
            btnDeleteProd.Location = new Point(603, 75);
            btnDeleteProd.Margin = new Padding(4, 6, 4, 6);
            btnDeleteProd.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteProd.Name = "btnDeleteProd";
            btnDeleteProd.NoAccentTextColor = Color.Empty;
            btnDeleteProd.Size = new Size(241, 36);
            btnDeleteProd.TabIndex = 7;
            btnDeleteProd.Text = "Delete Product";
            btnDeleteProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDeleteProd.UseAccentColor = false;
            btnDeleteProd.UseVisualStyleBackColor = true;
            // 
            // btnEditProd
            // 
            btnEditProd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEditProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEditProd.Depth = 0;
            btnEditProd.Dock = DockStyle.Top;
            btnEditProd.HighEmphasis = true;
            btnEditProd.Icon = null;
            btnEditProd.Location = new Point(603, 39);
            btnEditProd.Margin = new Padding(4, 6, 4, 6);
            btnEditProd.MouseState = MaterialSkin.MouseState.HOVER;
            btnEditProd.Name = "btnEditProd";
            btnEditProd.NoAccentTextColor = Color.Empty;
            btnEditProd.Size = new Size(241, 36);
            btnEditProd.TabIndex = 6;
            btnEditProd.Text = "Edit Product";
            btnEditProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEditProd.UseAccentColor = false;
            btnEditProd.UseVisualStyleBackColor = true;
            // 
            // btnAddProd
            // 
            btnAddProd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddProd.Depth = 0;
            btnAddProd.Dock = DockStyle.Top;
            btnAddProd.HighEmphasis = true;
            btnAddProd.Icon = null;
            btnAddProd.Location = new Point(603, 3);
            btnAddProd.Margin = new Padding(4, 6, 4, 6);
            btnAddProd.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddProd.Name = "btnAddProd";
            btnAddProd.NoAccentTextColor = Color.Empty;
            btnAddProd.Size = new Size(241, 36);
            btnAddProd.TabIndex = 5;
            btnAddProd.Text = "Add Product";
            btnAddProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddProd.UseAccentColor = false;
            btnAddProd.UseVisualStyleBackColor = true;
            // 
            // gridProducts
            // 
            gridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProducts.Dock = DockStyle.Left;
            gridProducts.Location = new Point(3, 3);
            gridProducts.Name = "gridProducts";
            gridProducts.RowHeadersWidth = 51;
            gridProducts.Size = new Size(600, 366);
            gridProducts.TabIndex = 0;
            gridProducts.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tabCategory
            // 
            tabCategory.Controls.Add(btnRefreshCat);
            tabCategory.Controls.Add(btnDeleteCat);
            tabCategory.Controls.Add(btnEditCat);
            tabCategory.Controls.Add(btnAddCat);
            tabCategory.Controls.Add(gridCategories);
            tabCategory.Location = new Point(4, 29);
            tabCategory.Name = "tabCategory";
            tabCategory.Padding = new Padding(3);
            tabCategory.Size = new Size(847, 372);
            tabCategory.TabIndex = 1;
            tabCategory.Text = "Categories";
            tabCategory.UseVisualStyleBackColor = true;
            // 
            // btnRefreshCat
            // 
            btnRefreshCat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRefreshCat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRefreshCat.Depth = 0;
            btnRefreshCat.Dock = DockStyle.Top;
            btnRefreshCat.HighEmphasis = true;
            btnRefreshCat.Icon = null;
            btnRefreshCat.Location = new Point(603, 111);
            btnRefreshCat.Margin = new Padding(4, 6, 4, 6);
            btnRefreshCat.MouseState = MaterialSkin.MouseState.HOVER;
            btnRefreshCat.Name = "btnRefreshCat";
            btnRefreshCat.NoAccentTextColor = Color.Empty;
            btnRefreshCat.Size = new Size(241, 36);
            btnRefreshCat.TabIndex = 8;
            btnRefreshCat.Text = "Refresh Category";
            btnRefreshCat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRefreshCat.UseAccentColor = false;
            btnRefreshCat.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCat
            // 
            btnDeleteCat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteCat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDeleteCat.Depth = 0;
            btnDeleteCat.Dock = DockStyle.Top;
            btnDeleteCat.HighEmphasis = true;
            btnDeleteCat.Icon = null;
            btnDeleteCat.Location = new Point(603, 75);
            btnDeleteCat.Margin = new Padding(4, 6, 4, 6);
            btnDeleteCat.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteCat.Name = "btnDeleteCat";
            btnDeleteCat.NoAccentTextColor = Color.Empty;
            btnDeleteCat.Size = new Size(241, 36);
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
            btnEditCat.Dock = DockStyle.Top;
            btnEditCat.HighEmphasis = true;
            btnEditCat.Icon = null;
            btnEditCat.Location = new Point(603, 39);
            btnEditCat.Margin = new Padding(4, 6, 4, 6);
            btnEditCat.MouseState = MaterialSkin.MouseState.HOVER;
            btnEditCat.Name = "btnEditCat";
            btnEditCat.NoAccentTextColor = Color.Empty;
            btnEditCat.Size = new Size(241, 36);
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
            btnAddCat.Dock = DockStyle.Top;
            btnAddCat.HighEmphasis = true;
            btnAddCat.Icon = null;
            btnAddCat.Location = new Point(603, 3);
            btnAddCat.Margin = new Padding(4, 6, 4, 6);
            btnAddCat.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddCat.Name = "btnAddCat";
            btnAddCat.NoAccentTextColor = Color.Empty;
            btnAddCat.Size = new Size(241, 36);
            btnAddCat.TabIndex = 5;
            btnAddCat.Text = "Add Category";
            btnAddCat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddCat.UseAccentColor = false;
            btnAddCat.UseVisualStyleBackColor = true;
            // 
            // gridCategories
            // 
            gridCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCategories.Dock = DockStyle.Left;
            gridCategories.Location = new Point(3, 3);
            gridCategories.Name = "gridCategories";
            gridCategories.RowHeadersWidth = 51;
            gridCategories.Size = new Size(600, 366);
            gridCategories.TabIndex = 0;
            // 
            // tabUser
            // 
            tabUser.Controls.Add(btnViewUser);
            tabUser.Controls.Add(gridUsers);
            tabUser.Location = new Point(4, 29);
            tabUser.Name = "tabUser";
            tabUser.Padding = new Padding(3);
            tabUser.Size = new Size(847, 372);
            tabUser.TabIndex = 2;
            tabUser.Text = "Users";
            tabUser.UseVisualStyleBackColor = true;
            // 
            // btnViewUser
            // 
            btnViewUser.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnViewUser.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnViewUser.Depth = 0;
            btnViewUser.Dock = DockStyle.Top;
            btnViewUser.HighEmphasis = true;
            btnViewUser.Icon = null;
            btnViewUser.Location = new Point(603, 3);
            btnViewUser.Margin = new Padding(4, 6, 4, 6);
            btnViewUser.MouseState = MaterialSkin.MouseState.HOVER;
            btnViewUser.Name = "btnViewUser";
            btnViewUser.NoAccentTextColor = Color.Empty;
            btnViewUser.Size = new Size(241, 36);
            btnViewUser.TabIndex = 1;
            btnViewUser.Text = "View User Details and Orders";
            btnViewUser.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnViewUser.UseAccentColor = false;
            btnViewUser.UseVisualStyleBackColor = true;
            // 
            // gridUsers
            // 
            gridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsers.Dock = DockStyle.Left;
            gridUsers.Location = new Point(3, 3);
            gridUsers.Name = "gridUsers";
            gridUsers.RowHeadersWidth = 51;
            gridUsers.Size = new Size(600, 366);
            gridUsers.TabIndex = 0;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 472);
            Controls.Add(tabControl1);
            Name = "DashboardForm";
            Text = "Dashboard";
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

        private TabControl tabControl1;
        private TabPage tabProducts;
        private TabPage tabCategory;
        private TabPage tabUser;
        private DataGridView gridProducts;
        private DataGridView gridCategories;
        private DataGridView gridUsers;
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