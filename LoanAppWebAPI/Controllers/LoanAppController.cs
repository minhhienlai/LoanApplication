﻿using LoanAppWebAPI.Models;
using LoanAppWebAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

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
        #region GET
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
        #endregion
        #region POST PUT
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
            List<string> propertyList = GetPropertiesToUpdate();
            if (_unitOfWork.GetLoanAppRepository().UpdateSelectedProperties(value.Id,value,propertyList))
            {
                _unitOfWork.Save();
                return Ok();
            }
            return NotFound();
        }
        private List<string> GetPropertiesToUpdate()
        {
            List<string> result = new List<string>();
            result.Add("Amount");
            result.Add("PayBackInMonths");
            result.Add("APRPercent");
            result.Add("CreditScore");
            result.Add("LatePaymentRate");
            result.Add("TotalDebt");
            result.Add("RiskRate");
            result.Add("DateSubmitted");
            result.Add("DateProcessed");
            result.Add("Status");
            result.Add("BusinessId");
            result.Add("ModifiedBy");
            result.Add("ModifiedAt");
            return result;
        }
        #endregion
        #region DELETE
        // DELETE api/<LoanAppController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.GetLoanAppRepository().Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
        #endregion
    }
}
