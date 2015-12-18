using System.Collections.Generic;
using System.Linq;
using ParkHelper.Data;

namespace ParkHelper.Api.Models
{
    public class AttractionsRepository
    {
        public static List<Attraction> GetAllAttractions()
        {
            using (var db = new ParcHelperEntities())
            {
                return db.Attractions.ToList();
            }
        }

        public static List<Attraction> SearchAttractionsByName(string name)
        {
            using (var db = new ParcHelperEntities())
            {
                return db.Attractions.Where(i => i.Libelle.Equals(name)).ToList();
            }
        }

        public static Attraction GetAttraction(int iD)
        {
            using (var db = new ParcHelperEntities())
            {
                return db.Attractions.FirstOrDefault(i => i.Id == iD);
            }
        }

        public static List<Attraction> InsertAttraction(Attraction attraction)
        {
            using (var db = new ParcHelperEntities())
            {
                db.Attractions.Add(attraction);
                db.SaveChanges();
            }
            return GetAllAttractions();
        }
        public static List<Attraction> UpdateAttraction(Attraction attraction)
        {
            using (var db = new ParcHelperEntities())
            {
                var attractionTemp = db.Attractions.FirstOrDefault(i => i.Id == attraction.Id);
                attractionTemp = attraction;
                db.SaveChanges();
            }
            return GetAllAttractions();
        }

        public static List<Attraction> DeleteAttraction(Attraction e)
        {
            using (var db = new ParcHelperEntities())
            {
                var attraction = db.Attractions.FirstOrDefault(i => i.Id == e.Id);
                db.Attractions.Remove(attraction);
                db.SaveChanges();
            }
            return GetAllAttractions();
        }
    }
}