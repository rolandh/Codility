using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { -1,3,-4,5,1,-6,2,1 };
            int[] array1 = new int[] { 0 };
            int[] array2 = new int[] { Int32.MaxValue, Int32.MaxValue, Int32.MaxValue,Int32.MinValue ,0, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MinValue };

            int m1 = solution(array); //4
            int m2 = solution(array1); //4
            int m3 = solution(array2); //4
        }

        static int solution(int[] A)
        {
            //Equilibrium index
            if (A == null) return -1;
            if (A.Length <= 0) return -1;

            int length = A.Length;
            if (length > 100000) length = 100000;

            //Calculate the sum moving from the left
            long[] leftSum = new long[length];
            long sum = 0;
            for(int i = 0; i < length; i++)
            {

                sum += A[i];

                if (i > 0)
                {
                    //Check for overflow
                    if (sum - A[i] != leftSum[i - 1])
                    {
                        sum = leftSum[i - 1];
                    }
                }

                leftSum[i] = sum;

                
            }

            //Calculate the sum moving from the right
            long[] rightSum = new long[length];
            sum = 0;
            
            for (int i = length - 1; i >= 0; i--)
            {
                sum += A[i];

                if (i < length - 1)
                {
                    //Check for overflow
                    if (sum - A[i] != rightSum[i + 1])
                    {
                        sum = leftSum[i + 1];
                    }
                }

                rightSum[i] = sum;
            }

            for(int i = 1; i < length; i++)
            {
                if (rightSum[i] == leftSum[i]) return i;
            }

            return -1;
        }
    }
}
