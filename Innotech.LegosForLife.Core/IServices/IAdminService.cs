using System.Collections.Generic;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Core.IServices
{
    public interface IAdminService
    {
        List<Admin> GetAdmins();

        Admin GetAdminById(int id);
        Admin CreateNewAdmin(Admin admin);
        Admin UpdateAdmin(Admin admin);
        Admin DeleteAdmin(int id);
    }
}