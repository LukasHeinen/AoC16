using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Day7
{
    public class IpAddress
    {
        private readonly List<string> _outside;
        private readonly List<string> _inside;

        public IpAddress(string input)
        {
            _outside = new List<string>();
            _inside = new List<string>();

            var depth = 0;
            var builder = new StringBuilder();
            for (var i = 0; i < input.Length; i++)
            {
                if (!input[i].Equals('[') && !input[i].Equals(']'))
                {
                    builder.Append(input[i]);
                }

                if (input[i].Equals('['))
                {
                    if (depth == 0)
                    {
                        _outside.Add(builder.ToString());
                    }
                    else
                    {
                        _inside.Add(builder.ToString());
                    }
                    builder = new StringBuilder();
                    depth++;
                }

                if (input[i].Equals(']'))
                {
                    _inside.Add(builder.ToString());
                    builder = new StringBuilder();
                    depth--;
                }
            }
            _outside.Add(builder.ToString());
        }

        public bool SupportsTls()
        {
            var hypernetSequences = new List<string>();
            foreach (var s in _inside)
            {
                hypernetSequences.AddRange(GetFourDigitSequences(s));
            }
            if (hypernetSequences.Any(FourDigitSequenceIsValid))
            {
                return false;
            }

            var sequences = new List<string>();
            foreach (var s in _outside)
            {
                sequences.AddRange(GetFourDigitSequences(s));
            }

            return sequences.Any(FourDigitSequenceIsValid);
        }

        public bool SupportsSsl()
        {
            var hypernetSequences = new List<string>();
            foreach (var s in _inside)
            {
                hypernetSequences.AddRange(GetValidThreeDigitSequences(s));
            }

            var sequences = new List<string>();
            var revertedSequences = new List<string>();
            foreach (var s in _outside)
            {
                sequences.AddRange(GetValidThreeDigitSequences(s));
            }
            foreach (var sequence in sequences)
            {
                revertedSequences.Add(Swap(sequence));
            }

            return hypernetSequences.Any(t => revertedSequences.Contains(t));
        }

        private string[] GetFourDigitSequences(string input)
        {
            var sequences = new List<string>();
            
            for (var i = 0; i < input.Length-3; i++)
            {
                sequences.Add(input.Substring(i,4));
            }

            return sequences.ToArray();
        }

        private bool FourDigitSequenceIsValid(string input)
        {
            if (input.Length > 4) return false;

            var set = new HashSet<char>();
            foreach (var c in input)
            {
                set.Add(c);
            }
            if (set.Count != 2) return false;

            return (input.Substring(0, 2).Equals(Revert(input.Substring(2, 2)))) ;
        }

        public string[] GetValidThreeDigitSequences(string input)
        {
            var sequences = new List<string>();

            for (var i = 0; i < input.Length - 2; i++)
            {
                var substring = input.Substring(i, 3);
                if (ThreeDigitSequenceIsValid(substring)) sequences.Add(substring);
            }

            return sequences.ToArray();
        }

        private bool ThreeDigitSequenceIsValid(string input)
        {
            if (input.Length > 3) return false;

            var set = new HashSet<char>();
            foreach (var c in input)
            {
                set.Add(c);
            }
            if (set.Count != 2) return false;

            return (input.Substring(0, 2).Equals(Revert(input.Substring(1, 2))));
        }

        private string Revert(string input)
        {
            var builder = new StringBuilder();

            for (var i = input.Length-1; i >= 0; i--)
            {
                builder.Append(input[i]);
            }

            return builder.ToString();
        }

        private string Swap(string validThreeDigitSequence)
        {
            var builder = new StringBuilder();
            builder.Append(Revert(validThreeDigitSequence.Substring(0, 2))).Append(validThreeDigitSequence[1]);
            return builder.ToString();
        }
    }
}
