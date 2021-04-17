using System;
using System.Text;

public class HangmanGame
{
    public string secretWord;
    public string guessedWord;

    public void Init(string secretWord)
    {
        this.secretWord = secretWord;
        guessedWord = new string('.', secretWord.Length);
    }

    // This method checks if the secret word contains the given letter, and returns true if it does, false otherwise
    public bool ContainsLetter(char letter)
    {
        return secretWord.Contains(letter);
    }

    //This method changes the guessed word by putting the given letter in the correct places
    public void ProcessLetter(char letter)
    {
        int index = secretWord.IndexOf(letter);
        while (index >= 0)
        {
            StringBuilder sb = new StringBuilder(guessedWord);
            sb[index] = letter;
            guessedWord = sb.ToString();
            index = secretWord.IndexOf(letter, index + 1);
        }
    }

    // This method returns true if the guessed word is the same as the secret word, false otherwise
    public bool IsGuessed()
    {
        return secretWord.Equals(guessedWord);
    }
}
