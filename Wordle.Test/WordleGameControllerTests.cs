using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Controllers;
using Wordle.Api.Models;
using Wordle.Api.Services;

namespace Wordle.Tests;

public abstract class WordleGameControllerTests
{
    private readonly WordleGameController _controller = new();
    private readonly WordFetcherService _service = new();
    private readonly WordContext _context;
    protected DbContextOptions<WordContext> ContextOptions { get; }
    
    protected WordleGameControllerTests(DbContextOptions<WordContext> contextOptions)
    {
        ContextOptions = contextOptions;
        _context = new WordContext(ContextOptions);
        Seed();
    }
    
    private async void Seed()
    {
        await _context.Database.EnsureDeletedAsync();
        await _context.Database.EnsureCreatedAsync();

        var words = new List<WordItem>()
        {
            new("Loven"),
            new ("Hagen"),
            new("Tiger"),
            new("Mobbe"),
            new("Circe")
        };
        
        await _context.Word.AddRangeAsync(words);
        _context.SaveChanges();
    }
    
    [Fact]
    public async void testDB_is_seeded_correctly()
    {
        var result = await _context.Word.FirstAsync();
        var result2 = await _context.Word.AnyAsync(ctx => ctx.Word == "Tiger");

        result.Should().NotBeNull();
        result.Word.Should().Be("Loven");
        result2.Should().BeTrue();
    }
    
    [Fact]
    public async void Getword_returns_a_word()
    {
        var result = await _controller.GetAnswer();

        result.Should().NotBeNull();
        result.Should().NotBe("");
    }
    
    [Fact]
    public async void WordFetcherService_has_correct_path()
    {
        var result = await _service.GetAnswerFromDictionary("five-letter-words.json");
        
        result.Should().NotBeNull();
        result.Should().NotBe("");
    }
    [Fact]
    public async void WordFetcherService_returns_random_word_from_list()
    {
        var result = await _service.GetAnswerFromDictionary("five-letter-words.json");
        
        result.Should().NotBeNull();
        result.Should().NotBe("");
    }
}