using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncProgramming2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BinarySearch(1, new int[] { 1,2,3,4,5,6,7}, 0, 7));
            foreach(var element in firstNPerfectNumbers(28, new List<int>()))
                Console.WriteLine(element);
        }

        private static int BinarySearch(int searcheable ,int[] sortedArray, int leftBound, int rightBound)
        {
            int middleValueIndex = rightBound / 2;
            return sortedArray[middleValueIndex] == searcheable ? middleValueIndex :
                sortedArray[middleValueIndex] > searcheable ? BinarySearch(searcheable, sortedArray, middleValueIndex, rightBound) :
                BinarySearch(searcheable, sortedArray, leftBound, rightBound);
        }

        private static List<int> firstNPerfectNumbers(int n, List<int> arrayOfPerfects)
        {
            int buffer = dividersSum(n, n);
            if (n == buffer)
                arrayOfPerfects.Add(n);
            return n == 1 ? arrayOfPerfects : firstNPerfectNumbers(--n, arrayOfPerfects);
        }
        private static int dividersSum(int n, int i)
        {
            if (n == 1)
                return 0;
            return i == 1 ? 0 : n % (--i) == 0 ? i + dividersSum(n, i) : dividersSum(n, i);   
        }
    }
}
