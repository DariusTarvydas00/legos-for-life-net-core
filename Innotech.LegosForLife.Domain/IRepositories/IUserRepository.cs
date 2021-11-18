using System.Collections.Generic;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Domain.IRepositories
{
    public interface IUserRepository
    {
        List<User> FindAll();
        User GetUserById(int Id);
        User CreateNewUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int id);
    }
}