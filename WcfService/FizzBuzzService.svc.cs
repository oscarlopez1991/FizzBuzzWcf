using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace FizzBuzzWcf
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "FizzBuzzService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione FizzBuzzService.svc o FizzBuzzService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class FizzBuzzService : IFizzBuzzService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private FizzBuzzBuilder builder;

        public List<string> GetSerieFizzBuzz(int randomNumber)
        {
            log.Info("Inicio del proceso para la obtención de la serie FizzBuzz");

            List<string> listSerie = new List<string>();
            var randomToOneHundred = Enumerable.Range(randomNumber, 100).ToList();

            randomToOneHundred.ForEach(number =>
            {
                listSerie.Add(builder.Build(number));
            });

            log.Info("Se ha obtenido toda la serie FizzBuzz");

            return listSerie;
        }

        public FizzBuzzService()
        {
            this.builder = new FizzBuzzBuilder(new FizzBuzzRules());
        }
    }
}
