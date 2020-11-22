using CoutriesManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoutriesManagement.Core.Database
{
    public class CountryContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("countries");
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().HasData(
                new Region { Id = 1, Code = "RA", Name = "Region A" },
                new Region { Id = 2, Code = "RB", Name = "Region B" },
                new Region { Id = 3, Code = "RC", Name = "Region C" });

            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, Code = "MA", Name = "Contact A" },
                new Contact { Id = 2, Code = "MB", Name = "Contact B" },
                new Contact { Id = 3, Code = "MC", Name = "Contact C" });

            modelBuilder.Entity<Country>().HasData(
               new Country { Id = 1, Code = "Code A", Name = "Spain", RegionId = 1, ContactId = 1, BackupContactId = 1 },
               new Country { Id = 2, Code = "Code B", Name = "France", RegionId = 2, ContactId = 2, BackupContactId = 2 },
               new Country { Id = 3, Code = "Code C", Name = "Germany", RegionId = 3, ContactId = 3, BackupContactId = 3 });

            modelBuilder.Entity<Market>().HasData(
                new Market { Id = 1, Code = "Market A", CountryId = 1 },
                new Market { Id = 2, Code = "Market B", CountryId = 2 },
                new Market { Id = 3, Code = "Market C", CountryId = 3 });

        }
    }
}
