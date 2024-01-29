using Wordle.Api.DTOs;

namespace Wordle.Api.Services;

public interface IWordFetcherService
{
    public string[] GetWords(string slug);
    public Task<GetWordResDTO> GetAnswerFromDictionary(string slug);
    public Task<bool> CheckWordExists(string slug, string guess);
}