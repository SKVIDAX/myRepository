﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pagination
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Koroleva_1_dbEntities : DbContext
    {
        private static Koroleva_1_dbEntities _context;

        public Koroleva_1_dbEntities()
            : base("name=Koroleva_1_dbEntities")
        {
        }

        public static Koroleva_1_dbEntities GetContext()
        {
            if (_context== null)
                _context = new Koroleva_1_dbEntities();

            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PAGINATION_GENDERS> PAGINATION_GENDERS { get; set; }
        public virtual DbSet<PAGINATION_USERS> PAGINATION_USERS { get; set; }
    }
}
