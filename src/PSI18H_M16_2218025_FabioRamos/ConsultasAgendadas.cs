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
    public partial class ConsultasAgendadas : UserControl
    {
        public ConsultasAgendadas()
        {
            InitializeComponent();
        }

        private static ConsultasAgendadas _instancia;

        public static ConsultasAgendadas instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ConsultasAgendadas();
                return _instancia;
            }
        }

        private void ConsultasAgendadas_Load(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select  idMarcacao as 'ID Marcação', User_id_user as 'ID User',
                                c.nome_completo AS 'Nome do Utente ', num_saude as 'Nº de Saúde', 
                                c.contacto as 'Contacto', Data_nascimento as 'Data de Nascimento', 
                                c.morada as 'Morada', nome_hospital as 'Hospital', nome_especialidade 
                                as 'Especialidade', data_consulta as 'Data da Consulta', Medico_idMedico as'Médico Designado',
                                IF(data_consulta is null, 'nao confirmado', 'confirmado') AS Estado  from consulta c
                                join `user` u
                                on c.User_id_user = u.id_user  WHERE Data_consulta is not null
                                UNION

							-- select para ver as consultas agendadas pelo admin com ID do User = null

                                select  idMarcacao as 'ID Marcação', User_id_user as 'ID User',
                                c.nome_completo AS 'Nome do Utente ', num_saude as 'Nº de Saúde', 
                                c.contacto as 'Contacto', Data_nascimento as 'Data de Nascimento', 
                                c.morada as 'Morada', nome_hospital as 'Hospital', nome_especialidade 
                                as 'Especialidade', data_consulta as 'Data da Consulta', Medico_idMedico as'Médico Designado',
                                IF(data_consulta is null, 'nao confirmado', 'confirmado') AS Estado 
								from consulta c WHERE Data_consulta is not null ";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
        }

        public void pesquisar(string valorpesquisa)
        {
            MDB mdb = new MDB();
            {
                string pesquisarQuery = $@"select  idMarcacao as 'ID Marcação', User_id_user as 'ID User',
                                c.nome_completo AS 'Nome do Utente ', num_saude as 'Nº de Saúde', 
                                c.contacto as 'Contacto', Data_nascimento as 'Data de Nascimento', 
                                c.morada as 'Morada', nome_hospital as 'Hospital', nome_especialidade 
                                as 'Especialidade', data_consulta as 'Data da Consulta', 
                                IF(data_consulta is null, 'nao confirmado', 'confirmado') AS Estado  from consulta c
                                join `user` u
                                on c.User_id_user = u.id_user  
                                WHERE Data_consulta is not null and CONCAT( idMarcacao, c.nome_completo, num_saude, nome_hospital ) 
                                LIKE '%" + valorpesquisa + "%'" +
                               
                                "UNION " +
                              
                                "select  idMarcacao as 'ID Marcação', User_id_user as 'ID User', c.nome_completo " +
                                "AS 'Nome do Utente ', num_saude as 'Nº de Saúde',   " +
                                "c.contacto as 'Contacto', Data_nascimento as 'Data de Nascimento', " +
                                "c.morada as 'Morada', nome_hospital as 'Hospital', nome_especialidade  " +
                                "as 'Especialidade', data_consulta as 'Data da Consulta', " +
                                "IF(data_consulta is null, 'nao confirmado', 'confirmado') " +
                                "AS Estado from consulta c WHERE Data_consulta is not null and " +
                                "CONCAT(idMarcacao, c.nome_completo, num_saude, nome_hospital ) LIKE '%" + valorpesquisa + "%'";


                MySqlDataAdapter adapter = new MySqlDataAdapter(pesquisarQuery, mdb.getConnection());
                DataTable table = new DataTable();
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pesquisar(txtSearch.Text);
        }
    }
}
