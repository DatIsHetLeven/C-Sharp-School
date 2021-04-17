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
            Console.WriteLine("Number of lines containing the word: {0}", count);
            Console.ReadKey();
        }

        bool WordInLine(string line, string word)
        {
            return line.ToLower().Contains(word.ToLower());
        }

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

        void DisplayWordInLine(string line, string word)
        {
            int start = 0;
            int end;
            string lowerline = line.ToLower();
            string lowerword = word.ToLower();
            char prev, next;
            while (true)
            {
                end = lowerline.IndexOf(lowerword, start);
                if (end == -1)
                {
                    Console.WriteLine(line.Substring(start));
                    return;
                }
                if (end == 0)
                    prev = ' ';
                else
                    prev = lowerline[end - 1];
                if (end + word.Length >= line.Length)
                    next = ' ';
                else
                    next = lowerline[end + word.Length];

                Console.Write(line.Substring(start, end - start));
                if ((prev >= 'a' && prev <= 'z') || (next >= 'a' && next <= 'z'))
                {
                    Console.Write(word);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[" + word + "]");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                start = end + word.Length;
            }
        }
    }
}
