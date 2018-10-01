using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzWcf.Tests
{    
    [TestClass()]
    public class IntegrationTest
    {
        private EndpointAddress address = new EndpointAddress("http://localhost:51417/FizzBuzzService");
        private static ServiceHost serviceHost;

        [TestInitialize()]
        public void InitializeTest()
        {
            serviceHost = new ServiceHost(typeof(FizzBuzzService), address.Uri);
            serviceHost.AddServiceEndpoint(typeof(IFizzBuzzService), new BasicHttpBinding(), address.Uri);
            serviceHost.Open();
        }

        [TestCleanup()]
        public void CleanUpTest()
        {
            if (serviceHost == null)
                return;
            if (serviceHost.State == CommunicationState.Opened)
                serviceHost.Close();
            else if (serviceHost.State == CommunicationState.Faulted)
                serviceHost.Abort();
        }

        [TestMethod()]
        public void CallServiceTest()
        {
            // Arrange
            var binding = new BasicHttpBinding();
            ChannelFactory<IFizzBuzzService> factory =
                 new ChannelFactory<IFizzBuzzService>(binding, address);
            IFizzBuzzService service = factory.CreateChannel();
            int randomNumber = new Random().Next();
            var listNumbers = Enumerable.Range(randomNumber, 100).ToList();
            var actual = new List<string>();

            listNumbers.ForEach(elementSerie =>
            {
                string valueConvertedSerie = String.Empty;

                if (elementSerie % 3 == 0)
                    valueConvertedSerie = "Fizz";

                if (elementSerie % 5 == 0)
                    valueConvertedSerie += "Buzz";

                if (elementSerie % 3 != 0 && elementSerie % 5 != 0)
                    valueConvertedSerie = elementSerie.ToString();

                actual.Add(valueConvertedSerie);
            });


            // Act
            var expected = service.GetSerieFizzBuzz(new Random().Next());

            // Assert
            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
