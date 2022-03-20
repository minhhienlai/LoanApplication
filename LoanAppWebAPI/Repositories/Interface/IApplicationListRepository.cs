using LoanAppWebAPI.DTO.ApplicationList;
using LoanAppWebAPI.Models;
using System;
using System.Collections.Generic;
namespace LoanAppWebAPI.Repositories.Interface
{
    public interface IApplicationListRepository
    {
        public IEnumerable<ApplicationListResponseDto> GetList();
        public IEnumerable<ApplicationListResponseDto> Search(string? app, string? bcode, string? bname,
            int? MinScore, int? MaxScore, int? MinAmount, int? MaxAmount);
    }
}
