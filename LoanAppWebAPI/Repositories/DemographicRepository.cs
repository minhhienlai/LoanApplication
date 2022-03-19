using LoanAppWebAPI.Models;
using SharedClassLibrary.Data;
using SharedClassLibrary.Repositories;
using System.Linq.Expressions;

namespace LoanAppWebAPI.Repositories
{
    public class DemographicRepository : GenericRepository<DemographicModel>
    {
        public DemographicRepository(DataContext _context) : base(_context)
        {
        }

        public override IEnumerable<DemographicModel> GetByParentId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<string> GetPropertiesToUpdate()
        {
            var list = typeof(DemographicModel).GetProperties().ToList();
            List<string> result = new List<string>();
            result.Add("FirstName");
            result.Add("LastName");
            result.Add("PhoneNo");
            result.Add("Email");
            result.Add("Address1");
            result.Add("Address2");
            result.Add("State");
            result.Add("Zipcode");
            result.Add("ModifiedBy");
            result.Add("ModifiedAt");
            return result;
        }
        //public override List<Expression<Func<TEntity, TProperty>>> GetPropertiesExpressionToUpdate<TEntity, TProperty>()
        //{
        //    List<Expression<Func<TEntity, TProperty>>> results = new();

        //    var arg = Expression.Parameter(typeof(TEntity), "d");
        //    var property = Expression.Property(arg, "FirstName");
        //    //return the property as object
        //    var conv = Expression.Convert(property, typeof(TProperty));
        //    var exp = Expression.Lambda<Func<TEntity, TProperty>>(conv, new ParameterExpression[] { arg });

        //    //Expression<Func<TEntity, TProperty>> expression = d => d.CreatedBy?? "";

        //    results.Add(exp);

        //    return results;
        //}
    }
}
