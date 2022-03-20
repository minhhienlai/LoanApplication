using LoanAppWebAPI.DTO.ApplicationList;
using LoanAppWebAPI.Models;

namespace LoanAppWebAPI.Mapper
{
    public class ApplicationListMapper
    {
        public static ApplicationListResponseDto ToBusinessResponse(LoanAppModel model)
        {
            return new ApplicationListResponseDto
            {
                LoanApplicationId = model.Id,
                DemographicId = model.Business.Owner.Id,
                DemographicName = model.Business.Owner.FirstName + " " + model.Business.Owner.LastName,
                Email = model.Business.Owner.Email,
                PhoneNo = model.Business.Owner.PhoneNo,
                BusinessCode = model.Business.BusinessCode,
                BusinessName = model.Business.Name,
                Amount = model.Amount,
                PayBackInMonths = model.PayBackInMonths,
                APRPercent = model.APRPercent,
                CreditScore = model.CreditScore,
                LatePaymentRate = model.LatePaymentRate,
                TotalDebt = model.TotalDebt,
                RiskRate = model.RiskRate,
                DateSubmitted = model.DateSubmitted,
                DateProcessed = model.DateProcessed,
                Status = model.Status
            };
        }
    }
}
