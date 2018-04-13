using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ConsoleHackerRank
{
    class Program
    {
        static int nonDivisibleSubset(int k, int[] S)
        {
            /*
             * Write your code here.
             */

            var allCombinations = DifferentCombinations(S, 2).ToList() ;
            Dictionary<List<int>, int> sums = new Dictionary<List<int>, int>() ;
            allCombinations.ForEach(x =>
            {
                if(x.Sum()%k!=0)
                    sums.Add(x.ToList(), x.Sum());
            });

            var all = sums.Keys.Aggregate((tot, key) =>
            {
                return tot.Concat(key).ToList();
            });

            return all.Distinct().Count();

        }
        static void Main(String[] args)
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] S = Array.ConvertAll(Console.ReadLine().Split(' '), STemp => Convert.ToInt32(STemp))
            ;
            int result = nonDivisibleSubset(k, S);

            Console.WriteLine(result);
            Console.ReadKey();
        }



        public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                DifferentCombinations(elements.Skip(i + 1), k - 1).Select(c => (new[] { e }).Concat(c)));
        }
    }
}
