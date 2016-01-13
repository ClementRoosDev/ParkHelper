using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Data
{
    [KnownType(typeof(Parcours))]
    public class Parcours
    {
        public List<IElementDeParcours> ListeParcours { get; set; }
    }
}
