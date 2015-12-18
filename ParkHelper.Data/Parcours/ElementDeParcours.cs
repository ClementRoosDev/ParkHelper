using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Data
{
    public interface IElementDeParcours
    {
        int Duree { get; set; }
        int Ordre { get; set; }
        bool EstDejaDansLeParcours { get; set; }
    }
}
