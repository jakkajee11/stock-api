using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockApi.DTOs;
using StockApi.Entities;
using StockApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : AppControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _service.GetProducts();

            return Ok(_mapper.Map<List<ProductListDto>>(products));
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _service.GetProduct(id));
        }

        // POST api/products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductDto dto)
        {
            if (dto == null)
                return BadRequest();

            var product = _mapper.Map<Product>(dto);
            SetInsertProperties(product);
            return Ok(await _service.CreateProduct(product));
        }

        
    }
}

