using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equi
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { -1, 3, -4, 5, 1, -6, 2, 1 };
            int[] array2 = new int[] { 0 };
            int[] array3 = new int[] { 1, 2, -100, 2, 1 };
            List<int> t1 = solution(array, array.Length);
            List<int> t2 = solution(array2, array2.Length);
            List<int> t3 = solution(array3, array3.Length);
        }

        static List<int> solution(int[] A, int N)
        {
            List<int> solution = new List<int>();

            if (N == 0 || N == 1)
            {
                solution.Add(-1);
                return solution;
            }


            int[] leftSum = new int[N];
            int[] rightSum = new int[N];
            int summer = 0;
            for (int i = 1; i < N; i++)
            {
                summer += A[i - 1];
                leftSum[i] = summer;
            }

            summer = 0;
            for (int i = N - 2; i >= 0; i--)
            {
                summer += A[i + 1];
                rightSum[i] = summer;
            }

            for (int i = 0; i < N; i++)
            {
                if (leftSum[i] == rightSum[i]) solution.Add(i);
            }

            if (solution.Count == 0) solution.Add(-1);

            return solution;
        }
    }
}
