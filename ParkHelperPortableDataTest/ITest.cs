using System.Collections.Generic;
using System.Threading.Tasks;
using ParkHelper.Common.Models.RequeteListeLieux;

namespace ParkHelperPortableDataTest
{

    public interface ITest
    {
        List<Lieu> Attractions { get; }

        Task<List<Lieu>> getAttractions(string urlAttractions);

        void getParcours(string parcours);

        void Update();
    }
}
