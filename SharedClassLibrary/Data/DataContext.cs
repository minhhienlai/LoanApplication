using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Models;

namespace SharedClassLibrary.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public List<Action<ModelBuilder>> RegisterModels { get; set; }
        //public DbSet<ListModel> List { get; set; }
        public DbSet<DemographicModel> Demographics { get; set; }
        public DbSet<BusinessModel> Businesses { get; set; }
        public DbSet<LoanAppModel> LoanApps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DemographicModel>()
                .ToTable("Demographics")
                .HasIndex(d => new { d.Name, d.PhoneNo, d.Email });
            modelBuilder.Entity<DemographicModel>()
                .HasMany(d => d.Business)
                .WithOne(b => b.Owner)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BusinessModel>().ToTable("Businesses")
                .HasIndex(b => new { b.BusinessCode, b.Name });
            modelBuilder.Entity<BusinessModel>()
                .HasMany(b => b.LoanApps)
                .WithOne(b => b.Business)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LoanAppModel>()
                .ToTable("LoanApps")
                .HasIndex(l => new { l.Amount, l.CreditScore, l.RiskRate });
            
        }
    }
}
