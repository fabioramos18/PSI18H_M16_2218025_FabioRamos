using System;
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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void movepanel(Control btn)
        {
            panelSlide.Width = btn.Width;
            panelSlide.Left = btn.Left;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            movepanel(button1);
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            movepanel(button2);
            panel2.Visible = false;
            panel4.Visible = false;
            panel3.Visible = true;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Medicos medicosform = new Medicos();
            this.Hide();
            medicosform.Show();
              movepanel(button3);
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

       
    }
}
