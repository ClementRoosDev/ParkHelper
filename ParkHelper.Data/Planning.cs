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
    public partial class Planning
    {
        public int IdLieu { get; set; }
        public int IdJour { get; set; }
        public int IdHoraire { get; set; }
        public int IdEtat { get; set; }
    
        public virtual EtatLieu EtatLieu { get; set; }
        public virtual Horaire Horaire { get; set; }
        public virtual Jour Jour { get; set; }
        public virtual Lieu Lieu { get; set; }
    }
}