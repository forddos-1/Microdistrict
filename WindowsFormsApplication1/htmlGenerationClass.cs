using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{
    class htmlGenerationClass
    {
        public void OpenFile(XmlWriter testWriterHTML, string nameTest, string themeTest)
        {
            testWriterHTML.WriteStartDocument();
            testWriterHTML.WriteStartElement("html");
            testWriterHTML.WriteStartElement("head");
            testWriterHTML.WriteStartElement("title");
            testWriterHTML.WriteString(nameTest);
            testWriterHTML.WriteEndElement();
            testWriterHTML.WriteEndElement();
            testWriterHTML.WriteStartElement("body");
            testWriterHTML.WriteStartAttribute("background");
            testWriterHTML.WriteString("zastavka.jpg");
            testWriterHTML.WriteEndAttribute();
            testWriterHTML.WriteStartElement("table");
            testWriterHTML.WriteStartAttribute("border");
            testWriterHTML.WriteString("1");
            testWriterHTML.WriteEndAttribute();
            testWriterHTML.WriteStartElement("caption");
            testWriterHTML.WriteString(themeTest);
            testWriterHTML.WriteEndElement();

            testWriterHTML.WriteStartElement("tr");// tr
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString("№");
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString("ПІБ");
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString("Школа");
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString("Клас");
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString("Стать");
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString("Дата");
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString("Відповідальний");
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteEndElement();// /tr

        }

        public void CloseFile(XmlWriter testWriterHTML)
        {
            testWriterHTML.WriteEndElement();
            testWriterHTML.WriteEndElement();
            testWriterHTML.WriteEndElement();
            testWriterHTML.Close();
        }

        public void WriteQuestion(XmlWriter testWriterHTML, ListViewItem Student, int count)
        {

            testWriterHTML.WriteStartElement("tr");// tr
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString(count.ToString());
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString(Student.SubItems[1].Text);
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString(Student.SubItems[2].Text);
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString(Student.SubItems[3].Text);
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString(Student.SubItems[4].Text);
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString(Student.SubItems[5].Text);
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteStartElement("td");// td
            testWriterHTML.WriteString(Student.SubItems[6].Text);
            testWriterHTML.WriteEndElement();// /td
            testWriterHTML.WriteEndElement();// /tr


        }
    }
}
