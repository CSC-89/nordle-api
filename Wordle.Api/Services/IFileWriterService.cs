using Microsoft.AspNetCore.Mvc;

namespace Wordle.Api.Services;

public interface IFileWriterService
{
    public Task<string> WriteWordsToFile();
}