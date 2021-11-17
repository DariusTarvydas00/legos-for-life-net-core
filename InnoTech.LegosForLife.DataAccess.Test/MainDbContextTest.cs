using EntityFrameworkCore.Testing.Moq;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InnoTech.LegosForLife.DataAccess.Test
{
    public class MainDbContextTest
    {
        
        [Fact]
        public void DbContext_WithDbContextOptions_IsAvailable()
        {
            var mockedDbContext = Create.MockedDbContextFor<MainDbContext>();
            Assert.NotNull(mockedDbContext);
        }
        
        [Fact]
        public void DbContext_DbSets_MustHaveDbSetWithTypeProductEntity()
        {
            var mockedDbContext = Create.MockedDbContextFor<MainDbContext>();
            Assert.True(mockedDbContext.Products is DbSet<ProductEntity>);
        }

        [Fact]
        public void DbContext_DbSets_MustHaveDbSetWithTypeUserEntity()
        {
            var mockedDbContext = Create.MockedDbContextFor<MainDbContext>();
            Assert.True(mockedDbContext.Users is DbSet<UserEntity>);
        }

        [Fact]
        public void DbContext_DbSets_MustHaveDbSetWithTypeAdminEntity()
        {
            var mockedDbContext = Create.MockedDbContextFor<MainDbContext>();
            Assert.True(mockedDbContext.Admins is DbSet<AdminEntity>);
        }
    }
}