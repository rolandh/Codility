using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peaks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 5,   4, 5, 4,   1, 5, 3,   4, 6, 2 };
            int[] array2 = new int[] { 0, 50, 49,  51, 52, 0 };
            int[] array3 = new int[] { 1,2,-100,2,1 };
            int[] array4 = new int[] { 1 };
            int[] array5 = new int[] { 1, 2, 3, 4,  3, 4, 1, 2,  3, 4, 6, 2 };

            int[] array6 = new int[] { 1, 5, 6, 8,6,8,   4,5, 4, 5, 2,1,   4,6, 4, 6, 2,1 };

            int m1 = MaxBlocks(array); //4
            int m2 = MaxBlocks(array2); //2
            int m3 = MaxBlocks(array3); //1
            int m4 = MaxBlocks(array4); //1
            int m5 = MaxBlocks(array5); //4
            int m6 = MaxBlocks(array6); //4
        }

        static List<int> peaks;
        static int[] array;

        static int MaxBlocks(int [] A)
        {
            int length = A.Length;
            array = A;

            if (length <= 0) return 0;
            if (length > 100000) length = 100000;

            int foundAPeak = 0;

            //Pre compute all peaks so we don't check multiple times, O(n) storage required
            peaks = new List<int>(length);

            //if we only have 1 element
            if (length == 1) if (A[0] > 0)
            {
                peaks.Add(0);
                foundAPeak=1;
            }

            for (int i = 1; i < length - 1; i++)
            {
                //Found a peak?
                if (A[i] > A[i + 1] && A[i] > A[i - 1])
                {
                    peaks.Add(i);
                    foundAPeak++;
                } else
                {
                    A[i] = 0;
                }
                    
            }

            //We must have at least 1 peaks
            if (foundAPeak < 1) return 0;

            //Use static arrays so we don't need to pass pointers
            array = A;

            //Find divisors of A
            int maxDivisor = 0;

            //largest possible divisor is sqrt(length)
            //Ignore divisor 1
            //find the smallest divisor
            int smallestDivisor = 0;
            for(int i = 2; i <= (int)Math.Sqrt(length); i++)
            {
                if ((length % i) == 0)
                {
                    smallestDivisor = i;
                    break;
                }
            }

            //If there were no smallest divisors check case 1
            if (smallestDivisor == 0)
            {
                if (GroupHasPeak(0, 1) != 0)
                {
                    return  1;
                }
            }

            //Division by itself does not count as we can't have a peak in every cell of length 1
            int largestDivisor = length / smallestDivisor;

            for (int divisor = largestDivisor; divisor >= smallestDivisor; divisor--)
            {
                if ((length % divisor) == 0)
                {
                    Console.WriteLine("Found Divisor: " + divisor);
                    //We have found a divisor, lets check if a peak exists in all groups
                    int groupsWithPeaks = 0;
                    for (int groupNumber = 0; groupNumber < divisor; groupNumber++)
                    {
                        //If this group doesn't have a peak, skip this divisor
                        if (GroupHasPeak(groupNumber, divisor) == 0)
                        {
                            break;
                        }
                        else
                        {
                            groupsWithPeaks++;
                        }
                    }
                    //If all groups had a peak then we successfully found a valid divisor, keep track of this divisor
                    if (groupsWithPeaks == divisor) return divisor;

                }

            }


            //List was either indivisible or there existed no number of groups that all contained a peak
            return maxDivisor;
        }

        static int GroupHasPeak(int groupNumber, int divisor)
        {
            if (array.Length == 0 || peaks.Count == 0) return 0;

            int result = 0;
            int i;
            int lengthOfABlock = (array.Length / divisor);

            int endIndex = (groupNumber + 1) * lengthOfABlock;

            foreach(int peak in peaks)
            {
                //If our peak is beyond the group index no point checking any further
                if (peak > endIndex) return 0;

                //if our peak is within this block we are ok, return true
                if (peak >= (groupNumber * lengthOfABlock) && peak < endIndex) return 1;
            }


            return result;

        }



    }
}


