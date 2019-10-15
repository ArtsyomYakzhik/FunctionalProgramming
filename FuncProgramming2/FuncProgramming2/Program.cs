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
        }

        private static int BinarySearch(int searcheable ,int[] sortedArray, int leftBound, int rightBound)
        {
            int middleValueIndex = rightBound / 2;
            return sortedArray[middleValueIndex] == searcheable ? middleValueIndex :
                sortedArray[middleValueIndex] > searcheable ? BinarySearch(searcheable, sortedArray, middleValueIndex, rightBound) :
                BinarySearch(searcheable, sortedArray, leftBound, rightBound);
        }
    }
}
