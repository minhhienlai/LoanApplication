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
    public class LoanAppRepository : GenericRepository<LoanAppModel>
    {
        public LoanAppRepository(DataContext _context) : base(_context)
        {
        }
        public override IEnumerable<LoanAppModel> GetByParentId(int businessId)
        {
            return table.Where(b => b.BusinessId == businessId).ToList();
        }
    }
}
