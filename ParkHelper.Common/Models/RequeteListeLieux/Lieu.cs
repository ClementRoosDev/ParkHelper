﻿using System;
using System.Collections.Generic;

namespace ParkHelper.Common.Models.RequeteListeLieux
{
    public class Lieu
    {
        public event EventHandler<EventArgs> OnToggled = delegate { };

        public TypeDeLieu TypeDeLieu { get; set; }
        public List<Indication> Indications { get; set; }
        public List<Planning> Plannings { get; set; } 
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public string LienGif { get; set; }
        public double Latittude { get; set; }
        public double Longitude { get; set; }
        public int Attente { get; set; }
        public int Duree { get; set; }
        public int CapaciteWagon { get; set; }
        public int IdType { get; set; }
        public int IdEtat { get; set; }
        public bool EstDejaDansLeParcours
        {
            get { return estDejaDansLeParcours.Value; }
            set
            {
                if (estDejaDansLeParcours.HasValue && estDejaDansLeParcours.Value != value)
                {
                    estDejaDansLeParcours = value;
                    OnToggled(this, new EventArgs());
                }
                else
                {
                    estDejaDansLeParcours = value;
                }
                //	System.Diagnostics.Debug.WriteLine ("IsSelected for {0} updated to {1}", Name, value);
            }
        }

        bool? estDejaDansLeParcours;

        public int Ordre { get; set; }
    }
}
