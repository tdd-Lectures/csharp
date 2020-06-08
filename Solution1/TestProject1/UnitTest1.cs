using ConsoleApp1;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void Returns_number_when_not_multiple_of_3_or_5([Values(1, 2, 4, 7, 8, 11)]int value)
        {
            var result = FizzBuzz.Execute(value);

            Assert.AreEqual(value.ToString(), result);
        }

        [Test]
        public void Returns_fizz_for_multiple_of_3([Values(3, 6, 9, 12)]int value)
        {
            var result = FizzBuzz.Execute(value);

            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void Returns_buzz_for_multiple_of_5([Values(5, 10, 20)]int value)
        {
            var result = FizzBuzz.Execute(value);

            Assert.AreEqual("Buzz", result);
        }
        [Test]
        public void Returns_fizzbuzz_for_multiple_of_3_and_5([Values(15, 30)]int value)
        {
            var result = FizzBuzz.Execute(value);

            Assert.AreEqual("FizzBuzz", result);
        }
    }
}
