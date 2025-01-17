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
using MySql.Data.MySqlClient;


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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void BarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //-------------------------------------------------------------------------------\\


        private void customizeDesign()
        {
            panel1.Visible = false;

        }

        private void hideSubmenu()
        {
            if (panel1.Visible == true)
                panel1.Visible = false;
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
            hideSubmenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            openChildForm(new HospLuz());
            hideSubmenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openChildForm(new HospTrofa());
            hideSubmenu();
        }

        private void btnProfissionais_Click(object sender, EventArgs e)
        {
            openChildForm(new Profissionais());
            hideSubmenu();
        }
      
        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            openChildForm(new MinhaConta());
            hideSubmenu();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            openChildForm(new PedidoMarcacao());
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

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void button6_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show(@"Deseja terminar a sessão?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            switch (result)
            {
                case DialogResult.Yes:
                    Entrar entrarform = new Entrar();
                    entrarform.Show();
                    this.Hide();
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }


            
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openChildForm(new ConteudoPrincipal());
            hideSubmenu();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            openChildForm(new ConteudoPrincipal());
            hideSubmenu();
        }
    
    }
   
}
