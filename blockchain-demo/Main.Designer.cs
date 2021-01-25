namespace blockchain_demo
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.txt_Input = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_Error = new System.Windows.Forms.Label();
            this.pnl_Accounts = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_Help = new System.Windows.Forms.Label();
            this.btn_Python = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Address = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // txt_Input
            // 
            this.txt_Input.BorderColor = System.Drawing.Color.Red;
            this.txt_Input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Input.DefaultText = "";
            this.txt_Input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Input.DisabledState.Parent = this.txt_Input;
            this.txt_Input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Input.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.txt_Input.FocusedState.Parent = this.txt_Input;
            this.txt_Input.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_Input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Input.HoverState.Parent = this.txt_Input;
            this.txt_Input.Location = new System.Drawing.Point(218, 31);
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.PasswordChar = '\0';
            this.txt_Input.PlaceholderText = "";
            this.txt_Input.SelectedText = "";
            this.txt_Input.ShadowDecoration.Parent = this.txt_Input;
            this.txt_Input.Size = new System.Drawing.Size(570, 36);
            this.txt_Input.TabIndex = 0;
            this.txt_Input.TextChanged += new System.EventHandler(this.OnInputChanged);
            this.txt_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnInputCompleted);
            // 
            // lbl_Error
            // 
            this.lbl_Error.AutoSize = true;
            this.lbl_Error.Location = new System.Drawing.Point(215, 70);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(35, 13);
            this.lbl_Error.TabIndex = 1;
            this.lbl_Error.Text = "label1";
            // 
            // pnl_Accounts
            // 
            this.pnl_Accounts.AutoScroll = true;
            this.pnl_Accounts.Location = new System.Drawing.Point(4, 31);
            this.pnl_Accounts.Name = "pnl_Accounts";
            this.pnl_Accounts.Size = new System.Drawing.Size(208, 407);
            this.pnl_Accounts.TabIndex = 27;
            // 
            // lbl_Help
            // 
            this.lbl_Help.AutoSize = true;
            this.lbl_Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Help.Location = new System.Drawing.Point(389, 15);
            this.lbl_Help.Name = "lbl_Help";
            this.lbl_Help.Size = new System.Drawing.Size(221, 13);
            this.lbl_Help.TabIndex = 28;
            this.lbl_Help.Text = "Please type Help to see available commands.";
            // 
            // btn_Python
            // 
            this.btn_Python.BackColor = System.Drawing.Color.Transparent;
            this.btn_Python.CheckedState.Parent = this.btn_Python;
            this.btn_Python.CustomImages.Parent = this.btn_Python;
            this.btn_Python.FillColor = System.Drawing.Color.Transparent;
            this.btn_Python.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Python.ForeColor = System.Drawing.Color.White;
            this.btn_Python.HoverState.Parent = this.btn_Python;
            this.btn_Python.Image = ((System.Drawing.Image)(resources.GetObject("btn_Python.Image")));
            this.btn_Python.Location = new System.Drawing.Point(708, 414);
            this.btn_Python.Name = "btn_Python";
            this.btn_Python.ShadowDecoration.Parent = this.btn_Python;
            this.btn_Python.Size = new System.Drawing.Size(37, 27);
            this.btn_Python.TabIndex = 49;
            this.btn_Python.UseTransparentBackground = true;
            this.btn_Python.Click += new System.EventHandler(this.OnPythonClick);
            // 
            // btn_Address
            // 
            this.btn_Address.BackColor = System.Drawing.Color.Transparent;
            this.btn_Address.CheckedState.Parent = this.btn_Address;
            this.btn_Address.CustomImages.Parent = this.btn_Address;
            this.btn_Address.FillColor = System.Drawing.Color.Transparent;
            this.btn_Address.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Address.ForeColor = System.Drawing.Color.White;
            this.btn_Address.HoverState.Parent = this.btn_Address;
            this.btn_Address.Image = ((System.Drawing.Image)(resources.GetObject("btn_Address.Image")));
            this.btn_Address.Location = new System.Drawing.Point(751, 414);
            this.btn_Address.Name = "btn_Address";
            this.btn_Address.ShadowDecoration.Parent = this.btn_Address;
            this.btn_Address.Size = new System.Drawing.Size(37, 27);
            this.btn_Address.TabIndex = 50;
            this.btn_Address.UseTransparentBackground = true;
            this.btn_Address.Click += new System.EventHandler(this.OnAddressClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Address);
            this.Controls.Add(this.btn_Python);
            this.Controls.Add(this.lbl_Help);
            this.Controls.Add(this.pnl_Accounts);
            this.Controls.Add(this.lbl_Error);
            this.Controls.Add(this.txt_Input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txt_Input;
        private System.Windows.Forms.Label lbl_Error;
        public System.Windows.Forms.FlowLayoutPanel pnl_Accounts;
        private System.Windows.Forms.Label lbl_Help;
        private Guna.UI2.WinForms.Guna2Button btn_Python;
        private Guna.UI2.WinForms.Guna2Button btn_Address;
    }
}

