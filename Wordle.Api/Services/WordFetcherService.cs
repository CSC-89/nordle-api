using System.Net.Http.Headers;
using System.Text.Json;
using Wordle.Api.DTOs;

namespace Wordle.Api.Services;

public class WordFetcherService : IWordFetcherService
{
    private string _path = AppDomain.CurrentDomain.BaseDirectory;

    public string[] GetWords(string slug)
    {
        var url = Path.Join(_path, $"data/{slug}");
        return JsonSerializer.Deserialize<string[]>(File.ReadAllText(url))!;
    }
    
    public GetWordResDTO GetAnswerFromDictionary(string slug)
    {
        var wordsJson = GetWords(slug);
        var randNum = new Random().Next(wordsJson.Length - 1);

        return new GetWordResDTO() { Word = wordsJson[randNum] };
    }

    public bool CheckWordExists(string slug, string guess)
    {
        var wordsJson = GetWords(slug);
        return wordsJson.Any(x => x.ToUpper() == guess);
    }
}