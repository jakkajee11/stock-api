using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockApi.DTOs;
using StockApi.Entities;
using StockApi.Services;

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : AppControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UsersController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetUsers());
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDto dto)
        {
            if (dto == null)
                return BadRequest();

            var user = _mapper.Map<User>(dto);
            SetInsertProperties(user);
            return Ok(await _service.CreateUser(user));
        }

        
    }
}

