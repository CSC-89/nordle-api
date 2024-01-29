using Microsoft.AspNetCore.Mvc;

namespace Wordle.Api.Services;

public interface IFileReaderService
{
    public Task<string[]> FetchAllWords();
}