using System;
using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace ParkHelper.Data
{
    public interface IElementDeParcours
    {
        int Duree { get; set; }
        int Ordre { get; set; }
        bool EstDejaDansLeParcours { get; set; }
        Type type { get; }
    }
}
