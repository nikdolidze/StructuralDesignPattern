using Adapter2;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdapterIntroduction
{
    public interface ICharacterSourceAdapter
    {
        Task<IEnumerable<Person>> GetCharacters();
    }
}
