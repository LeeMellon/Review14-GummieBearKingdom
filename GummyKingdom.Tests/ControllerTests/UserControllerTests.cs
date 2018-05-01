using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Review14.Models;
using GummyKingdom.Tests.Models;
using Review14.Controllers;
using Moq;
using System.Linq;
using Microsoft.AspNetCore.Mvc;



namespace GummyKingdom.Tests.ControllerTests
{
    public class UserControllerTests
    {
        private Mock<IUserRepository> mock = new Mock<IUserRepository>();
        EFUserRepository db = new EFUserRepository(new TestDbContext());

        private void DbSetup()
        {
            //mock.Setup(m => m.Users).Returns(new User[]
            //{
            //    new User {UserId = 1, UserNameFirst = "Bob", UserNameLast = "Burgers", ProfileName = "H.John_Benjamin", UserEmail = "fake@phony.com", }
            //}.AsQueryable());
        }

        [TestMethod]
        public void  Mock_CreateUserGet_User()
        {
            //Arrange
            UserController controller = new UserController();
            
            //Act
            var result = controller.Create();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));

        }

        [TestMethod]
        public void Mock_CreateUserPost_User()
        {
            //Arrange
            UserController controller = new UserController();
            var testUser = new User { UserId = 1, UserNameFirst = "Bob", UserNameLast = "Burgers", ProfileName = "H.John_Benjamin", UserEmail = "fake@phony.com", };
            
            //Act
            var result = controller.Create(testUser);

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));

        }
    }
}
