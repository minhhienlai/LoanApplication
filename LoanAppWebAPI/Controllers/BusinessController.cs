using LoanAppWebAPI.DTO.Businesses;
using LoanAppWebAPI.Mapper;
using LoanAppWebAPI.Models;
using LoanAppWebAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using SharedClassLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public BusinessController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region GET
        // GET api/<BusinessController>/GetByDemo/5
        [HttpGet]
        [Route("GetByDemo/{id}")]
        public IActionResult GetByDemographicId(int id, [FromQuery] int? pageNumber, int? pageSize)
        {
            var listAll = _unitOfWork.GetBusinessRepository().GetByParentId(id);
            var results = PaginatedList<BusinessModel>.SliceAndCreate(listAll, pageNumber ?? 1, pageSize ?? Common.DEFAULT_PAGE_SIZE);
            if (results == null) return NotFound();
            var resultsDto = new List<BusinessResponseDto>();
            foreach (var result in results.list)
            {
                resultsDto.Add(BusinessMapper.ToBusinessResponse(result));
            }
            return Ok(PaginatedList<BusinessResponseDto>.Create(resultsDto, results.totalCount, pageNumber ?? 1, pageSize ?? Common.DEFAULT_PAGE_SIZE));
        }

        // GET api/<BusinessController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _unitOfWork.GetBusinessRepository().GetById(id);
            if (result == null) return NotFound();
            return Ok(BusinessMapper.ToBusinessResponse(result));
        }
        #endregion
        #region POST PUT
        // POST api/<BusinessController>
        [HttpPost]
        public IActionResult Post([FromBody] BusinessRequestDto value)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            BusinessModel model = BusinessMapper.InsertToBusinessModel(value);
            _unitOfWork.GetBusinessRepository().Insert(model);
            _unitOfWork.Save();
            return Ok(model.Id);
        }

        // PUT api/<BusinessController>
        [HttpPut]
        public IActionResult Put([FromBody] BusinessRequestDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            List<string> propertyList = GetPropertiesToUpdate();
            BusinessModel model = BusinessMapper.UpdateToBusinessModel(value);
            if (_unitOfWork.GetBusinessRepository().UpdateSelectedProperties(model.Id, model, propertyList))
            {
                _unitOfWork.Save();
                return Ok(model.Id);
            }
            return NotFound();
        }
        private List<string> GetPropertiesToUpdate()
        {
            List<string> result = new List<string>();
            result.Add("BusinessCode");
            result.Add("Name");
            result.Add("Description");
            result.Add("OwnerId");
            result.Add("ModifiedBy");
            result.Add("ModifiedAt");
            return result;
        }
        #endregion
        #region DELETE
        // DELETE api/<BusinessController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.GetBusinessRepository().Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
        #endregion
    }
}
