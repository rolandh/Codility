using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toptal1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 5,5,1,7,2,3,5 };
            int[] array2 = new int[] { 0, 0, 0,1}; 

            int m1 = solution(array, 5); //4
            if (m1 != 4) throw new Exception();

            //int m2 = solution(array2); //4
            //if (m2 != 3) throw new Exception();

        }
        static int solution(int[] A, int X)
        {
            
            if (A == null) return -1;
            if (A.Length <= 0) return -1;

            int length = A.Length;
            //Range check
            if (length > 100000) length = 100000;

            int sameAsXCount = 0;

            //int lastSameAsXIndex = 0;
            //int last
            int[] sameCount = new int[length];

            for (int i = 0; i < length; i++)
            {

                if (A[i] == X)
                {
                    sameAsXCount++;
                    
                }
                sameCount[i] = sameAsXCount;
            }

            int differentToXCount = 0;
            int[] differentCount = new int[length];
            for (int i = length - 1; i >= 0; i--)
            {

                if (A[i] != X)
                {
                    differentToXCount++;
                    
                }
                differentCount[i] = differentToXCount;
            }

            for (int i = 0; i < length; i++)
            {
                if (sameCount[i] == differentCount[i]) return i;
            }

            return 0;
        }
    }
}
