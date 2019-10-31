using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncProgramming3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string constString = "You can't change me";//Переменная с неизменяемым значением
            
            Console.WriteLine(Sum(4, 7));//Функция чистая, так как: при одних и тех же значения переменных результат не меняется,
                                         //а так же срабатывание функции не влияет на какое-либо состояние за пределами
            
            Func<int, int, int> funcOfFirstOrder = (a, b) => a + b;//Функция принимает функцию первого порядка, так как она передается в качестве аргумента
                                                                   //и может быть представлена в виду объекта, с помощью делегатов
            
            FunctionOfHighestOrder(funcOfFirstOrder)("Jhon", Sum(10,5));//Функция высшего порядка, принимает функцию как аргумент и возвращает функцию как аргумент
            Func<int, int, int> multiply = (x, y) => x * y;
            //Func<int, Func<int, int>> curryMultiply = multiply.Curry(); В C# отсутствует каррирование

            Dictionary<int, int> cache = new Dictionary<int, int>();//Меморизация работает, если объект, который хранит кэш, находится за пределами функции
            Func<int, int> addTen = (number) =>
            {
                if (!cache.Keys.Contains(number))
                    cache.Add(number, number + 10);
                return cache[number];
            };
            Console.WriteLine(addTen(10));
            Console.WriteLine(addTen(10));
            Lazy<object> lazyObject = new Lazy<object>();//Возможна только ленивая инициализация объекта
            Enumerable.Range(1, 10).Select(a => "{a}");//Map
            Enumerable.Range(1, 10).Aggregate(0, (acc, x) => acc + x);//Reduce
            Enumerable.Range(1, 10).Where(a => a > 5);//Filter
        }

        private static int Sum(int a, int b) => a + b;//Лямбда
        private static Action<string, int> FunctionOfHighestOrder(Func<int, int, int> sum)
        {
            Console.WriteLine(sum(10, 5));
            return OutputSumWithName;
        }

        private static void OutputSumWithName(string name, int sum)
        {
            Console.WriteLine(@"Hello {0}, sum of this numbers is {1}", name, sum);
        }
    }
}
