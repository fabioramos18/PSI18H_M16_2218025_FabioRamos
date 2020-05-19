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
    public partial class Form3 : Form
    {
        private bool isCollapsed;
        public Form3()
        {
            InitializeComponent();
            customizeDesign();

        }

        private void customizeDesign()
        {
            panel1.Visible = false;
            panel3.Visible = false;
        }

        private void hideSubmenu()
        {
            if (panel1.Visible == true)
                panel1.Visible = false;
            if (panel3.Visible == true)
                panel3.Visible = false;

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

        private void btnServicos_Click(object sender, EventArgs e)
        {
            showSubmenu(panel1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //...
            //meu codico
            //...
            hideSubmenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //...
            //meu codico
            //...
            hideSubmenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //...
            //meu codico
            //...
            hideSubmenu();
        }

        private void btnProfissionais_Click(object sender, EventArgs e)
        {
            showSubmenu(panel3);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //...
            //meu codico
            //...
            hideSubmenu();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //...
            //meu codico
            //...
            hideSubmenu();
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            //...
            //meu codico
            //...
            hideSubmenu();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            //...
            //meu codico
            //...
            hideSubmenu();
        }

        private void btnExame_Click(object sender, EventArgs e)
        {
            //...
            //meu codico
            //...
            hideSubmenu();
        }

        private void btnQuemsomos_Click(object sender, EventArgs e)
        {
            //...
            //meu codico
            //...
            hideSubmenu();
        }




        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;


        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;


        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void panelConteudo_Paint(object sender, PaintEventArgs e)
        {

        }


    }
   
}
