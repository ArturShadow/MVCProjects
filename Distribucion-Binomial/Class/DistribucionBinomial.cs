using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribucion_Binomial.Class
{
    public static class DistribucionBinomial
    {
        private static long Factorial(long num)
        {
            if (num == 0)
            {
                return 1;
            }
            else
            {
                return num * Factorial(num - 1);
            }
        }
        public static long nCx(int n, int x)
        {
            long factN = Factorial(n);
            Console.WriteLine($"Factorial de {n} es {factN}");
            long factX = Factorial(x);
            Console.WriteLine($"Factorial de {x} es {factX}");
            long nx = n - x;
            Console.WriteLine($"{n} - {x} es {nx}");
            long factNX = Factorial(nx);
            Console.WriteLine($"Factorial de {nx} es {factNX}");
            long ncx = factN/(factX*factNX);
            return ncx;
;        }
    }
}