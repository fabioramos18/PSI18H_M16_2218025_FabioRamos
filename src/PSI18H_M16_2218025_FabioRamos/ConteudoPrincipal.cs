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
    public partial class ConteudoPrincipal : Form
    {
        public ConteudoPrincipal()
        {
            InitializeComponent();
        }

        private void ConteudoPrincipal_Load(object sender, EventArgs e)
        {
            contMedico();
            contUsers();
        }
        
        private void contMedico()
        {
            #region COUNT quantidade de Medicos
            MDB mdb = new MDB();
            {
                try
                {
                    mdb.openConnection();
                    DataTable table = new DataTable();
                    MySqlCommand command = new MySqlCommand("SELECT count(distinct idMedico )  FROM medico ", mdb.getConnection());
                    command.Parameters.Clear();
                    command.CommandType = CommandType.Text;
                    MySqlDataReader dr;
                    dr = command.ExecuteReader();
                    dr.Read();
                    label19.Text = dr.GetString(0);

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
            #endregion
        }
        

        
        private void contUsers()
        {
            #region COUNT quantidade de utillizadores
            MDB mdb = new MDB();
            {
                try
                {
                    mdb.openConnection();
                    DataTable table = new DataTable();
                    MySqlCommand command = new MySqlCommand("SELECT count(distinct id_user)  FROM user", mdb.getConnection());
                    command.Parameters.Clear();
                    command.CommandType = CommandType.Text;
                    MySqlDataReader dr;
                    dr = command.ExecuteReader();
                    dr.Read();
                    label18.Text = dr.GetString(0);

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
            #endregion
        }
        

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            panel7.Visible = true;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }

    }
}
