using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day10
{
    internal class Day10 : AoC
    {
        bool isTest = false;
        List<Instruction> instructions;
        public void Run()
        {
            GetInstructions();
            Part1();
            Console.WriteLine("===== Part2 =====");
            Part2();
            Console.ReadLine();
        }

        void Part1()
        {
            int signalStrength = 0;
            int exeNum = 0;
            int x = 1;
            foreach (var exe in instructions)
            {
                exeNum++;
                signalStrength += CheckSignalStrength(exeNum, x);
                if(exe.Type == "noop")
                    continue;
                else if(exe.Type == "addx")
                {
                    exeNum++;
                    signalStrength += CheckSignalStrength(exeNum, x);
                    x += exe.Value;
                }
            }
            Console.WriteLine("===== Part 1 =====");
            Console.WriteLine("Sum of signal strength is: " + signalStrength);
        }
        void Part2()
        {
            int exeNum = 0;
            int x = 1;
            foreach (var exe in instructions)
            {
                exeNum++;
                if (exeNum == 41)
                {
                    Console.Write("\n");
                    exeNum = 1;
                }
                Console.Write(SignToPrint(exeNum, x));
                if (exe.Type == "noop")
                    continue;
                else if (exe.Type == "addx")
                {
                    exeNum++;
                    if(exeNum == 41)
                    {
                        Console.Write("\n");
                        exeNum = 1;
                    }
                    Console.Write(SignToPrint(exeNum, x));
                    x += exe.Value;
                }
            }
        }
        char SignToPrint(int exeNum, int x)
        {
            if (exeNum >= x && exeNum <= x + 2)
                return '#';
            else
                return '.';
        }
        int CheckSignalStrength(int exeNum, int x)
        {
            if(exeNum == 20 || (exeNum - 20) % 40 == 0)
            {
                Console.WriteLine($"{exeNum}: {x}");
                return exeNum * x;
            }
            return 0;

        }
        void GetInstructions()
        {
            instructions = new List<Instruction>();
            var input = GetInputLines(10, isTest);
            foreach (var line in input)
            {
                var type = line.Substring(0, 4);
                var value = type == "noop" ? 0 : Convert.ToInt32(line.Substring(5));
                instructions.Add(new Instruction { Type = type, Value = value });
            }
        }
    }
    class Instruction
    {
        public string Type { get; set; }
        public int Value { get; set; }   
    }
}
