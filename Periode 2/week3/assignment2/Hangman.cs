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

    public bool ContainsLetter(char letter)
    {
        return secretWord.Contains(letter);
    }

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
    public bool IsGuessed()
    {
        return secretWord.Equals(guessedWord);
    }
}
