﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Data
{
    partial class Attraction : IElementDeParcours
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
