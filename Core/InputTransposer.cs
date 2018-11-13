using System.Text;

namespace Core
{
    public static class InputTransposer
    {
        public static string[] Convert(string[] input)
        {
            var length = input[0].Length;
            var resultBuilder = new StringBuilder[length];
            for (var i = 0; i < resultBuilder.Length; i++)
            {
                resultBuilder[i] = new StringBuilder();
            }

            foreach (var s in input)
            {
                var chars = s.ToCharArray();
                for (var i = 0; i < chars.Length; i++)
                {
                    resultBuilder[i].Append(chars[i].ToString());
                }
            }

            var result = new string[length];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = resultBuilder[i].ToString();
            }

            return result;
        }
    }
}
