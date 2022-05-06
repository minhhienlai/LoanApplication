using LoanAppWebAPI.DTO.LoanApps;
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
    public class LoanAppController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public LoanAppController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region GET
        // GET api/<LoanAppController>/GetByBusiness/5
        [HttpGet]
        [Route("GetByBusiness/{id}")]
        public IActionResult GetByBusinessId(int id, [FromQuery] int? pageNumber, int? pageSize)
        {
            var listAll = _unitOfWork.GetLoanAppRepository().GetByParentId(id);
            var results = PaginatedList<LoanAppModel>.SliceAndCreate(listAll, pageNumber ?? 1, pageSize ?? Common.DEFAULT_PAGE_SIZE);
            if (results == null) return NotFound();
            var resultsDto = new List<LoanAppResponseDto>();
            foreach (var result in results.list)
            {
                resultsDto.Add(LoanAppMapper.ToLoanAppResponse(result));
            }
            return Ok(PaginatedList<LoanAppResponseDto>.Create(resultsDto, results.totalCount, pageNumber ?? 1, pageSize ?? Common.DEFAULT_PAGE_SIZE));
        }
        // GET api/<LoanAppController>/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _unitOfWork.GetLoanAppRepository().GetById(id);
            if (result == null) return NotFound();
            return Ok(LoanAppMapper.ToLoanAppResponse(result));
        }
        #endregion
        #region POST PUT
        // POST api/<LoanAppController>
        [HttpPost]
        public IActionResult Post([FromBody] LoanAppRequestDto value)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            LoanAppModel model = LoanAppMapper.InsertToLoanAppModel(value);
            _unitOfWork.GetLoanAppRepository().Insert(model);
            _unitOfWork.Save();
            return Ok(model.Id);
        }

        // PUT api/<LoanAppController>
        [HttpPut]
        public IActionResult Put([FromBody] LoanAppRequestDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            List<string> propertyList = GetPropertiesToUpdate();
            LoanAppModel model = LoanAppMapper.UpdateToLoanAppModel(value);
            if (_unitOfWork.GetLoanAppRepository().UpdateSelectedProperties(value.Id,model,propertyList))
            {
                _unitOfWork.Save();
                return Ok(model.Id);
            }
            return NotFound();
        }
        private List<string> GetPropertiesToUpdate()
        {
            List<string> result = new List<string>();
            result.Add("Amount");
            result.Add("PayBackInMonths");
            result.Add("APRPercent");
            result.Add("DateSubmitted");
            result.Add("DateProcessed");
            result.Add("Status");
            result.Add("BusinessId");
            result.Add("ModifiedBy");
            result.Add("ModifiedAt");
            return result;
        }
        #endregion
        #region DELETE
        // DELETE api/<LoanAppController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.GetLoanAppRepository().Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
        #endregion
    }
}
