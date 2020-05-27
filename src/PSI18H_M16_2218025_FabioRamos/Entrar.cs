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

        private void button1_Click(object sender, EventArgs e)
        {
            MDB mdb = new MDB();

            String username = TextboxUser.Text;
            String password = TextboxPassword.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username`= @usn AND`password` = @pass", mdb.GetConnection());
            
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            
            adapter.SelectCommand = command;
            
            adapter.Fill(table);


            //ver se u utilizador existe ou não


            if (table.Rows.Count > 0)
            {
                MessageBox.Show("YES");
            }
            else
            {
                MessageBox.Show("NO");
            }


            Principal Outroform = new Principal();
            Outroform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registar Outroform = new Registar();
            Outroform.ShowDialog();
        }

        private void TextboxPasseword_OnValueChanged(object sender, EventArgs e)
        {
            TextboxPassword.isPassword = true;          
        }
    }
}
