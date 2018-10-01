namespace FizzBuzzWcf
{
    public class NumberByDefault:IFizzBuzzRule
    {
        public string Process(string value, int number)
        {
            return (value.Length == 0) ? number.ToString() : string.Empty;
        }
    }
}