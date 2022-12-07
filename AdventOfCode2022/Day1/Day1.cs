using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day1
{
    internal class Day1 : AoC
    {
        List<int[]> Elfs = new List<int[]>();
        public void Run()
        {
            SortInElfs();
            GetMostCalories();
            GetTopThree();
            Console.ReadLine();
        }

        void SortInElfs()
        {
            var elfsStringArr = GetInputString(1).Split("\r\n\r\n").ToList();
            for (int i = 0; i < elfsStringArr.Count; i++)
            {
                string[] asString= elfsStringArr[i].Split("\r\n");
                int[] asInt = new int[asString.Count()];
                for (int j = 0; j < asString.Count(); j++)
                {
                    asInt[j] = Convert.ToInt32(asString[j]);
                }
                Elfs.Add(asInt);
            }
        }

        void GetMostCalories()
        {
            var SumOfCalories = GetSumCalories();
            Console.WriteLine("Most calories is: " + SumOfCalories.Max());
        }

        List<int> GetSumCalories()
        {
            List<int> SumOfCalories = new List<int>();
            foreach (var item in Elfs)
            {
                SumOfCalories.Add(item.Sum());
            }
            return SumOfCalories;
        }

        private void GetTopThree()
        {
            var SumOfCalories = GetSumCalories();
            SumOfCalories.Sort();
            Console.WriteLine("Top 3 together: " + SumOfCalories.TakeLast(3).Sum());
        }
       


    }
}
