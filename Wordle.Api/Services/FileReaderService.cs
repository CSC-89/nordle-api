using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Wordle.Api.Services;

public class FileReaderService : IFileReaderService
{
    private string _url = "./data/lemma_bokmal_2012.txt";

    public async Task<string[]> FetchAllWords()
    {
        // Specify Encoding for your file
        Encoding encoding = Encoding.GetEncoding("ISO-8859-1");
        
        var file = await File.ReadAllLinesAsync(_url, encoding);
        var words = await SplitFile(file);
        
        var filteredWords = await FilterWords(words, 5);
        return filteredWords;
    }

    private Task<string[]> SplitFile(string[] fileContents)
    {
        return Task.FromResult(fileContents.Select(line =>
        {
            var splitted = line.Split("\t");
            return splitted[2];
        }).ToArray());
    }

    private Task<string[]> FilterWords(string[] words, int number)
    {
        return Task.FromResult(words.Where(w => w.Length == number)
            .Where(w => !w.Contains('-'))
            .Select(w => w.ToUpper())
            .ToArray());
    }
}