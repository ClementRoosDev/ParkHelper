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

        string Name { get; set; }
    }
}
