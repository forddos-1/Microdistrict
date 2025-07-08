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
    public partial class Search : Form
    {
        bool name = false;
        bool data = false;
        bool ticher = false;

        public Search()
        {
            InitializeComponent();
            DirectoryInfo TestsDir = new DirectoryInfo("Мікрорайон"); //Создаем DiryctoryInfo соответствующее папке Tests c тестами
            if (!TestsDir.Exists) //Если папки Tests нет
                TestsDir.Create(); //Создаем её
            comboBox1.Items.AddRange(TestsDir.GetDirectories());
          
        }

        private void LoadTable(ListView lst, String fname, int ncol)
        {
            if (File.Exists(fname)) // якщо файл існує 
            {
                String[] buf = new String[100]; // буфер рядків 
                string item = "", sc = "", sd = "";
                char delim = (char)9;
                int i = 0, n = 0, j = 0, l = 0, p = 0, index = 0;
                // відкрити потік для читання 
                StreamReader streamreader = new StreamReader(fname);
                // поки є записи 
                while ((item = streamreader.ReadLine()) != null)
                {
                    string result1 = "";
                    for (int j1 = 0; j1 < item.Length; j1++)
                    {
                        Char ch1 = (Char)(item[j1] ^ 'r');
                        result1 += ch1;
                    }
                    item = result1;
                    buf[i] = item; i++; // зберігати записи в буфері
                }

                streamreader.Close(); // закрити потік 
                n = i; // запам'ятати кількість записів 
                if (n > 0)
                {
                    for (i = 0; i < n; i++) // цикл по записах 
                    {
                        item = buf[i] + delim.ToString(); // запам'ятати запис 
                        l = item.Length; // довжина запису 
                        j = 0;
                        while (l > 1) // цикл по рядку 
                        {
                            // позиція роздільника полів
                            p = item.IndexOf(delim);
                            if (p > 0)
                            {
                                // копіюємо частину рядка 
                                sc = item.Substring(0, p);
                                // заносимо в список поле 0 
                                if (j == 0) index = listView1.Items.Add(sc).Index;
                                // заносимо в список решту полів 
                                else listView1.Items[index].SubItems.Add(sc);
                                // зберігаємо частину рядка, що залишилася 
                                sd = item.Substring(p + 1, l - p - 1);
                                item = sd;
                                // визначаємо довжину частини рядка, що залишилася 
                                l = item.Length;
                                j++; // перехід до наступного поля 
                            }
                        }
                    }
                }
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();     
        }

        public void Global_Search(string find)
        {
            for (int i = 0; i < 19; i++)
            {
                progressBar1.Value += 6;
                listView1.Items.Clear();
                LoadTable(listView1, "Мікрорайон" + "\\" + comboBox1.Items[i].ToString() + "\\" + "list.txt", 7);
                //listView2.Items.Clear();

                for (int j = 0; j < listView1.Items.Count; j++)
                {
                    if (listView1.Items[j].SubItems[1].Text == find && name)
                    {
                        int number = listView2.Items.Count + 1;
                        ListViewItem Student = new ListViewItem();
                        Student.Text = number.ToString();
                        Student.SubItems.Add(listView1.Items[j].SubItems[1].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[2].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[3].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[4].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[5].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[6].Text);
                        Student.SubItems.Add(comboBox1.Items[i].ToString());
                        listView2.Items.Add(Student);
                    }
                    if (listView1.Items[j].SubItems[5].Text == find && data)
                    {
                        int number = listView2.Items.Count + 1;
                        ListViewItem Student = new ListViewItem();
                        Student.Text = number.ToString();
                        Student.SubItems.Add(listView1.Items[j].SubItems[1].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[2].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[3].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[4].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[5].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[6].Text);
                        Student.SubItems.Add(comboBox1.Items[i].ToString());
                        listView2.Items.Add(Student);
                    }
                    if (listView1.Items[j].SubItems[6].Text == find && ticher)
                    {
                        int number = listView2.Items.Count + 1;
                        ListViewItem Student = new ListViewItem();
                        Student.Text = number.ToString();
                        Student.SubItems.Add(listView1.Items[j].SubItems[1].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[2].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[3].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[4].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[5].Text);
                        Student.SubItems.Add(listView1.Items[j].SubItems[6].Text);
                        Student.SubItems.Add(comboBox1.Items[i].ToString());
                        listView2.Items.Add(Student);
                    }
                }
                if (i == 18)
                {
                    name = false;
                    data = false;
                    ticher = false;
                    listView1.Items.Clear();
                    if (listView2.Items.Count < listView2.Items.Count - listView2.Items.Count + 1)
                    {
                        MessageBox.Show("Збігів не знайдено, перевірте введену інформацію.");
                    }
                }

            }
        }

        private void button_find_1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                progressBar1.Value = 0;
                listView2.Items.Clear();
                name = true;
                Global_Search(textBox1.Text);
            }
            else MessageBox.Show("Заповніть всі поля перед початком пошуку!", "Помилка!");
        }

        private void button_find_3_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text != "")
            {
                progressBar1.Value = 0;
                listView2.Items.Clear();
                ticher = true;
                Global_Search(comboBox6.Text);
            }
            else MessageBox.Show("Заповніть всі поля перед початком пошуку!", "Помилка!");
            
        }

        private void button_find_2_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "")
            {
                progressBar1.Value = 0;
                listView2.Items.Clear();
                data = true;
                Global_Search(comboBox3.Text + "." + comboBox4.Text + "." + comboBox5.Text);
            }
            else MessageBox.Show("Заповніть всі поля перед початком пошуку!", "Помилка!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            textBox1.Text = "";
            comboBox6.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
        }

    }
}
