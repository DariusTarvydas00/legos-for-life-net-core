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
    public class AdminServiceTest
    {
        private readonly AdminService _service;
        private readonly Mock<IAdminRepository> _mock;
        private List<Admin> _expected;

        public AdminServiceTest()
        {
            _mock = new Mock<IAdminRepository>();
            _service = new AdminService(_mock.Object);
            _expected = new List<Admin>()
            {
                new Admin() {Id = 1, Name = "Joshua"},
                new Admin() {Id = 2, Name = "Jack"}
            };
        }

        [Fact]
        public void AdminService_IsIAdminService()
        {
            Assert.True(_service is IAdminService);
        }

        [Fact]
        public void AdminService_WithNullAdminRepository_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AdminService(null));
        }
        
        [Fact]
        public void AdminService_WithNullAdminRepository_ThrowsExceptionWithMessage()
        {
            var actual = Assert.Throws<InvalidDataException>(() => new AdminService(null));
            Assert.Equal("AdminRepository Cannot Be Null",actual.Message);
        }

        [Fact]
        public void AdminService_CallsRepositoryFindAll_ExactlyOnce()
        {
            _service.GetAdmins();
            _mock.Verify(r => r.FindAll(), Times.Once);
        }

        [Fact]
        public void AdminService_NoFilters_ReturnsListOfAllAdmins()
        {
            _mock.Setup(r => r.FindAll()).Returns(_expected);
            var actual = _service.GetAdmins();
            Assert.Equal(_expected, actual);

        }

    }
}