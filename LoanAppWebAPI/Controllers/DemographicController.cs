using LoanAppWebAPI.DTO.Demographics;
using LoanAppWebAPI.Mapper;
using LoanAppWebAPI.Models;
using LoanAppWebAPI.Models.DTO;
using LoanAppWebAPI.Repositories.Interface;
using Microsoft.AspNetCore.JsonPatch;
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

            if (_unitOfWork.GetDemographicRepository().Patch(model.Id, model))
            {
                _unitOfWork.Save();
                return Ok(value.Id);
            }
            return NotFound();
        }

        // DELETE api/<DemographicController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.GetDemographicRepository().Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
