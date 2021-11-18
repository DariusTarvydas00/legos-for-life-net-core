using System.Collections.Generic;
using System.IO;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.Domain.IRepositories;

namespace InnoTech.LegosForLife.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new InvalidDataException("UserRepository Cannot Be Null");
        }

        public List<User> GetUsers()
        {
            return _userRepository.FindAll();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User CreateNewUser(User user)
        {
            return _userRepository.CreateNewUser(user);
        }
    }
}