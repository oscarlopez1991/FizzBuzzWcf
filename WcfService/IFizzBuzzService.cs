using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzWcf
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IFizzBuzzService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IFizzBuzzService
    {
        [OperationContract]
        List<string> GetSerieFizzBuzz(int randomNumber);
    }
}
