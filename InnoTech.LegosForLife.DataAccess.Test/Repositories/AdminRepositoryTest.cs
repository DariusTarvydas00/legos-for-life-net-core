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
    public class AdminRepositoryTest
    {
        [Fact]
        public void AdminRepository_IsIAdminRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AdminRepository(fakeContext);
            Assert.IsAssignableFrom<IAdminRepository>(repository);
        }
        
        [Fact]
        public void AdminRepository_WithNullDBContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AdminRepository(null));
        }
        
        [Fact]
        public void AdminRepository_WithNullDBContext_ThrowsExceptionWithMessage()
        {
            var exception = Assert
                .Throws<InvalidDataException>(() => new AdminRepository(null));
            Assert.Equal("Admin Repository Must have a DBContext", exception.Message);
        }
        
        [Fact]
        public void FindAll_GetAllAdminsEntitiesInDBContext_AsAListOfAdmins()
        {
            //Arrange
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AdminRepository(fakeContext);
            var list = new List<AdminEntity>
            {
                new AdminEntity { Id = 1, Name = "Admin" },
                new AdminEntity { Id = 2, Name = "Admin2" },
                new AdminEntity { Id = 3, Name = "Admin3" }
            };
            fakeContext.Set<AdminEntity>().AddRange(list);
            fakeContext.SaveChanges();
            
            var expectedList = list
                .Select(pe => new Admin
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

    public partial class Comparer: IEqualityComparer<Admin>
    {
        public bool Equals(Admin x, Admin y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode(Admin obj)
        {
            return HashCode.Combine(obj.Id, obj.Name);
        }
    }
}