//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkHelper.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Planning
    {
        private int j;
        private int jourdebutMois;
        private int i;
        private int mois;
        private int v;

        public Planning()
        {
            
        }

        public Planning(int id, int lieu, int jourdebutMois, int numeroJour, int mois, int horaire, int etat)
        {
            this.id = id;
            this.idLieu = lieu;
            this.idJour= jourdebutMois;
            this.idNumeroJour = numeroJour;
            this.idMois = mois;
            this.idHoraire = horaire;
            this.idEtat = etat;
        }

        public int id { get; set; }
        public Nullable<int> idLieu { get; set; }
        public Nullable<int> idJour { get; set; }
        public Nullable<int> idNumeroJour { get; set; }
        public Nullable<int> idMois { get; set; }
        public Nullable<int> idHoraire { get; set; }
        public Nullable<int> idEtat { get; set; }
    
        public virtual EtatLieu EtatLieu { get; set; }
        public virtual Horaire Horaire { get; set; }
        public virtual Jour Jour { get; set; }
        public virtual Lieu Lieu { get; set; }
        public virtual Mois Mois { get; set; }
        public virtual NumeroJour NumeroJour { get; set; }
    }
}
