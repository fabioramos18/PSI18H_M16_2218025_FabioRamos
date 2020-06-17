using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace PSI18H_M16_2218025_FabioRamos
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

       

      

        private void txtNSaude_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Insira apenas números", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNomeCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Apenas letras (a-z)", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Insira apenas números", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }



        public static string passingText2;
        public static string passingText3;
        public static string passingText4;
        public static string passingText5;
        public static string passingText6;
        public static string passingText7;




        private void Btn2_Click(object sender, EventArgs e)
        {
          //  DateTime data1 = Convert.ToDateTime(dateTimePicker1.text);
            passingText2 = txtNomeCompleto.Text;
            passingText3 = txtNSaude.Text;
            passingText4 = txtContacto.Text;
            passingText5 = dateTimePicker1.Text;
            passingText6 = txtMorada.Text;
            passingText7 = txtEmail.Text;
            this.Hide();
            this.Parent.Controls.Add(new UserControl3());
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            this.Parent.Controls.Add(new UserControl1());
        }
    }
}
