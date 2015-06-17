using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzZip
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fizzs = RepeatEndless("", "", "Fizz");
            var buzzs = RepeatEndless("", "", "", "", "Buzz");
            var numbers = Numbers().Select(n => n.ToString());
            var fizzsAndBuzzs = fizzs.Zip(buzzs, (x, y) => x + y);
            var fizzsAndBuzzsWithNumbers = fizzsAndBuzzs.Zip(numbers, (x, y) => string.IsNullOrEmpty(x) ? y : x);
            
            foreach (var fizzBuzz in fizzsAndBuzzsWithNumbers.Take(100))
            {
                Console.Write($"{fizzBuzz}, ");
            }
            
            Console.ReadLine();
        }
        
        public static IEnumerable<int> Numbers()
        {
            for (int i = 1; ; i++)
            {
                yield return i;
            }
        }
        
        public static IEnumerable<T> RepeatEndless<T>(params T[] values)
        {
            for (;;)
            {
                foreach(var value in values)
                {
                    yield return value;
                }
            }
        }
    }
}
