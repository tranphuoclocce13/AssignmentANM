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
    public partial class ChangePortForm : Form
    {
        public int newPort = 0;
        public ChangePortForm()
        {
            InitializeComponent();
            tbNewPort.Select();
        }

        public void setOldPort(int port)
        {
            this.tbOldPort.Text = port.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            acceptChange();
        }

        private void acceptChange()
        {
            string port = tbNewPort.Text;
            if (port == "")
            {
                MessageBox.Show("You must input new Port!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            newPort = Int32.Parse(port);
        }

        private void tbNewPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acceptChange();
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void ChangePortForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
