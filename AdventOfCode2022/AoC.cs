using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class AoC
    {
        public Stopwatch sw { get; set; } = new Stopwatch();
        public string GetInputString(int day, bool isTest = false)
        {
            if(!isTest)
                return FileHandler.GetPuzzleInput($"\\Day{day}\\Day{day}Input.txt");
            return FileHandler.GetPuzzleInput($"\\Day{day}\\Day{day}TestInput.txt");
        }
        public List<string> GetInputLines(int day, bool isTest)
        {
            return GetInputString(day, isTest).Split("\r\n").ToList();
        }
        public List<string> GetInputLines(string input)
        {
            return input.Split("\r\n").ToList();
        }
    }
}
