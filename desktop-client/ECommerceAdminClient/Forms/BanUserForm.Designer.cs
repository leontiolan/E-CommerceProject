namespace ECommerceAdminClient.Forms
{
    partial class BanUserForm
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
            this.txtReason = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.btnConfirm = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.lblInstruction = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
             
            // txtReason
            this.txtReason.AnimateReadOnly = false;
            this.txtReason.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtReason.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReason.Depth = 0;
            this.txtReason.HideSelection = true;
            this.txtReason.Hint = "Enter ban reason...";
            this.txtReason.Location = new System.Drawing.Point(20, 110);
            this.txtReason.MaxLength = 32767;
            this.txtReason.MouseState = MaterialSkin.MouseState.OUT;
            this.txtReason.Name = "txtReason";
            this.txtReason.PasswordChar = '\0';
            this.txtReason.ReadOnly = false;
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtReason.SelectedText = "";
            this.txtReason.SelectionLength = 0;
            this.txtReason.SelectionStart = 0;
            this.txtReason.ShortcutsEnabled = true;
            this.txtReason.Size = new System.Drawing.Size(360, 100);
            this.txtReason.TabIndex = 0;
            this.txtReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtReason.UseSystemPasswordChar = false;
            
            // btnConfirm
            this.btnConfirm.AutoSize = false;
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConfirm.Depth = 0;
            this.btnConfirm.HighEmphasis = true;
            this.btnConfirm.Icon = null;
            this.btnConfirm.Location = new System.Drawing.Point(210, 230);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConfirm.Size = new System.Drawing.Size(170, 36);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "BAN USER";
            this.btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirm.UseAccentColor = true;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
             
            // btnCancel
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = false;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(20, 230);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(170, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
             
            // lblInstruction
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Depth = 0;
            this.lblInstruction.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInstruction.Location = new System.Drawing.Point(20, 80);
            this.lblInstruction.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(280, 19);
            this.lblInstruction.TabIndex = 3;
            this.lblInstruction.Text = "Please provide a reason for banning this user.";
            
            // BanUserForm 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtReason);
            this.Name = "BanUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ban User";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtReason;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialLabel lblInstruction;
    }
}