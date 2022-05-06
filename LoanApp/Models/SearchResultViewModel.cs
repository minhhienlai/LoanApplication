using LoanAppMVC.Client.LoanApiResponseDto;
using SharedClassLibrary;

namespace LoanAppMVC.Models
{
    public class SearchResultViewModel
    {
        public string? app { get; set; }
        public string? bcode { get; set; }
        public string? bname { get; set; }
        public int? MinScore { get; set; }
        public int? MaxScore { get; set; }
        public int? MinAmount { get; set; }
        public int? MaxAmount { get; set; }
        public PaginatedList<ListLoanApplicationResponseDto> searchResult { get; set; }
    }
}
