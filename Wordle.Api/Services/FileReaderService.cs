using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Wordle.Api.Services;

public class FileReaderService : IFileReaderService
{
    // private string _url = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "data/20220201_norsk_ordbank_nob_2005/lemma_2012.txt");
    private string _url = "./data/lemma_bokmal_2012.txt";

    public async Task<string[]> FetchAllWords()
    {
        // Use a decoder fallback to replace invalid characters
        DecoderFallback replacementFallback = new DecoderReplacementFallback("?");
        DecoderFallback originalFallback = DecoderFallback.ReplacementFallback;

        // Specify UTF-8 or the appropriate encoding for your file
        Encoding encoding = Encoding.GetEncoding("ISO-8859-1");

        // Set up the decoder fallback for the specified encoding
        //encoding.DecoderFallback = replacementFallback;
        var file = await File.ReadAllLinesAsync(_url, encoding);
        var words = await SplitFile(file);
        Console.WriteLine(words);
        var filteredWords = await FilterWords(words, 5);
        foreach (var val in filteredWords)
        {
            Console.WriteLine(val);
        }

        Console.WriteLine($"Total word Count: {filteredWords.Length}");
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