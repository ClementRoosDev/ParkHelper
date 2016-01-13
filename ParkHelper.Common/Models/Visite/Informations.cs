using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Common.Models.Visite
{
    public class Informations
    {
        public DateTime Entree { get; set; }

        public DateTime Sortie { get; set; }

        public int DureePauseDej { get; set; }

        public bool Nocturne { get; set; }
    }
}
