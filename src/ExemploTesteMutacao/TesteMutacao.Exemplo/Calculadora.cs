using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteMutacao.Exemplo
{
    public class Calculadora
    {
        public decimal Somar(decimal a, decimal b)
        {
            return a + b;
        }

        public decimal Subtrair(decimal a, decimal b)
        {
            return a - b;
        }

        public decimal Dividir(decimal a, decimal b)
        {
            if (b == decimal.Zero) throw new DivideByZeroException("Não é possível dividir por zero‬");
            return a / b;
        }

        public decimal Multiplicar(decimal a, decimal b)
        {
            return a * b;
        }
    }
}
