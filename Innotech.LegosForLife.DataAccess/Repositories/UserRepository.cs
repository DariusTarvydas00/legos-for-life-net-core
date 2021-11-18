using System.Collections.Generic;
using System.IO;
using System.Linq;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.DataAccess.Entities;
using InnoTech.LegosForLife.Domain.IRepositories;

namespace InnoTech.LegosForLife.DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly MainDbContext _ctx;

        public UserRepository(MainDbContext ctx)
        {
            if(ctx == null) throw new InvalidDataException("User Repository Must have a DBContext");
            _ctx = ctx;
        }

        public List<User> FindAll()
        {
            return _ctx.Users.Select(ue => new User()
            {
                Id = ue.Id,
                Name = ue.Name
            }).ToList();
        }
        
        public User GetUserById(int id)
        {
            return _ctx.Users.Select(pe => new User()
            {
                Id = pe.Id,
                Name = pe.Name
            }).FirstOrDefault(user => user.Id == id);
        }

        public User CreateNewUser(User user)
        {
            var entity = _ctx.Users.Add(new UserEntity()
            {
                Id = user.Id,
                Name = user.Name
            }).Entity;
            _ctx.SaveChanges();
            return new User()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public User UpdateUser(User user)
        {
            var entity = _ctx.Users.Update(new UserEntity()
            {
                Id = user.Id,
                Name = user.Name
            }).Entity;
            _ctx.SaveChanges();
            return new User()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public User DeleteUser(int id)
        {
            var entity = _ctx.Users.Remove(new UserEntity()
            {
                Id = id
            }).Entity;
            _ctx.SaveChanges();
            return new User() {Id = entity.Id};
        }
    }
}