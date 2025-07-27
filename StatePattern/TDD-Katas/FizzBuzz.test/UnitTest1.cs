using NUnit.Framework;
using FizzBuzz;
using System.Text;
using System;

namespace FizzBuzz.test
{
    public class Tests
    {
        [Test]
        [TestCase(1, @"1")]
        [TestCase(2, @"1 2")]
        [TestCase(3, @"1 2 Fizz")]
        [TestCase(5, @"1 2 Fizz 4 Buzz")]
        [TestCase(15, @"1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz")]
        [TestCase(100, @"1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz Fizz 22 23 Fizz Buzz 26 Fizz 28 29 FizzBuzz 31 32 Fizz 34 Buzz Fizz 37 38 Fizz Buzz 41 Fizz 43 44 FizzBuzz 46 47 Fizz 49 Buzz Fizz 52 53 Fizz Buzz 56 Fizz 58 59 FizzBuzz 61 62 Fizz 64 Buzz Fizz 67 68 Fizz Buzz 71 Fizz 73 74 FizzBuzz 76 77 Fizz 79 Buzz Fizz 82 83 Fizz Buzz 86 Fizz 88 89 FizzBuzz 91 92 Fizz 94 Buzz Fizz 97 98 Fizz Buzz")]
        [Parallelizable(ParallelScope.All)]
        public void AllNumbersToBoundPrintCorrectly(int bound, string desiredResult)
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            string result = fizzBuzz.GetAllNumbersToBound(bound);

            Assert.AreEqual(desiredResult, result);
        }

        [Test]
        [TestCase(1)]
        [TestCase(15)]
        [TestCase(2000)]
        [Parallelizable(ParallelScope.All)]
        public void FizzBuzzNextWorksCorrectly(int bound)
        {
            FizzBuzz fizzBuzz = new FizzBuzz();

            int i = 1;
            foreach (string next in fizzBuzz.Next())
            {
                if (i > bound)
                {
                    break;
                }

                string fbNumber = fizzBuzz.GetFizzBuzzNumber(i);
                Console.WriteLine(next);
                Console.WriteLine(fbNumber);

                if (next != fbNumber)
                {
                    Assert.Fail();
                }

                i++;
            }

            Assert.Pass();
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(7)]
        [Parallelizable(ParallelScope.All)]
        public void NumberShouldOnlyPrintNumber(int number)
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            Assert.AreEqual(number.ToString(), fizzBuzz.GetFizzBuzzNumber(number));
        }

        [Test]
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(12)]
        [Parallelizable(ParallelScope.All)]
        public void NumberShouldOnlyPrintFizz(int number)
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            Assert.AreEqual("Fizz", fizzBuzz.GetFizzBuzzNumber(number));
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(25)]
        [Parallelizable(ParallelScope.All)]
        public void NumberShouldOnlyPrintBuzz(int number)
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            Assert.AreEqual("Buzz", fizzBuzz.GetFizzBuzzNumber(number));
        }

        [Test]
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(60)]
        [Parallelizable(ParallelScope.All)]
        public void NumberShouldPrintFizzBuzz(int number)
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            Assert.AreEqual("FizzBuzz", fizzBuzz.GetFizzBuzzNumber(number));
        }
    }
}