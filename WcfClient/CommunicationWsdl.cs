using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzWcf
{
    public class CommunicationWsdl
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<string> EstablishCommunication(int randomNumber)
        {
            log.Info("Estableciendo comuniación con el servicio web...");

            List<string> listSerieFizzBuzz = CallServiceAsync(randomNumber).Result;

            if (!listSerieFizzBuzz.Any())
            {
                log.Error("No se ha podido obtener la serie FizzBuzz del servicio web");
                throw new Exception("No se ha podido obtener la serie FizzBuzz del servicio web");
            }
            else
            {
                log.Info("Comuniación realizada con éxito. Lista con la serie FizzBuzz recuperada correctamente del servicio web");
                return listSerieFizzBuzz;
            }

        }

        private static async Task<List<string>> CallServiceAsync(int randomNumber)
        {            
            using (WsdlFizzBuzz.FizzBuzzServiceClient client = new WsdlFizzBuzz.FizzBuzzServiceClient())
            {
                try
                {
                    var result = await client.GetSerieFizzBuzzAsync(randomNumber);                    

                    return result.ToList();                    
                }
                catch(Exception ex)
                {
                    log.Error("Error durante la comunicación con el servicio web. Mensaje de error: " + ex.Message);
                    return new List<string>();
                }
            }
        }        
    }
}
