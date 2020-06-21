﻿using System;
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
        #region COUNT quantidade de Medicos
        private void contMedico()
        {
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
        }
        #endregion

        #region COUNT quantidade de utillizadores
        private void contUsers()
        {
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
        }
        #endregion

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
