using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace PSI18H_M16_2218025_FabioRamos
{
    public partial class Entrar : Form
    {
       
        public Entrar()
        {
            InitializeComponent();
        }

        //----------------------------ARRASTAR O FORM-----------------------------------\\

        bool drag = false;
        Point start_point = new Point(0, 0);
        private void panel7_MouseDown_1(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel7_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
               Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }
       
        //-------------------------------------------------------------------------------\\


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        public static string passingText2;

        private void button1_Click(object sender, EventArgs e)
        {
            MDB mdb = new MDB();

            String username = TextboxUser.Text;
            String password = TextboxPassword.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE (`user`collate utf8_bin) = @usn AND (`passe` collate utf8_bin) = @pass", mdb.getConnection());
            
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            
            adapter.SelectCommand = command;
            
            adapter.Fill(table);


            //ver se u utilizador existe ou não
        

            if (TextboxUser.Text.Equals("Admin") && TextboxPassword.Text.Equals("Admin"))
            {
                Admin adminform = new Admin();
                this.Hide();
                adminform.Show();
            }
            else if (table.Rows.Count > 0)
            {
                passingText2 = TextboxUser.Text;
                Loading loadingform = new Loading();
                this.Hide();
                loadingform.Show();
            }
            else
            {
                if(username.Trim().Equals(""))
                {
                    MessageBox.Show("Digite o seu nome de utilizador para fazer login", " Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Digite a sua palavra passe para fazer login", " Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Nome de utilizador ou senha incorretos", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.AcceptButton = buttonLogin;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registar registarform = new Registar();
            this.Hide();
            registarform.Show();
            
        }

        private void TextboxPasseword_OnValueChanged(object sender, EventArgs e)
        {
            TextboxPassword.isPassword = true;          
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
