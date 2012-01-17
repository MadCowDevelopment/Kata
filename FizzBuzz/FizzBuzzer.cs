using System;

namespace FizzBuzz
{
    public class FizzBuzzer
    {
        public string Calculate(int i)
        {
            ThrowExceptionIfValueIsOutOfRange(i);

            if (IsDivisibleByFive(i) && IsDivisibleByThree(i))
            {
                return "FizzBuzz";
            }

            if (IsDivisibleByFive(i))
            {
                return "Buzz";
            }

            if (IsDivisibleByThree(i))
            {
                return "Fizz";
            }

            return i.ToString();
        }

        private static void ThrowExceptionIfValueIsOutOfRange(int i)
        {
            if (i < 1 || i > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private static bool IsDivisibleByFive(int i)
        {
            return i % 5 == 0;
        }

        private static bool IsDivisibleByThree(int i)
        {
            return i % 3 == 0;
        }
    }
}