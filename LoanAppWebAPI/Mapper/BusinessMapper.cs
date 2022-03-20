using LoanAppWebAPI.DTO.Businesses;
using LoanAppWebAPI.Models;

namespace LoanAppWebAPI.Mapper
{
    public class BusinessMapper
    {
        public static BusinessResponseDto ToBusinessResponse(BusinessModel model)
        {
            return new BusinessResponseDto
            {
                Id = model.Id,
                BusinessCode = model.BusinessCode,
                Name = model.Name,
                Description = model.Description,
                OwnerName = model.Owner.FirstName + " " + model.Owner.LastName,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                ModifiedBy = model.ModifiedBy,
                ModifiedAt = model.ModifiedAt
            };
        }

        public static BusinessModel InsertToBusinessModel(BusinessRequestDto dto)
        {
            return new BusinessModel
            {
                BusinessCode = dto.BusinessCode,
                Name = dto.Name,
                Description = dto.Description,
                OwnerId = dto.OwnerId,
                CreatedBy = dto.UserRequested,
                CreatedAt = DateTime.Now
            };
        }
        public static BusinessModel UpdateToBusinessModel(BusinessRequestDto dto)
        {
            return new BusinessModel
            {
                Id = dto.Id,
                BusinessCode = dto.BusinessCode,
                Name = dto.Name,
                Description = dto.Description,
                OwnerId = dto.OwnerId,
                ModifiedBy = dto.UserRequested,
                ModifiedAt = DateTime.Now
            };
        }
    }
}
