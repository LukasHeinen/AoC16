using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day4
{
    public class Room
    {
        private readonly string _name;
        private readonly string _checksum;
        private readonly int _sectorId;

        public Room(string fullName)
        {
            var trimmedName = fullName.Replace("]", "");
            var seperatedChecksum = trimmedName.Split("[");
            _checksum = seperatedChecksum[1];
            var separatedName = seperatedChecksum[0].Split("-");

            _sectorId = int.Parse(separatedName[separatedName.Length - 1]);
            separatedName[separatedName.Length - 1] = "";
            var stringBuilder = new StringBuilder();
            foreach (var s in separatedName)
            {
                stringBuilder.Append(s);
                stringBuilder.Append("-");
            }
            stringBuilder.Append(" ");
            stringBuilder.Replace("- ", "");
            _name = stringBuilder.ToString();
        }

        public int GetSectorId()
        {
            return _sectorId;
        }

        public string GetName()
        {
            return _name.Replace("-","");
        }

        public string GetEncryptedName()
        {
            var subNames = _name.Split("-");
            var encryptedNameBuilder = new StringBuilder();
            foreach (var subName in subNames)
            {
                var builder = new StringBuilder();
                var chars = subName.ToCharArray();
                foreach (var c in chars)
                {
                    var tmpC = c;
                    for (var i = 0; i < _sectorId; i++)
                    {
                        tmpC = IncrementCharacter(tmpC);
                    }

                    builder.Append(tmpC.ToString());
                }
                encryptedNameBuilder.Append(builder.ToString());
                encryptedNameBuilder.Append(" ");

            }
            return encryptedNameBuilder.ToString().Substring(0, encryptedNameBuilder.Length-2);

        }

        private char IncrementCharacter(char input)
        {
            return (input == 'z' ? 'a' : (char)(input + 1));
        }

        public string GetChecksum()
        {
            return _checksum;
        }

        public bool IsValid()
        {
            return _checksum.Equals(GenerateChecksum());
        }

        private string GenerateChecksum()
        {
            var dict = new Dictionary<string, int>();

            var chars = _name.ToCharArray();

            foreach (var c in chars)
            {
                if (c != '-')
                {
                    var s = c.ToString();
                    var count = 0;
                    if (dict.ContainsKey(s))
                    {
                        dict.TryGetValue(s, out count);
                        dict.Remove(s);
                    }

                    count++;
                    dict.Add(s, count);
                }
            }

            var t = new List<Tuple<string, int>>();

            foreach (var keyValuePair in dict)
            {
                t.Add(new Tuple<string, int>(keyValuePair.Key, keyValuePair.Value));
            }

            var orderedByCount = t.OrderByDescending(x => x.Item2).ToList();
            var buffer = "";
            var listOfSameCount = new List<string>();
            var currentIndex = orderedByCount[0].Item2;
            foreach (var tuple in orderedByCount)
            {
                if (tuple.Item2 == currentIndex)
                {
                    buffer += tuple.Item1;
                }
                else
                {
                    listOfSameCount.Add(buffer);
                    buffer = "";
                    currentIndex = tuple.Item2;
                    buffer += tuple.Item1;
                }
            }

            listOfSameCount.Add(buffer);
            var builder = new StringBuilder();
            foreach (var s in listOfSameCount)
            {
                var cs = s.ToCharArray();
                Array.Sort(cs);
                builder.Append(new string(cs));
            }

            return builder.ToString().Substring(0, 5);
        }
    }
}