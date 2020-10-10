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

        private readonly IMapper _mapper;
        private readonly BikeStoresContext _context;

        public CategoriesController(BikeStoresContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public ActionResult<IEnumerable<CategoriesReadDto>> GetAllCategories()
        {

            var categories = _context.Categories.ToList();

            return Ok(_mapper.Map<IEnumerable<CategoriesReadDto>>(categories));


        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}", Name = "GetCategoriesById")]
        public ActionResult<CategoriesReadDto> GetCategoriesById(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            if (category == null)
            {
                return NotFound();

            }

            return Ok(_mapper.Map<CategoriesReadDto>(category));

        }

        // POST api/<CategoriesController>
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<CategoriesReadDto> CreateCategories(CategoriesCreateDto categoriesCreateDto)
        {
            var categoriesModel = _mapper.Map<Categories>(categoriesCreateDto);

            _context.Categories.Add(categoriesModel);
            _context.SaveChanges();

            var categoriesReadDto = _mapper.Map<CategoriesReadDto>(categoriesModel);

            // return 201 with location of created resource inside header
            return CreatedAtRoute(nameof(GetCategoriesById), new { id = categoriesReadDto.CategoryId }, categoriesReadDto);

        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateCategories(int id, CategoriesUpdateDto categoriesUpdateDto)
        {
            var categoriesModel = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            _mapper.Map(categoriesUpdateDto, categoriesModel);

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
