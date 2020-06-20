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
            #region select para preencher o gridview
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select idMarcacao as 'ID Marcação', User_id_user as 'ID User',
                                c.nome_completo AS 'Nome do Utente ', num_saude as 'Nº de Saúde', 
                                c.contacto as 'Contacto', Data_nascimento as 'Data de Nascimento', 
                                c.morada as 'Morada', nome_hospital as 'Hospital', nome_especialidade
                                as 'Especialidade', data_consulta as 'Data da Consulta', nome_medico as 'Medico Designado', 
                                IF(data_consulta is null, 'nao confirmado', 'confirmado') AS Estado  from consulta c
                                join `user` u
                                on(c.User_id_user = u.id_user)
                                join medico m
                                on(c.Medico_idMedico = m.idMedico)
                                WHERE DATE_FORMAT(data_consulta, '%Y-%m-%d') > CURDATE()


                               UNION

                                select  idMarcacao as 'ID Marcação', User_id_user as 'ID User',
                                c.nome_completo AS 'Nome do Utente ', num_saude as 'Nº de Saúde', 
                                c.contacto as 'Contacto', Data_nascimento as 'Data de Nascimento', 
                                c.morada as 'Morada', nome_hospital as 'Hospital', nome_especialidade
                                as 'Especialidade', data_consulta as 'Data da Consulta',  nome_medico as 'Medico Designado', 
                                IF(data_consulta is null, 'nao confirmado', 'confirmado') AS Estado

                                from consulta c
                                join medico m
                                on (c.Medico_idMedico = m.idMedico)
                                WHERE DATE_FORMAT(data_consulta, '%Y-%m-%d') > CURDATE(); ";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
            #endregion
        }



        public void pesquisar(string valorpesquisa)
        {
            #region textbox pesquisar
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
            #endregion
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pesquisar(txtSearch.Text);
        }

        private void bunifuCustomDataGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
            else
            {
                panel6.Visible = true;
            }
                label15.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
        }

        private void ConsultasAgendadas_MouseClick(object sender, MouseEventArgs e)
        {
            hidepanel();
        }

        private void hidepanel()
        {
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
        }

        private void bunifuCustomDataGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            hidepanel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          #region passar valores do datagrid para os campos do panel3 
            txtIdmarcacao.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            txtIduser.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            txtNomeutente.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            txtnums.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
            txtContacto.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
            txtMorada.Text = bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
            txtHospital.Text = bunifuCustomDataGrid1.CurrentRow.Cells[7].Value.ToString();
            txtEspecialidade.Text = bunifuCustomDataGrid1.CurrentRow.Cells[8].Value.ToString();
            dateTimePicker2.Text = bunifuCustomDataGrid1.CurrentRow.Cells[9].Value.ToString();
            txtidMedico.Text = bunifuCustomDataGrid1.CurrentRow.Cells[10].Value.ToString();
            #endregion

            panel6.Visible = false;
            panel3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

       
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            #region update na tabela consulta
            MDB mdb = new MDB();
            {
                string sql = $@"UPDATE `consulta` SET `data_consulta`= @dc, `Medico_idMedico`= @med WHERE `idMarcacao` = @im ";

                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());

                command.Parameters.Add("@dc", MySqlDbType.Date).Value = dateTimePicker2.Value;
                command.Parameters.AddWithValue("@med", textBox1.Text);
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
            #endregion
        }
        
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            #region atualizadar o datagrid 
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select  idMarcacao as 'ID Marcação', User_id_user as 'ID User',
                                c.nome_completo AS 'Nome do Utente ', num_saude as 'Nº de Saúde', 
                                c.contacto as 'Contacto', Data_nascimento as 'Data de Nascimento', 
                                c.morada as 'Morada', nome_hospital as 'Hospital', nome_especialidade 
                                as 'Especialidade', data_consulta as 'Data da Consulta', nome_medico as 'Medico Designado', 
                                IF(data_consulta is null, 'nao confirmado', 'confirmado') AS Estado  from consulta c
                                join `user` u
                                on (c.User_id_user = u.id_user)  
                                join medico m
                                on (c.Medico_idMedico = m.idMedico)
                                WHERE DATE_FORMAT(data_consulta, '%Y-%m-%d') > CURDATE()
                                
                                UNION
								
                                select  idMarcacao as 'ID Marcação', User_id_user as 'ID User',
                                c.nome_completo AS 'Nome do Utente ', num_saude as 'Nº de Saúde', 
                                c.contacto as 'Contacto', Data_nascimento as 'Data de Nascimento', 
                                c.morada as 'Morada', nome_hospital as 'Hospital', nome_especialidade 
                                as 'Especialidade', data_consulta as 'Data da Consulta',  nome_medico as 'Medico Designado', 
                                IF(data_consulta is null, 'nao confirmado', 'confirmado') AS Estado 
								from consulta c 
                                join medico m
                                on (c.Medico_idMedico = m.idMedico)
                                WHERE DATE_FORMAT(data_consulta, '%Y-%m-%d') > CURDATE();";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;


            }
            #endregion

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            #region Botão eliminar
            MDB mdb = new MDB();
            {
                string sql = $@"DELETE FROM `consulta` WHERE idMarcacao= @im ";
                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());

                command.Parameters.AddWithValue("@im", label15.Text);

                try
                {
                    mdb.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Consulta eliminada com sucesso", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        panel6.Visible = false;
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
            #endregion
        }
         
        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
