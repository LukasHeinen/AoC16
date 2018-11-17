using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day11.data
{
    public class Floor
    {
        private readonly HashSet<string> _generators = new HashSet<string>();
        private readonly HashSet<string> _chips = new HashSet<string>();
        
        private bool _hasGenerator = false;
        private bool _hasChip = false;

        public Floor(string[] objs)
        {
            foreach (var s in objs)
            {
                if (s != "" && !Ignoration.ToIgnore.Contains(s))
                {
                    if (s[1].Equals('G'))
                    {
                        _hasGenerator = true;
                        _generators.Add(s);
                    }
                    else
                    {
                        _hasChip = true;
                        _chips.Add(s);
                    }
                }
            }
        }

        public void Add(string obj)
        {
            if (obj[1].Equals('G'))
            {
                _hasGenerator = true;
                _generators.Add(obj);
            }
            else
            {
                _hasChip = true;
                _chips.Add(obj);
            }
        }

        public List<string> GetAll()
        {
            var list = new List<string>();
            foreach (var g in _generators)
            {
                list.Add(g);
            }
            foreach (var m in _chips)
            {
                list.Add(m);
            }

            return list;
        }

        public bool IsEmpty()
        {
            return !(_hasGenerator || _hasChip);
        }
      
        public override string ToString()
        {
            var builder = new StringBuilder();
            var gens = _generators.ToArray();
            var micros = _chips.ToArray();
            Array.Sort(gens);
            Array.Sort(micros);

            foreach (var g in gens)
            {
                builder.Append(g + ',');
            }
            foreach (var m in micros)
            {
                builder.Append(m + ',');
            }

            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }

            return builder.ToString();
        }

        public Floor Clone()
        {
            var s = ToString();
            return new Floor(s.Split(","));
        }

        public bool IsValid()
        {
            if (!_hasGenerator || !_hasChip) return true;
            foreach (var micro in _chips)
            {
                if (!_generators.Contains(micro[0] + "G")) return false;
            }

            return true;
        }
    }
}