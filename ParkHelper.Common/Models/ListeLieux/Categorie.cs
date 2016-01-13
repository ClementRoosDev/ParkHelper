using System.Collections.ObjectModel;
using ParkHelper.Common.Models.RequeteListeLieux;

namespace ParkHelper.Common.Models.ListeLieux
{
    public class Categorie : ObservableCollection<Lieu>
    {
        public Categorie(string name)
        {
            Name = name;
        }

        //NEED TO BE PUBLIC FOR THE VIEW
        public string Name { get; set; }
    }
}
