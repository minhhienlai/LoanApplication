using LoanAppMVC.Models;
using SharedClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary.Repositories
{
    internal class LoanAppRepository : GenericRepository<LoanAppModel>
    {
        public LoanAppRepository(DataContext _context) : base(_context)
        {
        }
    }
}
