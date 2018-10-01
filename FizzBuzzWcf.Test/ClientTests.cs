using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzWcf.Tests
{
    [TestClass()]
    public class ClientTests
    {
        private List<string> actual;

        [TestInitialize()]
        public void InitializaTest()
        {
            int randomNumber = new Random().Next();
            var listNumbers = Enumerable.Range(randomNumber, 100).ToList();
            this.actual = new List<string>();

            listNumbers.ForEach(elementSerie =>
            {
                string valueConvertedSerie = String.Empty;

                if (elementSerie % 3 == 0)
                    valueConvertedSerie = "Fizz";

                if (elementSerie % 5 == 0)
                    valueConvertedSerie += "Buzz";

                if (elementSerie % 3 != 0 && elementSerie % 5 != 0)
                    valueConvertedSerie = elementSerie.ToString();

                this.actual.Add(valueConvertedSerie);
            });

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "La lista a escribir no puede ser nula")]
        public void ExecuteProcessTest()
        {
            ProcessWriteFile.ExecuteProcess(null);
        }

        [TestMethod()]
        public void GetBufferTest()
        {
            // Arrange
            PrivateType privateType = new PrivateType(typeof(ProcessWriteFile));
            char[] expected = String.Join(Environment.NewLine, this.actual.Select(valueOfSerie => DateTime.Now + " " + valueOfSerie).ToArray()).ToCharArray();

            // Act
            char[] actual = (char[])privateType.InvokeStatic("GetBuffer", this.actual);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void WriteFileTest()
        {
            // Arrange
            PrivateType privateType = new PrivateType(typeof(ProcessWriteFile));
            char[] buffer = String.Join(Environment.NewLine, this.actual.ToArray()).ToCharArray();

            // Act
            var result = (Task<bool>)privateType.InvokeStatic("WriteFileAsync", buffer);

            // Assert
            Assert.AreEqual(true, result.Result);
        }                
    }
}