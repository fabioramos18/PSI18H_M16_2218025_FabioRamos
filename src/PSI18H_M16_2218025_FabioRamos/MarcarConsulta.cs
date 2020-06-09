using System;
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
    public partial class MarcarConsulta : Form
    {
        public MarcarConsulta()
        {
            InitializeComponent();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NomeCompleto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MarcarConsulta_Load(object sender, EventArgs e)
        {
            // carregar hospitais
            CarregarHospitais();

        }


    

        private void PedidoMarcar_Click(object sender, EventArgs e)
        {
             
                 MDB mdb = new MDB();

              {
                MySqlCommand command = new MySqlCommand("INSERT INTO `marcacao`(`nome_completo`, `num_saude`, `contacto`, `Data_nascimento`, `morada`, `nome_especialidade`,  `nome_hospital`)VALUES (@nc, @ns,@cont, @dn, @mor, @ne, @nh)", mdb.getConnection());

                  command.Parameters.Add("@nc", MySqlDbType.VarChar).Value = txtNomeCompleto.Text;
                  command.Parameters.Add("@ns", MySqlDbType.VarChar).Value = txtNumSaude.Text;
                  command.Parameters.Add("@cont", MySqlDbType.VarChar).Value = txtContacto.Text;
                  command.Parameters.Add("@dn", MySqlDbType.Date).Value = dateTimePicker1.Value;
                  command.Parameters.Add("@mor", MySqlDbType.VarChar).Value = txtMorada.Text;
                  command.Parameters.Add("@ne", MySqlDbType.VarChar).Value = cmbespecialidade.Text;
                  command.Parameters.Add("@nh", MySqlDbType.VarChar).Value = cmbhospital.Text;
                //abrir conecção
                mdb.openConnection();

               

                //consultar os dados
                if (command.ExecuteNonQuery() == 1)
                  {
                    MessageBox.Show("A sua conta foi criada com sucesso", "Conta criada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERRO");
                }
              
              }

          //fechar conecção
          mdb.closeConnection();
        }



        void CarregarHospitais()
        {
            MDB mdb = new MDB();
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM hospital ORDER BY nome_hospital ASC;", mdb.getConnection());

               // string selectQuery = "SELECT * FROM hospital ORDER BY nome_hospital ASC;";
              //  using (MySqlCommand mysqlcommand = new MySqlCommand(selectQuery, mdb.Connection))
                {
                    MySqlDataReader myReader;
                    try
                    {
                        mdb.openConnection();
                        myReader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(myReader);
                        cmbhospital.DisplayMember = "nome_hospital";
                        cmbhospital.ValueMember = "idHospita";
                        cmbhospital.DataSource = dt;
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Erro:" + erro.Message);
                    }
                    finally
                    {
                        mdb.closeConnection();
                    }
                }

                





            }

        }



        private void cmbhospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                MDB mdb = new MDB();

            {
                

                    string sql= $@"select e.idEspecialidade
,       e.nome_especialidade 
from hospital_tem_especialidade x 
	 inner join especialidade e on x.Especialidade_idEspecialidade = e.idEspecialidade 
where x.Hospital_idHospital = {cmbhospital.SelectedValue} order by e.nome_especialidade";

                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());
                {
                    MySqlDataReader myReader;
                    try
                    {
                        mdb.openConnection();
                        myReader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(myReader);
                        cmbespecialidade.DisplayMember = "nome_especialidade";
                        cmbespecialidade.ValueMember = "Especialidade_idEspecialidade";
                        cmbespecialidade.DataSource = dt;
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Erro:" + erro.Message);
                    }
                    finally
                    {
                        mdb.closeConnection();
                    }
                }
                

            }


        }
        

        private void txtNumSaude_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Insira apenas números", "Atenção",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNomeCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Apenas letras (a-z)", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Insira apenas números", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMorada_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }

       
}

