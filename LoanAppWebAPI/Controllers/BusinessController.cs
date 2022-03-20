﻿using LoanAppWebAPI.Models;
using LoanAppWebAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public BusinessController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region GET
        // GET: api/<BusinessController>
        [HttpGet]
        public IActionResult Get()
        {
            var results = _unitOfWork.GetBusinessRepository().GetAll();
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }
        // GET api/<BusinessController>/GetByDemo/5
        [HttpGet]
        [Route("GetByDemo/{id}")]
        public IActionResult GetByDemographicId(int id)
        {
            var results = _unitOfWork.GetBusinessRepository().GetByParentId(id);
            if (results == null) return NotFound();
            return Ok(results);
        }

        // GET api/<BusinessController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var results = _unitOfWork.GetBusinessRepository().GetById(id);
            if (results == null) return NotFound();
            return Ok(results);
        }
        #endregion
        #region POST PUT
        // POST api/<BusinessController>
        [HttpPost]
        public IActionResult Post([FromBody] BusinessModel value)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            _unitOfWork.GetBusinessRepository().Insert(value);
            _unitOfWork.Save();
            return Ok(value.Id);
        }

        // PUT api/<BusinessController>
        [HttpPut]
        public IActionResult Put([FromBody] BusinessModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            List<string> propertyList = GetPropertiesToUpdate();
            if (_unitOfWork.GetBusinessRepository().UpdateSelectedProperties(value.Id,value,propertyList))
            {
                _unitOfWork.Save();
                return Ok(value.Id);
            }
            return NotFound();
        }
        private List<string> GetPropertiesToUpdate()
        {
            List<string> result = new List<string>();
            result.Add("BusinessCode");
            result.Add("Name");
            result.Add("Description");
            result.Add("OwnerId");
            result.Add("ModifiedBy");
            result.Add("ModifiedAt");
            return result;
        }
        #endregion
        #region DELETE
        // DELETE api/<BusinessController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.GetBusinessRepository().Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
        #endregion
    }
}
