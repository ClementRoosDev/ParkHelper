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
                return db.Attractions.Where(i => i.Libelle == name).ToList();
            }
        }
        public static Attraction GetAttraction(int iD)
        {
            using (var db = new ParcHelperEntities())
            {
                return db.Attractions.FirstOrDefault(i => i.Id == iD);
            }
        }
        public static List<Attraction> InsertAttraction(Attraction e)
        {
            using (var db = new ParcHelperEntities())
            {
                db.Attractions.Add(e);
                db.SaveChanges();
            }
            return GetAllAttractions();
        }
        public static List<Attraction> UpdateAttraction(Attraction e)
        {
            using (var db = new ParcHelperEntities())
            {
                var attraction = db.Attractions.FirstOrDefault(i => i.Id == e.Id);
                attraction.Libelle = e.Libelle;
                db.SaveChanges();
            }
            /**var emp = (from employee in dataContext.Employees
                       where employee.EmployeeID == e.EmployeeID
                       select employee).SingleOrDefault();
            emp.EmployeeName = e.EmployeeName;
            emp.Designation = e.Designation;
            emp.ContactNo = e.ContactNo;
            emp.EMailID = e.EMailID;
            emp.SkillSets = e.SkillSets;
            dataContext.SaveChanges();*/
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
            /**var emp = (from employee in dataContext.Employees
                       where employee.EmployeeID == e.EmployeeID
                       select employee).SingleOrDefault();
            dataContext.Employees.Remove(emp);
            dataContext.SaveChanges();*/
            return GetAllAttractions();
        }
    }
}