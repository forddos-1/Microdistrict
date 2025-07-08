using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class Password : Form
    {
        string name;
        string password;

        ClassError CE = new ClassError();

        public Password()
        {
            InitializeComponent();
        }

        private void Loading(String Text, String fname)
        {
            if (File.Exists(fname))
            {
                string item = "";
                StreamReader streamreader = new StreamReader(fname);
                while ((item = streamreader.ReadLine()) != null)
                {
                    Text = item;
                }
                streamreader.Close();
                if (fname == "Password" + "\\" + "name.txt") { name = Text; }
                if (fname == "Password" + "\\" + "password.txt") { password = Text; }
                
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Loading(name, "Password" + "\\" + "name.txt");
            Loading(password, "Password" + "\\" + "password.txt");
            for (int i = 0; i <= 100; i++)
            {
                if (i < 101)
                {
                    progressBar1.Value = i;
                }

            }
            if (name == textBox1.Text && password == textBox2.Text)
            {
                CE.Error_005();
                Form1 F1 = new Form1();
                this.Hide();
                F1.ShowDialog();
                this.Close();
                
            }
            else
            {
                CE.Error_006();
                progressBar1.Value = 0;
            }

        }


    }
}
