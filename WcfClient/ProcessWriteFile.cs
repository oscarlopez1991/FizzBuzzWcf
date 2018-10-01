using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FizzBuzzWcf
{
    public class ProcessWriteFile
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void ExecuteProcess(List<string> listSerieFizzBuzz)
        {
            log.Info("Se va a realizar la escritura de la serie FizzBuzz en un fichero de texto");

            if (listSerieFizzBuzz == null)
            {
                log.Error("La lista recibida para escribir en el fichero es nula");
                throw new ArgumentNullException("La lista a escribir no puede ser nula");
            }

            char[] buffer = GetBuffer(listSerieFizzBuzz);

            bool returnValue = WriteFileAsync(buffer).Result;

            if (returnValue)
                log.Info("Proceso de escritura finalizado con éxito");
            else
            {
                log.Error("No se ha podido escribir la lista FizzBuzz en el fichero de texto");
                throw new Exception("No se ha podido escribir la serie FizzBuzz en un fichero de texto");
            }
                
        }

        private static char[] GetBuffer(List<string> listSerieFizzBuzz)
        {            
            return String
                .Join(Environment.NewLine, listSerieFizzBuzz.Select(valueOfSerie => DateTime.Now + " " + valueOfSerie)
                .ToArray())
                .ToCharArray();
        }

        private async static Task<bool> WriteFileAsync(char[] buffer)
        {
            string path = @"..\..\..\FizzBuzzSerie\FizzBuzzSerie.txt";                        

            using (StreamWriter writer = new StreamWriter(path))
            {
                try
                {
                    await writer.WriteAsync(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    log.Error("Se ha producido un error durante la escritura de la serie FizzBuzz. " +
                            "Mensaje de error: " + ex.Message);
                    return false;
                }

                return true;
            }
        }                
    }    
}
