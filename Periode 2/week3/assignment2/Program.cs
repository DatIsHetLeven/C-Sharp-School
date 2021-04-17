using System;
using System.Collections.Generic;

namespace opdr2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myprogram = new Program();
            myprogram.Start();
        }

        void Start()
        {
            HangmanGame hangman = new HangmanGame();
            List<string> words = ListOfWords();
            string word = SelectWord(words);
            hangman.Init(word);
            DisplayWord(hangman.guessedWord);
            bool passed = PlayHangman(hangman);

            if (passed)
            {
                Console.WriteLine("you guessed the word");
            }
            else
            {
                Console.WriteLine("Too bad, you did not guess the word ({0})", hangman.secretWord);
            }
        }

        bool PlayHangman(HangmanGame hangman)
        {
            int attempts = 8;
            List<char> enteredLetters = new List<char>();
            while (attempts > 0)
            {
                Console.WriteLine();
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
                    DisplayWord(hangman.guessedWord);
                    return true;
                }

                Console.WriteLine($"attemtps left: {attempts}");
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
            string result =" ";
            foreach (char ch in letters)
            {
                result += ch + "";
            }
            Console.WriteLine();
            Console.WriteLine("Entered letters: {0}", result);
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

        string SelectWord(List<string> Words)
        {
            Random random = new Random();
            int index = random.Next(Words.Count);
            return Words[index];
        }

        List<string> ListOfWords()
        {
            List<string> mywords = new List<string> { "airplane", "kitchen", "building", "incredible", "funny", "trainstation", "neighbour", "different", "department", "planet", "presentation", "embarrassment", "integration", "scenario", "discount", "management", "understanding", "registration", "security", "language" };
            return mywords;
        }

        string ReadString(string question)
        {
            Console.Write(question);
            string val = Console.ReadLine();
            return val;
        }
    }
}
