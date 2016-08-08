using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toptal2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 0, 0, 1, 1 };
            int[] array2 = new int[] { 0, 0, 0 };

            int[] m1 = solution(array); //4
        }

        static int[] solution(int[] A)
        {
            if (A == null) return new int[0];
            if (A.Length == 0) return new int[0];

            //Range check
            int length = A.Length;
            if (length > 100000) length = 100000;

            //Obtain the actual number
            int val = 0;
            for (int i = 0; i < length; i++)
            {
                val += A[i] * (int)Math.Pow((double)(-2), i);
            }
            Console.WriteLine("number = " + val);

            //Invert the number
            int value = -val;

            //Create the new number
            List<int> list = new List<int>();
            while (value != 0)
            {
                int div = (int)Math.Ceiling((double)value / (double)-2);
                int remainder = value % -2;
                value = div;
                list.Add(Math.Abs(remainder));
            }

            //Reverse the bits
            int [] returnVal = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                returnVal[i] = list[i];
            }

            return returnVal;

        }

        static int[] fromIntToBinary(int value, int radix)
        {
            List<int> list = new List<int>();
            while (value != 0)
            {
                int div = value / radix;
                int remainder = value % (int)radix;
                value = div;
                list.Add(Math.Abs(remainder));
            }
            int[] ret = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                ret[i] = list[i];
            }
            return ret;
        }
    }
}
