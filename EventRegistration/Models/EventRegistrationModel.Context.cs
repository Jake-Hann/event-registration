﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventRegistration.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Web.Mvc;

    public partial class EventRegistrationDBEntities : DbContext
    {
        public EventRegistrationDBEntities()
            : base("name=EventRegistrationDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public SelectList CategoryList { get; internal set; }
    }
}
