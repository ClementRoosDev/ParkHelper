using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ParkHelper.Common.Models.Visite
{
    public class Informations
    {
        private DateTime _sortie;
        private DateTime _entree;

        public DateTime Entree
        {
            get { return _entree; }
            set
            {
                var date = DateTime.Now;
                if(value != null)
                {
                    var setDate = value is DateTime ? (DateTime) value : new DateTime();
                    _entree = setDate.CompareTo(date) < 0 ? date : value;
                }
                else
                {
                    _entree = value;
                }
            }
        }

        public DateTime Sortie
        {
            get { return _sortie; }
            set { _sortie = value; }
        }

        public int DureePauseDej { get; set; }

        public bool Nocturne { get; set; }
    }
}
