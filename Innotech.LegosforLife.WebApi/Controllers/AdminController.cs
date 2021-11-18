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
    }
}