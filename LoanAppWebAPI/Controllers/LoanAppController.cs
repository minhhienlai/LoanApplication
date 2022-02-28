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
    public class LoanAppController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public LoanAppController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<LoanAppController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<LoanAppModel> results = _unitOfWork.GetLoanAppRepository().GetAll();
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }

        // GET api/<LoanAppController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            LoanAppModel results = _unitOfWork.GetLoanAppRepository().GetById(id);
            if (results == null) return NotFound();
            return Ok(results);
        }
        // GET api/<LoanAppController>/GetByBusiness/5
        [HttpGet]
        [Route("GetByBusiness/{id}")]
        public IActionResult GetByBusinessId(int id)
        {
            IEnumerable<LoanAppModel> results = _unitOfWork.GetLoanAppRepository().GetByParentId(id);
            if (results == null) return NotFound();
            return Ok(results);
        }

        // POST api/<LoanAppController>
        [HttpPost]
        public IActionResult Post([FromBody] LoanAppModel value)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            _unitOfWork.GetLoanAppRepository().Insert(value);
            _unitOfWork.Save();
            return Ok();
        }

        // PUT api/<LoanAppController>
        [HttpPut]
        public IActionResult Put([FromBody] LoanAppModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            //var isExist = _unitOfWork.LoanAppRepository.GetById(value.Id);
            //if (isExist == null) return NotFound();

            if (_unitOfWork.GetLoanAppRepository().Update(value))
            {
                _unitOfWork.Save();
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<LoanAppController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.GetLoanAppRepository().Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
