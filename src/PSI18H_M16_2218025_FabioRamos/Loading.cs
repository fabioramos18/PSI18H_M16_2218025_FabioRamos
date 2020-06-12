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
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel3.Width += 1;
            if(panel3.Width >= 801)
            {
                timer1.Stop();
                Principal principalform = new Principal();
                this.Hide();
                principalform.Show();
            }
        }
    }
}
