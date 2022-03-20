using LoanAppWebAPI.DTO.Demographics;
using LoanAppWebAPI.Mapper;
using LoanAppWebAPI.Models;
using LoanAppWebAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemographicController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public DemographicController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region GET
        // GET: api/<DemographicController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<DemographicModel> results = _unitOfWork.GetDemographicRepository().GetAll();
            if (results.Count() == 0) return NotFound();
            List<DemographicResponseDto> resultsDto = new List<DemographicResponseDto>();
            foreach (var result in results)
            {
                resultsDto.Add(DemographicMapper.ToDemographicResponse(result));
            }
            return Ok(resultsDto);
        }
        [HttpGet("GetPaging")]
        public IActionResult GetPaging([FromQuery] int? pageNumber, int? pageSize)
        {
            IEnumerable<DemographicModel> results = _unitOfWork.GetDemographicRepository().GetPaging(pageNumber, pageSize);
            if (results.Count() == 0) return NotFound();
            List<DemographicResponseDto> resultsDto = new List<DemographicResponseDto>();
            foreach (var result in results)
            {
                resultsDto.Add(DemographicMapper.ToDemographicResponse(result));
            }
            return Ok(resultsDto);
        }

        // GET api/<DemographicController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DemographicModel result = _unitOfWork.GetDemographicRepository().GetById(id);
            if (result == null) return NotFound();
            return Ok(DemographicMapper.ToDemographicResponse(result));
        }
        #endregion
        #region POST PUT
        // POST api/<DemographicController>
        [HttpPost]
        public IActionResult Post([FromBody] DemographicRequestDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            DemographicModel model = DemographicMapper.InsertToDemographicModel(value);
            _unitOfWork.GetDemographicRepository().Insert(model);
            _unitOfWork.Save();
            return Ok(model.Id);
        }

        // PUT api/<DemographicController>
        [HttpPut]
        public IActionResult Put([FromBody] DemographicRequestDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            DemographicModel model = DemographicMapper.UpdateToDemographicModel(value);
            List<string> propertyList = GetPropertiesToUpdate();

            if (_unitOfWork.GetDemographicRepository().UpdateSelectedProperties(model.Id, model, propertyList))
            {
                _unitOfWork.Save();
                return Ok(value.Id);
            }
            return NotFound();
        }

        private List<string> GetPropertiesToUpdate()
        {
            List<string> result = new List<string>();
            result.Add("FirstName");
            result.Add("LastName");
            result.Add("PhoneNo");
            result.Add("Email");
            result.Add("Address1");
            result.Add("Address2");
            result.Add("State");
            result.Add("Zipcode");
            result.Add("ModifiedBy");
            result.Add("ModifiedAt");
            return result;
        }
        #endregion
        #region DELETE
        // DELETE api/<DemographicController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.GetDemographicRepository().Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
        #endregion
    }
}
