﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StudentsEntities : DbContext
    {
        public StudentsEntities()
            : base("name=StudentsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<t_Categories> t_Categories { get; set; }
        public virtual DbSet<t_Languages> t_Languages { get; set; }
        public virtual DbSet<t_Publishers> t_Publishers { get; set; }
        public virtual DbSet<t_RegisterBooks> t_RegisterBooks { get; set; }
        public virtual DbSet<t_Students> t_Students { get; set; }
        public virtual DbSet<t_Stream> t_Stream { get; set; }
        public virtual DbSet<t_Users> t_Users { get; set; }
    }
}
