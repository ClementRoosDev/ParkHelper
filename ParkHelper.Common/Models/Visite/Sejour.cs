using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkHelper.Common.Models.RequeteListeLieux;

namespace ParkHelper.Common.Models.Visite
{
    public class Sejour
    {
        public int NumeroResa { get; set; }

        public Lieu Hotel { get; set; }
        public int Chambre { get; set; }
        public int NbPeople { get; set; }
    }
}
