using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day8
{
    internal class Day8 : AoC
    {
        List<List<int>> forest;
        public void Run()
        {
            GetTrees();
            Console.WriteLine("Part1:");
            Console.WriteLine("Sum of visible trees is: " + GetVisibleTrees());
            Console.WriteLine("Part2:");
            Console.WriteLine("Highest scenic score is: " + GetHighestScenicScore());
            Console.ReadLine();
        }

        private int GetTreeScoreX(IEnumerable<int> trees, int forestNum, int curTree)
        {
            int sum = 0;
            foreach (var tree in trees)
            {
                if (tree < forest[forestNum][curTree])
                    sum++;
                else if (tree == forest[forestNum][curTree])
                {
                    sum++;
                    break;
                }
                else
                {
                    sum++;
                    break;
                }
            }
            return sum;
        }
        private int GetTreeScoreY(IEnumerable<List<int>> treeRows, int forestNum, int curTree)
        {
            int sum = 0;
            foreach (var trees in treeRows)
            {
                if (trees[curTree] < forest[forestNum][curTree])
                    sum++;
                else if (trees[curTree] == forest[forestNum][curTree])
                {
                    sum++;
                    break;
                }
                else
                {
                    sum++;
                    break;
                }
            }
            return sum;
        }
        private int GetHighestScenicScore()
        {
            List<int> scores = new List<int>();
            for (int i = 0; i < forest.Count; i++)
            {
                for (int j = 0; j < forest[i].Count; j++)
                {
                    List<int> treeScore = new List<int>();

                    if (i > 0)
                    {
                        treeScore.Add(GetTreeScoreX(forest[i].Take(j).Reverse(), i, j));
                        treeScore.Add(GetTreeScoreY(forest.Take(i).Reverse(), i, j));
                    }

                    if (i < forest.Count - 1)
                    {
                        treeScore.Add(GetTreeScoreX(forest[i].Take((j + 1)..forest[i].Count), i, j));
                        treeScore.Add(GetTreeScoreY(forest.Take((i + 1)..forest.Count), i, j));
                    }

                    scores.Add(treeScore.Aggregate((n,m) => n * m));
                }
            }
            return scores.Max();
        }

        private int GetVisibleTrees()
        {
            int sum = 0;
            for (int i = 0; i < forest.Count; i++)
            {
                for (int j = 0; j < forest[i].Count; j++)
                {
                    if (j == 0 || j == forest[i].Count - 1)
                        sum++;
                    else if (i == 0 || i == forest.Count - 1)
                        sum++;
                    else if (!forest[i].Take(j).Any(t => t >= forest[i][j]) ||
                        !forest[i].Take((j+1)..forest.Count).Any(t => t >= forest[i][j]))
                        sum++;
                    else if (!forest.Take(i).Any(t => t[j] >= forest[i][j]) ||
                    !forest.Take((i+1)..forest.Count).Any(t => t[j] >= forest[i][j]))
                        sum++;
                }
            }
            return sum;
        }

    public void GetTrees()
        {
            forest = new List<List<int>>();
            var treesStr = GetInputLines(8, false);
            foreach (var str in treesStr)
            {
                forest.Add(str.ToArray().Select(t => Convert.ToInt32(t.ToString())).ToList());
            }
        }
    }
}
