using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.DataAccess.Entities;
using InnoTech.LegosForLife.DataAccess.Repositories;
using InnoTech.LegosForLife.Domain.IRepositories;
using Xunit;

namespace InnoTech.LegosForLife.DataAccess.Test.Repositories
{
    public class UserRepositoryTest
    {
        [Fact]
        public void UserRepository_IsIUserRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new UserRepository(fakeContext);
            Assert.IsAssignableFrom<IUserRepository>(repository);
        }
        
        [Fact]
        public void UserRepository_WithNullDBContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new UserRepository(null));
        }
        
        [Fact]
        public void UserRepository_WithNullDBContext_ThrowsExceptionWithMessage()
        {
            var exception = Assert
                .Throws<InvalidDataException>(() => new UserRepository(null));
            Assert.Equal("User Repository Must have a DBContext", exception.Message);
        }
        
        [Fact]
        public void FindAll_GetAllUsersEntitiesInDBContext_AsAListOfUsers()
        {
            //Arrange
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new UserRepository(fakeContext);
            var list = new List<UserEntity>
            {
                new UserEntity { Id = 1, Name = "User" },
                new UserEntity { Id = 2, Name = "User2" },
                new UserEntity { Id = 3, Name = "User3" }
            };
            fakeContext.Set<UserEntity>().AddRange(list);
            fakeContext.SaveChanges();
            
            var expectedList = list
                .Select(pe => new User
                {
                    Id = pe.Id,
                    Name = pe.Name
                })
                .ToList();
            
            //Act
            var actualResult = repository.FindAll();
            
            //Assert
            Assert.Equal(expectedList, actualResult, new Comparer());
        }
        
    }

    public partial class Comparer: IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode(User obj)
        {
            return HashCode.Combine(obj.Id, obj.Name);
        }
    }
}