using SharedClassLibrary.Data;
using SharedClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary.Repositories
{
    public class UnitOfWork : IDisposable
    {
        public DataContext context;
        private ListRepository listRepository;
        private GenericRepository<DemographicModel> demographicRepository;
        private GenericRepository<BusinessModel> businessRepository;
        private GenericRepository<LoanAppModel> loanAppRepository;

        public ListRepository ListRepository {
            get {
                if (this.listRepository == null) {
                    this.listRepository = new ListRepository(context);
                }
                return listRepository;
            }
        }
        public GenericRepository<DemographicModel> DemographicRepository
        {
            get
            {
                if (this.demographicRepository == null)
                {
                    this.demographicRepository = new DemographicRepository(context);
                }
                return demographicRepository;
            }
        }
        public GenericRepository<BusinessModel> BusinessRepository
        {
            get
            {
                if (this.businessRepository == null)
                {
                    this.businessRepository = new BusinessRepository(context);
                }
                return businessRepository;
            }
        }
        public GenericRepository<LoanAppModel> LoanAppRepository
        {
            get
            {
                if (this.loanAppRepository == null)
                {
                    this.loanAppRepository = new LoanAppRepository(context);
                }
                return loanAppRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
