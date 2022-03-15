using LoanAppWebAPI.Data;
using LoanAppWebAPI.Models;
using SharedClassLibrary.Repositories;

namespace LoanAppWebAPI.Repositories
{
    public class BusinessRepository : GenericRepository<BusinessModel>
    {
        public BusinessRepository(APIDataContext _context) : base(_context)
        {
        }
        public override IEnumerable<BusinessModel> GetByParentId(int ownerId)
        {
            return table.Where(b => b.OwnerId == ownerId).ToList();
        }
    }
}
