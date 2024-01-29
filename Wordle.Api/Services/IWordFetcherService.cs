using Wordle.Api.DTOs;

namespace Wordle.Api.Services;

public interface IWordFetcherService
{
    public Task<GetWordResDTO> GetAnswerFromDictionary(string slug);
    public Task<bool> CheckWordExists(string slug, string guess);
}