using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzWcf
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            int randomNumber = new Random().Next();

            log.Debug("Inicio de ejecución");

            List<string> listSerieFizzBuzz = CommunicationWsdl.EstablishCommunication(randomNumber);

            ProcessWriteFile.ExecuteProcess(listSerieFizzBuzz);

            log.Debug("Fin de ejecución");
        }
    }
}
