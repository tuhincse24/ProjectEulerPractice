using System;
using System.Collections;
using System.Collections.Generic;

namespace LargestPrimeFactor
{
    public class Enumerator : IEnumerable<long>
    {
        private static List<long> _primes = new List<long>();
        private long _lastChecked;


        public Enumerator()
        {
            _primes.Add(2);
            _lastChecked = 2;
        }


        private bool IsPrime(long checkValue)
        {
            bool isPrime = true;

            foreach (long prime in _primes)
            {
                if ((checkValue % prime) == 0 && prime <= Math.Sqrt(checkValue))
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }


        public IEnumerator<long> GetEnumerator()
        {
            foreach (long prime in _primes)
                yield return prime;

            while (_lastChecked < long.MaxValue)
            {
                _lastChecked++;

                if (IsPrime(_lastChecked))
                {
                    _primes.Add(_lastChecked);
                    yield return _lastChecked;
                }
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
