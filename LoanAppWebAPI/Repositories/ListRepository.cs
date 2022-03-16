using LoanAppWebAPI.Data;
using LoanAppWebAPI.Models;
using LoanAppWebAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LoanAppWebAPI.Repositories
{
    public class ListRepository: IListRepository
    {
        protected APIDataContext _context;
        public ListRepository(APIDataContext context)
        {
            this._context = context;
        }
        public IEnumerable<ListModelDTO> GetList()
        {
            var result = _context.Set<LoanAppModel>()
                .Include(b => b.Business)
                .ThenInclude(o => o.Owner)
                .Select(l => new ListModelDTO() {
                    DemographicId = l.Business.Owner.Id
                    , LoanApplicationId = l.Id
                    , DemographicName = l.Business.Owner.FirstName + " " + l.Business.Owner.LastName
                    , Email = l.Business.Owner.Email
                    , PhoneNo = l.Business.Owner.PhoneNo
                    , BusinessCode = l.Business.BusinessCode
                    , BusinessName = l.Business.Name
                    , Amount = l.Amount
                    , CreditScore = l.CreditScore
                    , RiskRate = l.RiskRate
                }).ToList();
            return (IEnumerable<ListModelDTO>)result;
        }

        public IEnumerable<ListModelDTO> Search(string? app, string? bcode, string? bname,
            int? MinScore, int? MaxScore, int? MinAmount, int? MaxAmount)
        {
            var result = _context.Set<LoanAppModel>()
                .Include(b => b.Business)
                .ThenInclude(o => o.Owner)
                .Select(l => new ListModelDTO() {
                    DemographicId = l.Business.Owner.Id
                    , LoanApplicationId = l.Id
                    , DemographicName = l.Business.Owner.FirstName + " " + l.Business.Owner.LastName
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
            return (IEnumerable<ListModelDTO>)result;
        }
    }
}
