using System;

namespace FizzBuzzWcf
{
    public class FizzForThree: IFizzBuzzRule
    {
        public string Process(string value, int number)
        {
            return (DivisibleByThree(number)) ? FizzBuzzContract.FIZZ : String.Empty;
        }

        private bool DivisibleByThree(int number)
        {
            return (number % 3 == 0);
        }
    }
}