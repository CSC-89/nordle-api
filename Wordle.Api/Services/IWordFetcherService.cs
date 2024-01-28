using Wordle.Api.DTOs;

namespace Wordle.Api.Services;

public interface IWordFetcherService
{
    public string[] GetWords(string slug);
    public GetWordResDTO GetAnswerFromDictionary(string slug);
    public bool CheckWordExists(string slug, string guess);
}