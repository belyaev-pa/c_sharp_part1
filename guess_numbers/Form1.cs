﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guess_number
{
    public partial class Form1 : Form
    {
        static private Random rnd = new Random();
        private int number = rnd.Next(1, 101);
        public Form1()
        {
            InitializeComponent();
            btnAnswer.Text = "Ответить";
            lblTry.Text = "0";
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (int.Parse(userAnswer.Text)==number)
            {
                lblResult.Text = "Верно!";
            }
            else
            {
                lblResult.Text = "Неверно!";
                lblTry.Text = (int.Parse(lblTry.Text) + 1).ToString();
            }
        }
    }
}
