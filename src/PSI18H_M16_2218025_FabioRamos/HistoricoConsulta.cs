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

        //pesquisar
        public void pesquisar(string valorpesquisa)
        {
            #region select de pesquisa
            MDB mdb = new MDB();
            {
                string pesquisarQuery = "select idMarcacao as 'ID Marcação', User_id_user as 'ID User', " +
                                        "c.nome_completo AS 'Nome do Utente ',  num_saude as 'Nº de Saúde'," +
                                        " Data_nascimento as 'Data de Nascimento', c.contacto as 'Contacto', " +
                                        "c.morada as 'Morada', nome_hospital as 'Hospital', " +
                                        "nome_especialidade as 'Especialidade', Data_consulta as 'Data da Consulta', " +
                                        "nome_medico as'Médico Designado' " +
                                        "FROM consulta c join `medico` m on c.Medico_idMedico = m.idMedico  " +
                                        "WHERE Data_consulta  BETWEEN DATE_ADD(CURRENT_DATE(), INTERVAL -100 year ) AND CURRENT_DATE() " +
                                        "AND CONCAT(c.nome_completo, nome_medico,nome_hospital, nome_especialidade )  LIKE '%" + valorpesquisa + "%'";

                MySqlDataAdapter adapter = new MySqlDataAdapter(pesquisarQuery, mdb.getConnection());
                DataTable table = new DataTable();
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
            #endregion
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            pesquisar(txtSearch.Text);
        }
       
        private void contConsultas()
        {
            #region COUNT total de consultas realizadas
            MDB mdb = new MDB();
            {
                try
                {
                    mdb.openConnection();
                    DataTable table = new DataTable();
                    MySqlCommand command = new MySqlCommand("SELECT count(distinct id_user ) FROM user", mdb.getConnection());
                    command.Parameters.Clear();
                    command.CommandType = CommandType.Text;
                    MySqlDataReader dr;
                    dr = command.ExecuteReader();
                    dr.Read();
                    label1.Text = dr.GetString(0);

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
       



        private void HistoricoConsulta_Load(object sender, EventArgs e)
        {
            contConsultas();
            #region select historico
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select idMarcacao as 'ID Marcação', User_id_user as 'ID User', c.nome_completo AS 'Nome do Utente ', 
                                num_saude as 'Nº de Saúde', Data_nascimento as 'Data de Nascimento', 
                                c.contacto as 'Contacto', c.morada 'Morada', nome_hospital as 'Hospital', 
                                nome_especialidade as 'Especialidade', Data_consulta as 'Data da Consulta', nome_medico as'Médico Designado'
                                FROM consulta c join `medico` m
                                on c.Medico_idMedico = m.idMedico 
                                WHERE Data_consulta  BETWEEN DATE_ADD(CURRENT_DATE(), INTERVAL -100 year ) AND CURRENT_DATE() 
                                ORDER BY Data_consulta desc";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
            #endregion
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            #region select historico
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select idMarcacao as 'ID Marcação', User_id_user as 'ID User', c.nome_completo AS 'Nome do Utente ', 
                                num_saude as 'Nº de Saúde', Data_nascimento as 'Data de Nascimento', 
                                c.contacto as 'Contacto', c.morada 'Morada', nome_hospital as 'Hospital', 
                                nome_especialidade as 'Especialidade', Data_consulta as 'Data da Consulta', nome_medico as'Médico Designado'
                                FROM consulta c join `medico` m
                                on c.Medico_idMedico = m.idMedico 
                                WHERE Data_consulta  BETWEEN DATE_ADD(CURRENT_DATE(), INTERVAL -100 year ) AND CURRENT_DATE() 
                                ORDER BY Data_consulta desc";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
        }
        #endregion
        }
}
