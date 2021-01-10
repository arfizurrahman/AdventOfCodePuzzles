using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayOneFindTheEntries
{
    class Program
    {
        static void Main(string[] args)
        {
            var target = 2020;

            var numbers = File.ReadAllLines(@"E:\Arfiz\Projects\Advent of Code Puzzles\AdventOfCodePuzzles\DayOneFindTheEntries\input.txt")
                     .Select(n => int.Parse(n))
                     .ToArray();

            var twoEntries = FindTheTwoEntries(target, numbers);
            var threeEntries = FindTheThreeEntries(target, numbers);

            if(twoEntries.Count == 2)
                Console.WriteLine(twoEntries[0] * twoEntries[1]);
            if (threeEntries.Count == 3)
                Console.WriteLine(threeEntries[0] * threeEntries[1] * threeEntries[2]);
        }

        private static List<int> FindTheTwoEntries(int target, int[] numbers)
        {
            var results = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                var complement = target - numbers[i];
                if (numbers.Contains(complement))
                {
                    results.Add(numbers[i]);
                    results.Add(complement);
                    break;
                }
            }

            return results;
        }

        private static List<int> FindTheThreeEntries(int target, int[] numbers)
        {
            var results = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                var newTarget = target - numbers[i];
                HashSet<int> existingNumbers = new HashSet<int>();
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    var complement = newTarget - numbers[j];
                    if (existingNumbers.Contains(complement))
                    {
                        results.Add(numbers[i]);
                        results.Add(numbers[j]);
                        results.Add(complement);
                        return results;
                    }
                    else
                    {
                        existingNumbers.Add(numbers[j]);
                    }
                }
            }

            return results;
        }
    }
}
