using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flags
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 };
            int[] array2 = new int[] { 1, 5, 3, 4, 3, 4, 1, 2, 8, 4, 6, 2 };
            int[] array3 = new int[] { 1, 5, 3, 4, 3, 4, 1, 6, 2, 2, 2, 2 };
            int[] array4 = new int[] { 0, 5, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0 };
            int[] array5 = new int[] { 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 0 };
            int[] array6 = new int[] { 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] array7 = new int[] { 0, 0, 0, 0, 0, 0 };
            int[] array8 = new int[] { 5 };
            int[] array9 = new int[] { 0, 5 };
            int[] array10 = new int[] { 0, 5, 0 };
            int[] array11 = new int[] { 0, 0, 0 };

            int m1 = solution(array); //4
            if (m1 != 3) throw new Exception();

            int m2 = solution(array2); //4
            if (m2 != 3) throw new Exception();

            int m3 = solution(array3); //4
            if (m3 != 2) throw new Exception();

            int m4 = solution(array4); //4
            if (m4 != 4) throw new Exception();

            int m5 = solution(array5); //4
            if (m5 != 4) throw new Exception();

            int m6 = solution(array6); //4
            if (m6 != 4) throw new Exception();

            int m7 = solution(array7); //4
            if (m7 != 0) throw new Exception();

            int m8 = solution(array8); //4
            if (m8 != 0) throw new Exception();

            int m9 = solution(array9); //4
            if (m9 != 0) throw new Exception();

            int m10 = solution(array10); //4
            if (m10 != 0) throw new Exception();

            int m11 = solution(array11);
            if (m11 != 0) throw new Exception();

            //Test time complexity
            int max = 2000000;
            long[] timers = new long[max];
            Stopwatch timer = new Stopwatch();
            int Min = 0;
            int Max = 20;
            int p = 0;
            for (int i = 1; i < max; i+=1000)
            {
                int[] test2 = new int[i];
                Random randNum = new Random();
                for (int j = 0;j < test2.Length; j++)
                {
                    test2[j] = randNum.Next(Min, Max);
                }
                timer.Reset();
                timer.Start();
                int test = solution(test2);
                timer.Stop();
                long temp = timer.ElapsedMilliseconds;
                timers[p] = temp;

                p++;
            }
            String results = "";
            for (int i = 0; i < max/1000; i++)
            {
                results += i.ToString() + "\t" + timers[i].ToString() + Environment.NewLine;
            }
            using (StreamWriter writer = new StreamWriter(@"C:\temp\temp.txt"))
            {
                writer.Write(results);
            }
        }
                



        static public int solution(int [] A)
        {
            int length = A.Length;

            if (length <= 2) return 0;
            if (length > 400000) length = 400000;

            int peakCount = 0;

            //Pre compute all peaks so we don't check multiple times, O(n) storage required
            List<int> allPeaks = new List<int>(length);

            //if we only have 1 element
            if (length == 1) if (A[0] > 0)
            {
                allPeaks.Add(0);
                    peakCount = 1;
            }

            for (int i = 1; i < length - 1; i++)
            {
                //Found a peak?
                if (A[i] > A[i + 1] && A[i] > A[i - 1])
                {
                    allPeaks.Add(i);
                    peakCount++;
                }
                else
                {
                    A[i] = 0;
                }
            }

            //Edge cases
            if (peakCount == 0) return 0;
            if (peakCount == 1) return 1;

            //Find the maximum number of peaks/minimum distance between peaks, subtract the start and end as these cannot be peaks
            int maxPeaksPossible = (int)Math.Sqrt(length);

            //If we found more peaks than is possible, cap it at this amount
            if (peakCount < maxPeaksPossible) maxPeaksPossible = peakCount;

            //Start at 1 as the first peak is always valid
            int validPeakCount = 1;

            int distanceBetweenPeaks;

            //Start at the maximum number of peaks and see if our found peaks have enough distance between them
            for (int peakNumber = maxPeaksPossible; peakNumber > 0; peakNumber--)
            {
                distanceBetweenPeaks = peakNumber;

                //To invalidate a peak add an offset
                int offset = 0;
                validPeakCount = 1;

                for (int i = 0; i < allPeaks.Count - 1; i++)
                {
                    int leftIndex = i - offset;
                    int rightIndex = i + 1;
                    int currentDistanceBetweenPeaks = allPeaks[rightIndex] - allPeaks[leftIndex];
                    if (currentDistanceBetweenPeaks >= distanceBetweenPeaks)
                    {
                        validPeakCount++;
                        offset = 0;
                    } else
                    {
                        offset++;
                    }
                    if (validPeakCount == peakNumber) return peakNumber;
                }
                
            }

            return 0;
        }
    }
}
