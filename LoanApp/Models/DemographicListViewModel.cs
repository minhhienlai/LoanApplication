using LoanAppMVC.Client.LoanApiResponseDto;
using SharedClassLibrary;

namespace LoanAppMVC.Models
{
    public class DemographicListViewModel
    {
        public PaginatedList<DemographicViewResponseDto> list { get; set; }
    }
}
