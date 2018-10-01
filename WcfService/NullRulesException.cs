using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FizzBuzzWcf
{
    public class NullRulesException : NullReferenceException
    {
        public NullRulesException()
        {

        }

        public NullRulesException(string message)
            : base(message)
        {

        }

        public NullRulesException(string messsage, Exception inner)
        {

        }
    }
}