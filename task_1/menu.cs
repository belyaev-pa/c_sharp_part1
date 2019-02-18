using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Udvoitel
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            playButton.Text = "Играть";
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }
    }
}
