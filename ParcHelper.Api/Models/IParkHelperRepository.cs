using System.Collections.Generic;
using ParkHelper.Data;

namespace ParkHelper.Api.Models
{
    public interface IParkHelperRepository
    {
        List<Attraction> GetAllAttractions();
        bool SaveAll();
        List<Attraction> SearchAttractionsByName(string name);
        Attraction GetAttraction(int iD);
        List<Attraction> InsertAttraction(Attraction e);
        List<Attraction> UpdateAttraction(Attraction e);
        List<Attraction> DeleteAttraction(Attraction e);

    }
}
