﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfService1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PIb_162_BeloborodovaEntities : DbContext
    {
        public PIb_162_BeloborodovaEntities()
            : base("name=PIb_162_BeloborodovaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_Author> T_Author { get; set; }
        public virtual DbSet<T_Book> T_Book { get; set; }
        public virtual DbSet<T_Errors> T_Errors { get; set; }
        public virtual DbSet<T_Genre> T_Genre { get; set; }
        public virtual DbSet<T_Journal> T_Journal { get; set; }
        public virtual DbSet<T_Reader> T_Reader { get; set; }
        public virtual DbSet<T_Messages> T_Messages { get; set; }
    }
}
