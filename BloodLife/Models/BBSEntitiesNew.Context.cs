﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BloodLife.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BBSEntitiesNew : DbContext
    {
        public BBSEntitiesNew()
            : base("name=BBSEntitiesNew")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DICT_PRODUCTS> DICT_PRODUCTS { get; set; }
        public virtual DbSet<DICT_TESTS> DICT_TESTS { get; set; }
        public virtual DbSet<PATIENT> PATIENTS { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTS { get; set; }
        public virtual DbSet<REQUEST_PRODUCT> REQUEST_PRODUCT { get; set; }
        public virtual DbSet<REQUEST> REQUESTS { get; set; }
        public virtual DbSet<TEST> TESTS { get; set; }
    }
}
