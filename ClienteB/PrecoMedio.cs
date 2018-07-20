using System;
using System.Linq;
using Assinatura;

namespace ClienteB
{
    public class PrecoMedio : ICalculaPrecoMedio
    {
        public decimal Calcula(decimal[] valores)
        {
            Console.WriteLine("rotina da Calcula na dll " + GetType().Assembly.GetName());
            var resultado = 0m;
            var total = 0m;
            var conta = 0;
            // Ordena os preços e remove o maior e o menor, tecnica para evitar distorções bruscas na média
            valores = valores.OrderBy(p => p).ToArray();
            if (valores.Length >= 3)
            {
                valores = valores.Skip(1).Take(valores.Length - 2).ToArray();
            }

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