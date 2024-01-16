using FluentAssertions;
using Wordle.Api.Controllers;
using Wordle.Api.Services;
using Xunit.Abstractions;

namespace Wordle.Tests;

public class WordleGameControllerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly WordleGameController _controller = new();
    private readonly WordFetcherService _service = new();

    public WordleGameControllerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void Getword_returns_a_word()
    {
        var result = await _controller.GetWordleAnswer();

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