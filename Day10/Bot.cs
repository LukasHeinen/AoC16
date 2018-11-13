using System;
using System.Collections.Generic;
using System.Text;

namespace Day10
{
    public class Bot
    {
        public List<int> _bucket;
        public string Name { get; set; }
        public string Lower { get; set; }
        public string Higher { get; set; }
        
        public Bot()
        {
            _bucket = new List<int>();
        }

        public bool IsFull()
        {
            return _bucket.Count == 2;
        }

        public void Clear()
        {
            _bucket.Clear();
        }

        public int GetLowerValue()
        {
            var a = _bucket.ToArray();
            Array.Sort(a);
            return a[0];

        }

        public int GetHigherValue()
        {
            var a = _bucket.ToArray();
            Array.Sort(a);
            return a[1];

        }

        public bool Add(int number)
        {
            if (!Name.Contains("output") && _bucket.Count == 2) return false;
            _bucket.Add(number);
            return true;
        }
    }
}
