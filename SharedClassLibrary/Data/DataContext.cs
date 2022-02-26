using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanAppMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SharedClassLibrary.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DemographicModel> Demographics { get; set; }
        public DbSet<BusinessModel> Businesses { get; set; }
        public DbSet<LoanAppModel> LoanApps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DemographicModel>().ToTable("Demographics");
            modelBuilder.Entity<BusinessModel>().ToTable("Businesses");
            modelBuilder.Entity<LoanAppModel>().ToTable("LoanApps");
        }
    }
}
