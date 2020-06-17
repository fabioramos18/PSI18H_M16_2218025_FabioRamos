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
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
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


        private void cmbhospital_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void Btn4_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Parent.Controls.Add(new UserControl1());
        }


        public static string passingText10;

        private void UserControl3_Load(object sender, EventArgs e)

        {
            MDB mdb = new MDB();
            {
                try
                {
                    mdb.openConnection();
                    DataTable table = new DataTable();
                    MySqlCommand command = new MySqlCommand("select id_user from `user` where `user` = @im ", mdb.getConnection());
                    command.Parameters.Clear();
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@im", MySqlDbType.VarChar).Value = Entrar.passingText2;
                    MySqlDataReader dr;
                    dr = command.ExecuteReader();
                    dr.Read();
                    passingText10 = dr.GetString(0);

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

                cmbhospital.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbespecialidade.DropDownStyle = ComboBoxStyle.DropDownList;
                CarregarHospitais();

                cmbhospital.Text = UserControl1.passingText;
                cmbespecialidade.Text = UserControl1.passingText1;
                txtNomeCompleto.Text = UserControl2.passingText2;
                txtNSaude.Text = UserControl2.passingText3;
                txtContacto.Text = UserControl2.passingText4;
                dateTimePicker1.Text = UserControl2.passingText5;
                txtMorada.Text = UserControl2.passingText6;
             // txtEmail.Text = UserControl2.passingText7;
           
        }



        private void Btn5_Click(object sender, EventArgs e)
        {
              MDB mdb = new MDB();

           {
             string sql = $@"INSERT INTO `consulta`(`User_id_user`, `nome_completo`, `num_saude`, `contacto`, `Data_nascimento`, `morada`, `nome_especialidade`, `nome_hospital`)VALUES (@iu, @nc, @ns,@cont, @dn, @mor, @ne, @nh )";
             MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());

             command.Parameters.Add("@nc", MySqlDbType.VarChar).Value = txtNomeCompleto.Text;
             command.Parameters.Add("@ns", MySqlDbType.VarChar).Value = txtNSaude.Text;
             command.Parameters.Add("@cont", MySqlDbType.VarChar).Value = txtContacto.Text;
             command.Parameters.Add("@dn", MySqlDbType.Date).Value = dateTimePicker1.Value;
             command.Parameters.Add("@mor", MySqlDbType.VarChar).Value = txtMorada.Text;
             command.Parameters.Add("@ne", MySqlDbType.VarChar).Value = cmbespecialidade.Text;
             command.Parameters.Add("@nh", MySqlDbType.VarChar).Value = cmbhospital.Text;

             command.Parameters.Add("@iu", MySqlDbType.VarChar).Value = UserControl3.passingText10;

                try
             {
                 mdb.openConnection();
                 if (command.ExecuteNonQuery() == 1)
                 {
                     MessageBox.Show("Pedido de consulta realizado com sucesso", "Mrcação de consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
         //this.AcceptButton = PedidoMarcar;
        }

        
    }
}
