using System;
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
    public partial class HistoricoConsulta : UserControl
    {
        public HistoricoConsulta()
        {
            InitializeComponent();
        }

        private static HistoricoConsulta _instancia;

        public static HistoricoConsulta instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new HistoricoConsulta();
                return _instancia;
            }
        }

        private void HistoricoConsulta_Load(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select * FROM consulta WHERE Data_consulta  BETWEEN DATE_ADD(CURRENT_DATE(), INTERVAL -100 year ) AND CURRENT_DATE()";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
        }
    }
}
