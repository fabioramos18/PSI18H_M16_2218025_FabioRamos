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
    public partial class MarcarC : UserControl
    {
        public MarcarC()
        {
            InitializeComponent();
        }


        public void CarregarHospitais()
        {
            MDB mdb = new MDB();
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM hospital ORDER BY nome_hospital ASC;", mdb.getConnection());
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
                string sql = $@"select e.idEspecialidade
,           e.nome_especialidade 
            from hospital_tem_especialidade x 
	        inner join especialidade e on x.Especialidade_idEspecialidade = e.idEspecialidade 
            where x.Hospital_idHospita = {cmbhospital.SelectedValue} order by e.nome_especialidade";

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

        private void MarcarC_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;
            CarregarHospitais();
            txtNomeCompleto.Text = "Nome Completo";
            txtNSaude.Text = "Nº de Saude";
            txtContacto.Text = "Telemovel / Telefone";
            txtMorada.Text = "Morada";
        }


        private static MarcarC _instancia;
        public static MarcarC instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new MarcarC();
                return _instancia;
            }
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            txtNomeCompleto.Text = "Nome Completo";
            txtNSaude.Text = "Nº de Saude";
            txtContacto.Text = "Telemovel / Telefone";
            dateTimePicker1.Value = DateTime.Now;
            txtMorada.Text = "Morada";
            this.Parent.Controls.Clear(); ;
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            MDB mdb = new MDB();

            {
                string sql = $@"INSERT INTO `consulta`( `nome_completo`, `num_saude`, `contacto`, `Data_nascimento`, `morada`, `nome_especialidade`, `nome_hospital`)VALUES (@nc, @ns,@cont, @dn, @mor, @ne, @nh )";
                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());

                command.Parameters.Add("@nc", MySqlDbType.VarChar).Value = txtNomeCompleto.Text;
                command.Parameters.Add("@ns", MySqlDbType.VarChar).Value = txtNSaude.Text;
                command.Parameters.Add("@cont", MySqlDbType.VarChar).Value = txtContacto.Text;
                command.Parameters.Add("@dn", MySqlDbType.Date).Value = dateTimePicker1.Value;
                command.Parameters.Add("@mor", MySqlDbType.VarChar).Value = txtMorada.Text;
                command.Parameters.Add("@ne", MySqlDbType.VarChar).Value = cmbespecialidade.Text;
                command.Parameters.Add("@nh", MySqlDbType.VarChar).Value = cmbhospital.Text;

                try
                {
                    mdb.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Pedido de consulta realizado com sucesso", "Mrcação de consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNomeCompleto.Text = "Nome Completo";
                        txtNSaude.Text = "Nº de Saude";
                        txtContacto.Text = "Telemovel / Telefone";
                 //       dateTimePicker1.Value = DateTime.Now;
                        txtMorada.Text = "Morada";
                        //this.Parent.Controls.Clear(); ;
                       
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

        
    }
}
