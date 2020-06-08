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
    public partial class Formtestarcombobobxes1 : Form
    {
        public Formtestarcombobobxes1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
              if (comboBox1.SelectedItem.ToString() == "a")
              {
                  comboBox2.Items.Clear();
                  comboBox2.Items.Add("1");
                  comboBox2.Items.Add("2");
                  comboBox2.Items.Add("3");
              }
              else if(comboBox1.SelectedItem.ToString() == "bb")
              {
                  comboBox2.Items.Clear();
                  comboBox2.Items.Add("11");
                  comboBox2.Items.Add("22");
                  comboBox2.Items.Add("33");
              }
              else
              {
                  comboBox2.Items.Clear();
                  comboBox2.Items.Add("111");
                  comboBox2.Items.Add("222");
                  comboBox2.Items.Add("333");
              }
        }


    }
}
