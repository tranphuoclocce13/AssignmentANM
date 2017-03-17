using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssigmentForm
{
    public partial class InputIPForm : Form
    {
        public string IP;
        public int port;
        public InputIPForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            acceptConnection();
        }

        private void acceptConnection()
        {
            string p = tbPort.Text;
            IP = tbIPAddress.Text;
            if (IP == "" || p == "")
            {
                MessageBox.Show("Invalid IP or Port", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            port = Int32.Parse(p);
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
