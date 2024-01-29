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
    
    public async Task<GetWordResDTO> GetAnswerFromDictionary(string slug)
    {
        var readerService = new FileReaderService();
        var words = await readerService.FetchAllWords();
        var randNum = new Random().Next(words.Length - 1);

        return new GetWordResDTO() { Word = words[randNum] };
    }

    public async Task<bool> CheckWordExists(string slug, string guess)
    {
        var readerService = new FileReaderService();
        var words = await readerService.FetchAllWords();
        return words.Any(x => x.ToUpper() == guess);
    }
}