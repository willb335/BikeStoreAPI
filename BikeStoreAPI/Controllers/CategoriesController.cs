﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStoreAPI.Data;
using BikeStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BikeStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoriesRepo _repository;
        //private readonly IMapper _mapper;

        public CategoriesController(ICategoriesRepo repository)
        {
            _repository = repository;
            //_mapper = mapper;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public ActionResult<IEnumerable<Categories>> GetAllCategories()
        {

            var categories = _repository.GetAllCategories();

            return Ok(categories);

        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
