using System;
using System.Collections.Generic;
using System.Text;

namespace LargestPrimeFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Enumerator enumerator = new Enumerator();

            bool ok = true;

            while (ok)
            {
                Console.WriteLine("Enter number to factorise or Enter to stop.");
                string entered = Console.ReadLine();

                long toFactorise;
                ok = long.TryParse(entered, out toFactorise);

                if (ok && toFactorise >= 2)
                {
                    StringBuilder factorList = new StringBuilder();

                    foreach (long factor in GetPrimeFactors(toFactorise, enumerator))
                    {
                        if (factorList.Length == 0)
                            factorList.Append("Prime factor(s): ");
                        else
                            factorList.Append(", ");
                        factorList.Append(factor);
                    }

                    Console.WriteLine(factorList);
                }
            }
        }


        private static IEnumerable<long> GetPrimeFactors(long value, Enumerator eratosthenes)
        {
            List<long> factors = new List<long>();

            foreach (long prime in eratosthenes)
            {
                while (value % prime == 0)
                {
                    value /= prime;
                    factors.Add(prime);
                }

                if (value == 1)
                    break;
            }

            return factors;
        }
    }
}
