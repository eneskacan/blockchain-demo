using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blockchain_demo
{
    public partial class Account : UserControl
    {
        string address;
        public Account(string username, string address, string balance, string coinname)
        {
            InitializeComponent();

            lbl_Username.Text = username;
            lbl_Balance.Text = $"{balance} {coinname}";

            this.address = address;
        }

        private void OnCopyPressed(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(this.address);
            MessageBox.Show(this.address, "Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
