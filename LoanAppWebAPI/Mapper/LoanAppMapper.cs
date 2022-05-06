using LoanAppWebAPI.DTO.LoanApps;
using LoanAppWebAPI.Models;

namespace LoanAppWebAPI.Mapper
{
    public class LoanAppMapper
    {
        public static LoanAppResponseDto ToLoanAppResponse(LoanAppModel model)
        {
            return new LoanAppResponseDto
            {
                Id = model.Id,
                Amount = model.Amount,
                PayBackInMonths = model.PayBackInMonths,
                APRPercent = model.APRPercent,
                CreditScore = model.CreditScore,
                LatePaymentRate = model.LatePaymentRate,
                TotalDebt = model.TotalDebt,
                RiskRate = model.RiskRate,
                DateSubmitted =  model.DateSubmitted,
                DateProcessed = model.DateProcessed,
                Status = model.Status,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                ModifiedBy = model.ModifiedBy,
                ModifiedAt = model.ModifiedAt,
                BusinessId = model.BusinessId,
                BusinessCode = model.Business == null? null : model.Business.BusinessCode,
                BusinessName = model.Business == null ? null : model.Business.Name
            };
        }

        public static LoanAppModel InsertToLoanAppModel(LoanAppRequestDto dto)
        {
            var result =  new LoanAppModel
            {
                Amount = dto.Amount,
                PayBackInMonths = dto.PayBackInMonths,
                DateSubmitted = dto.DateSubmitted,
                DateProcessed = dto.DateProcessed,
                Status = dto.Status,
                CreatedBy = dto.UserRequested,
                CreatedAt = DateTime.Now,
                BusinessId = dto.BusinessId
            };
            return result.Init();
        }
        public static LoanAppModel UpdateToLoanAppModel(LoanAppRequestDto dto)
        {
            return new LoanAppModel
            {
                Id = dto.Id,
                Amount = dto.Amount,
                PayBackInMonths = dto.PayBackInMonths,
                APRPercent = dto.APRPercent,
                CreditScore = dto.CreditScore,
                LatePaymentRate = dto.LatePaymentRate,
                TotalDebt = dto.TotalDebt,
                RiskRate = dto.RiskRate,
                DateSubmitted = dto.DateSubmitted,
                DateProcessed = dto.DateProcessed,
                Status = dto.Status,
                ModifiedBy = dto.UserRequested,
                ModifiedAt = DateTime.Now,
                BusinessId = dto.BusinessId
            };
        }
    }
}
