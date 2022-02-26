using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Data;
using SharedClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary.Repositories
{
    public class DemographicRepository : GenericRepository<DemographicModel>
    {
        public DemographicRepository(DataContext _context) : base(_context)
        {
        }
    }
}
