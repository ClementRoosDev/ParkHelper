﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ParcHelperEntities : DbContext
    {
        public ParcHelperEntities()
            : base("name=ParcHelperEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attraction> Attractions { get; set; }
        public virtual DbSet<Boutique> Boutiques { get; set; }
        public virtual DbSet<Indication> Indications { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<IndicationParAttraction> IndicationParAttractions { get; set; }
        public virtual DbSet<IndicationParBoutique> IndicationParBoutiques { get; set; }
        public virtual DbSet<IndicationParRestaurant> IndicationParRestaurants { get; set; }
    }
}
