using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace PSI18H_M16_2218025_FabioRamos
{
    public partial class MarcarConsulta : Form
    {
        public MarcarConsulta()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NomeCompleto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MarcarConsulta_Load(object sender, EventArgs e)
        {

        }





        private void PedidoMarcar_Click(object sender, EventArgs e)
        {
            /* MDB mdb = new MDB();

             {
                 MySqlCommand command = new MySqlCommand("INSERT INTO `consulta`(`nomecompleto`, `email`, `username`, `password`, `textbox`) VALUES (@nc, @email, @usn, @pass, @tb)", mdb.getConnection());

                 command.Parameters.Add("@nc", MySqlDbType.VarChar).Value = TextboxCompleteName.Text;
                 command.Parameters.Add("@email", MySqlDbType.VarChar).Value = TextboxEmail.Text;
                 command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = TextboxUserName.Text;
                 command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = TextboxPassword.Text;
                 command.Parameters.Add("@tb", MySqlDbType.VarChar).Value = Especialidade.Text;

                 //abrir conecção
                 mdb.openConnection();


                 //verificar se as textbox teem valores padrao
                 if (!VerificarValoresTextBoxes())
                 {
                     //verificar se as passwords são iguais
                     if (TextboxPassword.Text.Equals(TextboxPasswordConfirm.Text))
                     {
                         // verificar se o username ja existe
                         if (verificarUserName())
                         {
                             MessageBox.Show("Esse nome de utilizador já existe. Experimente outro", " Username Duplicado ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                         }
                         else
                         {
                             //consultar os dados
                             if (command.ExecuteNonQuery() == 1)
                             {
                                 MessageBox.Show("A sua conta foi criada com sucesso", "Conta criada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                 Entrar entrarform = new Entrar();
                                 this.Hide();
                                 entrarform.Show();
                             }
                             else
                             {
                                 MessageBox.Show("ERRO");
                             }
                         }
                     }
                     else
                     {
                         MessageBox.Show("As palavras-passe não correspondiam. Tente novamente", "Erro Passe", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                     }
                 }

                 else
                 {
                     MessageBox.Show("Preencha os campos com informação valida", "Empty Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                 }

                 //fechar conecção
                 mdb.closeConnection();
             }*/
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
