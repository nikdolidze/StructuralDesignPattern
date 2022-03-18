using Adapter2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImproveAdapterIntroduction
{
    public class StarWarsCharacterDisplayService
    {
        private readonly ICharacterSourceAdapter _characterSourceAdapter;

        public StarWarsCharacterDisplayService(ICharacterSourceAdapter characterSourceAdapter)
        {
            this._characterSourceAdapter = characterSourceAdapter;
        }


        public async Task<string> ListCharacters()
        {
            var people = await _characterSourceAdapter.GetCharacters();

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
