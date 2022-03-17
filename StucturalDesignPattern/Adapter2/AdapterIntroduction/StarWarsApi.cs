using Adapter2;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdapterIntroduction
{
    public class StarWarsApi
    {
        public async Task<List<Person>> GetCharacters()
        {
            using (var client = new HttpClient())
            {
                string url = "https://swapi.co/api/people";
                string result = await client.GetStringAsync(url);
                var people = JsonConvert.DeserializeObject<ApiResult<Person>>(result).Results;

                return people;
            }
        }
    }

    public class StarWarsApiCharacterSourceAdapter : ICharacterSourceAdapter
    {
        private StarWarsApi _starWarsApi = new StarWarsApi();

        public async Task<IEnumerable<Person>> GetCharacters()
        {
            return await _starWarsApi.GetCharacters();
        }
    }
}
