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

namespace WindowsFormsApplication1
{
    public partial class PasswordSettings : Form
    {
        string password;

        public PasswordSettings()
        {
            InitializeComponent();
            DirectoryInfo TestsDir = new DirectoryInfo("Password"); //Создаем DiryctoryInfo соответствующее папке Tests c тестами
            if (!TestsDir.Exists) //Если папки Tests нет
                TestsDir.Create(); //Создаем её
        }

        private void Save(String Text, String fname)
        {
            StreamWriter streamwriter = new StreamWriter(fname);
            streamwriter.WriteLine(Text);
            streamwriter.Close();
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
                password = Text;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Loading(password, "Password" + "\\" + "password.txt");
            error(password , textBox3.Text);
        }

        private void error(string password, string new_password )
        {
            if (password == new_password)
            {
                Save(textBox1.Text, "Password" + "\\" + "name.txt");
                Save(textBox4.Text, "Password" + "\\" + "password.txt");
            }
            else
            {
                MessageBox.Show("false");
            }
        }
    }
}
