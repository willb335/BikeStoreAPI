using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeStoreAPI.Data;
using BikeStoreAPI.Dtos.CategoriesDtos;
using BikeStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


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
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<CategoriesReadDto>> GetAllCategories()
        {

            var categories = _context.Categories.ToList();

            return Ok(_mapper.Map<IEnumerable<CategoriesReadDto>>(categories));


        }

        // GET api/<CategoriesController>/5
        [Authorize]
        [HttpGet("{id}", Name = "GetCategoryById")]
        public ActionResult<CategoriesReadDto> GetCategoryById(int id)
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
        public ActionResult<CategoriesReadDto> CreateCategory(CategoriesCreateDto categoriesCreateDto)
        {
            var category = _mapper.Map<Categories>(categoriesCreateDto);

            _context.Categories.Add(category);
            _context.SaveChanges();

            var categoriesReadDto = _mapper.Map<CategoriesReadDto>(category);

            // return 201 with location of created resource inside header
            return CreatedAtRoute(nameof(GetCategoryById), new { id = categoriesReadDto.CategoryId }, categoriesReadDto);

        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public ActionResult UpdateCategory(int id, CategoriesUpdateDto categoriesUpdateDto)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            _mapper.Map(categoriesUpdateDto, category);

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public ActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();

        }

        // PATCH api/<CategoriesController>/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        public ActionResult PartialCategoryUpdate(int id, JsonPatchDocument<CategoriesUpdateDto> patchDocument)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            var categoryToPatch = _mapper.Map<CategoriesUpdateDto>(category);
            patchDocument.ApplyTo(categoryToPatch, ModelState);

            if (!TryValidateModel(ModelState))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(categoryToPatch, category);


            _context.SaveChanges();

            return NoContent();
        }
    }
}
