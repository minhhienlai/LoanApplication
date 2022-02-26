using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Data;
using SharedClassLibrary.Models;
using SharedClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    internal class UnitOfWorkTest
    {
        private DataContext dataContext;
        private GenericRepository<DemographicModel> _demographicResponsitory;
        private GenericRepository<BusinessModel> _businessResponsitory;
        private GenericRepository<LoanAppModel> _loanAppResponsitory;

        public void InitUnitOfWork()
        {
            string connection = @"Server=.;Database=LoanApp;Trusted_Connection=True;MultipleActiveResultSets=true";
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connection);
            dataContext = new DataContext(builder.Options);
            dataContext.RegisterModels = new List<Action<ModelBuilder>>();
            dataContext.RegisterModels.Add(d => d.Entity<DemographicModel>().ToTable("Demographics"));
            dataContext.RegisterModels.Add(b => b.Entity<BusinessModel>().ToTable("Businesses"));
            dataContext.RegisterModels.Add(l => l.Entity<LoanAppModel>().ToTable("LoanApps"));
            _demographicResponsitory = new DemographicRepository(dataContext);
            _businessResponsitory = new BusinessRepository(dataContext);
            _loanAppResponsitory = new LoanAppRepository(dataContext);
        }

        public void RunWorks()
        {
            try
            {
                DemographicModel demo = new DemographicModel { Email = "hienlm@gmail.com", Name = "Hien", PhoneNo = "1234567890" };
                _demographicResponsitory.Insert(demo);
                BusinessModel business = new BusinessModel { Name = "Business 1", BusinessCode = "ABC123", Description = "New business", Owner = demo };
                _businessResponsitory.Insert(business);
                LoanAppModel loan = new LoanAppModel { Amount = 10000, APRPercent = 10, CreditScore = 700, TotalDebt = 20000, PayBackInMonths = 60, Business = business };
                _loanAppResponsitory.Insert(loan);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
