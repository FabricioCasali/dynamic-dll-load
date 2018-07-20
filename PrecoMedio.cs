using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDllLoad
{
    public interface IPrecoMedio
    {
        decimal Calcula(decimal[] values);
    }

    public class CalculaPrecoMedio
    {
        public decimal VerificaCliente(string cnpj, decimal[] values)
        {
            if (cnpj == "00000000000000") return new PrecoMedioClienteA(values);
            if (cnpj == "11111111111111") return new PrecoMedioClienteB(values);
            if (cnpj == "22222222222222") return new PrecoMedioClienteC(values);
            if (cnpj == "33333333333333") return new PrecoMedioClienteD(values);
        }
    }

    public class PrecoMedio
    {
        public decimal CalculaModoA(decimal[] values)
        {
            return 0;
        }

        public decimal CalculaModoB(decimal[] values)
        {
            return 0;
        }

        public decimal CalculaModoC(decimal[] values)
        {
            return 0;
        }

        public decimal CalculaModoD(decimal[] values)
        {
            return 0;
        }
    }
}