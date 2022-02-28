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


    }
}
