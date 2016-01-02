using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ParkHelper.Common.Objets;

namespace ParkHelper.Model
{
    public class Parcours : ObservableCollection<Attraction>
    {
        public Parcours(EtapeParcours objectifAttraction)
        {
            ObjectifAttraction = objectifAttraction;
        }

        //NEED TO BE PUBLIC FOR THE VIEW
        public EtapeParcours ObjectifAttraction { get; set; }

        public override string ToString()
        {
            return ObjectifAttraction.ToString();
        }
    }
}
