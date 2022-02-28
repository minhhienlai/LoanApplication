using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Data;
using SharedClassLibrary.Models;
using SharedClassLibrary.Repositories;
using SharedClassLibrary.Repositories.Interface;
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
        private IListRepository _listResponsitory;
        private static Random random = new Random();

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
            dataContext.RegisterModels.Add(l => l.Entity<ListModel>());
            _demographicResponsitory = new DemographicRepository(dataContext);
            _businessResponsitory = new BusinessRepository(dataContext);
            _loanAppResponsitory = new LoanAppRepository(dataContext);
            _listResponsitory = new ListRepository(dataContext);
        }

        public void SeedData()
        {
            try { 
                dataContext.AddRange(GenerateDemographicData(20));
                dataContext.SaveChanges();
                dataContext.AddRange(GenerateBusinessData(20));
                dataContext.SaveChanges();
                dataContext.AddRange(GenerateLoanAppData(20));
                dataContext.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
}
        public List<DemographicModel> GenerateDemographicData(int count)
        {
            List<DemographicModel> list = new List<DemographicModel>();

            for (int i = 0; i < count; i++)
            {
                list.Add(new DemographicModel() 
                        { Name = RandomString(4,6), 
                        PhoneNo = RandomNumber(10),
                        Email = RandomString(6,10) + "@gmail.com"
                        });
            }

            return list;
        }
        public List<BusinessModel> GenerateBusinessData(int count)
        {
            List<BusinessModel> list = new List<BusinessModel>();
            List<int> ownerList = GetOwnerIdForBusinessTable();

            for (int i = 0; i < count; i++)
            {
                list.Add(new BusinessModel()
                {
                    BusinessCode = RandomString(8),
                    Name = RandomString(10, 20),
                    Description = RandomString(30),
                    OwnerId = ownerList[random.Next(ownerList.Count)]
                });
            }

            return list;
        }
        public List<LoanAppModel> GenerateLoanAppData(int count)
        {
            List<LoanAppModel> list = new List<LoanAppModel>();
            List<int> bList = GetBusinessIdForLoanAppTable();

            for (int i = 0; i < count; i++)
            {
                list.Add(new LoanAppModel()
                {
                    Amount = random.Next(1000, 1000000),
                    PayBackInMonths = random.Next(6, 24),
                    APRPercent = random.Next(4,12),
                    CreditScore = random.Next(600,750),
                    LatePaymentRate = random.Next(0,100),
                    TotalDebt = random.Next(25000,1000000),
                    RiskRate = random.Next(0, 100),
                    DateSubmitted = DateTime.Today.AddDays(random.Next(0,500)*-1),
                    DateProcessed = DateTime.Today.AddDays(random.Next(0,100)*-1),
                    Status = random.Next(0,1),
                    BusinessId = bList[random.Next(bList.Count)]
                }) ;
            }

            return list;
        }
        public List<int> GetOwnerIdForBusinessTable()
        {
            List<int> list = new List<int>();
            IEnumerable<DemographicModel> demolist = _demographicResponsitory.GetAll();
            foreach(DemographicModel demographic in demolist)
            {
                list.Add(demographic.Id);
            }
            return list;
        }
        public List<int> GetBusinessIdForLoanAppTable()
        {
            List<int> list = new List<int>();
            IEnumerable<BusinessModel> blist = _businessResponsitory.GetAll();
            foreach (BusinessModel b in blist)
            {
                list.Add(b.Id);
            }
            return list;
        }

        public static string RandomString(int minLength, int maxLength = 0)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            int length = minLength;
            if (maxLength > 0) length = random.Next(minLength,maxLength);
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
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
