using FizzBuzzConsole.Utils;
using System;

namespace FizzBuzzConsole.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzz = new FizzBuzz();
            for (int i = 0; i < 100; i++)
            {
                var result = fizzBuzz.Validate(i);
                Console.WriteLine("{0} --> {1}", i, result);
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
