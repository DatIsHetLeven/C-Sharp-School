using System;
using System.Collections.Generic;
using System.IO;

namespace Hangman
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
                Console.WriteLine("Please enter the file name as command line argument");
                return;
            }

            Program myprogram = new Program();
            myprogram.Start(filename);
            Console.ReadKey();
        }

        void Start(string filename)
        {
            HangmanGame hangman = new HangmanGame();
            string []words = File.ReadAllLines(filename);
            string word = SelectWord(words);
            hangman.Init(word);
            DisplayWord(hangman.guessedWord);
            bool passed = PlayHangman(hangman);

            if (passed)
            {
                Console.WriteLine("You guessed the word!");
            }
            else
            {
                Console.WriteLine("Too bad, you did not guess the word({0})", hangman.secretWord);
            }
        }


        bool PlayHangman(HangmanGame hangman)
        {
            int attempts = 8;
            List<char> enteredLetters = new List<char>();
            while (attempts > 0)
            {
                Console.WriteLine();
                // Read a letter
                char ch = ReadLetter(enteredLetters);

                enteredLetters.Add(ch);

                DisplayLetters(enteredLetters);

                if (hangman.ContainsLetter(ch))
                {
                    hangman.ProcessLetter(ch);
                }
                else
                {
                    attempts--;
                }

                if (hangman.IsGuessed())
                {
                    Console.WriteLine($"Attempts left: {attempts}");
                    DisplayWord(hangman.guessedWord);
                    return true;
                }

                Console.WriteLine($"Attempts left: {attempts}");

                Console.WriteLine();
                DisplayWord(hangman.guessedWord);
            }

            return (attempts > 0);
        }


        char ReadLetter(List<char> blackListLetters)
        {
            char ch;
            string str;
            do
            {
                str = ReadString("Enter a letter: ");
                while (str.Length == 0)
                {
                    str = ReadString("Enter a letter: ");
                }
                ch = str[0];
            } while (blackListLetters.Contains(ch));

            return ch;
        }

        void DisplayLetters(List<char> letters)
        {
            string result = " ";
            foreach (char ch in letters)
            {
                result += ch + " ";
            }
            Console.WriteLine();
            Console.WriteLine("entered letters: {0}", result);
        }

        void DisplayWord(string word)
        {
            string displayword = " ";
            foreach (char ch in word)
            {
                displayword = displayword + ch + " ";
            }

            Console.WriteLine(displayword);
        }

        string SelectWord(string[] Words)
        {
            Random random = new Random();
            string word;
            do
            {
                int index = random.Next(Words.Length);
                word = Words[index];
            }
            while (word.Length < 3);
            return word;
        }

        string ReadString(string question)
        {
            Console.Write(question);
            string val = Console.ReadLine();
            return val;
        }

    }
}
