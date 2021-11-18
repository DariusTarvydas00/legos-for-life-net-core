using System.Collections.Generic;
using System.IO;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.Domain.IRepositories;

namespace InnoTech.LegosForLife.Domain.Services
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository _adminService;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminService = adminRepository ?? throw new InvalidDataException("AdminRepository Cannot Be Null");
        }

        public List<Admin> GetAdmins()
        {
            return _adminService.FindAll();
        }

        public Admin GetAdminById(int id)
        {
            return _adminService.GetAdminById(id);
        }

        public Admin CreateNewAdmin(Admin admin)
        {
            return _adminService.CreateNewAdmin(admin);
        }

        public Admin UpdateAdmin(Admin admin)
        {
            return _adminService.UpdateAdmin(admin);
        }

        public Admin DeleteAdmin(int id)
        {
            return _adminService.DeleteAdmin(id);
        }
    }
}