using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Coding_r
    {
        public string Kod(string s)
        {
            string result = "";
            for (int i1 = 0; i1 < s.Length; i1++)
            {
                Char ch = (Char)(s[i1] ^ 'r');
                result += ch;
            }
            s = result;
            return s;
        }

        public string De_kod(string item)
        {
            string result1 = "";
            for (int j1 = 0; j1 < item.Length; j1++)
            {
                Char ch1 = (Char)(item[j1] ^ 'r');
                result1 += ch1;
            }
            item = result1;
            return item;
        }
    }
}
