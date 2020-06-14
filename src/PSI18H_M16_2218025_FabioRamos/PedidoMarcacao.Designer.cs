namespace PSI18H_M16_2218025_FabioRamos
{
    partial class PedidoMarcacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidoMarcacao));
            this.Btn1 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.Btn2 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.userControl21 = new PSI18H_M16_2218025_FabioRamos.UserControl2();
            this.userControl11 = new PSI18H_M16_2218025_FabioRamos.UserControl1();
            this.SuspendLayout();
            // 
            // Btn1
            // 
            this.Btn1.ActiveBorderThickness = 1;
            this.Btn1.ActiveCornerRadius = 20;
            this.Btn1.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.Btn1.ActiveForecolor = System.Drawing.Color.White;
            this.Btn1.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.Btn1.BackColor = System.Drawing.SystemColors.Control;
            this.Btn1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn1.BackgroundImage")));
            this.Btn1.ButtonText = "Avançar";
            this.Btn1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.Btn1.IdleBorderThickness = 1;
            this.Btn1.IdleCornerRadius = 20;
            this.Btn1.IdleFillColor = System.Drawing.Color.White;
            this.Btn1.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.Btn1.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.Btn1.Location = new System.Drawing.Point(847, 573);
            this.Btn1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(148, 45);
            this.Btn1.TabIndex = 35;
            this.Btn1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn1.Click += new System.EventHandler(this.Btn1_Click);
            // 
            // Btn2
            // 
            this.Btn2.ActiveBorderThickness = 1;
            this.Btn2.ActiveCornerRadius = 20;
            this.Btn2.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.Btn2.ActiveForecolor = System.Drawing.Color.White;
            this.Btn2.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.Btn2.BackColor = System.Drawing.SystemColors.Control;
            this.Btn2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn2.BackgroundImage")));
            this.Btn2.ButtonText = "Avançar para ultimo passo";
            this.Btn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.Btn2.IdleBorderThickness = 1;
            this.Btn2.IdleCornerRadius = 20;
            this.Btn2.IdleFillColor = System.Drawing.Color.White;
            this.Btn2.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.Btn2.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.Btn2.Location = new System.Drawing.Point(593, 571);
            this.Btn2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(223, 45);
            this.Btn2.TabIndex = 36;
            this.Btn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userControl21
            // 
            this.userControl21.Location = new System.Drawing.Point(0, 0);
            this.userControl21.Name = "userControl21";
            this.userControl21.Size = new System.Drawing.Size(1080, 564);
            this.userControl21.TabIndex = 38;
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(0, 0);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(1080, 564);
            this.userControl11.TabIndex = 37;
            // 
            // PedidoMarcacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 640);
            this.Controls.Add(this.userControl21);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.Btn1);
            this.Name = "PedidoMarcacao";
            this.Text = "PedidoMarcacao";
            this.Load += new System.EventHandler(this.PedidoMarcacao_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuThinButton2 Btn1;
        private Bunifu.Framework.UI.BunifuThinButton2 Btn2;
        private UserControl1 userControl11;
        private UserControl2 userControl21;
    }
}