using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Wordle.Api.Services;

public class FileWriterService : IFileWriterService
{
    // private string _url = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "data/20220201_norsk_ordbank_nob_2005/lemma_2012.txt");
    private readonly string _url = "./data/lemma_bokmal_2012.txt";
    public async Task<string> WriteWordsToFile()
    {
        var file = await File.ReadAllLinesAsync(_url);
        var words = await SplitFile(file);
        Console.WriteLine(file[7]);
        return file[7];
    }

    private Task<string[]> SplitFile(string[] fileContents)
    {
        return Task.FromResult(fileContents.Select(line =>
        {
            var splitted = line.Split(" ");
            foreach (var val in splitted)
            {
                Console.WriteLine(val);
            }
            return "Hello";
        }).ToArray());
    }
}