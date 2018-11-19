using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Core;

namespace Day5
{
    public class PasswordGenerator
    {
        private readonly HashGenerator _hashGenerator;

        public PasswordGenerator()
        {
            _hashGenerator = new HashGenerator();
        }
        public string ComputePassword(string input)
        {
            var password = new StringBuilder();
            var numberOfFoundDigits = 0;
            var i = 0;
            while (numberOfFoundDigits < 8)
            {
                var origin = input + i;
                if (HasValidHash(origin, out string hash))
                {
                    numberOfFoundDigits++;
                    password.Append(hash[5].ToString().ToLower());
                }
                i++;
            }
            return password.ToString();
        }

        public  string ComputePassword2(string input)
        {
            var passwordDigits = new [] {"", "", "", "", "", "", "", ""};
            var numberOfFoundDigits = 0;
            var i = 0;
            while (numberOfFoundDigits < 8)
            {
                var origin = input + i;
                if (HasValidHash(origin, out string hash) && int.TryParse(hash[5].ToString(), out int pos) && pos < passwordDigits.Length && passwordDigits[pos].Equals(""))
                {
                    passwordDigits[pos] = hash[6].ToString().ToLower();
                    numberOfFoundDigits++;
                }
                i++;
            }
            var password = new StringBuilder();
            foreach (var d in passwordDigits)
            {
                password.Append(d);
            }
            return password.ToString();
        }

        public bool HasValidHash(string input, out string hash)
        {
            hash = "";
            if (_hashGenerator.ComputeHash(input, out string fullhash))
            {
                hash = fullhash;
                return fullhash.Substring(0, 5).Equals("00000");
            }

            return false;
        }
    }
}
