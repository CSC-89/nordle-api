using FluentAssertions;
using Wordle.Api.Controllers;
using Wordle.Api.Services;
using Xunit.Abstractions;

namespace Wordle.Tests;

public class WordleGameControllerTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public WordleGameControllerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void Getword_returns_a_word()
    {
        WordleGameController controller = new();

        var result = await controller.GetWordleAnswer();

        result.Should().NotBeNull();
        result.Should().NotBe("");
    }
    
    [Fact]
    public async void WordFetcherService_has_correct_path()
    {
        WordFetcherService service = new();

        var result = await service.GetAnswerFromDictionary("five-letter-words.json");
        
        result.Should().NotBeNull();
        result.Should().NotBe("");
    }
}