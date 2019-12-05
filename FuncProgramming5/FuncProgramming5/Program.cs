using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncProgramming5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*List<int> passanger = Console.ReadLine().Split(' ').Select(Int32.Parse).ToList();
            List<int> taxi = Console.ReadLine().Split(' ').Select(Int32.Parse).ToList();
            Dictionary<int, int> sortedPas = passanger.Select((x, i) => new { x, i })
                .ToDictionary(x => x.i, x => x.x)
                .OrderBy((x) => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
            Dictionary<int, int> sortedTax = taxi.Select((x, i) => new { x, i })
                .ToDictionary(x => x.i, x => x.x)
                .OrderBy((x) => x.Value)
                .Reverse()
                .ToDictionary(x => x.Key, x => x.Value);
            var answer = sortedPas.Zip(sortedTax, (pas, tax) => new KeyValuePair<int, int>(pas.Key, tax.Key));
            var sortedAnswer = answer.OrderBy((x) => x.Key);
            foreach(var element in sortedAnswer)
            {
                Console.Write(element.Value + " ");
            }*/
            foreach (var element in
                Console.ReadLine().Split(' ').Select(Int32.Parse).ToList()
                .Select((x, i) => new { x, i })
                .ToDictionary(x => x.i, x => x.x)
                .OrderBy((x) => x.Value)
                .ToDictionary(x => x.Key, x => x.Value)
                .Zip(Console.ReadLine().Split(' ').Select(Int32.Parse).ToList().Select((x, i) => new { x, i })
                .ToDictionary(x => x.i, x => x.x)
                .OrderBy((x) => x.Value)
                .Reverse()
                .ToDictionary(x => x.Key, x => x.Value), (pas, tax) => new KeyValuePair<int, int>(pas.Key, tax.Key))
                .OrderBy((x) => x.Key))
            {
                Console.Write(element.Value + " ");
            }
        }
    }
}
