using System.Collections.Generic;
using System.Threading.Tasks;
using ParkHelper.Common.Objets;

namespace ParkHelperPortableDataTest
{

    public interface ITest
    {
        List<Attraction> Attractions { get; }

        Task<List<Attraction>> getAttractions(string urlAttractions);

        void getParcours(string parcours);

        void Update();
    }
}
