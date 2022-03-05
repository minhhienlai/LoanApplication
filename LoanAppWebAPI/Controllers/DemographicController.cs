using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Data;
using SharedClassLibrary.Models;
using SharedClassLibrary.Repositories;
using SharedClassLibrary.Repositories.Interface;

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
            //_unitOfWork = InitRepository();
        }
     
        // GET: api/<DemographicController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<DemographicModel> results = _unitOfWork.GetDemographicRepository().GetAll();
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }

        // GET api/<DemographicController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DemographicModel results = _unitOfWork.GetDemographicRepository().GetById(id);
            if (results == null) return NotFound();
            return Ok(results);
        }

        // POST api/<DemographicController>
        [HttpPost]
        public IActionResult Post([FromBody] DemographicModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            _unitOfWork.GetDemographicRepository().Insert(value);
            _unitOfWork.Save();
            return Ok(value.Id);
        }

        // PUT api/<DemographicController>
        [HttpPut]
        public IActionResult Put([FromBody] DemographicModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            if (_unitOfWork.GetDemographicRepository().Update(value))
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
