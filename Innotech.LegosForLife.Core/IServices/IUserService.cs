using System.Collections.Generic;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Core.IServices
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}