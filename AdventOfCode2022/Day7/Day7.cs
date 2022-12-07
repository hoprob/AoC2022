using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7
{
    internal class Day7 : AoC
    {
        public List<string> commands = new List<string>();
        public List<Directory> directories = new List<Directory>();
        
        public void Run()
        {
            commands = GetInputLines(7, false);
            sw.Start();
            GetDirectories();
            sw.Stop();
            Console.WriteLine($"Directories under 100 000 sum is: {GetDirectorySum(100000)}");
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
            var dirToDelete = GetDirToDelete();
            Console.WriteLine($"Directory to delete is:\n\tPath [{dirToDelete.Path}]\n\tSize [{dirToDelete.Size}]");
        }
        Directory GetDirToDelete()
        {
            int total = 70000000;
            int needed = 30000000;
            int currentFree = total - directories.First(d => d.Path == "/").Size;
            int missing = needed - currentFree;
            var dir = directories.Where(d => d.Size >= missing).OrderBy(d => d.Size).First();
            return dir;
        }
        int GetDirectorySum(int maxValue)
        {
            return directories.Where(d => d.Size <= maxValue).Sum(d => d.Size);
        }
        public void GetDirectories()
        {
            Directory curDir = new Directory
            {
                Path = "/"
            };
            directories.Add(curDir);

            foreach (var cmd in commands)
            {
                if (cmd.StartsWith("$"))
                {
                    if(cmd.StartsWith("$ cd"))
                    {
                        string dir = cmd.Split(" ").Last();
                        if (dir == "/")
                            curDir = directories.First(d => d.Path == dir);
                        else if(dir == "..")
                        {
                            var newDir = curDir.Path.Substring(0, curDir.Path.LastIndexOf("/"));
                            curDir = directories.First(d => d.Path == newDir);
                        }
                        else
                        {
                            string newDir = curDir.Path + "/" + dir;
                            curDir = new Directory { Path = newDir };
                            directories.Add(curDir);
                        }
                    }
                }
                else if(Int32.TryParse(cmd.Split(" ").First(), out int size))
                {
                    foreach (var dir in directories.Where(d => curDir.Path.StartsWith(d.Path)))
                    {
                        dir.Size += size;
                    }
                }
            }
        }
    }
    class Directory
    {
        public string Path { get; set; }
        public int Size { get; set; }
    }
}
