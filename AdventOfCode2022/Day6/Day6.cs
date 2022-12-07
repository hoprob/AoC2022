using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day6
{
    internal class Day6 : AoC
    {

        string input;
        public void Run()
        {
            input = GetInputString(6);
            Console.WriteLine("Start marker is: " + GetMarker(4));
            Console.WriteLine("Message marker is: " + GetMarker(14));
            Console.ReadLine();
        }

        int GetMarker(int distinctChars)
        {
            var charArr = input.ToCharArray();
            for (int i = 0; i < charArr.Length -distinctChars; i++)
            {
                var toCheck = charArr.Take(i..(i + distinctChars));
                if(toCheck.Count() == toCheck.Distinct().Count())
                {
                    return i + distinctChars;
                }
            }
            return 0;
        }

    }
}
