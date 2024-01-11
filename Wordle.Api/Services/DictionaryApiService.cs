using System.Net.Http.Headers;

namespace Wordle.Api.Services;

public class DictionaryApiService : IDictionaryApiService
{
    private readonly string _url = "https://random-words5.p.rapidapi.com/getMultipleRandom";

    public async Task<string> GetAnswerFromDictionary()
    {
        HttpClient client = new (); 
        var words = new string[] {"Loven", "Hagen", "Tiger", "Mobbe", "Circe"};
        return word[0];
        // var options = {
        //     method: 'GET',
        //     url: 'https://random-words5.p.rapidapi.com/getMultipleRandom',
        //     params: {count: '5', wordLength: '5'},
        //     headers: {
        //     'x-rapidapi-host': 'random-words5.p.rapidapi.com',
        //     'x-rapidapi-key': process.env.RAPID_API_KEY
        //     }
        // };
        //
        // axios.request(options).then((response) => {
        //     res.json(response.data[0])
        //     console.log(response.data);
        // }).catch((error) => {
        //     console.error(error);
        // });
    }
}