using Microsoft.AspNetCore.Mvc;
using Wordle.Api.DTOs;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WordleGameController : ControllerBase
{
    private readonly WordFetcherService _service = new ();
    
    
    [HttpGet("getWord")]
    public GetWordResDTO GetWordleAnswer()
    {
        return _service.GetAnswerFromDictionary("five-letter-words.json");
    }
    
    [HttpGet("check")]
    public CheckWordResDTO CheckGuess(string guess)
    {
        
        return new CheckWordResDTO()
        {
            Response = _service.CheckWordExists("five-letter-words.json", guess)
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