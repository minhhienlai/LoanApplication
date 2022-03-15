using LoanAppWebAPI.Models;
using System;
using System.Collections.Generic;
namespace LoanAppWebAPI.Repositories.Interface
{
    public interface IListRepository
    {
        public IEnumerable<ListModel> GetList();
        public IEnumerable<ListModel> Search(string? app, string? bcode, string? bname,
            int? MinScore, int? MaxScore, int? MinAmount, int? MaxAmount);
    }
}
