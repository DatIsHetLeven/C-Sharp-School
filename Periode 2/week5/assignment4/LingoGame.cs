using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    class LingoGame
    {
        public string lingoWord;
        public string playerWord;

        public void Init(string lingoWord)
        {
            this.lingoWord = lingoWord;
            this.playerWord = "";
        }

        public bool WordGuessed()
        {
            return lingoWord == playerWord;
        }

        // Process the player word and return against all the letters if they are at correct, incorrect position or not present in lingo word
        public LetterState[] ProcessWord(string playerWord)
        {
            this.playerWord = playerWord;
            LetterState[] letterResult = new LetterState[lingoWord.Length];
            List<char> refLetters = new List<char>();

            for (int i = 0; i < lingoWord.Length; i++)
            {
                if (lingoWord[i] != playerWord[i])
                    refLetters.Add(lingoWord[i]);
            }

            for (int i = 0; i < playerWord.Length; i++)
            {
                if (lingoWord[i] == playerWord[i])
                {
                    letterResult[i] = LetterState.Correct;
                }
                else
                {
                    if (refLetters.Contains(playerWord[i]))
                    {
                        letterResult[i] = LetterState.WrongPosition;
                        refLetters.Remove(playerWord[i]);
                    }
                    else
                    {
                        letterResult[i] = LetterState.Incorrect;
                    }
                }
            }

            return letterResult;
        }
    }
}
