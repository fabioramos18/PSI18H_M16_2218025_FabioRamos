using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PSI18H_M16_2218025_FabioRamos
{
    public partial class Registar : Form
    {
        public Registar()
        {
            InitializeComponent();
        }


        

        public static bool ValidarEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void TextboxCompleteName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 191 || e.KeyChar >= 246 && e.KeyChar <= 248))
            {
                MessageBox.Show("Apenas letras (a-z)", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TextboxUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 45 || e.KeyChar == 47 || e.KeyChar >= 58 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 94 ||
                e.KeyChar == 96 || e.KeyChar >= 123 && e.KeyChar <= 191 || e.KeyChar >= 246 && e.KeyChar <= 248))
            {
                MessageBox.Show("Apenas letras (a-z)", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }


        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            //adicionar novo user

            MDB mdb = new MDB();

            {
                string sql = $@"INSERT INTO `user`(`nome_completo`, `email`, `user`, `passe`) VALUES (@nc, @email, @usn, @pass)";
                    MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());

                command.Parameters.Add("@nc", MySqlDbType.VarChar).Value = TextboxCompleteName.Text;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = TextboxEmail.Text;
                command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = TextboxUserName.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = TextboxPassword.Text;


                try
                {
                    //abrir conecção
                    mdb.openConnection();


                    //verificar se as textbox teem valores padrao
                    if (!VerificarValoresTextBoxes())
                    {
                        //verificar se as passwords são iguais
                        if (TextboxPassword.Text.Equals(TextboxPasswordConfirm.Text))
                        {
                            //verificar email
                            if (ValidarEmail(TextboxEmail.Text))
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
                                MessageBox.Show("Email com formato incorreto!", "ef3.Cinco");
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
                }
                catch (Exception erro)
                {
                    throw erro;
                }
                finally
                {
                    mdb.closeConnection();
                }
            }

        



            //VERIFICAR SE O USERNAME JA EXISTE

             Boolean verificarUserName()
            {

                String username = TextboxUserName.Text;
                
                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `user`= @usn ", mdb.getConnection());

                command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;               

                adapter.SelectCommand = command;

                adapter.Fill(table);

                //ver se o username existe na base de dados
                if (table.Rows.Count > 0)
                {
                    return true;                   
                }
                else
                {
                    return false;                   
                }            
             }

            //verificar se  textbox contém os valores padrão
            Boolean VerificarValoresTextBoxes()
            {
                String completename = TextboxCompleteName.Text;  
                String email = TextboxEmail.Text;
                String uname = TextboxUserName.Text;
                String pass = TextboxPassword.Text;


                if (completename.Equals("nome completo") || email.Equals("email")|| uname.Equals("nome utilizador") || pass.Equals("palavra-passe")  )
                {
                    return true;
                }
                else
                {
                    return false;
                }               
            }

        }


        bool drag = false;
        Point start_point = new Point(0, 0);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Entrar entrarform = new Entrar();
            this.Hide();
            entrarform.Show();
        }

       
    }
}
