using InnoTech.LegosForLife.Core.Models;
using Xunit;

namespace InnoTech.LegosForLife.Core.Test.Models
{
    public class UserTest
    {
        private readonly User _user;

        public UserTest()
        {
            _user = new User();
        }

        [Fact]
        public void UserCanBeInitialized()
        {
            Assert.NotNull(_user);
        }

        [Fact]
        public void UserIdMustBeLong()
        {
            Assert.True(_user.Id is int);
        }

        [Fact]
        public void User_UserId_StoresId()
        {
            _user.Id = 1;
            Assert.Equal(1,_user.Id);
        }
        
        [Fact]
        public void User_UserId_StoresNewId()
        {
            _user.Id = 1;
            _user.Id = 2;
            Assert.Equal(2,_user.Id);
        }
        //
        // [Fact]
        // public void UserNameIsString()
        // {
        //     Assert.True(_user.Name is string);
        // }

        [Fact]
        public void User_UserName_StoresName()
        {
            _user.Name = "Bob";
            Assert.Equal("Bob", _user.Name);
        }

        [Fact]
        public void User_UserName_StoresNewName()
        {
            _user.Name = "Bob";
            _user.Name = "Cloud";
            Assert.Equal("Cloud", _user.Name);
        }
    }
}