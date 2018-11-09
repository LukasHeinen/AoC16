using System;
using System.IO;

namespace Core
{
    public static class InputFileReader
    {
        public static string[] ReadAllLines(string file)
        {
            var buildDir = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf("bin"));
            var filePath = buildDir + @"\" + file;
            return File.ReadAllLines(filePath);
        }
    }
}
