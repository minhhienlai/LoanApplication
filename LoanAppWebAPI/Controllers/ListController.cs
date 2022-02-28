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
    public class ListController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public ListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<ListController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ListModel> results = _unitOfWork.GetListRepository().GetList();
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult Get(string? app, string? bcode, string? bname,
            int? MinScore, int? MaxScore, int? MinAmount, int? MaxAmount)
        {
            IEnumerable<ListModel> results = _unitOfWork.GetListRepository().Search(
                app, bcode, bname, MinScore,  MaxScore,  MinAmount,  MaxAmount);
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }

        // GET api/<ListController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

       
    }
}
