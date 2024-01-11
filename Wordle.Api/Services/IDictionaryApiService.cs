namespace Wordle.Api.Services;

public interface IDictionaryApiService
{
    public Task<string> GetAnswerFromDictionary();
}