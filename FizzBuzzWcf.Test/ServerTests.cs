using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzWcf.Test
{
    [TestClass()]
    public class ServerTests
    {
        private FizzBuzzBuilder builder;

        [TestInitialize()]
        public void InitializeTest()
        {
             builder = new FizzBuzzBuilder(new FizzBuzzRules());
        }

        [TestMethod()]
        [ExpectedException(typeof(NullRulesException), "El objeto reglas no puede ser nulo")]
        public void NullRulesInConstructorTest()
        {
            new FizzBuzzBuilder(null);
        }

        [TestMethod()]
        public void ProcessFizzTest()
        {
            // Assert
            Assert.AreEqual(builder.Build(3), "Fizz");
            Assert.AreEqual(builder.Build(6), "Fizz");
            Assert.AreEqual(builder.Build(9), "Fizz");
        }

        [TestMethod()]
        public void ProcessBuzzTest()
        {
            // Assert
            Assert.AreEqual(builder.Build(5), "Buzz");
            Assert.AreEqual(builder.Build(10),"Buzz");
            Assert.AreEqual(builder.Build(20),"Buzz");
        }

        [TestMethod()]
        public void ProcessFizzBuzzTest()
        {
            // Assert
            Assert.AreEqual(builder.Build(15), "FizzBuzz");
            Assert.AreEqual(builder.Build(30), "FizzBuzz");
            Assert.AreEqual(builder.Build(45), "FizzBuzz");
        }

        [TestMethod()]
        public void ProcessByDefaultTest()
        {
            // Assert
            Assert.AreEqual(builder.Build(1), "1");
            Assert.AreEqual(builder.Build(7), "7");
            Assert.AreEqual(builder.Build(17),"17");
        }
    }
}
