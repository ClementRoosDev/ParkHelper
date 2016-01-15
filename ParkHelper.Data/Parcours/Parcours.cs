using System.Collections.Generic;
using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace ParkHelper.Data
{
    [CollectionDataContract]
    [KnownType(typeof(Parcours))]
    public class Parcours
    {
        public List<IElementDeParcours> ListeParcours { get; set; }
    }
}
