using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSI18H_M16_2218025_FabioRamos
{
    public partial class Consulas : Form
    {
        public Consulas()
        {
            InitializeComponent();
        }

        private void Consulas_Load(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select * from consulta order by idMarcacao";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
        }
    }
}
