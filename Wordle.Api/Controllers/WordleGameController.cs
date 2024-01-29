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
    public async Task<ActionResult<GetWordResDTO>> GetWordleAnswer()
    {
        try
        {
            return Ok(await _service.GetAnswerFromDictionary("five-letter-words.json"));
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
        
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
    public async Task<ActionResult> writeWordsToFile()
    {
        var writerService = new FileReaderService();
        var result = await writerService.FetchAllWords();
        return Ok(result);
    }
}