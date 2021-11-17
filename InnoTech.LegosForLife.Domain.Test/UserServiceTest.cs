using System.Collections.Generic;
using System.IO;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.Domain.IRepositories;
using InnoTech.LegosForLife.Domain.Services;
using Moq;
using Xunit;

namespace InnoTech.LegosForLife.Domain.Test
{
    public class UserServiceTest
    {
        private readonly UserService _service;
        private readonly Mock<IUserRepository> _mock;
        private readonly List<User> _expected;

        public UserServiceTest()
        {
            _mock = new Mock<IUserRepository>();
            _service = new UserService(_mock.Object);
            _expected = new List<User>
            {
                new User { Id = 1, Name = "User1" },
                new User { Id = 2, Name = "User2" }
            };
        }

        [Fact]
        public void UserService_IsIUserService()
        {
            Assert.True(_service is IUserService);
        }

        [Fact]
        public void UserService_WithNullUserRepository_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new UserService(null));
        }

        [Fact]
        public void UserService_WithNullUserRepository_ThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(() => new UserService(null));
            Assert.Equal("UserRepository Cannot Be Null", exception.Message);
        }

        [Fact]
        public void Getusers_CallsUserRepositoriesFindAll_ExactlyOnce()
        {
            _service.GetUsers();
            _mock.Verify(r => r.FindAll(), Times.Once);
        }

        [Fact]
        public void GetUsers_NoFilter_ReturnsListOfAllUsers()
        {
            _mock.Setup(r => r.FindAll()).Returns(_expected);
            var actual = _service.GetUsers();
            Assert.Equal(_expected,actual);
        }

        [Fact]
        public void GetProducts_NoFilter_ReturnsListOfAllProducts()
        {
            _mock.Setup(r => r.FindAll())
                .Returns(_expected);
            var actual = _service.GetUsers();
            Assert.Equal(_expected, actual);
        }

    }
}