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
    public partial class Registar : Form
    {
        public Registar()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Regitar_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void TextboxName_Enter(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //adicionar novo user

            MDB mdb = new MDB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(, `nomecompleto`, `email`, `username`, `password`) VALUES (@nc, @email, @usn, @pass)", mdb.GetConnection());
            
            command.Parameters.Add("@nc", MySqlDbType.VarChar).Value = TextboxCompleteName;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = TextboxEmail;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = TextboxUserName;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = TextboxPassword;


            //open conection


        }
    }
}
