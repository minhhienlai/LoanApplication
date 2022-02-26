using LoanAppMVC.Models;
using SharedClassLibrary.Repositories;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BusinessController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public BusinessController()
        {
        }
        // GET: api/<BusinessController>
        [HttpGet]
        public IHttpActionResult Get()
        {
            IEnumerable<BusinessModel> results = _unitOfWork.BusinessRepository.GetAll();
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }

        // GET api/<BusinessController>/5
        [HttpGet]
        [Route("api/Business/{id}")]
        public IHttpActionResult Get(int id)
        {
            BusinessModel results = _unitOfWork.BusinessRepository.GetById(id);
            if (results == null) return NotFound();
            return Ok(results);
        }

        // POST api/<BusinessController>
        [HttpPost]
        public IHttpActionResult Post([FromBody] BusinessModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            _unitOfWork.BusinessRepository.Insert(value);
            _unitOfWork.Save();
            return Ok();
        }

        // PUT api/<BusinessController>
        [HttpPut]
        public IHttpActionResult Put([FromBody] BusinessModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var isExist = _unitOfWork.BusinessRepository.GetById(value.Id);
            if (isExist == null) return NotFound();

            _unitOfWork.BusinessRepository.Update(value);
            _unitOfWork.Save();

            return Ok();
        }

        // DELETE api/<BusinessController>/5
        [HttpDelete]
        [Route("api/Business/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _unitOfWork.BusinessRepository.Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
