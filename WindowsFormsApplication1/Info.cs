using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Info : Form
    {
        public Info( string name, string school, string class_school , string gender , string day , string responsible)
        {
            InitializeComponent();

            label1.Text = name;
            label2.Text = school;
            label3.Text = class_school;
            label4.Text = gender;
            label5.Text = day;
            label6.Text = responsible;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
