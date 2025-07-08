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
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public string [] info = new string [3];
        private TreeNode MyNode = new TreeNode();
        htmlGenerationClass html = new htmlGenerationClass();
        XmlTextWriter testWriterHTML;

        Coding_r CR = new Coding_r();
        ClassError CE = new ClassError();
        Password p = new Password();

        public Form1()
        {
            InitializeComponent();          

            DirectoryInfo TestsDir = new DirectoryInfo("Мікрорайон");
            if (!TestsDir.Exists)
                TestsDir.Create();
            comboBox1.Items.AddRange(TestsDir.GetDirectories());
            buttonAdd.Enabled = false;
            button_Delete.Enabled = false;
            button_Edit.Enabled = false;
            button_Info.Enabled = false;
            button_Save.Enabled = false;
            btn_print.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void SaveList(ListView lst, String fname, int ncol)
        {
            int i, j, n;
            char delim = (char)9; // роздільник полів - Tab 
            string s, sitem, sdelim = delim.ToString();
             //відкрити потік для запису 
            StreamWriter streamwriter = new StreamWriter(fname);
            n = lst.Items.Count; // кількість записів 
            for (i = 0; i < n; i++) // цикл по записах 
            {
                s = "";
                for (j = 0; j < ncol; j++) // цикл по полях запису 
                {
                    sitem = listView1.Items[i].SubItems[j].Text;
                    s = s + sitem + sdelim;
                }
                streamwriter.WriteLine(CR.Kod(s)); // запис у файл 
            }
            streamwriter.Close(); // закрити потік 
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
                    buf[i] = CR.De_kod(item);
                    i++; // зберігати записи в буфері
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonAdd.Enabled = true;
            button_Delete.Enabled = true;
            button_Edit.Enabled = true;
            button_Info.Enabled = true;
            button_Save.Enabled = true;
            btn_print.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            listView1.Items.Clear();
            LoadTable(listView1, "Мікрорайон" + "\\" + comboBox1.Text + "\\" + "list.txt", 7);
            
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            listView1.FocusedItem.ForeColor = Color.Black;
            if (e.Button == MouseButtons.Right)
            {
                listView1.FocusedItem.BackColor = Color.White;
            }   
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddStudent();         
        }

        private void AddStudent()
        {
            NewStudent NS = new NewStudent();
            int n = listView1.Items.Count - 1; 
            string n2 = listView1.Items[n].SubItems[0].Text;
            int n3 = Convert.ToInt32(n2)+1;
            ListViewItem Student = new ListViewItem();
            NS.ShowDialog();
            Student.Text = n3.ToString();
            Student.SubItems.Add(NS.Full_Name);
            Student.SubItems.Add(NS.class_school);
            Student.SubItems.Add(NS.school);
            Student.SubItems.Add(NS.gender);
            Student.SubItems.Add(NS.Day);
            Student.SubItems.Add(NS.Responsible);
            listView1.Items.Add(Student);
            
        }

        public void AddStudents(ListViewItem Student, int i)
        {
            Student.Text = listView1.Items.Count + 1.ToString();
            Student.SubItems.Add(listView1.Items[i].SubItems[1].Text);
            Student.SubItems.Add(listView1.Items[i].SubItems[2].Text);
            Student.SubItems.Add(listView1.Items[i].SubItems[3].Text);
            Student.SubItems.Add(listView1.Items[i].SubItems[4].Text);
            Student.SubItems.Add(listView1.Items[i].SubItems[5].Text);
            Student.SubItems.Add(listView1.Items[i].SubItems[6].Text);
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SaveList(listView1, "Мікрорайон" + "\\" + comboBox1.Text + "\\" + "list.txt", 7);
            testWriterHTML = new XmlTextWriter("Мікрорайон" + "\\" + comboBox1.Text + "\\" + "list.html", Encoding.UTF8);
            testWriterHTML.Formatting = Formatting.Indented;//Обеспечиваем читабельность файла
            html.OpenFile(testWriterHTML, comboBox1.Text, "Список даного мікрорайону.");
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ListViewItem Student = new ListViewItem();
                AddStudents(Student, i);
                html.WriteQuestion(testWriterHTML, Student, i + 1);
            }
            html.CloseFile(testWriterHTML);
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            Search SE = new Search();
            SE.ShowDialog();
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                EditStudent(listView1.FocusedItem.Index);                
            }
            else CE.Error_001();
        }

        private void EditStudent(int n)
        {
            Editing Ed = new Editing(listView1.Items[n].SubItems[1].Text, listView1.Items[n].SubItems[3].Text, listView1.Items[n].SubItems[2].Text, listView1.Items[n].SubItems[6].Text);
            Ed.ShowDialog();
            listView1.Items[n].SubItems[1].Text = Ed.Full_Name;
            listView1.Items[n].SubItems[3].Text = Ed.school;
            listView1.Items[n].SubItems[2].Text = Ed.class_school;
            listView1.Items[n].SubItems[4].Text = Ed.Gender;
            listView1.Items[n].SubItems[5].Text = Ed.Day;
            listView1.Items[n].SubItems[6].Text = Ed.Responsible;
            
        }

        private void button_Info_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                int n = listView1.FocusedItem.Index;
                Info IN = new Info(listView1.Items[n].SubItems[1].Text, listView1.Items[n].SubItems[2].Text, listView1.Items[n].SubItems[3].Text, listView1.Items[n].SubItems[4].Text, listView1.Items[n].SubItems[5].Text, listView1.Items[n].SubItems[6].Text);
                IN.ShowDialog();
            }
            else CE.Error_001(); 
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
             if (listView1.FocusedItem != null)
            {
                if (listView1.FocusedItem.Index >= 0)
                {
                    int n = listView1.Items.Count - 2;
                    listView1.Items[listView1.FocusedItem.Index].Remove();
                    ListViewItem Student = new ListViewItem();
                    for (int i = 0; i <= n; i++)
                    {
                        listView1.Items[i].SubItems[0].Text = (i + 1).ToString();
                    }
                }
            }
             else CE.Error_001(); 


        }

        private void button_Password_Click(object sender, EventArgs e)
        {
            PasswordSettings PS = new PasswordSettings();
            PS.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem Student = new ListViewItem();
            if (textBox1.Text != "" || comboBox2.Text != "" && comboBox7.Text != "" && comboBox8.Text != "" || comboBox3.Text != "")
            {
                if (textBox1.Text != "")
                {
                    SearchStudent(listView1.Items.Count, 1, textBox1.Text, Color.Red);
                    textBox1.Text = "";
                    
                }

                if (comboBox2.Text != "" && comboBox7.Text != "" && comboBox8.Text != "")
                {
                   string date_of_birth = comboBox2.Text + "." + comboBox7.Text + "." + comboBox8.Text;
                   SearchStudent(listView1.Items.Count, 5, date_of_birth, Color.Silver);
                   comboBox2.Text = ""; comboBox7.Text = ""; comboBox8.Text = "";
                    
                }

                if (comboBox3.Text != "")
                {
                    SearchStudent(listView1.Items.Count, 6, comboBox3.Text, Color.Violet);
                    comboBox3.Text = "";
                   
                }
            }
            else CE.Error_002(); 
        }

        private void SearchStudent(int n , int count, string text , Color t)
        {
            for (int i = 0; i < n; i++)
            {
                if (listView1.Items[i].SubItems[count].Text == text)
                {
                    listView1.Items[i].BackColor = t;
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listView1.FocusedItem.ForeColor = Color.Red;      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].BackColor = Color.White;
                
            }
        }

        private void button_Internet_Click(object sender, EventArgs e)
        {
            Process html = new Process();
            html.StartInfo.FileName = "Мікрорайон\\" +"index.html";
            html.Start();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(listView1.Size.Width + 10, listView1.Size.Width + 10);
            listView1.DrawToBitmap(bmp, listView1.Bounds);
            e.Graphics.DrawImage(bmp, 0, 0);
        }

    }

}
