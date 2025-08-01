﻿using Microsoft.EntityFrameworkCore;
using testRestApi.data.models;




namespace testRestApi.data
{
    public class appdbcontext :DbContext
    {

        private readonly AuditSaveChangesInterceptor _auditInterceptor;


        public appdbcontext(DbContextOptions<appdbcontext>options, AuditSaveChangesInterceptor auditInterceptor ):base(options) {
          auditInterceptor = _auditInterceptor;



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InfrastructureTransaction>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<InfrastructureTransaction> infrastructureTransactions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.AddInterceptors(_auditInterceptor);
        }



        public DbSet<Category> categories { get; set; }
    public DbSet<item> items { get; set; }

    }
}
  



