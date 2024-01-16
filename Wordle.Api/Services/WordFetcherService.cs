using System.Net.Http.Headers;
using System.Text.Json;

namespace Wordle.Api.Services;

public class WordFetcherService : IWordFetcherService
{
    private string _path = AppDomain.CurrentDomain.BaseDirectory;
    
    public async Task<string> GetAnswerFromDictionary(string slug)
    {
        var url = Path.Join(_path, $"data/{slug}");
        var wordsJSON = JsonSerializer.Deserialize<string[]>(File.ReadAllText(url));
        var randNum = new Random().Next(wordsJSON.Length - 1);
        
        return wordsJSON[randNum];
    }
}