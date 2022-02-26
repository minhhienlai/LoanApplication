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
    public class ListController : ControllerBase
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public ListController()
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
            dataContext.RegisterModels.Add(l => l.Entity<ListModel>().ToTable("Businesses"));
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.context = dataContext;
            return unitOfWork;
        }
        // GET: api/<ListController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ListModel> results = _unitOfWork.ListRepository.GetList();
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }

        // GET api/<ListController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       
    }
}
