﻿using System.Collections.Generic;
using ParkHelper.Common.Models.RequeteListeLieux;
using ParkHelper.Common.Models.Visite;

namespace ParkHelper
{
    public class ParkHelper
    {
        public List<int> ListeAppliSelectionnees { get; set; }
        public RequeteListe requeteLieux { get; set; }
        public Informations VisitePark { get; set; }
        public bool HasApplicationList { get; set; }
    }
}
