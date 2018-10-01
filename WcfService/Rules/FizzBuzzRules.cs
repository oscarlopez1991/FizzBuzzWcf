using System.Collections.Generic;

namespace FizzBuzzWcf
{
    public class FizzBuzzRules: List<IFizzBuzzRule>
    {
        public FizzBuzzRules()
        {
            this.Add(new FizzForThree());
            this.Add(new BuzzForFive());
            this.Add(new NumberByDefault());
        }
    }
}