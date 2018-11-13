using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Day10
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var instructions = InputFileReader.ReadAllLines("Input.txt");
            var bots = new List<Bot>();

            foreach (var instruction in instructions)
            {
                var instructionDetails = instruction.Split(" ");
                if (instructionDetails[0].Equals("bot"))
                {
                    var name = instructionDetails[0] + instructionDetails[1];
                    var lower = instructionDetails[5] + int.Parse(instructionDetails[6]);
                    var higher = instructionDetails[10] + int.Parse(instructionDetails[11]);
                    if (lower.Contains("output")) bots.Add(new Bot(){Name = lower});
                    if (higher.Contains("output")) bots.Add(new Bot() { Name = higher });
                    bots.Add(new Bot() {Name = name, Higher = higher, Lower = lower});
                }
            }

            foreach (var instruction in instructions)
            {
                var instructionDetails = instruction.Split(" ");
                if (instructionDetails[0].Equals("value"))
                {
                    var value = int.Parse(instructionDetails[1]);
                    var target = instructionDetails[4] + int.Parse(instructionDetails[5]);
                    bots.Where(b => b.Name.Equals(target)).Take(1).First().Add(value);
                }
            }

            while (true)
            {
                var actionCount = 0;
                foreach (var bot in bots)
                {
                    if (bot.Name.Contains("bot") && bot.IsFull())
                    {
                        if (bot.GetLowerValue() == 17 && bot.GetHigherValue() == 61)

                        {
                            Console.WriteLine(bot.Name);
                            
                        }
                        bots.Where(b => b.Name.Equals(bot.Lower)).Take(1).First().Add(bot.GetLowerValue());
                        bots.Where(b => b.Name.Equals(bot.Higher)).Take(1).First().Add(bot.GetHigherValue());
                        bot.Clear();
                        actionCount++;
                    }
                }

                if (actionCount == 0) break;
            }

            var result = bots.Where(b => b.Name.Equals("output0")).Take(1).First()._bucket[0] * bots.Where(b => b.Name.Equals("output1")).Take(1).First()._bucket[0]*bots.Where(b => b.Name.Equals("output2")).Take(1).First()._bucket[0];
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
