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
    public partial class HospBeatriz : Form
    {
        public HospBeatriz()
        {
            InitializeComponent();
        }

        private void HospBeatriz_Load(object sender, EventArgs e)
        {
            MDB mdb = new MDB();

            {
              

                string sql = $@"select e.nome_especialidade 
from hospital_tem_especialidade x 
	 inner join especialidade e on x.Especialidade_idEspecialidade = e.idEspecialidade 
where x.Hospital_idHospita = 1 order by e.nome_especialidade";

                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());
                {
                    MySqlDataReader myReader;
                    try
                    {
                        mdb.openConnection();
                        myReader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(myReader);
                        cmbhospitalBA.DisplayMember = "nome_especialidade";
                        cmbhospitalBA.ValueMember = "Especialidade_idEspecialidade";
                        cmbhospitalBA.DataSource = dt;
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
