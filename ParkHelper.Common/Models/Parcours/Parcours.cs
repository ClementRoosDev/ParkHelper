﻿using System.Collections.ObjectModel;

namespace ParkHelper.Common.Models.Parcours
{
    public class Parcours : ObservableCollection<ListeParcour>
    {
        public Parcours(string heure, EtapeParcours objectifAttraction)
        {
            Heure = heure;
            ObjectifAttraction = objectifAttraction;
        }

        public string Heure { get; set; }

        //NEED TO BE PUBLIC FOR THE VIEW
        public EtapeParcours ObjectifAttraction { get; set; }

        public override string ToString()
        {
            return ObjectifAttraction.ToString();
        }
    }
}
