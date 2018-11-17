using System;
using Day11.data;

namespace Day11
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var input = new State(new[] { "FG,FM,GG,GM,AG,AM,BG,CG", "BM,CM","DG,DM,EG,EM","" });
            var output = new State(new[] { "", "", "", "FG,FM,GG,GM,AG,AM,BG,CG,BM,CM,DG,DM,EG,EM" },3);

            var searcher = new SearchEngine(input);
            var res = searcher.Run(output);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
