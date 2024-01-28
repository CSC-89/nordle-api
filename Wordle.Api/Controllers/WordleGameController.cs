using Microsoft.AspNetCore.Mvc;
using Wordle.Api.DTOs;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WordleGameController : ControllerBase
{
    [HttpGet("getWord")]
    public async Task<GetWordResDTO> GetWordleAnswer()
    {
        WordFetcherService apiService = new();
        return await apiService.GetAnswerFromDictionary("five-letter-words.json");
    }
    
    [HttpGet("check")]
    public async Task<CheckWordResDTO> checkGuess(string guess)
    {
        return new CheckWordResDTO()
        {
            Response = true
        };
        
    }[HttpGet("writeFile")]
    public async Task<CheckWordResDTO> writeWordsToFile()
    {
        return new CheckWordResDTO()
        {
            Response = true
        };
    }
}