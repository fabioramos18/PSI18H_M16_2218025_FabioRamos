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
    public partial class Medicos : Form
    {
        public Medicos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // toggle panel
            if (panel3.Visible == true)
                panel3.Visible = false;
            else
                panel3.Visible = true;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
                panel3.Visible = true;
            else
                panel3.Visible = false;
        }
    }
}
