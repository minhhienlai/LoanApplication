using LoanAppWebAPI.Data;
using LoanAppWebAPI.Models;
using SharedClassLibrary.Repositories;

namespace LoanAppWebAPI.Repositories
{
    public class DemographicRepository : GenericRepository<DemographicModel>
    {
        public DemographicRepository(APIDataContext _context) : base(_context)
        {
        }

        public override IEnumerable<DemographicModel> GetByParentId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
