using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day6
{
    public static class Simplifier
    {
        public static char Simplify(string s, bool flag = true)
        {
            var dict = new Dictionary<char, int>();
            var chars = s.ToCharArray();
            foreach (var c in chars)
            {
                var count = 1;
                if (dict.ContainsKey(c))
                {
                    dict.TryGetValue(c, out count);
                    count++;
                    dict.Remove(c);
                }
                dict.Add(c, count);
            }

            var tuples = new List<Tuple<char, int>>();
            foreach (var kv in dict)
            {
                tuples.Add(new Tuple<char, int>(kv.Key, kv.Value));
            }

            var sortedTuples = !flag ? tuples.OrderBy(t => t.Item2).ToList() : tuples.OrderByDescending(t => t.Item2).ToList();
            
            return sortedTuples[0].Item1;
        }

        public static string Simplify(string[] strings, bool flag = true)
        {
            var builder = new StringBuilder();
            foreach (var s in strings)
            {
                builder.Append(Simplify(s, flag).ToString());
            }
            return builder.ToString();
        }
    }
}
