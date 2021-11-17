using InnoTech.LegosForLife.Core.Models;
using Xunit;

namespace InnoTech.LegosForLife.Core.Test.Models
{
    public class AdminTest
    {
        private readonly Admin _admin;

        public AdminTest()
        {
            _admin = new Admin();
        }

        [Fact]
        public void Admin_CanBeInitialized()
        {
            Assert.NotNull(_admin);
        }

        [Fact]
        public void Admin_IdMustBeLong()
        {
            Assert.True(_admin.Id is int);
        }

        [Fact]
        public void Admin_SetId_StoresId()
        {
            _admin.Id = 1;
            Assert.Equal(1, _admin.Id);
        }
    }
}