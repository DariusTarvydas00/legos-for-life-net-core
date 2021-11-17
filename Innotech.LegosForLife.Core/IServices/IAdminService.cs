using System.Collections.Generic;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Core.IServices
{
    public interface IAdminService
    {
        List<Admin> GetAdmins();
    }
}