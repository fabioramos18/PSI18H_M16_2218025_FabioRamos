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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        private void hideSubmenu()
        {
            if (panel2.Visible == true)
                panel2.Visible = false;
        }
        
        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void movepanel(Control btn)
        {
            panelSlide.Width = btn.Width;
            panelSlide.Left = btn.Left;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubmenu(panel2);
            movepanel(button1);
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            #region childform
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
            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelConteudo.Controls.Clear();
            openChildForm(new Medicos());
            hideSubmenu();
            movepanel(button3);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (panelConteudo.Controls.Contains(HistoricoConsulta.instancia) ||
                panelConteudo.Controls.Contains(Utilizadores.instancia) ||
                panelConteudo.Controls.Contains(ConsultasAgendadas.instancia) ||
                panelConteudo.Controls.Contains(ucConsultas.instancia) ||
                !panelConteudo.Controls.Contains(MarcarC.instancia))
            {
                panelConteudo.Controls.Clear();
                panelConteudo.Controls.Add(MarcarC.instancia);
                MarcarC.instancia.Dock = DockStyle.Fill;
                MarcarC.instancia.BringToFront();
            }
            hideSubmenu();
            movepanel(button2);

        }


       

        private void button6_Click(object sender, EventArgs e)
        {
            movepanel(button6);

            if (panelConteudo.Controls.Contains(MarcarC.instancia) ||
                panelConteudo.Controls.Contains(ucConsultas.instancia) ||
                panelConteudo.Controls.Contains(HistoricoConsulta.instancia) ||
                panelConteudo.Controls.Contains(ConsultasAgendadas.instancia) ||
                !panelConteudo.Controls.Contains(Utilizadores.instancia))
            {
                panelConteudo.Controls.Clear();
                panelConteudo.Controls.Add(Utilizadores.instancia);
                Utilizadores.instancia.Dock = DockStyle.Fill;
                Utilizadores.instancia.BringToFront();
            }
            hideSubmenu();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            if (panelConteudo.Controls.Contains(MarcarC.instancia) ||
                panelConteudo.Controls.Contains(Utilizadores.instancia) ||
                panelConteudo.Controls.Contains(HistoricoConsulta.instancia) ||
                panelConteudo.Controls.Contains(ConsultasAgendadas.instancia) ||
                !panelConteudo.Controls.Contains(ucConsultas.instancia))
            {
                panelConteudo.Controls.Clear();
                panelConteudo.Controls.Add(ucConsultas.instancia);
                ucConsultas.instancia.Dock = DockStyle.Fill;
                ucConsultas.instancia.BringToFront();
            }
            hideSubmenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panelConteudo.Controls.Contains(MarcarC.instancia) ||
                panelConteudo.Controls.Contains(Utilizadores.instancia) ||
                panelConteudo.Controls.Contains(ucConsultas.instancia) ||
                panelConteudo.Controls.Contains(ConsultasAgendadas.instancia) ||
                !panelConteudo.Controls.Contains(HistoricoConsulta.instancia))
            {
                panelConteudo.Controls.Clear();
                panelConteudo.Controls.Add(HistoricoConsulta.instancia);
                HistoricoConsulta.instancia.Dock = DockStyle.Fill;
                HistoricoConsulta.instancia.BringToFront();
            }
            hideSubmenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (panelConteudo.Controls.Contains(MarcarC.instancia) ||
                panelConteudo.Controls.Contains(Utilizadores.instancia) ||
                panelConteudo.Controls.Contains(ucConsultas.instancia) ||
                panelConteudo.Controls.Contains(HistoricoConsulta.instancia) ||
               !panelConteudo.Controls.Contains(ConsultasAgendadas.instancia))
            {
                panelConteudo.Controls.Clear();
                panelConteudo.Controls.Add(ConsultasAgendadas.instancia);
                ConsultasAgendadas.instancia.Dock = DockStyle.Fill;
                ConsultasAgendadas.instancia.BringToFront();
            }
            hideSubmenu();
        }
    }
}
