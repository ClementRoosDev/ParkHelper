using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Common.Models.RequeteListeLieux
{
    public class Planning
    {
        public int id { get; set; }
        public int idLieu { get; set; }
        public int idJour { get; set; }
        public int idNumeroJour { get; set; }
        public int idMois { get; set; }
        public int idHoraire { get; set; }
        public int idEtat { get; set; }
    }
}
