using Adapter2;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImproveAdapterIntroduction
{
    public interface ICharacterSourceAdapter
    {
        Task<IEnumerable<Person>> GetCharacters();
    }
}
