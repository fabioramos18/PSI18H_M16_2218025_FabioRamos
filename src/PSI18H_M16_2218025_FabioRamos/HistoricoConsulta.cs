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
                string sql = $@"select idMarcacao as 'ID Marcação', User_id_user as 'ID User', c.nome_completo AS 'Nome do Utente ', 
                                num_saude as 'Nº de Saúde', Data_nascimento as 'Data de Nascimento', 
                                c.contacto as 'Contacto', c.morada 'Morada', nome_hospital as 'Hospital', 
                                nome_especialidade as 'Especialidade', Data_consulta as 'Data da Consulta', nome_medico as'Médico Designado'
                                FROM consulta c join `medico` m
                                on c.Medico_idMedico = m.idMedico 
                                WHERE Data_consulta  BETWEEN DATE_ADD(CURRENT_DATE(), INTERVAL -100 year ) AND CURRENT_DATE()";


                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
        }
    }
}
