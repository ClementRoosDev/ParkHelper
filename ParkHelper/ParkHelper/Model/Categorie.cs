using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Model
{
    using System.Collections.ObjectModel;
    using System.Globalization;
    using ParkHelper.Common.Objets;

    public class Categorie : ObservableCollection<Attraction>
    {
        public Categorie(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
