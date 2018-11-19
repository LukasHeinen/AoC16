using System.Security.Cryptography;
using System.Text;

namespace Core
{
    public class HashGenerator
    {
        private readonly MD5 _hashGenerator;
        public HashGenerator()
        {
            _hashGenerator = MD5.Create();
        }
        public bool ComputeHash(string input, out string output)
        {

            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = _hashGenerator.ComputeHash(inputBytes);

            var builder = new StringBuilder();
            for (var i = 0; i < 5; i++)
            {
                var s = hashBytes[i].ToString("X2");
                if (i < 2 && !s.Equals("00"))
                {
                    output = "";
                    return false;
                }
                builder.Append(s);
            }

            output = builder.ToString();
            return true;
        }

        public string ComputeFullHash(string input)
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = _hashGenerator.ComputeHash(inputBytes);

            var builder = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                builder.Append(hashByte.ToString("X2"));
            }

            return builder.ToString();
        }
    }
}
