using System.Collections.ObjectModel;
using ParkHelper.Common.Objets;

namespace ParkHelper.Model
{
    public class Categorie : ObservableCollection<Attraction>
    {
        public Categorie(string name)
        {
            Name = name;
        }

        //NED TO BE PUBLIC FOR THE VIEW
        public string Name { get; set; }
    }
}
