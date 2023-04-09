using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W6_BRYAN_C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int Guessingint;

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (TBInputUser.Text != "")
            {
                if (Convert.ToInt32(TBInputUser.Text) > 3)
                {
                    Form2 f2 = new Form2();
                    Guessingint = Convert.ToInt32(TBInputUser.Text);
                    f2.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Input more than 3 tries", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Input a number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBInputUser_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
