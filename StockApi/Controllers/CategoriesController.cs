using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockApi.DTOs;
using StockApi.Entities;
using StockApi.Services;

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : AppControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetCategories());
        }        

        // POST api/categories
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto dto)
        {
            if (dto == null)
                return BadRequest();

            var category = _mapper.Map<Category>(dto);
            SetInsertProperties(category);
            return Ok(await _service.CreateCategory(category));
        }

        
    }
}

