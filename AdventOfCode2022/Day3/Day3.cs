using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
    internal class Day3 : AoC
    {
        List<string[]> Rucksacks = new List<string[]>();
        List<char> sameItem = new List<char>();
        List<int> points = new List<int>();
        List<int> badges = new List<int>();

        public void Run()
        {
            GetRucksacks();
            GetSameItems();
            foreach (var item in sameItem)
            {
                points.Add(GetPoint(item));
            }
            Console.WriteLine($"Points: {points.Sum()}");
            GetBadges();
            Console.WriteLine($"Badges: {badges.Sum()}");
            Console.ReadLine();
        }

        private int GetPoint(char x)
        {
            if (Char.IsUpper(x))
            {
                return Convert.ToInt32(x) - 38;
            }
            return Convert.ToInt32(x) - 96;
        }


        private void GetSameItems()
        {
            foreach (var item in Rucksacks)
            {
                sameItem.Add(item[0].ToCharArray().Intersect(item[1].ToCharArray()).First());
            }
        }

        void GetBadges()
        {
            var rucksacks = GetInputLines(3, false);
            for (int i = 0; i < rucksacks.Count; i = i + 3)
            {
                badges.Add(GetPoint(rucksacks[i].Intersect(rucksacks[i + 1]).Intersect(rucksacks[i + 2]).First()));
            }
        }

        public void GetRucksacks()
        {
            List<string> strings = GetInputLines(3, false);
            foreach (var item in strings)
            {
                var compartments = item.Insert((item.Count()/2), "?").Split("?");
                Rucksacks.Add(compartments);
            }
        }
    }
}
