using System.Collections.Generic;
using System.Linq;
using ParkHelper.Data;

namespace ParkHelper.Api.Models
{
    public class ParkHelperRepository : IParkHelperRepository
    {
        private readonly ParcHelperEntities _context;

        public ParkHelperRepository(ParcHelperEntities context)
        {
            _context = context;
        }
        public List<Attraction> GetAllAttractions()
        {
            return _context.Attractions.ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public List<Attraction> SearchAttractionsByName(string name)
        {
            return _context.Attractions.Where(i => i.Libelle == name).ToList();
        }

        public Attraction GetAttraction(int iD)
        {
            return _context.Attractions.FirstOrDefault(i => i.Id == iD);
        }

        public List<Attraction> InsertAttraction(Attraction e)
        {
            _context.Attractions.Add(e);
            _context.SaveChanges();

            return GetAllAttractions();
        }
        public List<Attraction> UpdateAttraction(Attraction e)
        {
            var attraction = _context.Attractions.FirstOrDefault(i => i.Id == e.Id);
            if (attraction != null)
                attraction.Libelle = e.Libelle;

            _context.SaveChanges();

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
        public List<Attraction> DeleteAttraction(Attraction e)
        {
            var attraction = _context.Attractions.FirstOrDefault(i => i.Id == e.Id);
            _context.Attractions.Remove(attraction);
            _context.SaveChanges();

            /**var emp = (from employee in dataContext.Employees
                       where employee.EmployeeID == e.EmployeeID
                       select employee).SingleOrDefault();
            dataContext.Employees.Remove(emp);
            dataContext.SaveChanges();*/
            return GetAllAttractions();
        }
    }
}