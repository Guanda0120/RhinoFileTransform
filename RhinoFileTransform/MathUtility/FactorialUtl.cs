using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoFileTransform.MathUtility
{
    public class FactorialUtl
    {
        /// <summary>
        /// Compute the Factorial of a Number
        /// </summary>
        /// <param name="n"> The Int to Compute </param>
        /// <returns> int </returns>
        public static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
