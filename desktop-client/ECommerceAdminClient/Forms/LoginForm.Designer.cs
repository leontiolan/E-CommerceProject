namespace ECommerceAdminClient.Forms
{
    partial class LoginForm
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
            this.txtUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.btnGoToRegister = new MaterialSkin.Controls.MaterialButton(); 
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUsername.Hint = "Username";
            this.txtUsername.Location = new System.Drawing.Point(50, 100);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(300, 50);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.Hint = "Password";
            this.txtPassword.Location = new System.Drawing.Point(50, 170);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Password = true;
            this.txtPassword.Size = new System.Drawing.Size(300, 50);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "";
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = false;
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(50, 250);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogin.Size = new System.Drawing.Size(300, 45);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.UseAccentColor = false;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnGoToRegister
            // 
            this.btnGoToRegister.AutoSize = false;
            this.btnGoToRegister.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGoToRegister.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGoToRegister.Depth = 0;
            this.btnGoToRegister.HighEmphasis = false; // Less emphasis than Login
            this.btnGoToRegister.Icon = null;
            this.btnGoToRegister.Location = new System.Drawing.Point(50, 310);
            this.btnGoToRegister.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGoToRegister.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGoToRegister.Name = "btnGoToRegister";
            this.btnGoToRegister.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGoToRegister.Size = new System.Drawing.Size(300, 36);
            this.btnGoToRegister.TabIndex = 3;
            this.btnGoToRegister.Text = "Create Admin Account";
            this.btnGoToRegister.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGoToRegister.UseAccentColor = false;
            this.btnGoToRegister.UseVisualStyleBackColor = true;
            this.btnGoToRegister.Click += new System.EventHandler(this.btnGoToRegister_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400); // Slightly taller
            this.Controls.Add(this.btnGoToRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Login";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtUsername;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private MaterialSkin.Controls.MaterialButton btnGoToRegister;
    }
}