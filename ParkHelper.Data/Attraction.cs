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
    
    public partial class Attraction
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public string LienGif { get; set; }
        public Nullable<double> Latittude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<int> Attente { get; set; }
        public Nullable<int> CapaciteWagon { get; set; }
        public Nullable<int> IdType { get; set; }
    
        public virtual Type Type { get; set; }
    }
}
