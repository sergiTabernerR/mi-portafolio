﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestioBusCrud.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GestioBusEntities : DbContext
    {
        public GestioBusEntities()
            : base("name=GestioBusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Conductor> Conductors { get; set; }
        public virtual DbSet<Horari> Horaris { get; set; }
        public virtual DbSet<InteresTuristic> InteresTuristics { get; set; }
        public virtual DbSet<Linia> Linias { get; set; }
        public virtual DbSet<LiniaParadaHora> LiniaParadaHoras { get; set; }
        public virtual DbSet<Parada> Paradas { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
