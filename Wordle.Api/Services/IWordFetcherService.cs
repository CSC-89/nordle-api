namespace Wordle.Api.Services;

public interface IWordFetcherService
{
    public Task<string> GetAnswerFromDictionary(string slug);
}