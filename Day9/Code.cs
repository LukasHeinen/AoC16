using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day9
{
    public class Code
    {
        private readonly string _compressed;
        private StringBuilder _decompressed;

        public Code(string input)
        {
            _compressed = input;
        }

        public long DecompressAndCount(out string decompressed)
        {
            _decompressed = new StringBuilder();
            for (var i = 0; i < _compressed.Length; i++)
            {
                if (_compressed[i].Equals('('))
                {
                    var marker = new StringBuilder();
                    i++;
                    while (!_compressed[i].Equals(')'))
                    {
                        marker.Append(_compressed[i]);
                        i++;
                    }

                    var markerCommand = marker.ToString();
                    var length = int.Parse(markerCommand.Split("x")[0]);
                    var multi = int.Parse(markerCommand.Split("x")[1]);
                    var substring = _compressed.Substring(i + 1, length);
                    for (var j = 0; j < multi; j++)
                    {
                        _decompressed.Append(substring);
                    }

                    i += length;
                }
                else
                {
                    _decompressed.Append(_compressed[i]);
                }
            }

            decompressed = _decompressed.ToString();
            return _decompressed.Length;
        }

        public long DecompressAndCount2()
        {
            var markers = new List<Marker>();
            var letters = new List<Letter>();
            for (var i = 0; i < _compressed.Length; i++)
            {
                if (_compressed[i].Equals('('))
                {
                    var markerBuilder = new StringBuilder();
                    i++;
                    while (!_compressed[i].Equals(')'))
                    {
                        markerBuilder.Append(_compressed[i]);
                        i++;
                    }

                    var markerCommand = markerBuilder.ToString();
                    var length = int.Parse(markerCommand.Split("x")[0]);
                    var factor = int.Parse(markerCommand.Split("x")[1]);

                    var marker = new Marker() {Factor = factor, Length = length, Pos = i+1};
                    markers.Add(marker);
                }
                else
                {
                    letters.Add(new Letter(){Count = 1, Pos = i});
                }
            }

            foreach (var marker in markers)
            {
                for (var i = marker.Pos; i < marker.Pos + marker.Length; i++)
                {
                    foreach (var letter in letters.Where(l => l.Pos == i))
                    {
                        letter.Count = letter.Count * marker.Factor;
                    }
                }
            }

            long count = 0;
            foreach (var letter in letters)
            {
                count += letter.Count;
            }

            return count;
        }
    }
}