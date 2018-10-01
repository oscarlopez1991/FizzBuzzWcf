using System;
using System.Threading.Tasks;

namespace FizzBuzzWcf
{
    public interface IFizzBuzzRule
    {
        String Process(String value, int number);
    }
}