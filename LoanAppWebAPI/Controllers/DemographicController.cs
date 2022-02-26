using LoanAppMVC.Models;
using SharedClassLibrary.Repositories;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DemographicController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public DemographicController()
        {
        }
        // GET: api/<DemographicController>
        [HttpGet]
        public IHttpActionResult Get()
        {
            IEnumerable<DemographicModel> results = _unitOfWork.DemographicRepository.GetAll();
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }

        // GET api/<DemographicController>/5
        [HttpGet]
        [Route("api/Demographic/{id}")]
        public IHttpActionResult Get(int id)
        {
            DemographicModel results = _unitOfWork.DemographicRepository.GetById(id);
            if (results == null) return NotFound();
            return Ok(results);
        }

        // POST api/<DemographicController>
        [HttpPost]
        public IHttpActionResult Post([FromBody] DemographicModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            _unitOfWork.DemographicRepository.Insert(value);
            _unitOfWork.Save();
            return Ok();
        }

        // PUT api/<DemographicController>
        [HttpPut]
        public IHttpActionResult Put([FromBody] DemographicModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var isExist = _unitOfWork.DemographicRepository.GetById(value.Id);
            if (isExist == null ) return NotFound();

            _unitOfWork.DemographicRepository.Update(value);
            _unitOfWork.Save();

            return Ok();
        }

        // DELETE api/<DemographicController>/5
        [HttpDelete]
        [Route("api/Demographic/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _unitOfWork.DemographicRepository.Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
