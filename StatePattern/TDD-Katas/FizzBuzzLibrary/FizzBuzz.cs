using System.Text;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public string GetFizzBuzzNumber(int number)
        {
            string result = string.Empty;
            result = Fizz(number);
            result += Buzz(number);

            if (string.IsNullOrWhiteSpace(result))
            {
                result = number.ToString();
            }

            return result;
        }

        public string GetAllNumbersToBound(int bound)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= bound; i++)
            {
                result.Append(GetFizzBuzzNumber(i) + " ");
            }

            return result.ToString().Trim();
        }

        public IEnumerable<string> Next()
        {
            int currentNumber = 1;

            while (currentNumber < int.MaxValue)
            {
                yield return GetFizzBuzzNumber(currentNumber);
                currentNumber++;
            }
        }

        private string Fizz(int number)
        {
            if (IsFizz(number))
            {
                return "Fizz";
            }

            return string.Empty;
        }

        private string Buzz(int number)
        {
            if (IsBuzz(number))
            {
                return "Buzz";
            }

            return string.Empty;
        }

        private bool IsFizz(int number)
        {
            return number % 3 == 0;
        }

        private bool IsBuzz(int number)
        {
            return number % 5 == 0;
        }
    }
}