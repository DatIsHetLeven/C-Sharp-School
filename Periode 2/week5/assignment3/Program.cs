using System;
using System.IO;
using System.Collections.Generic;
using MyTools;

namespace Assignment3
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
            Dictionary<string, string> words = ReadWords(filename);
            TranslateWords(words);
            Console.ReadKey();

        }

        //This method reads all words from a textfile and stores these words in a Dictionary
        Dictionary<string, string> ReadWords(string filename)
        {
            Dictionary<string, string> mydict = new Dictionary<string, string>();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File {0} does not exist, please run the program with a valid filename");
                Environment.Exit(0);
            }

            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                if (words.Length == 2)
                {
                    mydict.Add(words[0], words[1]);
                }
            }

            return mydict;
        }

        // This method reads all words from a textfile and stores these words in a Dictionary
        void TranslateWords(Dictionary<string, string> words)
        {
            string key = ReadTools.ReadString("Enter a word: ");
            string value;
            while (key != "stop")
            {
                if (key == "listall")
                {
                    ListAllWords(words);
                }
                else if (words.TryGetValue(key, out value))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0} => {1}", key, value);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Word '{0}' not found", key);
                }

                key = ReadTools.ReadString("Enter a word: ");
            }
        }

        // This method displays all Dutch words in the dictionary, together with the corresponding translations
        void ListAllWords(Dictionary<string, string> words)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (KeyValuePair<string, string> entry in words)
            {
                Console.WriteLine("{0} => {1}", entry.Key, entry.Value);
            }
            Console.ResetColor();
        }


    }
}
