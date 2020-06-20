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
    public partial class HospTrofa : Form
    {
        public HospTrofa()
        {
            InitializeComponent();
        }

        private void HospTrofa_Load(object sender, EventArgs e)
        {
            MDB mdb = new MDB();

            {


                string sql = $@"select e.nome_especialidade 
from hospital_tem_especialidade x 
	 inner join especialidade e on x.Especialidade_idEspecialidade = e.idEspecialidade 
where x.Hospital_idHospita = 3 order by e.nome_especialidade";

                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());
                {
                    MySqlDataReader myReader;
                    try
                    {
                        mdb.openConnection();
                        myReader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(myReader);
                        cmbhospitalTS.DisplayMember = "nome_especialidade";
                        cmbhospitalTS.ValueMember = "Especialidade_idEspecialidade";
                        cmbhospitalTS.DataSource = dt;
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
