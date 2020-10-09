using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeStoreAPI.Data;
using BikeStoreAPI.Dtos.CategoriesDtos;
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
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public ActionResult<IEnumerable<CategoriesReadDto>> GetAllCategories()
        {

            var categories = _repository.GetAllCategories();

            return Ok(_mapper.Map<IEnumerable<CategoriesReadDto>>(categories));


        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}", Name = "GetCategoriesById")]
        public ActionResult<CategoriesReadDto> GetCategoriesById(int id)
        {
            var category = _repository.GetCategoriesById(id);

            if (category == null)
            {
                return NotFound();

            }

            return Ok(_mapper.Map<CategoriesReadDto>(category));

        }

        // POST api/<CategoriesController>
        [HttpPost]
        public ActionResult<CategoriesReadDto> CreateCategories(CategoriesCreateDto categoriesCreateDto)
        {
            var categoriesModel = _mapper.Map<Categories>(categoriesCreateDto);
            _repository.CreateCategories(categoriesModel);
            _repository.SaveChanges();

            var categoriesReadDto = _mapper.Map<CategoriesReadDto>(categoriesModel);

            // return 201 with location of created resource inside header
            return CreatedAtRoute(nameof(GetCategoriesById), new { id = categoriesReadDto.CategoryId }, categoriesReadDto);

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
