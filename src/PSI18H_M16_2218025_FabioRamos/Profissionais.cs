﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSI18H_M16_2218025_FabioRamos
{
    public partial class Profissionais : Form
    {
        public Profissionais()
        {
            InitializeComponent();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.ToString() == "a")
            {

                panel1.Visible = false;


            }
            else if (comboBox1.SelectedItem.ToString() == "bb")
            {

                panel1.Visible = true;
                panel2.Visible = true;
                panel8.Visible = true;
                panel5.Visible = true;



            }
        }
   
    }
}
