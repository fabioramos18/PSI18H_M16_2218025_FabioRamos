﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PSI18H_M16_2218025_FabioRamos 
{ 

    public partial class Principal : Form
    {  
       
        public Principal()
        {
            InitializeComponent();
            customizeDesign();

        }

        //----------------------------ARRASTAR O FORM-----------------------------------\\

        bool drag = false;
        Point start_point = new Point(0, 0);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }
        private void BarraTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        private void BarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }
        //-------------------------------------------------------------------------------\\


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
            openChildForm(new HospBeatriz());
            //....
            //meu codico
            //....
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
            //....
            //meu codico
            //....
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
            openChildForm(new MarcarConsulta());
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

         
        //--------------------------------------------------------------------
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


        //--------------------------------------------------------------------




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

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
    }
   
}