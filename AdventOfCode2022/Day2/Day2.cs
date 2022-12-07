using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdventOfCode2022.Day2
{
    internal class Day2 : AoC
    {
        List<string[]> inputList = new List<string[]>();
        List<int> score = new List<int>();

        public void Run()
        { 
            //part1
            StartUp();
            GetScores(1);
            Console.WriteLine("Total score is: " + score.Sum());
            //part2
            StartUp();
            GetScores(2);
            Console.WriteLine("Total score is: " + score.Sum());
            Console.ReadLine();
        }

        void StartUp()
        {
            score.Clear();
            inputList.Clear();
            List<string> x = GetInputLines(2, false);
            foreach (var c in x)
            {
                inputList.Add(c.Split(" "));
            }
        }

        void GetScores(int part)
        {
            foreach (var round in inputList)
            {

                int winScore = part == 1 ? CalculateWinPart1(round) : CalculateWinPart2(round);
                int shapePoint = 0;
                if (winScore == 3)
                    shapePoint += GetShapePoint(GetDrawShape(round[0]));
                else if(winScore == 6)
                    shapePoint += GetShapePoint(GetWinningShape(round[0]));
                else if(winScore == 0)
                    shapePoint += GetShapePoint(GetLosingShape(round[0]));
                score.Add(shapePoint + winScore);
            }
        }

        private string GetLosingShape(string x)
        {
            switch (x)
            {
                case "A":
                    return "Z";
                case "B":
                    return "X";
                case "C":
                    return "Y";
            }
            return "";
        }

        private string GetDrawShape(string x)
        {
            switch (x)
            {
                case "A":
                    return "X";
                case "B":
                    return "Y";
                case "C":
                    return "Z";
            }
            return "";
        }

        private string GetWinningShape(string x)
        {
            switch (x)
            {
                case "A":
                    return "Y";
                case "B":
                    return "Z";
                case "C":
                    return "X";
            }
            return "";
        }

        int GetShapePoint(string shape)
        {
            switch (shape.ToUpper())
            {
                case "X":
                    return 1;
                case "Y":
                    return 2;
                case "Z":
                    return 3;
                default:
                    return 0;
            }
        }

        //Part 2

        int CalculateWinPart2(string[] round)
        {
            switch (round[1].ToUpper())
            {
                case "Y":
                    return 3;
                case "X":
                    return 0;
                case "Z":
                    return 6;
            }
            return 0;
        }

        //Part 1

        int CalculateWinPart1(string[] round)
        {
            if (round[0].ToUpper() == "A")
            {
                switch (round[1].ToUpper())
                {
                    case "Y":
                        return 6;
                    case "X":
                        return 3;
                    case "Z":
                        return 0;
                }
            }
            else if (round[0].ToUpper() == "B")
            {
                switch (round[1].ToUpper())
                {
                    case "Y":
                        return 3;
                    case "X":
                        return 0;
                    case "Z":
                        return 6;
                }
            }
            else if (round[0].ToUpper() == "C")
            {
                switch (round[1].ToUpper())
                {
                    case "Y":
                        return 0;
                    case "X":
                        return 6;
                    case "Z":
                        return 3;
                }
            }
            return 0;
        }
    }
}
