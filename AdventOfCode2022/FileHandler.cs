using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class FileHandler
    {
        public static string ReadFile(string fileName)
        {
            using(StreamReader sr = new StreamReader(fileName))
            {
                return sr.ReadToEnd(); 
            }
        }

        public static string GetPuzzleInput(string inputPath)
        {
            string basePath = Path.Combine(Environment.CurrentDirectory);
            if (basePath.Contains("Debug"))
            {
                basePath = basePath.Remove(basePath.IndexOf("bin"));
            }
            string fullPath = basePath + inputPath;
            return ReadFile(fullPath);
        }
    }
}
