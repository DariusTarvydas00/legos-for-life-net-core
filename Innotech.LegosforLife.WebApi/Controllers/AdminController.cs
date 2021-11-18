using System;
using System.Collections.Generic;
using System.IO;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.WebApi.DTOs.AdminDtos;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService ?? throw new InvalidDataException("AdminService Cannot Be Null");
        }
        
        [HttpGet]
        public ActionResult<List<Admin>> GetAll()
        {
            return _adminService.GetAdmins();
        }
        
        [HttpGet("{id}")]
        public ActionResult<GetAdminByIdDto> GetAdminByIdDto(int id)
        {
            var admin = _adminService.GetAdminById(id);
            if (admin is not null)
            {
                return Ok(new GetAdminByIdDto()
                {
                    Id = admin.Id,
                    Name = admin.Name
                });
            }
            return NotFound();
        }
        
        [HttpPost]
        public ActionResult<PostAdminDto> PostAdminDto([FromBody]PostAdminDto dto)
        {
            var adminDto = new Admin()
            {
                Name = dto.Name
            };
            try
            {
                var newAdmin = _adminService.CreateNewAdmin(adminDto);
                return Created($"https://localhost:5001/api/videos/{newAdmin.Id}", newAdmin);
            }
            catch (ArgumentException e)
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        public ActionResult<PutAdminDto> PutAdminDto(int id, [FromBody] PutAdminDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            return Ok(_adminService.UpdateAdmin(new Admin()
            {
                Id = dto.Id,
                Name = dto.Name
            }));
        }
        
        [HttpDelete]
        public ActionResult<DeleteAdminDto> DeleteAdminDto(int id)
        {
            var adminDto = _adminService.DeleteAdmin(id);
            if (adminDto is not null)
            {
                return Ok(new DeleteAdminDto()
                {
                    Id = adminDto.Id,
                    Name = adminDto.Name
                });
            }
            return NotFound();
        }
    }
}