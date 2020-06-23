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
    public partial class MinhaConta : Form
    {
        public MinhaConta()
        {
            InitializeComponent();
        }

        private void MinhaConta_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            label5.Text = Entrar.passingText2;

            MDB mdb = new MDB();
            {
                try
                {
                    mdb.openConnection();
                MySqlCommand command = new MySqlCommand("select id_user, nome_completo, email from `user` where `user` = @im ", mdb.getConnection());
                    command.Parameters.Clear();
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@im", MySqlDbType.VarChar).Value = label5.Text;
                MySqlDataReader dr = command.ExecuteReader();

                    while (dr.Read()) 
                    {
                        label8.Text = dr.GetString(0);
                        label7.Text = dr.GetString(1);
                        label6.Text = dr.GetString(2);
                    }
                    dr.Close();
                }
                catch (Exception erro)
                {
                    throw erro;
                }
                finally
                {
                    mdb.closeConnection();
                }
                    DataTable tablex = new DataTable();
                    string sql = $@"SELECT idMarcacao as 'ID Marcação' ,nome_completo as 'Nome do Untente', num_saude as 'Nº de Saúde',
                                 Data_nascimento as 'Data de Nascimento', c.contacto as 'contacto', c.morada as 'morada', 
                                 nome_hospital as 'Hospital', nome_especialidade as 'Especialidade', data_consulta as 'Data da Consulta',
                                 nome_medico as 'Médico Designado', 
                                 IF(data_consulta > curdate(), 'confirmado', 'concluido')  
                                 AS Estado FROM consulta c
                                 inner join medico m on c.Medico_idMedico = m.idMedico  
                                 where User_id_user = '" +label8.Text+ "' ";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                    adapter.Fill(tablex);
                    bunifuCustomDataGrid1.DataSource = tablex;
            }
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        
    }   
}

