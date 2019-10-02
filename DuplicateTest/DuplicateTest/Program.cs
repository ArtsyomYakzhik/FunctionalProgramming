using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DuplicateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(PascalTriangle(1, 2));
            //Console.WriteLine(NumberOfSums(4));
            //Console.WriteLine(FormatDuration(int.MaxValue));
            //Console.WriteLine(NextSmaller(29009));
            Console.WriteLine(StringFunc("This is a string exemplification!", 0));
        }

        public static string StringFunc(string s, long x)
        {
            string result = "";
            List<char> buffer = s.Reverse().ToList();
            for(int i = 0; i < x; i++)
            {
                result += buffer[i];
                buffer.RemoveAt(i);
                buffer.Reverse();
            }
            result += string.Join("", buffer);
            return result;
        }

        /*
        public static long NextSmaller(long n)
        {
            if (n < 10 || isAllDigitSame(n))
                return -1;
            else
                return replaceMinWithFirst(n);
        }

        private static bool isAllDigitSame(long n)
        {
            string nString = n.ToString();
            return nString.All(digit => digit == nString[0]) && 
                nString.Min() != nString[0];
        }
        
        private static long replaceMinWithFirst(long n)
        {
            List<char> nString = n.ToString().ToList();
            char firstElement = nString[0], firstMinElement = nString.FirstOrDefault(x => (x > '0' && x < firstElement));
            if (firstMinElement == '\0')
                return -1;
            int indexOfFirstMin = nString.IndexOf(firstMinElement);
            nString[0] = nString[indexOfFirstMin];
            nString[indexOfFirstMin] = firstElement;
            return long.Parse(string.Join("", nString));
        }
        
        public static string FormatDuration(int seconds)
        {
            if (seconds == 0)
                return "now";
            string result = "";
            Dictionary<string, int> times = new Dictionary<string, int> {
                { "year", 31536000 }
                , { "day", 86400 }
                , { "hour", 3600}
                , {"minute", 60}
                , {"second", 1} };
            foreach(var time in times)
            {
                int buffer = seconds / time.Value;
                if (buffer != 0)
                {
                    result += buffer + " " + (buffer > 1 ? time.Key + "s" : time.Key);
                    seconds -= buffer * time.Value;
                    if (seconds == 0 && result.Contains(","))
                    {
                        result = result.Insert(result.LastIndexOf(','), " and ");
                        result = result.Remove(result.LastIndexOf(','), 2);
                    }
                    else
                    {
                        if(seconds != 0)
                        result += ", ";
                    }
                }
            }
            return result;
        }
        */
        private static int PascalTriangle(int k, int n)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        private static int Factorial(int factor)
        {
            if (factor == 0)
                factor++;
            return factor == 1?factor:factor * Factorial(factor - 1);
        }

        private static int NumberOfSums(int number)
        {
            return number <= 1 ? 0 : number / 2 + (number == 2? 0: 1);
        }
    }
}