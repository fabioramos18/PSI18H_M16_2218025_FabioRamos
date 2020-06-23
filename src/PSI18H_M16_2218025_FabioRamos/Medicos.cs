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
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelConteudo.Controls.Add(childForm);
            panelConteudo.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }





        private void Medicos_Load(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select idMedico as ID, nome_medico as `Nome`,  email as Email, morada as Morada,
                                contacto as Contacto, nome_hospital as Hospital, nome_especialidade as Especialidade 
                                from medico m 
                                join especialidade e on m.Especialidade_idEspecialidade = e.idEspecialidade 
                                join hospital h on m.Hospital_idHospita = h.idHospita order by idMedico";

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
            txtEmail.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            txtMorada.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
            txtContacto.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            txtIdhospital.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
            txtIdespecialdade.Text = bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
            
            

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
            //_---------------------------------------------------------
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {

                string sql = $@"INSERT INTO `medico`(`nome_medico`, `email`, `morada`, `contacto`, `Especialidade_idEspecialidade`, `Hospital_idHospita`) 
                                VALUES (@nm, @email, @mor, @cont, @ie, @ih)";

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
            panel3.Visible = false;

            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select idMedico as ID, nome_medico as `Nome`,  
                             email as Email, morada as Morada, contacto as Contacto, nome_hospital as Hospital, 
                             nome_especialidade as Especialidade 
                             from medico m 
                             join especialidade e on m.Especialidade_idEspecialidade = e.idEspecialidade 
                             join hospital h on m.Hospital_idHospita = h.idHospita 
                             order by idMedico";


                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
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
            if (btnDelete.Visible == true || btnEditar.Visible == true || btnFicheiro.Visible == false || btnGuardar.Visible == false)
            {
                btnDelete.Visible = false;
                btnEditar.Visible = false;
                btnGuardar.Visible = true;
                btnFicheiro.Visible = true;
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
                string sql = $@"UPDATE `medico` SET `nome_medico`= @nm ,  `email`= @email, `morada` = @mor, `contacto` = @cont, `Especialidade_idEspecialidade` = @ie, `Hospital_idHospita` =@ih WHERE `idMedico` = @im ";

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
                string pesquisarQuery = "select idMedico as ID, nome_medico as `Nome`,  email as Email, morada as Morada, contacto as Contacto, " +
                    "nome_hospital as Hospital, nome_especialidade as Especialidade " +
                    "from medico m " +
                    "join especialidade e on m.Especialidade_idEspecialidade = e.idEspecialidade " +
                    "join hospital h on m.Hospital_idHospita = h.idHospita   " +
                    "WHERE  CONCAT( idMedico, nome_medico, nome_especialidade, nome_hospital ) " +
                    "LIKE '%" + valorpesquisa + "%'";

                MySqlDataAdapter adapter = new MySqlDataAdapter(pesquisarQuery, mdb.getConnection());
                DataTable table = new DataTable();
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            pesquisar(txtSearch.Text);
        }




        private void button4_Click(object sender, EventArgs e)
        {
            panelConteudo.Visible = true;
            openChildForm(new Form1());
        }
    }
}
