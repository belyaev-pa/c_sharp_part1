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
    public partial class Form1 : Form
    {
        List<int> tmp = new List<int>();
        public Form1()
        {
            InitializeComponent();
            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Сброс";
            btnUndo.Text = "Undo";
            lblNumber.Text = "0";
            this.Text = "Удвоитель";
            commands.Text = "0";
            //List<int> tmp = new List<int>;

        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            tmp.Add(int.Parse(lblNumber.Text) + 1);
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            commands.Text = (int.Parse(commands.Text) + 1).ToString();            
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            tmp.Add(int.Parse(lblNumber.Text) * 2);
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            commands.Text = (int.Parse(commands.Text) + 1).ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tmp.Add(1);
            lblNumber.Text = "1";
            commands.Text = (int.Parse(commands.Text) + 1).ToString();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (tmp.Count > 0)
            {
                lblNumber.Text = $"{tmp[tmp.Count - 1]}";
                tmp.RemoveAt(tmp.Count - 1);
                commands.Text = (int.Parse(commands.Text) + 1).ToString();
            }            
        }
    }
}
