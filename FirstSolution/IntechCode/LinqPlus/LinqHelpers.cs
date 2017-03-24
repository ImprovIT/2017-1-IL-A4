using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntechCode.Tests
{
    public static class LinqHelpers
    {

        public static IEnumerable<int> EventNumers(int start, int count)
                                        => Enumerable.Range(start, count)
                                                     .Select(n => n * 2);

        public static int Fibonacci(int n) => n < 2 ? n : Fibonacci(n - 2) + Fibonacci(n - 1);

        public static IEnumerable<int> Fibonacci()
        {
            int v = 0;
            int prev = 1;
            while (true)
            {
                int prevV = v;
                yield return v;
                v += prev;
                prev = prevV;
            }
        }
    }
}
