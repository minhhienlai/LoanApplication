using LoanAppWebAPI.DTO.Demographics;
using LoanAppWebAPI.Models;

namespace LoanAppWebAPI.Mapper
{
    public static class DemographicMapper
    {
        public static DemographicEditableResponseDto ToDemographicEditableResponse(DemographicModel model)
        {
            return new DemographicEditableResponseDto
            {
                Id = model.Id,
                FirstName = model.FirstName, 
                LastName = model.LastName,
                PhoneNo = model.PhoneNo,
                Email = model.Email,
                Address1 = model.Address1,
                Address2 = model.Address2,
                State = model.State,
                Zipcode = model.Zipcode,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                ModifiedBy = model.ModifiedBy,
                ModifiedAt = model.ModifiedAt
            };
        }

        public static DemographicViewResponseDto ToDemographicViewResponse(DemographicModel model)
        {
            return new DemographicViewResponseDto
            {
                Id = model.Id,
                FullName = model.FirstName + " " + model.LastName,
                PhoneNo = model.PhoneNo,
                Email = model.Email,
                Address = model.Address1 + " " + model.Address2,
                State = model.State,
                Zipcode = model.Zipcode,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                ModifiedBy = model.ModifiedBy,
                ModifiedAt = model.ModifiedAt
            };
        }

        public static DemographicModel InsertToDemographicModel(DemographicRequestDto dto)
        {
            return new DemographicModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNo = dto.PhoneNo,
                Email = dto.Email,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                State = dto.State,
                Zipcode = dto.Zipcode,
                CreatedBy = dto.UserRequested,
                CreatedAt = DateTime.Now
            };
        }
        public static DemographicModel UpdateToDemographicModel(DemographicRequestDto dto)
        {
            return new DemographicModel
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNo = dto.PhoneNo,
                Email = dto.Email,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                State = dto.State,
                Zipcode = dto.Zipcode,
                ModifiedBy = dto.UserRequested,
                ModifiedAt = DateTime.Now
            };
        }
    }
}
