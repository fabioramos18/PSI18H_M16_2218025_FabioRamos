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
    public partial class UserControl8 : UserControl
    {
        public UserControl8()
        {
            InitializeComponent();
        }


        private static UserControl8 _instancia;

        public static UserControl8 instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new UserControl8();
                return _instancia;
            }
        }
        private void UserControl8_Load(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select idMedico as ID, nome_medico as `Nome`,  email as Email, morada as Morada, contacto as Contacto, nome_hospital as Hospital, nome_especialidade as Especialidade from medico m join especialidade e on m.Especialidade_idEspecialidade = e.idEspecialidade join hospital h on m.Hospital_idHospita = h.idHospita order by idMedico";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }



        }

        private void bunifuCustomDataGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panel3.Visible = false;

            //panel
            if (panel3.Visible == true)
                panel3.Visible = false;
            else
                panel3.Visible = true;

            //mostrar botões
            if (btnDelete.Visible == false || btnEditar.Visible == false)
            {
                btnDelete.Visible = true;
                btnEditar.Visible = true;
            }


            txtIdmedico.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            txtNomeMedico.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            txtIdhospital.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
            txtIdespecialdade.Text = bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
            txtMorada.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
            txtContacto.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();


            //codico para quando o user der duble click apareca o id do hospital e especialidade em vez do nome
            MDB mdb = new MDB();
            {
                try
                {
                    mdb.openConnection();
                    //DataTable table = new DataTable();
                    MySqlCommand command = new MySqlCommand("select Hospital_idHospita, Especialidade_idEspecialidade from medico where idMedico = @im", mdb.getConnection());
                    command.Parameters.Clear();
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@im", MySqlDbType.VarChar).Value = txtIdmedico.Text;
                    MySqlDataReader dr;
                    dr = command.ExecuteReader();
                    dr.Read();
                    txtIdhospital.Text = dr.GetString(0);
                    txtIdespecialdade.Text = dr.GetString(1);

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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;

            //esvaziar textbox
            txtIdmedico.Text = "";
            txtNomeMedico.Text = "";
            txtIdespecialdade.Text = "";
            txtIdhospital.Text = "";
            txtMorada.Text = "";
            txtEmail.Text = "";
            txtContacto.Text = "";

            //ocultar os butões delet e editar
            if (btnDelete.Visible == true || btnEditar.Visible == true || btnGuardar.Visible == false)
            {
                btnDelete.Visible = false;
                btnEditar.Visible = false;
                btnGuardar.Visible = true;

            }

            //mostrar panel
            if (panel3.Visible == false)
                panel3.Visible = true;

            else
                panel3.Visible = false;
        }
    }
}
