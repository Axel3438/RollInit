﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RollInitiative
{
    public partial class Form2 : Form
    {
        public event EventHandler IHasText;
        public Form2()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //load this file/create file
        private void Button1_Click(object sender, EventArgs e)
        {
            IHasText?.Invoke(textBox1, null);
            Close();
        }

        //cancel
        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
