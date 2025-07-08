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
    public partial class Editing : Form
    {
        ClassError CE = new ClassError();
        bool flag = true;

        [Serializable]
        public struct item
        {
            public int n;
            public string Name;
            public string Value;
            public string Number;

        }
        string temp;
        string date_of_birth;

        Form1 F1 = new Form1();
        public List<item> List = new List<item>();
        ListViewItem Student = new ListViewItem();

        public Editing(string s1, string s2, string s3, string s4)
        {
            InitializeComponent();
            textBox1.Text = s1;
            comboBox1.Text = s2;
            comboBox2.Text = s3;
            comboBox6.Text = s4;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            day_mount_year();
            gender_yes();
            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "")
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

        public string Gender
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


        private void Editing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag)
                CE.Error_004();
            if (e.CloseReason == CloseReason.UserClosing && flag)
            {
                e.Cancel = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
