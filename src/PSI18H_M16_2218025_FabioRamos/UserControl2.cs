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
            #region validação 
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Insira apenas números", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            #endregion
        }

        private void txtNomeCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region validação 
            if ((e.KeyChar >= 33 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 191 || e.KeyChar >= 246 && e.KeyChar <= 248))     
            {
                MessageBox.Show("Apenas letras (a-z)", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            #endregion
        }
        
        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region validação 
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255))
              {
                   MessageBox.Show("Insira apenas números", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   e.Handled = true;
                   return;
            }
            #endregion
        }

        private void txtMorada_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region validação 
            if ((e.KeyChar >= 33 && e.KeyChar <= 43 || e.KeyChar >=60 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 185 || e.KeyChar >= 187 && e.KeyChar <= 191 || e.KeyChar >= 246 && e.KeyChar <= 248))
            {
                MessageBox.Show("Caracter invalido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            #endregion
        }

        public static string passingText2;
        public static string passingText3;
        public static string passingText4;
        public static string passingText5;
        public static string passingText6;
        public static string passingText7;


        //verificar se  textbox contém os valores padrão
        Boolean VerificarValoresTextBoxes()
        {
            String completename = txtNomeCompleto.Text;
            String nsaude = txtNSaude.Text;
            String cont = txtContacto.Text;
            String mor = txtMorada.Text;


            if (completename.Equals("") || nsaude.Equals("") || cont.Equals("") || mor.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            //verificar se as textbox teem valores padrao
            if (!VerificarValoresTextBoxes())
            { 
                passingText2 = txtNomeCompleto.Text;
                passingText3 = txtNSaude.Text;
                passingText4 = txtContacto.Text;
                passingText5 = dateTimePicker1.Text;
                passingText6 = txtMorada.Text;
                this.Hide();
                this.Parent.Controls.Add(new UserControl3());
            }
            else
            {
                MessageBox.Show("Preencha os campos com informação valida", "Empty Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Parent.Controls.Add(new UserControl1());
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;

            MaxContacto();
            MaxNumSaude();
        }


        //max numeros para buniffu textbox
        public void MaxContacto()
        {
          #region 
            foreach (var ctl in txtContacto.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    var txt = (TextBox)ctl;
                    txt.MaxLength = 9;
                }
            }
            #endregion
        }
        public void MaxNumSaude()
        {
            #region 
            foreach (var ctl in txtNSaude.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    var txt = (TextBox)ctl;
                    txt.MaxLength = 10;
                }
            }
            #endregion
        }


    }
}
