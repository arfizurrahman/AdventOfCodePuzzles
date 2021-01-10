using System;
using System.IO;
using System.Linq;

namespace DayTwoPasswordPhilosophy
{
    class Program
    {
        static void Main(string[] args)
        {


            // Read the file and display it line by line.  
            StreamReader file =
                new StreamReader(@"E:\Arfiz\Projects\Advent of Code Puzzles\AdventOfCodePuzzles\DayTwoPasswordPhilosophy\input.txt");

            //var validPasswordCounter = CountValidPasswords(file); // Frist part of the challenge

            var validPasswordCounter = CountValidPasswordsForPosition(file); // Second part of the challenge

            file.Close();
            Console.WriteLine("There were {0} valid passwords.", validPasswordCounter);
            Console.ReadLine();
        }

        private static int CountValidPasswords(StreamReader file)
        {
            int validPasswordCounter = 0;
            string line;

            while ((line = file.ReadLine()) != null)
            {
                var (lowerLimit, upperLimit, charToFind, passwordChars) = GetInputsFromLine(line);

                var count = passwordChars.Where(c => c == charToFind).Count();

                if (count >= lowerLimit+1 && count <= upperLimit+1) validPasswordCounter++;
            }

            return validPasswordCounter;
        }

        private static int CountValidPasswordsForPosition(StreamReader file)
        {
            int validPasswordCounter = 0;
            string line;

            while ((line = file.ReadLine()) != null)
            {
                var (lowerLimit, upperLimit, charToFind, passwordChars) = GetInputsFromLine(line);

                if ((passwordChars[lowerLimit] == charToFind &&
                    passwordChars[upperLimit] != charToFind) ||
                    (passwordChars[lowerLimit] != charToFind &&
                    passwordChars[upperLimit] == charToFind))
                {
                    validPasswordCounter++;
                }
            }

            return validPasswordCounter;
        }

        private static (int, int, char, char[]) GetInputsFromLine(string line)
        {
            var splittedPassword = line.Split(':');
            var splittedChar = splittedPassword[0].Split(' ');
            var splittedCount = splittedChar[0].Split('-').Select(x => int.Parse(x)).ToArray();
            var lowerLimit = splittedCount[0]-1;
            var upperLimit = splittedCount[1]-1;
            var charToFind = char.Parse(splittedChar[1]);
            var passwordChars = splittedPassword[1].Trim().ToCharArray();

            return (lowerLimit, upperLimit, charToFind, passwordChars);
        }
    } 
}

