using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {

            int count4 = countMaxZeroesInARow(51712); //110010100000000

            int count = countMaxZeroesInARow(9); //000001001  2
            int count1 = countMaxZeroesInARow(529); //1000010001  4
            int count2 = countMaxZeroesInARow(1041); //10000010001  5
            int count3 = countMaxZeroesInARow(Int32.MaxValue); //00000  0
            

            Stopwatch timer = new Stopwatch();
            timer.Start();

            for(int i = 0; i <= 50000000; i++)
            {
                int value = countMaxZeroesInARow(i);

                string nString = Convert.ToString(41, 2);
                int charLength = 0;

               MatchCollection matches = Regex.Matches(nString, ".?1([0]+)1");

                foreach (Match match in matches)
                {

                    string c1 = match.Groups[1].ToString();
                    if (c1.Length > charLength) charLength = c1.Length;

                }

                if(charLength != value)
                {
                    int test = 1;
                }
            }
            timer.Stop();
            Debug.WriteLine("Time taken: " + timer.Elapsed);
        }

        private static int countMaxZeroesInARow(int n)
        {
            
            int ones = 0;
            int zeroes = 0;
            int biggestCount = 0;

            while(n != 0)
            {
                int result = n & 1;
                if (result == 0 && ones > 0)
                {
                    zeroes++;
                }
                else if (result == 1)
                {
                    ones++;
                    //If we found two ones register the zero count
                    if (ones == 2)
                    {
                        if (zeroes > biggestCount) biggestCount = zeroes;
                        ones = 1;
                    }
                    zeroes = 0;

                }

                n = n >> 1;
                }



            return biggestCount;
        }

        private static int countMaxZeroesInARowOld(int n)
        {
            if (n == 0) return 0;

            int ones = 0;
            int zeroes = 0;
            int biggestCount = 0;
            int previousValue = 0;
            bool counting = false;

            //Ignore trailing zeroes by finding the leftmost bit
            int v = n;
            int r = 0;
            while (true)
            {
                v = v >> 1;
                r++;
                if (v == 0) break;
            }

            for (int i = 0; i < r; i++)
            {
                int result = n & 1;

                if (result == 1 && previousValue == 0)
                {
                    counting = false;
                }
                if (result == 0 && previousValue == 1)
                {
                    //We are counting now so we need to find another one, set ones to 1
                    ones = 1;
                    counting = true;
                }

                if (result == 0 && ones > 0)
                {
                    zeroes++;
                }
                else
                {
                    ones++;
                    //If we found two ones register the zero count
                    if (ones == 2)
                    {
                        if (zeroes > biggestCount) biggestCount = zeroes;
                        ones = 1;
                    }
                    zeroes = 0;

                }

                previousValue = result;

                n = n >> 1;



            }

            return biggestCount;
        }
    }
}
