using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day4
{
    internal class Day4 : AoC
    {
        List<List<int[]>> ranges = new List<List<int[]>>();
        public void Run()
        {
            GetRanges();
            Console.WriteLine("Sum FullyContains: " + AmountFullyContains());
            Console.WriteLine("Sum Overlapping: " + AmountOverlapping());
            Console.ReadLine();
        }

        int AmountOverlapping()
        {
            int sum = 0;
            foreach (var item in ranges)
            {
                List<int> r1 = new List<int>();
                List<int> r2 = new List<int>();
                List<int> intersect = new List<int>();
                for (int i = item[0][0]; i < item[0][1] + 1; i++)
                {
                    r1.Add(i);
                }
                for (int i = item[1][0]; i < item[1][1] + 1; i++)
                {
                    r2.Add(i);
                }
                intersect = r1.Intersect(r2).ToList();
                if (intersect.Count > 0)
                    sum++;
            }
            return sum;
        }

        int AmountFullyContains()
        {
            int sum = 0;
            foreach (var item in ranges)
            {
                if (item[0][0] <= item[1][0] && item[0][1] >= item[1][1])
                {
                    sum++;
                }
                else if (item[1][0] <= item[0][0] && item[1][1] >= item[0][1])
                    sum++;
            }
            return sum;
        }

        void GetRanges()
        {
            var inputLines = GetInputLines(4, false);
            for (int i = 0; i < inputLines.Count; i++)
            {
                var arr = inputLines[i].Split(",");
                var r1str = arr[0].Split("-");
                var r1 = new int[] { Convert.ToInt32(r1str[0]),
                    Convert.ToInt32(r1str[1]) };
                var r2str = arr[1].Split("-");
                var r2 = new int[] { Convert.ToInt32(r2str[0]),
                    Convert.ToInt32(r2str[1]) };
                ranges.Add(new List<int[]> { r1, r2});
            }
        }
    }
}
