using LoanAppWebAPI.Models;
using SharedClassLibrary.Data;
using SharedClassLibrary.Repositories;
using System.Linq.Expressions;

namespace LoanAppWebAPI.Repositories
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

        //public override List<Expression<Func<TEntity, TProperty>>> GetPropertiesExpressionToUpdate<TEntity, TProperty>()
        //{
        //    throw new NotImplementedException();
        //}

        public override List<string> GetPropertiesToUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
