using SharedClassLibrary.Data;
using SharedClassLibrary.Models;
using SharedClassLibrary.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DataContext _context;
        private ListRepository _listRepository;
        private GenericRepository<DemographicModel> _demographicRepository;
        private GenericRepository<BusinessModel> _businessRepository;
        private GenericRepository<LoanAppModel> _loanAppRepository;
        private static Random random = new Random();

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IGenericRepository<DemographicModel> GetDemographicRepository()
        {
           if (this._demographicRepository == null) {
                    this._demographicRepository = new DemographicRepository(_context);
           }
            return _demographicRepository;
        }

        public IGenericRepository<BusinessModel> GetBusinessRepository()
        {
            if (this._businessRepository == null) {
                this._businessRepository = new BusinessRepository(_context);
            }
            return _businessRepository;
        }

        public IGenericRepository<LoanAppModel> GetLoanAppRepository()
        {
            if (this._loanAppRepository == null) {
                this._loanAppRepository = new LoanAppRepository(_context);
            }
            return _loanAppRepository;
        }
        public IListRepository GetListRepository()
        {
            if (this._listRepository == null) {
                this._listRepository = new ListRepository(_context);
            }
            return _listRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed) {
                if (disposing) {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SeedData()
        {
            try {
                Console.WriteLine(DateTime.Now.Second);
                _context.AddRange(GenerateDemographicData(1000));
                _context.SaveChanges();
                _context.AddRange(GenerateBusinessData(1000));
                _context.SaveChanges();
                _context.AddRange(GenerateLoanAppData(1000));
                _context.SaveChanges();
                Console.WriteLine(DateTime.Now.Second);
            }
            catch (Exception exception) {
                Console.WriteLine(exception.Message);
            }
        }
        public List<DemographicModel> GenerateDemographicData(int count)
        {
            List<DemographicModel> list = new List<DemographicModel>();

            for (int i = 0; i < count; i++) {
                list.Add(new DemographicModel() {
                    Name = RandomString(4, 6),
                    PhoneNo = RandomNumber(10),
                    Email = RandomString(6, 10) + "@gmail.com"
                });
            }

            return list;
        }
        public List<BusinessModel> GenerateBusinessData(int count)
        {
            List<BusinessModel> list = new List<BusinessModel>();
            List<int> ownerList = GetOwnerIdForBusinessTable();

            for (int i = 0; i < count; i++) {
                list.Add(new BusinessModel() {
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

            for (int i = 0; i < count; i++) {
                list.Add(new LoanAppModel() {
                    Amount = random.Next(1000, 1000000),
                    PayBackInMonths = random.Next(6, 24),
                    APRPercent = random.Next(4, 12),
                    CreditScore = random.Next(600, 750),
                    LatePaymentRate = random.Next(0, 100),
                    TotalDebt = random.Next(25000, 1000000),
                    RiskRate = random.Next(0, 100),
                    DateSubmitted = DateTime.Today.AddDays(random.Next(0, 500) * -1),
                    DateProcessed = DateTime.Today.AddDays(random.Next(0, 100) * -1),
                    Status = random.Next(0, 1),
                    BusinessId = bList[random.Next(bList.Count)]
                });
            }

            return list;
        }
        public List<int> GetOwnerIdForBusinessTable()
        {
            List<int> list = new List<int>();
            IEnumerable<DemographicModel> demolist = GetDemographicRepository().GetAll();
            foreach (DemographicModel demographic in demolist) {
                list.Add(demographic.Id);
            }
            return list;
        }
        public List<int> GetBusinessIdForLoanAppTable()
        {
            List<int> list = new List<int>();
            IEnumerable<BusinessModel> blist = GetBusinessRepository().GetAll();
            foreach (BusinessModel b in blist) {
                list.Add(b.Id);
            }
            return list;
        }

        public static string RandomString(int minLength, int maxLength = 0)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            int length = minLength;
            if (maxLength > 0) length = random.Next(minLength, maxLength);
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
