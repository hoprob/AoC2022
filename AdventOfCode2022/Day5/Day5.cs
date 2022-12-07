using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day5
{
    internal class Day5 : AoC
    {
        Dictionary<int, List<string>> stacks;
        
        public void Run()
        {
            GetRows();
            SortStacks("9000");
            Console.WriteLine("Tops of craters with 9000 is: " + GetTops());
            GetRows();
            SortStacks("9001");
            Console.WriteLine("Tops of craters with 9001 is: " + GetTops());
            Console.ReadLine();
        }


        string GetTops()
        {
            string tops = "";
            foreach (var item in stacks)
            {
                tops = tops + item.Value[0];
            }
            return tops;
        }

        void SortStacks(string crateMover)
        {
            List<string> instructions = GetInputLines(5, false);
            foreach (var item in instructions)
            {
                var charArr = item.Replace("move", "").Replace("from", "").Replace("to", "").Trim().Replace("  ", " ").Replace(" ", "-").Split("-");
                var numArr = new int[charArr.Length];
                for (int i = 0; i < charArr.Length; i++)
                {
                    numArr[i] = Convert.ToInt32(charArr[i].ToString());
                }
                IEnumerable<string> toMove = new List<string>();
                if (crateMover == "9000")
                    toMove = stacks[numArr[1]].Take(numArr[0]).Reverse();
                else if (crateMover == "9001")
                    toMove = stacks[numArr[1]].Take(numArr[0]);
                
                if(toMove.Any())
                {
                    stacks[numArr[2]].InsertRange(0, toMove);
             
                    stacks[numArr[1]].RemoveRange(0, numArr[0]);
                }
            }
        }


        void GetRows()
        {
            stacks = new Dictionary<int, List<string>>();
            List<string> rows = FileHandler.GetPuzzleInput("\\Day5\\Day5Instructions.txt").Split("\r\n").ToList();
            var strArr = rows[rows.Count - 1].Replace(" ", "").ToCharArray();
            rows.RemoveAt(rows.Count - 1);
            foreach (var item in strArr)
            {
                stacks.Add(Convert.ToInt32(item.ToString()), new List<string>());
            }
            foreach (var item in rows)
            {
                var charArr = item.ToCharArray();
                int stack = 1;
                for (int i = 0; i < charArr.Length; i = i + 4)
                {
                    int lastindex = i + 4 > charArr.Length ? charArr.Length - i : 4;
                    var x = new string(charArr, i, lastindex).Replace(" ", "").Replace("[", "").Replace("]", "");
                    if (x.Length > 0)
                        stacks[stack].Add(x);
                    stack++;
                }
            }
        }
    }
}
