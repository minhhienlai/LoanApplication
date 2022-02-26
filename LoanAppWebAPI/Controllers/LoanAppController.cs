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
    public class LoanAppController : ControllerBase
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public LoanAppController()
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
            dataContext.RegisterModels.Add(d => d.Entity<LoanAppModel>().ToTable("LoanApps"));
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.context = dataContext;
            return unitOfWork;
        }

        // GET: api/<LoanAppController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<LoanAppModel> results = _unitOfWork.LoanAppRepository.GetAll();
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }

        // GET api/<LoanAppController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            LoanAppModel results = _unitOfWork.LoanAppRepository.GetById(id);
            if (results == null) return NotFound();
            return Ok(results);
        }
        // GET api/<LoanAppController>/GetByBusiness/5
        [HttpGet]
        [Route("GetByBusiness/{id}")]
        public IActionResult GetByBusinessId(int id)
        {
            IEnumerable<LoanAppModel> results = _unitOfWork.LoanAppRepository.GetByParentId(id);
            if (results == null) return NotFound();
            return Ok(results);
        }

        // POST api/<LoanAppController>
        [HttpPost]
        public IActionResult Post([FromBody] LoanAppModel value)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            _unitOfWork.LoanAppRepository.Insert(value);
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

            if (_unitOfWork.LoanAppRepository.Update(value))
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
            _unitOfWork.LoanAppRepository.Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
