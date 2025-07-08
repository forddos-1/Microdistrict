using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class NewStudent : Form
    {
        ClassError CE = new ClassError();
        bool flag = true;
        Form1 F1 = new Form1();
        ListViewItem Student = new ListViewItem();
        string temp;
        string date_of_birth;

        public NewStudent()
        {
            InitializeComponent();
        }

        private void button_ADD_Click(object sender, EventArgs e)
        {
            day_mount_year();
            gender_yes();
            if( textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "")
            {
                if (radioButton1.Checked || radioButton2.Checked)
                {
                    flag = false;
                    this.Close();
                }
                else CE.Error_003();
            }
            else CE.Error_003();
        }

        public string Full_Name
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string school
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }

        public string class_school
        {
            get { return comboBox2.Text; }
            set { comboBox2.Text = value; }
        }

        public string gender///
        {
            get { return temp; }
            set { temp = value; }
        }

        public string Day
        {
            get { return date_of_birth; }
            set { date_of_birth = value; }
        }

        public string Responsible
        {
            get { return comboBox6.Text; }
            set { comboBox6.Text = value; }
        }

        public void day_mount_year()
        {
            date_of_birth = comboBox3.Text + "." + comboBox4.Text + "." + comboBox5.Text; 
        }

        public void gender_yes()
        {
            if (radioButton1.Checked)
            {
                temp = "Ч";
            }
            if (radioButton2.Checked)
            {
                temp = "Ж";
            }

        }

        private void NewStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag)
                CE.Error_004();
            if (e.CloseReason == CloseReason.UserClosing && flag)
            {
                e.Cancel = true;
            }
        }

       
    }
}
