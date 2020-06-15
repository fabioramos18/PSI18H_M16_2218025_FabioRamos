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
    public partial class Medicos : Form
    {
        public Medicos()
        {
            InitializeComponent();
        }

        private void Medicos_Load(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select idMedico, nome_medico, morada, email, contacto, nome_hospital, nome_especialidade from medico m join especialidade e on m.id_especialidade = e.idEspecialidade join hospital h on m.id_hospital = h.idHospita order by idMedico";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                dataGridView_Medicos.DataSource = table;
            }
        }

        private void dataGridView_Medicos_MouseDoubleClick(object sender, MouseEventArgs e)
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


            txtIdmedico.Text = dataGridView_Medicos.CurrentRow.Cells[0].Value.ToString();
            txtNomeMedico.Text = dataGridView_Medicos.CurrentRow.Cells[1].Value.ToString();
            txtIdespecialdade.Text = dataGridView_Medicos.CurrentRow.Cells[5].Value.ToString();
            txtIdhospital.Text = dataGridView_Medicos.CurrentRow.Cells[6].Value.ToString();
            txtMorada.Text = dataGridView_Medicos.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataGridView_Medicos.CurrentRow.Cells[3].Value.ToString();
            txtContacto.Text = dataGridView_Medicos.CurrentRow.Cells[4].Value.ToString();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {

                string sql = $@"INSERT INTO `medico`(`nome_medico`, `morada`, `email`, `contacto`, `id_especialidade`, `id_hospital`) VALUES (@nm, @mor,@email, @cont, @ie, @ih)";
                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());


                command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = txtNomeMedico.Text;
                command.Parameters.Add("@mor", MySqlDbType.VarChar).Value = txtMorada.Text;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = txtEmail.Text;
                command.Parameters.Add("@cont", MySqlDbType.VarChar).Value = txtContacto.Text;
                command.Parameters.Add("@ie", MySqlDbType.VarChar).Value = txtIdespecialdade.Text;
                command.Parameters.Add("@ih", MySqlDbType.VarChar).Value = txtIdhospital.Text;


                try
                {
                    mdb.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Medico adicionado com sucesso", "Medico Adicionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            panel3.Visible = false;
        }

        //atualizar o gridview
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select idMedico, nome_medico, morada, email, contacto, nome_hospital, nome_especialidade from medico m join especialidade e on m.id_especialidade = e.idEspecialidade join hospital h on m.id_hospital = h.idHospita order by idMedico";


                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                dataGridView_Medicos.DataSource = table;
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
            if (btnDelete.Visible == true || btnEditar.Visible == true)
            {
                btnDelete.Visible = false;
                btnEditar.Visible = false;
            }

            //mostrar panel
            if (panel3.Visible == false)
                panel3.Visible = true;
            else
                panel3.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                string sql = $@"DELETE FROM `medico` WHERE idMedico = @im ";
                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());

                command.Parameters.AddWithValue("@im", txtIdmedico.Text);

                try
                {
                    mdb.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Médico eliminado com sucesso", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                string sql = $@"UPDATE medico SET nome_medico= @nm , morada= @mor,email= @email, contacto= @cont, id_especialidade = @ie, id_hospital=@ih WHERE idMedico = @im ";
                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());


                command.Parameters.AddWithValue("@nm", txtNomeMedico.Text);
                command.Parameters.AddWithValue("@mor", txtMorada.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@cont", txtContacto.Text);
                command.Parameters.AddWithValue("@ie", txtIdespecialdade.Text);
                command.Parameters.AddWithValue("@ih", txtIdhospital.Text);
                command.Parameters.AddWithValue("@im", txtIdmedico.Text);


                try
                {
                    mdb.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Registo editado com sucesso", "Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        //pesquisar
        public void pesquisar(string valorpesquisa)
        {
            MDB mdb = new MDB();
            { 
                string pesquisarQuery = "SELECT * FROM medico WHERE  CONCAT( idMedico, nome_medico, contacto, email ) LIKE '%" + valorpesquisa + "%'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(pesquisarQuery, mdb.getConnection());
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_Medicos.DataSource = table;
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            pesquisar(txtSearch.Text);
        }

        bool drag = false;
        Point start_point = new Point(0, 0);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
