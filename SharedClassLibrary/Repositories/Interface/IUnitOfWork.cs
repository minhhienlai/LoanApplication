using SharedClassLibrary.Data;
using SharedClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary.Repositories.Interface
{
    public interface IUnitOfWork
    {
        public IGenericRepository<DemographicModel> GetDemographicRepository();
        public IGenericRepository<BusinessModel> GetBusinessRepository();
        public IGenericRepository<LoanAppModel> GetLoanAppRepository();
        public IListRepository GetListRepository();
        public void Save();
    }
}
