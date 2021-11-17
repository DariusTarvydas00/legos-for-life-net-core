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
    public class AdminControllerTest
    {
        #region Controller Intialization

        [Fact]
        public void AdminController_HasAdminService_IsOfTypeControllerBase()
        {
            var service = new Mock<IAdminService>();
            var controller = new AdminController(service.Object);
            Assert.IsAssignableFrom<ControllerBase>(controller);
        }
        
        [Fact]
        public void AdminController_WithNullAdminService_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(
                () => new AdminController(null)
            );

        }
        
        [Fact]
        public void AdminController_WithNullAdminRepository_ThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(
                () => new AdminController(null)
            );
            Assert.Equal("AdminService Cannot Be Null",exception.Message);
        }
        
        [Fact]
        public void AdminController_UsesApiControllerAttribute()
        {
            //Arrange
            var typeInfo = typeof(AdminController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("ApiControllerAttribute"));
            //Assert
            Assert.NotNull(attr);
        }  
        
        [Fact]
        public void AdminController_UsesRouteAttribute()
        {  
            //Arrange
            var typeInfo = typeof(AdminController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("RouteAttribute"));
            //Assert
            Assert.NotNull(attr);
        }
        
        [Fact]
        public void AdminController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {  
            //Arrange
            var typeInfo = typeof(AdminController).GetTypeInfo();
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
        public void AdminController_HasGetAllMethod()
        {
            var method = typeof(AdminController)
                .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.NotNull(method);
        }
        
        [Fact]
        public void GetAll_WithNoParams_IsPublic()
        {
            var method = typeof(AdminController)
                .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        [Fact]
        public void GetAll_WithNoParams_ReturnsListOfAdminsInActionResult()
        {
            var method = typeof(AdminController)
                .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<List<Admin>>).FullName, method.ReturnType.FullName);
        }

        [Fact]
        public void GetAll_WithNoParams_HasGetHttpAttribute()
        {
            var methodInfo = typeof(AdminController)
                .GetMethods()
                .FirstOrDefault(m => m.Name == "GetAll");
            var attr = methodInfo.CustomAttributes
                .FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
            Assert.NotNull(attr);
        }
        
        [Fact]
        public void GetAll_CallsServicesGetAdmins_Once()
        {
            //Arrange
            var mockService = new Mock<IAdminService>();
            var controller = new AdminController(mockService.Object);
            
            //Act
            controller.GetAll();
            
            //Assert
            mockService.Verify(s => s.GetAdmins(),Times.Once);

        }


        #endregion

        #region Post Method

        

        #endregion
    }
}