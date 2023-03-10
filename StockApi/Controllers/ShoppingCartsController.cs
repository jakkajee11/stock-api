using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockApi.DTOs;
using StockApi.Entities;
using StockApi.Services;

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IShoppingCartService _service;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ShoppingCartsController(IShoppingCartService service, IUserService userService, IMapper mapper)
        {
            _service = service;
            _userService = userService;
            _mapper = mapper;
        }
        // GET: api/shoppingcarts/1
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var carts = await _service.GetShoppingCart(userId);
            var user = await _userService.GetUser(userId);
            var result = new ShoppingCartDto
            {
                UserId = userId,
                Username = user?.Username,
                //Products = _mapper.Map<List<ProductDto>>(carts.Select(c => c.Product))
                Products = carts.Select(c =>
                {
                    var p = _mapper.Map<ProductDto>(c.Product);
                    p.Amount = c.Amount;

                    return p;
                }).ToList()
            };

            return Ok(result);
        }

        // POST api/shoppingcarts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddToShoppingCartDto dto)
        {
            if (dto == null)
                return BadRequest();

            return Ok(await _service.AddToCart(dto.UserId, dto.ProductId, dto.Amount));
        }

        // POST api/shoppingcarts
        [HttpPost("checkout/{userId}")]
        public async Task<IActionResult> Checkout(Guid userId)
        {
            return Ok(await _service.Checkout(userId));
        }
    }
}

