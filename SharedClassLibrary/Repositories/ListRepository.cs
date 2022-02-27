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
    public class ListRepository     {
        protected DataContext _context;
        protected DbSet<DemographicModel> demographicTable;
        protected DbSet<BusinessModel> businessTable;
        protected DbSet<LoanAppModel> loanAppTable;
        public ListRepository(DataContext context) 
        {
            this._context = context;
        }
        public IEnumerable<ListModel> GetList()
        {
            var result = _context.Set<LoanAppModel>()
                .Include(b => b.Business)
                .ThenInclude(o => o.Owner)
                .Select(l => new ListModel() {
                    DemographicId = l.Business.Owner.Id
                    ,LoanApplicationId = l.Id
                    ,DemographicName = l.Business.Owner.Name
                    ,Email = l.Business.Owner.Email
                    ,PhoneNo = l.Business.Owner.PhoneNo
                    ,BusinessCode = l.Business.BusinessCode
                    ,BusinessName = l.Business.Name
                    ,Amount = l.Amount
                    ,CreditScore = l.CreditScore
                    ,RiskRate = l.RiskRate
                }).ToList();
            return (IEnumerable<ListModel>)result;
        }
    }
}
