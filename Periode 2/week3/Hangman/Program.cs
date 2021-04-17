using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myprogram = new Program();
            myprogram.Start();
            Console.ReadKey();
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
                Console.WriteLine("You guessed the word!");
            }
            else
            {
                Console.WriteLine("Too bad, you did not guess the word ({0})", hangman.secretWord);
            }
        }

        // This method returns true if the secret word has been guessed by the user, otherwise it returns false
        bool PlayHangman(HangmanGame hangman)
        {
            int attempts = 8;
            List<char> enteredLetters = new List<char>();
            while(attempts > 0)
            {
                Console.WriteLine();
                // Read a letter
                char ch = ReadLetter(enteredLetters);

                // Add the letter in list
                enteredLetters.Add(ch);

                // Display the entered letters
                DisplayLetters(enteredLetters);

                //process letter
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

                // print remaining attemps
                Console.WriteLine($"attemps left: {attempts}");

                // Display guessed word
                Console.WriteLine();
                DisplayWord(hangman.guessedWord);
            }

            return (attempts > 0);
        }

        //This method reads a letter until this letteris not in the blacklist
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

        // This method displays the given letters separated by spaces
        void DisplayLetters(List<char> letters)
        {
            string result = "";
            foreach(char ch in letters)
            {
                result += ch + " ";
            }

            Console.WriteLine("Entered letters {0}", result);
        }


        // This method displays the given word with spaces between the letters
        void DisplayWord(string word)
        {
            string displayword = "";
            foreach(char ch in word)
            {
                displayword = displayword + ch + " ";
            }

            Console.WriteLine(displayword);
        }

        // This method selects a random word from list of words
        string SelectWord(List<string> Words)
        {
            Random random = new Random();
            int index = random.Next(Words.Count);
            return Words[index];
        }

        // Return 20 hardcoded words. One of these will become secret word for hangman
        List<string> ListOfWords()
        {
            List<string> mywords = new List<string> { "airplane", "kitchen", "building", "incredible", "funny", "trainstation", "neighbour", "different", "department", "planet", "presentation", "embarrassment", "integration", "scenario", "discount", "management", "understanding", "registration", "security", "language"};
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
