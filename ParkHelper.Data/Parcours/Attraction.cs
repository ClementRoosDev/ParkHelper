using System;

// ReSharper disable once CheckNamespace
namespace ParkHelper.Data
{
    class Attraction : IElementDeParcours
    {
        public int Duree { get; set; }

        public bool EstDejaDansLeParcours { get; set; }

        public int Ordre { get; set; }

        public Type type
        {
            get
            {
                return this.GetType();
            }
        }
    }
}
