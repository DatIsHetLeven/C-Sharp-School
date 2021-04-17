using System;
using System.Collections.Generic;
using System.IO;
using MyTools;

namespace Assignment4
{
    public enum LetterState { Correct, Incorrect, WrongPosition }
 
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
                Console.WriteLine("Please run the program with starting file as command line argument");
                return;
            }

            if (!File.Exists(filename))
            {
                Console.WriteLine("File {0} does not exist. Please run the program with valid file");
                Environment.Exit(0);
            }

            Program myProgram = new Program();
            myProgram.Start(filename);
        }

        void Start(string filename)
        {
            Console.ReadKey();
            List<string> words = ReadWords(filename, 5);
            string lingoWord = SelectWord(words);
            LingoGame lingoGame = new LingoGame();
            lingoGame.Init(lingoWord);
            if (PlayLingo(lingoGame))
                Console.WriteLine("Congratulation you have guessed the word!");
            else
                Console.WriteLine("Too bad you didn't guess the word ({0})", lingoWord);
      
        }


        bool PlayLingo(LingoGame lingoGame)
        {
            int attemptsLeft = 5;
            int wordLength = lingoGame.lingoWord.Length;
            string playerWord;
            while (attemptsLeft > 0 & !lingoGame.WordGuessed())
            {
                playerWord = ReadPlayerWord(wordLength, attemptsLeft).ToUpper();
                LetterState[] letterResults = lingoGame.ProcessWord(playerWord);
                DisplayPlayerWord(playerWord, letterResults);
                attemptsLeft = attemptsLeft - 1;
            }
            return lingoGame.WordGuessed();
        }


        // read words with length <wordLength> from file...
        List<string> ReadWords(string filename, int wordLength)
        {
            string[] words = File.ReadAllLines(filename);
            List<string> mylist = new List<string>();
            foreach (string word in words)
            {
                if (word.Length == 5)
                {
                    mylist.Add(word);
                }
            }

            return mylist;
        }


        // return random word from list
        string SelectWord(List<string> words)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(words.Count - 1);
            return words[randomNumber];
        }

       
        // Read player word
        string ReadPlayerWord(int length, int attemptsLeft)
        {
            string word;
            do
            {
                Console.Write("Enter a ({0} - letter) word, attempt {1}: ", length, attemptsLeft);
                word = Console.ReadLine();
            } while (word.Length != length);

            return word;
        }

        // Display player word. If a letter is at correct then it will be displayed with green background. If a letter is present in the word but at incorrect position then it
        // will be displayed with yellow background. 
        void DisplayPlayerWord(string playerWord, LetterState[] letterResults)
        {
            Console.WriteLine();

            for (int i = 0; i < playerWord.Length; i++)
            {
                if (letterResults[i] == LetterState.Correct)
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                else if (letterResults[i] == LetterState.WrongPosition)
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write("{0}", playerWord[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
