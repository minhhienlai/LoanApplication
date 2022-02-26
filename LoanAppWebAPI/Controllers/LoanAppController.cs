using LoanAppMVC.Models;
using SharedClassLibrary.Repositories;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class LoanAppController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public LoanAppController()
        {
        }
        // GET: api/<LoanAppController>
        [HttpGet]
        public IHttpActionResult Get()
        {
            IEnumerable<LoanAppModel> results = _unitOfWork.LoanAppRepository.GetAll();
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }

        // GET api/<LoanAppController>/5
        [HttpGet]
        [Route("api/LoanApp/{id}")]
        public IHttpActionResult Get(int id)
        {
            LoanAppModel results = _unitOfWork.LoanAppRepository.GetById(id);
            if (results == null) return NotFound();
            return Ok(results);
        }

        // POST api/<LoanAppController>
        [HttpPost]
        public IHttpActionResult Post([FromBody] LoanAppModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            _unitOfWork.LoanAppRepository.Insert(value);
            _unitOfWork.Save();
            return Ok();
        }

        // PUT api/<LoanAppController>/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] LoanAppModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var isExist = _unitOfWork.LoanAppRepository.GetById(value.Id);
            if (isExist == null) return NotFound();

            _unitOfWork.LoanAppRepository.Update(value);
            _unitOfWork.Save();

            return Ok();
        }

        // DELETE api/<LoanAppController>/5
        [HttpDelete]
        [Route("api/LoanApp/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _unitOfWork.LoanAppRepository.Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
