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
            panel3.Visible = false;
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select idMarcacao as 'ID Marcação', User_id_user as 'ID User',
                                nome_completo AS 'Nome do Utente ', num_saude as 'Nº de Saúde', 
                                 Data_nascimento as 'Data de Nascimento', contacto as 'Contacto', 
                                morada as 'Morada', nome_hospital as 'Hospital', nome_especialidade 
                                as 'Especialidade' FROM consulta WHERE Data_consulta is null order by idMarcacao ASC ";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }

            dateTimePicker2.MinDate = DateTime.Now;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select idMarcacao as 'ID Marcação', User_id_user as 'ID User',
                                nome_completo AS 'Nome do Utente ', num_saude as 'Nº de Saúde', 
                                 Data_nascimento as 'Data de Nascimento', contacto as 'Contacto', 
                                morada as 'Morada', nome_hospital as 'Hospital', nome_especialidade 
                                as 'Especialidade' FROM consulta WHERE Data_consulta is null order by idMarcacao ASC ";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
        }
        private void bunifuCustomDataGrid1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            panel3.Visible = true;

                        txtIdmarcacao.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
                        txtIduser.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
                        txtNomeutente.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
                        txtnums.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
                        dateTimePicker1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
                        txtContacto.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
                        txtMorada.Text = bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
                        txtHospital.Text = bunifuCustomDataGrid1.CurrentRow.Cells[7].Value.ToString();
                        txtEspecialidade.Text = bunifuCustomDataGrid1.CurrentRow.Cells[8].Value.ToString();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                string sql = $@"UPDATE `consulta` SET `data_consulta`= @dc, `Medico_idMedico`= @med WHERE `idMarcacao` = @im ";

                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());

                command.Parameters.Add("@dc", MySqlDbType.Date).Value = dateTimePicker2.Value;
                command.Parameters.AddWithValue("@med", txtidMedico.Text);
                command.Parameters.AddWithValue("@im", txtIdmarcacao.Text);
               
                try
                {
                    mdb.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Consulta Agendada", "Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        panel3.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("ERRO");
                    }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                string sql = $@"DELETE FROM `consulta` WHERE idMarcacao= @im ";
                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());

                command.Parameters.AddWithValue("@im", txtIdmarcacao.Text);

                try
                {
                    mdb.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Pedido de consulta Cancelado", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        panel3.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("ERRO");
                    }
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

      
        //pesquisar
        public void pesquisar(string valorpesquisa)
        {
            MDB mdb = new MDB();
            {
                string pesquisarQuery = "select idMarcacao as 'ID Marcação', User_id_user as 'ID User'," +
                    "  nome_completo AS 'Nome do Utente ', num_saude as 'Nº de Saúde',   " +
                    "Data_nascimento as 'Data de Nascimento', contacto as 'Contacto',  morada as 'Morada', " +
                    "nome_hospital as 'Hospital', nome_especialidade as 'Especialidade' " +
                    "FROM consulta WHERE Data_consulta is null " +
                    "AND CONCAT(nome_completo, nome_especialidade, nome_hospital ) LIKE '%" + valorpesquisa + "%' order by idMarcacao ASC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(pesquisarQuery, mdb.getConnection());
                DataTable table = new DataTable();
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            pesquisar(txtSearch.Text);
        }
       
    }
}
