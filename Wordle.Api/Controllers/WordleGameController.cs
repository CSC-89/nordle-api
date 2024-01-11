using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WordleGameController : ControllerBase
{
    [HttpGet(Name = "GetWordleAnswer")]
    public async Task<string> GetWordleAnswer()
    {
        DictionaryApiService apiService = new();
        return await apiService.GetAnswerFromDictionary();
    }
}