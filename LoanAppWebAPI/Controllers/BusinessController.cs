﻿using Microsoft.AspNetCore.Mvc;
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
    public class BusinessController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public BusinessController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<BusinessController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<BusinessModel> results = _unitOfWork.GetBusinessRepository().GetAll();
            if (results.Count() == 0) return NotFound();
            return Ok(results);
        }
        // GET api/<BusinessController>/GetByDemo/5
        [HttpGet]
        [Route("GetByDemo/{id}")]
        public IActionResult GetByDemographicId(int id)
        {
            IEnumerable<BusinessModel> results = _unitOfWork.GetBusinessRepository().GetByParentId(id);
            if (results == null) return NotFound();
            return Ok(results);
        }

        // GET api/<BusinessController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BusinessModel results = _unitOfWork.GetBusinessRepository().GetById(id);
            if (results == null) return NotFound();
            return Ok(results);
        }

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

            //var isExist = _unitOfWork.BusinessRepository.GetById(value.Id);
            //if (isExist == null) return NotFound();

            if (_unitOfWork.GetBusinessRepository().Update(value))
            {
                _unitOfWork.Save();
                return Ok(value.Id);
            }
            return NotFound();
        }

        // DELETE api/<BusinessController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.GetBusinessRepository().Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
