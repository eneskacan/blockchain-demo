namespace blockchain_demo
{
    partial class Account
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Account));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lbl_Username = new System.Windows.Forms.Label();
            this.lbl_Balance = new System.Windows.Forms.Label();
            this.btn_Copy = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Username.Location = new System.Drawing.Point(7, 10);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(83, 20);
            this.lbl_Username.TabIndex = 45;
            this.lbl_Username.Text = "Username";
            // 
            // lbl_Balance
            // 
            this.lbl_Balance.AutoSize = true;
            this.lbl_Balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lbl_Balance.Location = new System.Drawing.Point(96, 16);
            this.lbl_Balance.Name = "lbl_Balance";
            this.lbl_Balance.Size = new System.Drawing.Size(35, 13);
            this.lbl_Balance.TabIndex = 46;
            this.lbl_Balance.Text = "1 BTC";
            // 
            // btn_Copy
            // 
            this.btn_Copy.BackColor = System.Drawing.Color.Transparent;
            this.btn_Copy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Copy.BackgroundImage")));
            this.btn_Copy.CheckedState.Parent = this.btn_Copy;
            this.btn_Copy.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("btn_Copy.CustomImages.Image")));
            this.btn_Copy.CustomImages.Parent = this.btn_Copy;
            this.btn_Copy.FillColor = System.Drawing.Color.Transparent;
            this.btn_Copy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Copy.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Copy.HoverState.Parent = this.btn_Copy;
            this.btn_Copy.Location = new System.Drawing.Point(137, 10);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.ShadowDecoration.Parent = this.btn_Copy;
            this.btn_Copy.Size = new System.Drawing.Size(37, 27);
            this.btn_Copy.TabIndex = 47;
            this.btn_Copy.UseTransparentBackground = true;
            this.btn_Copy.Click += new System.EventHandler(this.OnCopyPressed);
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.lbl_Balance);
            this.Controls.Add(this.lbl_Username);
            this.Name = "Account";
            this.Size = new System.Drawing.Size(176, 44);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Label lbl_Balance;
        private Guna.UI2.WinForms.Guna2Button btn_Copy;
    }
}
