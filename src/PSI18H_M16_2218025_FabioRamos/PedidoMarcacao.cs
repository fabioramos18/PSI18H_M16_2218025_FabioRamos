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
    public partial class PedidoMarcacao : Form
    {
        public PedidoMarcacao()
        {
            InitializeComponent();
            userControl21.Hide();
            Btn2.Visible = false;
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            
            userControl11.Hide();
            userControl21.Show();
            userControl21.BringToFront();
            Btn1.Visible = false;
            Btn2.Visible = true;
        }

        private void PedidoMarcacao_Load(object sender, EventArgs e)
        {

        }
    }
}
