using LoanAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Data;

namespace LoanAppWebAPI.Data
{
    public class APIDataContext : DataContext
    {
        public APIDataContext(): base(GetConnectionString())
        {
            InitDataContext();
        }

        private static string GetConnectionString()
        {
            string connection = "Server=DESKTOP-I234CM1\\MSSQLSERVER01;Database=LoanApp;Trusted_Connection=True;MultipleActiveResultSets=true";
            return connection;
        }

        private void InitDataContext()
        {
            RegisterModels = new List<Action<ModelBuilder>>();
            RegisterModels.Add(new Action<ModelBuilder>(mb =>
            {
                mb.Entity<DemographicModel>()
                .ToTable("Demographics")
                .HasIndex(d => new { d.Name });
                mb.Entity<DemographicModel>()
                .HasMany(d => d.Business)
                .WithOne(b => b.Owner)
                .OnDelete(DeleteBehavior.Cascade);
            }));

            RegisterModels.Add(new Action<ModelBuilder>(mb =>
            {
                mb.Entity<BusinessModel>().ToTable("Businesses")
                    .HasIndex(b => new { b.BusinessCode, b.Name });
                mb.Entity<BusinessModel>()
                    .HasMany(b => b.LoanApps)
                    .WithOne(b => b.Business)
                    .OnDelete(DeleteBehavior.Cascade);
            }));
            RegisterModels.Add(new Action<ModelBuilder>(mb =>
            {
                mb.Entity<LoanAppModel>()
                    .ToTable("LoanApps")
                    .HasIndex(l => new { l.Amount, l.CreditScore });
            }));
        }
    }
}
