using System;

namespace FizzBuzzWcf
{
    public class BuzzForFive: IFizzBuzzRule
    {
        public string Process(string value, int number)
        {
            return (DivisibleByFive(number)) ? FizzBuzzContract.BUZZ : String.Empty;
        }

        private bool DivisibleByFive(int number)
        {
            return (number % 5 == 0);
        }
    }
}