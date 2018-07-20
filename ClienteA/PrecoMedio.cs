using System;
using System.Linq;
using Assinatura;

namespace ClienteA
{
    public class PrecoMedio : ICalculaPrecoMedio
    {
        public decimal Calcula(decimal[] valores)
        {
            Console.WriteLine("rotina da Calcula na dll " + GetType().Assembly.GetName());
            var resultado = 0m;
            var total = 0m;
            var conta = 0;
            foreach (var valor in valores)
            {
                conta++;
                total += valor;
            }

            resultado = Decimal.Round(total / conta, 2);
            Console.WriteLine($"valor do preço medio: {resultado}");
            return resultado;
        }
    }
}