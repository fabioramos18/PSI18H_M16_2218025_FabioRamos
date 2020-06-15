namespace PSI18H_M16_2218025_FabioRamos
{
    partial class Profissionais
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label49 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cmbhospital = new System.Windows.Forms.ComboBox();
            this.userControl61 = new PSI18H_M16_2218025_FabioRamos.UserControl6();
            this.userControl51 = new PSI18H_M16_2218025_FabioRamos.UserControl5();
            this.userControl41 = new PSI18H_M16_2218025_FabioRamos.userControl4();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label49);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.cmbhospital);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 86);
            this.panel1.TabIndex = 0;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.label49.Location = new System.Drawing.Point(410, 9);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(312, 36);
            this.label49.TabIndex = 58;
            this.label49.Text = "Selecione o Hospital:";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.panel9.Location = new System.Drawing.Point(0, 81);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1080, 1);
            this.panel9.TabIndex = 57;
            // 
            // cmbhospital
            // 
            this.cmbhospital.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbhospital.Location = new System.Drawing.Point(350, 47);
            this.cmbhospital.Name = "cmbhospital";
            this.cmbhospital.Size = new System.Drawing.Size(436, 28);
            this.cmbhospital.TabIndex = 56;
            this.cmbhospital.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // userControl61
            // 
            this.userControl61.AutoScroll = true;
            this.userControl61.Location = new System.Drawing.Point(0, 92);
            this.userControl61.Name = "userControl61";
            this.userControl61.Size = new System.Drawing.Size(1080, 543);
            this.userControl61.TabIndex = 3;
            // 
            // userControl51
            // 
            this.userControl51.AutoScroll = true;
            this.userControl51.Location = new System.Drawing.Point(0, 84);
            this.userControl51.Name = "userControl51";
            this.userControl51.Size = new System.Drawing.Size(1080, 554);
            this.userControl51.TabIndex = 2;
            // 
            // userControl41
            // 
            this.userControl41.AutoScroll = true;
            this.userControl41.Location = new System.Drawing.Point(0, 92);
            this.userControl41.Name = "userControl41";
            this.userControl41.Size = new System.Drawing.Size(1080, 546);
            this.userControl41.TabIndex = 1;
            // 
            // Profissionais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1080, 640);
            this.Controls.Add(this.userControl61);
            this.Controls.Add(this.userControl51);
            this.Controls.Add(this.userControl41);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Profissionais";
            this.Text = "Formtestarcombobobxes1";
            this.Load += new System.EventHandler(this.Profissionais_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ComboBox cmbhospital;
        private userControl4 userControl41;
        private UserControl5 userControl51;
        private UserControl6 userControl61;
    }
}