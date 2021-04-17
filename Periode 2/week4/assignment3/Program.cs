using System;
using System.IO;

namespace wordfinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename;
            if (args.Length > 0)
            {
                filename = args[0];
            }
            else
            {
                Console.WriteLine("Enter the file to use as command line argument");
                return;
            }
            Program myprogram = new Program();
            myprogram.start(filename);
        }

        void start(string filename)
        {
            string word = helper.ReadString("Enter a word (to search): ");
            int count = SearchWordInFile(filename, word);
            Console.WriteLine("\nNumber of lines containing the word: {0}", count);
            Console.ReadKey();
        }

        //This method returns true if the(given)word is present in the (given) line.The check has to be ‘case insensitive
        bool WordInLine(string line, string word)
        {
            return line.ToLower().Contains(word.ToLower());
        }

        // This method reads and processes each line in a file.When a line contains the given word(use method WordInLine), then this line is printed on screen
        // The method SearchWordInFile returns the number of lines containing the word
        int SearchWordInFile(string filename, string word)
        {
            int count = 0;
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                if (WordInLine(line, word))
                {
                    DisplayWordInLine(line, word);
                    count++;
                }
            }
            return count;
        }

        // This method displays the given line to screen, with the word displayed in red
        void DisplayWordInLine(string line, string word)
        {
            int start = 0, end;
            string lowerline = line.ToLower();
            string lowerword = word.ToLower();
            while (true)
            {
                end = lowerline.IndexOf(lowerword, start);
                if (end == -1)
                {
                    Console.WriteLine(line.Substring(start));
                    return;
                }

                Console.Write(line.Substring(start, end - start));

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[" + line.Substring(end, word.Length) + "]");
                Console.ForegroundColor = ConsoleColor.White;

                start = end + word.Length;
            }
        }
    }
}
