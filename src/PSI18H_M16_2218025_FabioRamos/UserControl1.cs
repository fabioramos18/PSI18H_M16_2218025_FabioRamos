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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public static string passingText;
        public static string passingText1;


        private void UserControl1_Load(object sender, EventArgs e)
        {
            CarregarHospitais();
            cmbhospital.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbespecialidade.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void Btn2_Click(object sender, EventArgs e)
        {
            passingText = cmbhospital.Text;
            passingText1 = cmbespecialidade.Text;
            this.Hide();
            this.Parent.Controls.Add(new UserControl2());
        }

        private void cmbhospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            MDB mdb = new MDB();

            {


                string sql = $@"select e.idEspecialidade
,       e.nome_especialidade 
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

        
    }


    

    
}
