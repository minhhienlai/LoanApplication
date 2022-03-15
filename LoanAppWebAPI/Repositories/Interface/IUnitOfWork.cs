using LoanAppWebAPI.Models;
using SharedClassLibrary.Repositories.Interface;

namespace LoanAppWebAPI.Repositories.Interface
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
