using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Data
{
    partial class Lieu : IElementDeParcours
    {
        public Type type
        {
            get
            {
                return this.GetType();
            }
        }

        int IElementDeParcours.Duree
        {
            get
            {
                return (int)Duree;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
