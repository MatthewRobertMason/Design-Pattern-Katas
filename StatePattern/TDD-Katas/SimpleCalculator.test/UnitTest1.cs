using NUnit.Framework;

namespace SimpleCalculator.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(3, Operator.Addition, 1, 2)]
        [TestCase(3.0, Operator.Addition, 1.0, 2.0)]
        [TestCase(3.0f, Operator.Addition, 1.0f, 2.0f)]
        [TestCase(4, Operator.Subtraction, 6, 2)]
        [TestCase(4.0, Operator.Subtraction, 6.0, 2.0)]
        [TestCase(4.0f, Operator.Subtraction, 6.0f, 2.0f)]
        [TestCase(6, Operator.Multiplication, 2, 3)]
        [TestCase(6.0, Operator.Multiplication, 2.0, 3.0)]
        [TestCase(6.0f, Operator.Multiplication, 2.0f, 3.0f)]
        [TestCase(2, Operator.Division, 10, 5)]
        [TestCase(2.0, Operator.Division, 10.0, 5.0)]
        [TestCase(2.0f, Operator.Division, 10.0f, 5.0f)]
        [Parallelizable(ParallelScope.All)]
        public void TestCalculations(dynamic answer, Operator op, dynamic left, dynamic right)
        {
            Assert.AreEqual(answer, Calculator.Evaluate(op, left, right));
        }

        [Test]
        [TestCase(Operator.Division, 10, 0)]
        [TestCase(Operator.Division, 10.0f, 0.0f)]
        [TestCase(Operator.Division, 10.0, 0.0)]
        [Parallelizable(ParallelScope.All)]
        public void TestDivideByZero(Operator op, dynamic left, dynamic right)
        {
            Assert.Throws<System.DivideByZeroException>(() => { Calculator.Evaluate(op, left, right); });
        }

        [Test]
        [TestCase(0, Operator.Multiplication, 10, 0)]
        [TestCase(0.0, Operator.Multiplication, 10.0, 0.0)]
        [TestCase(0.0f, Operator.Multiplication, 10.0f, 0.0f)]
        [Parallelizable(ParallelScope.All)]
        public void TestMultiplyByZero(dynamic answer, Operator op, dynamic left, dynamic right)
        {
            Assert.AreEqual(answer, Calculator.Evaluate(op, left, right));
        }
    }
}