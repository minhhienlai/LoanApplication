using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Data;
using SharedClassLibrary.Models;
using SharedClassLibrary.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemographicController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        public DemographicController()
        {
            _unitOfWork = InitRepository();
        }
        private UnitOfWork InitRepository()
        {
            DataContext dataContext;
            string connection = @"Server=.;Database=LoanApp;Trusted_Connection=True;MultipleActiveResultSets=true";
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connection);
            dataContext = new DataContext(builder.Options);
            dataContext.RegisterModels = new List<Action<ModelBuilder>>();
            dataContext.RegisterModels.Add(d => d.Entity<DemographicModel>().ToTable("Demographics"));
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.context = dataContext;
            return unitOfWork;
        }
        // GET: api/<DemographicController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<DemographicModel> results = _unitOfWork.DemographicRepository.GetAll();
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }

        // GET api/<DemographicController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DemographicModel results = _unitOfWork.DemographicRepository.GetById(id);
            if (results == null) return NotFound();
            return Ok(results);
        }

        // POST api/<DemographicController>
        [HttpPost]
        public IActionResult Post([FromBody] DemographicModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            _unitOfWork.DemographicRepository.Insert(value);
            _unitOfWork.Save();
            return Ok(value.Id);
        }

        // PUT api/<DemographicController>
        [HttpPut]
        public IActionResult Put([FromBody] DemographicModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            //var currentObj = _unitOfWork.DemographicRepository.GetById(value.Id);
            //if (currentObj == null) return NotFound();

            if (_unitOfWork.DemographicRepository.Update(value))
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
            _unitOfWork.DemographicRepository.Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
