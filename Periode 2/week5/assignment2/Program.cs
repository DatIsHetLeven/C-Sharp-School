using System;
using System.IO;
using CandyCrushLogic;

namespace CandCrush
{
    class Program
    {

        /*
         * The function receives the 2-dim array as a parameter.
         * Fills the array with random candies
         */
        void InitCandies(RegularCandies[,] playingField, int min, int max)
        {
            Console.WriteLine("Filling Array with Candies ...");

            //generate random value in range of (min,max)
            Random rnd = new Random();
            for (int i = 0; i < playingField.GetLength(0); i++)//looping rows
            {
                for (int j = 0; j < playingField.GetLength(1); j++)//looping columns
                {
                    playingField[i, j] = (RegularCandies)rnd.Next(min, max);//setting value of random candy in the candy matrix
                }
            }
        }


        void DisplayCandies(RegularCandies[,] playingField)
        {
            Random rnd = new Random();
            for (int r = 0; r < playingField.GetLength(1); r++)
            {
                for (int c = 0; c < playingField.GetLength(0); c++)
                {
                    /*
                     * Following conditions are used to check the type of candy 
                     * and draw its sign in the corresponding color
                     */

                    if (playingField[c, r] == RegularCandies.JellyBean)
                    {
                        Console.ForegroundColor = System.ConsoleColor.Red;
                    }
                    else if (playingField[c, r] == RegularCandies.Lozenge)
                    {
                        Console.ForegroundColor = System.ConsoleColor.DarkYellow;
                    }
                    else if (playingField[c, r] == RegularCandies.GumSquare)
                    {
                        Console.ForegroundColor = System.ConsoleColor.Green;
                    }
                    else if (playingField[c, r] == RegularCandies.LemonDrop)
                    {
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                    }
                    else if (playingField[c, r] == RegularCandies.LollipopHead)
                    {
                        Console.ForegroundColor = System.ConsoleColor.Blue;
                    }
                    else if (playingField[c, r] == RegularCandies.JujubeCluster)
                    {
                        Console.ForegroundColor = System.ConsoleColor.DarkMagenta;
                    }
                    else
                    {
                        Console.ForegroundColor = System.ConsoleColor.Black;
                    }
                    Console.Write("#\t");
                }
                Console.Write("\n");
            }
            Console.ResetColor();//resetting the color
        }

        

        // This method saves the playing field to a textfile
        void WritePlayingField(RegularCandies[,] playingField, string filename)
        {
            StreamWriter sw = File.CreateText(filename);

            //Write number of rows and columns
            sw.WriteLine(playingField.GetLength(1));
            sw.WriteLine(playingField.GetLength(0));

            // Write playing field in file, row by row
            string row = "";
            for (int r = 0; r < playingField.GetLength(1); r++)
            {
                row = "";
                for (int c = 0; c < playingField.GetLength(0); c++)
                {
                    row += ((int)playingField[c, r]).ToString() + " ";
                }
                sw.WriteLine(row);
            }
            sw.Close();
        }

        // This method reads a playing field from a file (with the given filename)and returns this playing field
        RegularCandies[,] ReadPlayingField(string filename)
        {
            RegularCandies[,] playingField = null;

            // Read all lines of the file
            string[] lines = File.ReadAllLines(filename);

            // Read number of rows and columns
            int rows = int.Parse(lines[0]);
            int columns = int.Parse(lines[1]);
            playingField = new RegularCandies[columns, rows];

            // Fill all rows by reading all the numbers separated by a space in a line
            for (int line = 2; line < lines.Length; line++)
            {
                string[] numbers = lines[line].Split(' ');
                for (int col = 0; col < columns; col++)
                {
                    int num = int.Parse(numbers[col]);
                    // Throw exception if candy number is outside the boundary value
                    if (num <= (int)RegularCandies.None || num > (int)RegularCandies.JujubeCluster)
                    {
                        throw new ArgumentException("Candy is outside the allowed values [0,5]");
                    }
                    playingField[col, line - 2] = (RegularCandies)num;
                }
            }

            return playingField;
        }

        void Start(string filename)
        {
            RegularCandies[,] playingField = null;

            // catch exception if thrown by ReadPlayingField
            try
            {
                playingField = ReadPlayingField(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in reading playing field from file: {0}", ex.Message);
            }

            if (playingField == null)
            {
                Console.WriteLine("Generating random playing field");
                playingField = new RegularCandies[9, 9];
                InitCandies(playingField, 0, 6);
            }
            DisplayCandies(playingField);
            CandyCrusher.ScoreRowPresent(playingField);
            CandyCrusher.ScoreColumnPresent(playingField);
            WritePlayingField(playingField, filename);
        }

        static void Main(string[] args)
        {
            string filename;
            if (args.Length > 0)
            {
                filename = args[0];
            }
            else
            {
                Console.WriteLine("Please run the program with starting file as command line argument");
                return;
            }
            Program myProgram = new Program();
            myProgram.Start(filename);
            Console.ReadKey();
        }
    }
}

