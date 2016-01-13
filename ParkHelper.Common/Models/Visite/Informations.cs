using System;

namespace ParkHelper.Common.Models.Visite
{
    public class Informations
    {
        public DateTime Entree { get; set; }

        public DateTime Sortie { get; set; }

        public int DureePauseDej { get; set; }

        public bool Nocturne { get; set; }

        public Sejour Reservation { get; set; }
    }
}
