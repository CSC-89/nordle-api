using Microsoft.AspNetCore.Mvc;
using Wordle.Api.DTOs;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WordleGameController : ControllerBase
{
    private readonly WordFetcherService _service;
    public WordleGameController(WordFetcherService service)
    {
        _service = service;
    }
    
    [HttpGet("getWord")]
    public async Task<GetWordResDTO> GetWordleAnswer()
    {
        return await _service.GetAnswerFromDictionary("five-letter-words.json");
    }
    
    [HttpGet("check")]
    public async Task<CheckWordResDTO> CheckGuess(string guess)
    {
        
        return new CheckWordResDTO()
        {
            Response = await _service.CheckWordExists("five-letter-words.json", guess)
        };
        
    }
    
    [HttpGet("writeFile")]
    public async Task<CheckWordResDTO> writeWordsToFile()
    {
        return new CheckWordResDTO()
        {
            Response = true
        };
    }
}