﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CVProjectMvc.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbCVProjeEntities2 : DbContext
    {
        public DbCVProjeEntities2()
            : base("name=DbCVProjeEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Deneyim> Deneyims { get; set; }
        public virtual DbSet<Egitim> Egitims { get; set; }
        public virtual DbSet<Hakkimda> Hakkimdas { get; set; }
        public virtual DbSet<Hobi> Hobis { get; set; }
        public virtual DbSet<Iletisim> Iletisims { get; set; }
        public virtual DbSet<Sertifika> Sertifikas { get; set; }
        public virtual DbSet<Yetenek> Yeteneks { get; set; }
    }
}
