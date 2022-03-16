using LoanAppWebAPI.Models;
using LoanAppWebAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<ListModelDTO> results = _unitOfWork.GetListRepository().GetList();
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult Get(string? app, string? bcode, string? bname,
            int? MinScore, int? MaxScore, int? MinAmount, int? MaxAmount)
        {
            IEnumerable<ListModelDTO> results = _unitOfWork.GetListRepository().Search(
                app, bcode, bname, MinScore,  MaxScore,  MinAmount,  MaxAmount);
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }
    }
}
