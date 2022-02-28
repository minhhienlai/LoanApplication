using Microsoft.EntityFrameworkCore;
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
    public class ListRepository: IListRepository
    {
        protected DataContext _context;
        //protected DbSet<DemographicModel> demographicTable;
        //protected DbSet<BusinessModel> businessTable;
        //protected DbSet<LoanAppModel> loanAppTable;
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
                    , LoanApplicationId = l.Id
                    , DemographicName = l.Business.Owner.Name
                    , Email = l.Business.Owner.Email
                    , PhoneNo = l.Business.Owner.PhoneNo
                    , BusinessCode = l.Business.BusinessCode
                    , BusinessName = l.Business.Name
                    , Amount = l.Amount
                    , CreditScore = l.CreditScore
                    , RiskRate = l.RiskRate
                }).ToList();
            return (IEnumerable<ListModel>)result;
        }

        public IEnumerable<ListModel> Search(string? app, string? bcode, string? bname,
            int? MinScore, int? MaxScore, int? MinAmount, int? MaxAmount)
        {
            var result = _context.Set<LoanAppModel>()
                .Include(b => b.Business)
                .ThenInclude(o => o.Owner)
                .Select(l => new ListModel() {
                    DemographicId = l.Business.Owner.Id
                    , LoanApplicationId = l.Id
                    , DemographicName = l.Business.Owner.Name
                    , Email = l.Business.Owner.Email
                    , PhoneNo = l.Business.Owner.PhoneNo
                    , BusinessCode = l.Business.BusinessCode
                    , BusinessName = l.Business.Name
                    , Amount = l.Amount
                    , CreditScore = l.CreditScore
                    , RiskRate = l.RiskRate
                })
                .Where(l => ((app == null || app.Length == 0 || l.DemographicName.Contains(app))
                             && (bcode == null || bcode.Length == 0 || l.BusinessCode.Contains(bcode))
                             && (bname == null || bname.Length == 0 || l.BusinessName.Contains(bname))
                                && (MinScore == null || l.CreditScore > MinScore)
                                && (MaxScore == null || MaxScore == 0 || l.CreditScore < MaxScore)
                                && (MinAmount == null || l.Amount > MinAmount)
                                && (MaxAmount == null || MaxAmount == 0 || l.Amount < MaxAmount)
                                ))
                .ToList();
            return (IEnumerable<ListModel>)result;
        }
    }
}
