using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Wordle.Api.Services;

public class FileWriterService : IFileWriterService
{
    private string _url = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "data/20220201_norsk_ordbank_nob_2005/lemma_2012.txt");
    public async Task<string> WriteWordsToFile()
    {
        var file = await File.ReadAllLinesAsync(_url);
        // JsonSerializer.Deserialize<string[]>(file);
        Console.WriteLine(file[0]);
        return file[0];
    }
}