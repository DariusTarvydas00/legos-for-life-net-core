using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace InnoTech.LegosForLife.WebApi.Test.Controllers
{
    public class UserControllerTest
    {
        
        #region Controller Intialization

        [Fact]
        public void UserController_HasUserService_IsOfTypeControllerBase()
        {
            var service = new Mock<IUserService>();
            var controller = new UserController(service.Object);
            Assert.IsAssignableFrom<ControllerBase>(controller);
        }
        
        [Fact]
        public void UserController_WithNullUserService_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(
                () => new UserController(null)
            );

        }
        
        [Fact]
        public void UserController_WithNullUserRepository_ThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(
                () => new UserController(null)
            );
            Assert.Equal("UserService Cannot Be Null",exception.Message);
        }
        
        [Fact]
        public void UserController_UsesApiControllerAttribute()
        {
            //Arrange
            var typeInfo = typeof(UserController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("ApiControllerAttribute"));
            //Assert
            Assert.NotNull(attr);
        }  
        
        [Fact]
        public void UserController_UsesRouteAttribute()
        {  
            //Arrange
            var typeInfo = typeof(UserController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("RouteAttribute"));
            //Assert
            Assert.NotNull(attr);
        }
        
        [Fact]
        public void UserController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {  
            //Arrange
            var typeInfo = typeof(UserController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("RouteAttribute")) as RouteAttribute;
            //Assert
            Assert.Equal("api/[controller]", attr.Template);
        }
        

        #endregion

        #region GetAll Method

        [Fact]
        public void UserController_HasGetAllMethod()
        {
            var method = typeof(UserController)
                .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.NotNull(method);
        }
        
        [Fact]
        public void GetAll_WithNoParams_IsPublic()
        {
            var method = typeof(UserController)
                .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        [Fact]
        public void GetAll_WithNoParams_ReturnsListOfUsersInActionResult()
        {
            var method = typeof(UserController)
                .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<List<User>>).FullName, method.ReturnType.FullName);
        }

        [Fact]
        public void GetAll_WithNoParams_HasGetHttpAttribute()
        {
            var methodInfo = typeof(UserController)
                .GetMethods()
                .FirstOrDefault(m => m.Name == "GetAll");
            var attr = methodInfo.CustomAttributes
                .FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
            Assert.NotNull(attr);
        }
        
        [Fact]
        public void GetAll_CallsServicesGetUsers_Once()
        {
            //Arrange
            var mockService = new Mock<IUserService>();
            var controller = new UserController(mockService.Object);
            
            //Act
            controller.GetAll();
            
            //Assert
            mockService.Verify(s => s.GetUsers(),Times.Once);

        }


        #endregion

        #region Post Method

        

        #endregion
        
    }

}