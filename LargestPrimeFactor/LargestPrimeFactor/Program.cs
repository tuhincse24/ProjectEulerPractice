using System;
using System.Collections.Generic;
using System.Linq;
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
                    StringBuilder factorListBuilder = new StringBuilder();
                    var factorList = GetPrimeFactors(toFactorise, enumerator);

                    foreach (long factor in factorList)
                    {
                        if (factorListBuilder.Length == 0)
                            factorListBuilder.Append("Prime factor(s): ");
                        else
                            factorListBuilder.Append(", ");
                        factorListBuilder.Append(factor);
                    }
                    factorListBuilder.Append("\nLongest factor: ");
                    factorListBuilder.Append(factorList?.OrderByDescending(t => t).FirstOrDefault());

                    Console.WriteLine(factorListBuilder);
                }
            }
        }


        private static IEnumerable<long> GetPrimeFactors(long value, Enumerator enumerator)
        {
            List<long> factors = new List<long>();

            foreach (long prime in enumerator)
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
