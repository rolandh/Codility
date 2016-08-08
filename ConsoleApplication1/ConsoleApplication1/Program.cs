using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            String s = "127 150 141 164 040 143 145 156 164 165 162 171 040 144 151 144 040 155 141 164 150 145 155 141 164 151 143 151 141 156 163 040 146 151 162 163 164 040 165 163 145 040 160 154 165 163 040 141 156 144 040 155 151 156 165 163 040 163 151 147 156 163 077";


            var chars = s.ToCharArray();

            string Sa = "";

            for(int i = 0; i < chars.Length; i++) {


                Console.WriteLine(chars[i].ToString());

                Sa += chars[i].ToString();

            }

            Console.Write(Sa);
        }
    
    }
}
