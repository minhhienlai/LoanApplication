using SharedClassLibrary.Data;
using SharedClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary.Repositories
{
    public class BusinessRepository : GenericRepository<BusinessModel>
    {
        public BusinessRepository(DataContext _context) : base(_context)
        {
        }
        public override IEnumerable<BusinessModel> GetByParentId(int ownerId)
        {
            return table.Where(b => b.OwnerId == ownerId).ToList();
        }
    }
}
