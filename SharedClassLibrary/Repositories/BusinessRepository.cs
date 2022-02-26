using LoanAppMVC.Models;
using SharedClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary.Repositories
{
    internal class BusinessRepository : GenericRepository<BusinessModel>
    {
        public BusinessRepository(DataContext _context) : base(_context)
        {
        }
    }
}
