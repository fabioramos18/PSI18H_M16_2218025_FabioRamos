﻿ using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PSI18H_M16_2218025_FabioRamos
{
    public partial class ucConsultas : UserControl
    {
        public ucConsultas()
        {
            InitializeComponent();
        }

        private static ucConsultas _instancia;

        public static ucConsultas instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ucConsultas();
                return _instancia;
            }
        }

        private void ucConsultas_Load(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select * FROM consulta WHERE Data_consulta is null";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
        }
    }
}
