using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day9
{
    internal class Day9 : AoC
    {
        List<Instruction> instructions;
        public void Run()
        {
            Getinstructions();
            Part1();
            Console.ReadLine();
        }
        void Part1()
        {
            List<string> visited = new List<string>();

            int[] posT = new int[] { 0, 0 };
            int[] posH = new int[] { 0, 0 };

            int[] posHOld = new int[] { posH[0], posH[1] };

            visited.Add($"{posT[0]},{posT[1]}");

            foreach (var inst in instructions)
            {
                for (int i = 0; i < inst.Steps; i++)
                {
                    posHOld[0] = posH[0];
                    posHOld[1] = posH[1];
                    switch (inst.Direction)
                    {
                        case "R":
                            posH[0]++;
                            break;
                        case "L":
                            posH[0]--;
                            break;
                        case "D":
                            posH[1]--;
                            break;
                        case "U":
                            posH[1]++;
                            break;
                    }
                    if (Math.Abs(posH[1] - posT[1]) > 1)
                    {
                        posT[0] = posHOld[0];
                        posT[1] = posHOld[1];
                    }
                    else if (Math.Abs(posH[0] - posT[0]) > 1)
                    {
                        posT[0] = posHOld[0];
                        posT[1] = posHOld[1];
                    }
                    if (!visited.Contains($"{posT[1]},{posT[0]}"))
                        visited.Add($"{posT[1]},{posT[0]}");
                }
            }
            Console.WriteLine("===== Part 1 =====");

            Console.WriteLine("Visited positions: " + visited.Count());

        }
        void Getinstructions()
        {
            instructions = new List<Instruction>();
            var input = GetInputLines(9, false);
            foreach (var i in input)
            {
                instructions.Add(new Instruction
                {
                    Direction = i.Substring(0, 1),
                    Steps = Convert.ToInt32(i.Substring(2))
                });
            }
        }

    }
    class Instruction
    {
        public string Direction { get; set; }
        public int Steps { get; set; }
    }
}
