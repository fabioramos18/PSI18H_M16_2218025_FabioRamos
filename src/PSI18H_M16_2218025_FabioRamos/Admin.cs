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
            if (panel3.Visible == true)
                panel3.Visible = false;
            if (panel4.Visible == true)
                panel4.Visible = false;
        }
        private void hideuc()
        {
            if (panel2.Visible == true)
                panel2.Visible = false;
            if (panel3.Visible == true)
                panel3.Visible = false;
            if (panel4.Visible == true)
                panel4.Visible = false;
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
            if (!panelConteudo.Controls.Contains(ucConsultas.instancia))
            {
                panelConteudo.Controls.Add(ucConsultas.instancia);
                ucConsultas.instancia.Dock = DockStyle.Fill;
                ucConsultas.instancia.BringToFront();
            }

            movepanel(button1);
            //hideSubmenu();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //openChildForm(new TestargGridView());

            if (!panelConteudo.Controls.Contains(UserControl8.instancia))
            {
                panelConteudo.Controls.Add(UserControl8.instancia);
                UserControl8.instancia.Dock = DockStyle.Fill;
               // UserControl8.instancia.BringToFront();
            }

            movepanel(button2);
            hideSubmenu();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Medicos());

            

            //         Medicos medicosform = new Medicos();
            //  this.Hide();
            //       medicosform.Show();
            movepanel(button3);
            hideSubmenu();

        }

        private void Admin_Load(object sender, EventArgs e)
        {
          //  ucConsultas1.Hide();
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

        

       

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
