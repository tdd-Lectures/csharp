using System;
using System.Text;

namespace ConsoleApp1
{
    // Write a program that prints the numbers from 1 to 100.
    // But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”.
    // For numbers which are multiples of both three and five print “FizzBuzz”."
    public static class FizzBuzz
    {
        public static string Execute(int value)
        {
            var result = new StringBuilder();

            if (value % 3 == 0) result.Append("Fizz");
            if (value % 5 == 0) result.Append("Buzz");

            return result.Length == 0
                ? value.ToString()
                : result.ToString();
        }
    }
}
