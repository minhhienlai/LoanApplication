using LoanAppMVC.Client.LoanApiResponseDto;
using SharedClassLibrary.Models;

namespace LoanAppMVC.Models
{
    public class BusinessListViewModel
    {
        public IList<BusinessResponseDto> modelList;
        public int OwnerId;
    }
}
