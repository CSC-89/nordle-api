namespace Wordle.Api.Models;

public class WordItem
{
    public int Id { get; set; }
    public string Word { get; set; }
    public int LetterCount { get; set; }

    public WordItem(string word)
    {
        Word = word;
        LetterCount = word.Length;
    }
}