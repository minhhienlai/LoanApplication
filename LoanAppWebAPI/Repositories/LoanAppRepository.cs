using LoanAppWebAPI.Models;
using SharedClassLibrary.Data;
using SharedClassLibrary.Repositories;
using System.Linq.Expressions;

namespace LoanAppWebAPI.Repositories
{
    public class LoanAppRepository : GenericRepository<LoanAppModel>
    {
        public LoanAppRepository(DataContext _context) : base(_context)
        {
        }
        public override IEnumerable<LoanAppModel> GetByParentId(int businessId)
        {
            return table.Where(b => b.BusinessId == businessId).ToList();
        }

        public override List<string> GetPropertiesToUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
