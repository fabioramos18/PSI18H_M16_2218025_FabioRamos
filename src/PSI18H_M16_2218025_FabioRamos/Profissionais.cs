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
    public partial class Profissionais : Form
    {
        public Profissionais()
        {
            InitializeComponent();
            
        }

        private void Profissionais_Load(object sender, EventArgs e)
        {
            CarregarHospitais();
            userControl41.Hide();
            userControl51.Hide();
            userControl61.Hide();
           // userControl71.Hide();
            cmbhospital.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbhospital.Text.Equals("Hospital Beatriz Ângelo"))
            {
                //userControl71.Hide();
                userControl51.Hide();
                userControl61.Hide();
                userControl41.Show();
                userControl41.BringToFront();


            }
            else if (cmbhospital.Text.Equals("Hospital Da Luz"))
            {
                userControl71.Hide();
                userControl41.Hide();
                userControl61.Hide();
                userControl51.Show();
                userControl51.BringToFront();
            }
            else if (cmbhospital.Text.Equals("Hospital Trofa Saúde"))
            {
                userControl71.Hide();
                userControl41.Hide();
                userControl51.Hide();
                userControl61.Show();
                userControl61.BringToFront();
            }
            else
            {
                userControl71.Show();
                userControl71.BringToFront();
            }
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
    }
}
