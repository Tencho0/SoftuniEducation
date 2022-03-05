using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _02._Big_Factorial___sept_21
{
    class Factorial
    {
        public Factorial(int n)
        {
            N = n;
        }
        public int N { get; set; }
        public BigInteger Calculated()
        {
            BigInteger factorial = 1;
            for (int i = 2; i <= N; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
