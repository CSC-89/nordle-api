using System.Net.Http.Headers;
using System.Text.Json;

namespace Wordle.Api.Services;

public class WordFetcherService : IWordFetcherService
{
    public async Task<string> GetAnswerFromDictionary(string slug)
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var url = Path.Join(path, $"data/{slug}");
        var wordsFromFile = File.ReadAllText(url);
        var wordsJSON = JsonSerializer.Deserialize<string[]>(wordsFromFile);
        Console.WriteLine($"words JSON: {wordsJSON}");
        
        return wordsJSON[0];
    }
}