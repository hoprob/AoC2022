

using System;

namespace AdventOfCode2022.Day11
{
    internal class Day11 : AoC
    {
        bool isTest = false;
        List<Monkey> monkeys;
        public void Run()
        {
            Console.WriteLine("===== Part 1 =====");           
            GetMonkeyBusiness(true);
            Console.WriteLine("===== Part 2 =====");
            GetMonkeyBusiness(false);

        }
        void GetMonkeyBusiness(bool part1)
        {
            GetMonkeys();
            long div = monkeys.Select(m => m.Divider).Aggregate((x, y) => x * y);
            int rounds = part1 ? 20 : 10000;
            for (int i = 0; i < rounds; i++)
            {
                foreach (var monkey in monkeys)
                {
                    foreach (var item in monkey.Items)
                    {
                        long worryLevel = monkey.Multiplied(item);
                        if(part1)
                            worryLevel /= 3;
                        else
                            worryLevel %= div;
                        if (worryLevel % monkey.Divider == 0)
                            monkeys[monkey.True].Items.Add(worryLevel);
                        else
                            monkeys[monkey.False].Items.Add(worryLevel);
                        monkey.InspectedItems++;
                    }
                    monkey.Items.Clear();
                }
            }
            var top = monkeys.OrderByDescending(m => m.InspectedItems).Take(2).ToList();
            Console.WriteLine("Level of monkey business: " + top[0].InspectedItems * top[1].InspectedItems);
        }


        void GetMonkeys()
        {
            monkeys = new List<Monkey>();
            var monkeysStr = GetInputString(11, isTest).Split("\r\n\r\n");
            foreach (var monkey in monkeysStr)
            {
                var lines = monkey.Split("\r\n");
                var itemsStr = lines[1].Substring(lines[1].IndexOf(":") + 1).Split(",");
                List<long> items = new List<long>();
                foreach (var item in itemsStr)
                {
                    items.Add(Convert.ToInt32(item.Trim()));
                }
                monkeys.Add(new Monkey
                {
                    Id = Convert.ToInt32(lines[0].Substring(lines[0].IndexOf("y") + 1).Replace(":", "")),
                    Items = items,
                    MultiplierStr = lines[2],
                    Divider = Convert.ToInt64(lines[3].Substring(lines[3].IndexOf("y") + 1).Trim()),
                    True = Convert.ToInt32(lines[4].Substring(lines[4].IndexOf("y") + 1).Trim()),
                    False = Convert.ToInt32(lines[5].Substring(lines[5].IndexOf("y") + 1).Trim()),
                });
            }
        }
    }

    class Monkey
    {
        public int Id { get; set; }
        public List<long> Items { get; set; }
        public string MultiplierStr { get; set; }
        public long Divider { get; set; }
        public int True { get; set; }
        public int False { get; set; }
        public long InspectedItems { get; set; } = 0;

        public long Multiplied(long worryLevel)
        {
            long multiplier;
            if(!(Int64.TryParse(MultiplierStr.Substring(MultiplierStr.LastIndexOf(" ") + 1), out multiplier)))
                multiplier = worryLevel;
            if (MultiplierStr.Contains("+"))
                worryLevel += multiplier;
            else if(MultiplierStr.Contains("*"))
                worryLevel *=  multiplier;
            return worryLevel;
        }

    }
}
