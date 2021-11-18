using System;
using System.Collections.Generic;
using System.IO;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.WebApi.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new InvalidDataException("UserService Cannot Be Null");
        }
        
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _userService.GetUsers();
        }
        
        [HttpGet("{id}")]
        public ActionResult<GetUserByIdDto> GetUserByIdDto(int id)
        {
            var user = _userService.GetUserById(id);
            if (user is not null)
            {
                return Ok(new GetUserByIdDto()
                {
                    Id = user.Id,
                    Name = user.Name
                });
            }
            return NotFound();
        }
        
        [HttpPost]
        public ActionResult<PostUserDto> PostUserDto([FromBody]PostUserDto dto)
        {
            var userDto = new User()
            {
                Name = dto.Name
            };
            try
            {
                var newUser = _userService.CreateNewUser(userDto);
                return Created($"https://localhost:5001/api/videos/{newUser.Id}", newUser);
            }
            catch (ArgumentException e)
            {
                return BadRequest();
            }
        }

    }
}