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
    public partial class Utilizadores : UserControl
    {
        public Utilizadores()
        {
            InitializeComponent();
        }


        private static Utilizadores _instancia;
        public static Utilizadores instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Utilizadores();
                return _instancia;
            }
        }

        private void contConsultas()
        {
            #region COUNT total de consultas realizadas
            MDB mdb = new MDB();
            {
                try
                {
                    mdb.openConnection();
                    DataTable table = new DataTable();
                    MySqlCommand command = new MySqlCommand("SELECT count(distinct id_user ) FROM user", mdb.getConnection());
                    command.Parameters.Clear();
                    command.CommandType = CommandType.Text;
                    MySqlDataReader dr;
                    dr = command.ExecuteReader();
                    dr.Read();
                    label1.Text = dr.GetString(0);

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
            #endregion
        }

        private void Utilizadores_Load(object sender, EventArgs e)
        {
            contConsultas();
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select id_user as 'ID User', nome_completo as 'Nome', 
                             user as 'Nome de Utilizador' , email as 'Email', passe as 'Palavra Passe'
                             from user";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
        }

        private void bunifuCustomDataGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtIduser.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            txtNomecompleto.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            txtNomeUser.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
            txtPasse.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                string sql = $@"UPDATE `user` SET `nome_completo`= @nm , `user` = @us,  `email`= @email, `passe` = @ps WHERE `id_user` = @iu ";

                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());

                command.Parameters.AddWithValue("@nm", txtNomecompleto.Text);
                command.Parameters.AddWithValue("@us", txtNomeUser.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@ps", txtPasse.Text);
                command.Parameters.AddWithValue("@iu", txtIduser.Text);


                try
                {
                    mdb.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Registo atualizado", "Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNomecompleto.Text = "";
                        txtNomeUser.Text = "";
                        txtEmail.Text = "";
                        txtPasse.Text = "";
                        txtIduser.Text = "";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MDB mdb = new MDB();
            {
                string sql = $@"DELETE FROM user WHERE id_user = @iu ";
                MySqlCommand command = new MySqlCommand(sql, mdb.getConnection());
                command.Parameters.AddWithValue("@iu", txtIduser.Text);

                try
                {
                    mdb.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Utilizador eliminado com sucesso", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            contConsultas();
            MDB mdb = new MDB();
            {
                DataTable table = new DataTable();
                string sql = $@"select id_user as 'ID User', nome_completo as 'Nome', 
                             user as 'Nome de Utilizador' , email as 'Email', passe as 'Palavra Passe'
                             from user";


                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mdb.getConnection());
                adapter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
        }
    }
    
   
}
