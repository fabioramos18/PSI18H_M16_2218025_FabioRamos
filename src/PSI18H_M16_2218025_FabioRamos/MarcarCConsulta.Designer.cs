﻿namespace PSI18H_M16_2218025_FabioRamos
{
    partial class MarcarCConsulta
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.PedidoMarcar = new System.Windows.Forms.Button();
            this.Especialidade = new System.Windows.Forms.ComboBox();
            this.Hospital = new System.Windows.Forms.ComboBox();
            this.Morada = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.NumSaude = new System.Windows.Forms.TextBox();
            this.Contacto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NomeCompleto = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Manhã",
            "Almoço",
            "Tarde ",
            "Noite"});
            this.comboBox1.Location = new System.Drawing.Point(419, 381);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(518, 30);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.Text = "Quando deseja ser Contactado";
            // 
            // PedidoMarcar
            // 
            this.PedidoMarcar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PedidoMarcar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.PedidoMarcar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PedidoMarcar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PedidoMarcar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PedidoMarcar.ForeColor = System.Drawing.Color.White;
            this.PedidoMarcar.Location = new System.Drawing.Point(488, 457);
            this.PedidoMarcar.Name = "PedidoMarcar";
            this.PedidoMarcar.Size = new System.Drawing.Size(334, 42);
            this.PedidoMarcar.TabIndex = 29;
            this.PedidoMarcar.Text = "Pedido de Marcação de Consulta";
            this.PedidoMarcar.UseVisualStyleBackColor = false;
            // 
            // Especialidade
            // 
            this.Especialidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Especialidade.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Especialidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Especialidade.FormattingEnabled = true;
            this.Especialidade.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L"});
            this.Especialidade.Location = new System.Drawing.Point(419, 345);
            this.Especialidade.Name = "Especialidade";
            this.Especialidade.Size = new System.Drawing.Size(518, 30);
            this.Especialidade.TabIndex = 28;
            this.Especialidade.Text = "Especialidade";
            // 
            // Hospital
            // 
            this.Hospital.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Hospital.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hospital.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Hospital.FormattingEnabled = true;
            this.Hospital.Items.AddRange(new object[] {
            "Hospital Beatriz Ângelo",
            "Hospital Cruz  Vermelha",
            "Hospital Da Luz",
            "Hospital Santa Maria"});
            this.Hospital.Location = new System.Drawing.Point(419, 309);
            this.Hospital.Name = "Hospital";
            this.Hospital.Size = new System.Drawing.Size(518, 30);
            this.Hospital.TabIndex = 27;
            this.Hospital.Text = "Hospital";
            // 
            // Morada
            // 
            this.Morada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Morada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Morada.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Morada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Morada.Location = new System.Drawing.Point(419, 274);
            this.Morada.Name = "Morada";
            this.Morada.Size = new System.Drawing.Size(518, 29);
            this.Morada.TabIndex = 26;
            this.Morada.Text = "Morada";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(419, 239);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(266, 29);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // NumSaude
            // 
            this.NumSaude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NumSaude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumSaude.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumSaude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.NumSaude.Location = new System.Drawing.Point(419, 169);
            this.NumSaude.Name = "NumSaude";
            this.NumSaude.Size = new System.Drawing.Size(266, 29);
            this.NumSaude.TabIndex = 24;
            this.NumSaude.Text = "N. de Saude";
            // 
            // Contacto
            // 
            this.Contacto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Contacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Contacto.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.Contacto.Location = new System.Drawing.Point(419, 204);
            this.Contacto.Name = "Contacto";
            this.Contacto.Size = new System.Drawing.Size(266, 29);
            this.Contacto.TabIndex = 23;
            this.Contacto.Text = "Telemovel / Telefone ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label1.Location = new System.Drawing.Point(496, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 45);
            this.label1.TabIndex = 22;
            this.label1.Text = "Marcação de Consulta";
            // 
            // NomeCompleto
            // 
            this.NomeCompleto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NomeCompleto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NomeCompleto.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomeCompleto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.NomeCompleto.Location = new System.Drawing.Point(419, 134);
            this.NomeCompleto.Name = "NomeCompleto";
            this.NomeCompleto.Size = new System.Drawing.Size(518, 29);
            this.NomeCompleto.TabIndex = 21;
            this.NomeCompleto.Text = "Nome Completo";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(144, 535);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(184, 42);
            this.button4.TabIndex = 20;
            this.button4.Text = "Voltar ao inicio ";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // MarcarCConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 640);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.PedidoMarcar);
            this.Controls.Add(this.Especialidade);
            this.Controls.Add(this.Hospital);
            this.Controls.Add(this.Morada);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.NumSaude);
            this.Controls.Add(this.Contacto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NomeCompleto);
            this.Controls.Add(this.button4);
            this.Name = "MarcarCConsulta";
            this.Text = "MarcarCConsulta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button PedidoMarcar;
        private System.Windows.Forms.ComboBox Especialidade;
        private System.Windows.Forms.ComboBox Hospital;
        private System.Windows.Forms.TextBox Morada;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox NumSaude;
        private System.Windows.Forms.TextBox Contacto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NomeCompleto;
        private System.Windows.Forms.Button button4;
    }
}