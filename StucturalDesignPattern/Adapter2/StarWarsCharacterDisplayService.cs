using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
/*
The key problem the adapter pattern seeks to address is imcompatible interfaces.you have some client code that needs to use one or more service providers and the interface
the client is set up to call doesn't math the one the service providers defines.
*/

namespace Adapter2
{
    public class StarWarsCharacterDisplayService
    {
        public async Task<string> ListCharacters()
        {
            string filePath = @"People.json";
            var people = JsonConvert.DeserializeObject<List<Person>>(await File.ReadAllTextAsync(filePath));

            var sb = new StringBuilder();
            int nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}   {"HAIR"}");
            foreach (Person person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}   {person.HairColor}");
            }

            return sb.ToString();
        }
    }
}
