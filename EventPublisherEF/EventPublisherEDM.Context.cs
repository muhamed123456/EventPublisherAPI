﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventPublisherEF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EventPublisherDBEntities : DbContext
    {
        public EventPublisherDBEntities()
            : base("name=EventPublisherDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<PubEvent> PubEvents { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Type> Types { get; set; }
    }
}
