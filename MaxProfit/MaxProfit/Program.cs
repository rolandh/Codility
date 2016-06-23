using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data1 = { 0, 1, 2, 3, 4, 5 };
            int[] data2 = { 0, 1, 50, 65, 4, 5 };
            int[] data3 = { 0, 1, 2, 10, 11, 12,5,1};
            int[] data4 = { 3, 2, 2, 65, 1, 5 };
            int[] data5 = { 1000, 1000, 1500, 0, 499, 487 };
            int[] data6 = { 10, 9, 8, 7, 5, 4, 2, 1 };
            int[] data7 = { 0, 1, 2, 3, 4, 5 };
            int[] data8 = { 0, 1, 50, 65, 4, 5 };
            int[] data9 = { 0, 1, 2, 10, 11, 12, 5, 1 };

            int maximumProfit1 = MaximumProfit(data1, data1.Length);
            int maximumProfit2 = MaximumProfit(data2, data2.Length);
            int maximumProfit3 = MaximumProfit(data3, data3.Length);
            int maximumProfit4 = MaximumProfit(data4, data4.Length);
            int maximumProfit5 = MaximumProfit(data5, data5.Length);
            int maximumProfit6 = MaximumProfit(data6, data6.Length);
            int maximumProfit7 = MaximumProfit(data7, data7.Length);
            int maximumProfit8 = MaximumProfit(data8, data8.Length);
            int maximumProfit9 = MaximumProfit(data9, data9.Length);

        }

        static int MaximumProfit(int [] A, int n)
        {
            int min = Int32.MaxValue;
            int MaximumProfit = 0;
            for (int i = 0; i < n; i++)
            {
                if (A[i] < min) min = A[i];
                if ((A[i] - min) > MaximumProfit) MaximumProfit = (A[i] - min);
            }
            if (MaximumProfit < 0) return 0;
            return MaximumProfit;
        }
    }
}
