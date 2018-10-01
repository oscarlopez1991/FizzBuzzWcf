using System;
using System.Threading.Tasks;

namespace FizzBuzzWcf
{
    public class FizzBuzzBuilder
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private  FizzBuzzRules rules;

        public string Build(int number)
        {
            string valueConverted = string.Empty;
            log.Info("Procesado del valor: " + number);

            rules.ForEach(rule =>
            {
                try
                {
                    valueConverted += rule.Process(valueConverted, number);
                }
                catch
                {
                    log.Warn("La regla " + rule.ToString() + " ha producido una excepción mientras trataba el valor" + number);
                    valueConverted = "Error";
                }
            });

            log.Info("Valor obtenido: " + valueConverted);

            return valueConverted;
        }
        public FizzBuzzBuilder(FizzBuzzRules rules)
        {
            if (rules == null)
            {
                log.Error("Se ha producido un error que impide obtener las reglas para la obtención de la serie FizzBuzz");
                throw new NullRulesException("El objeto reglas no puede ser nulo");
            }

            this.rules = rules;
        }
    }
}