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
    [TestClass]
    public class AdminControllerTest
    {
        private Mock<IAdminRepository> mock = new Mock<IAdminRepository>();
        EFAdminRepository adminDb = new EFAdminRepository(new TestDbContext());

        private void DbSetup()
        {
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductId = 1, Name = "Test Monkies", Description = "Like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt ="Chewy Test Monkey", Rating = "0" },
                new Product {ProductId = 2, Name = "Test Gerbils", Description = "Just like real Gerbils, they're gone before you know it, and it's time for more.", Price = 3, Img = "~/img/Gerbil.jpg", ImgAlt ="Super Tasty Gerbil Candy!", Rating = "5" },
                new Product {ProductId = 3, Name = "Test Rock", Description = "Yum. Gummy Rock. Igneous Delicious!", Price = 9, Img = "~/img/boulder.jpg", ImgAlt ="Chewy Test Monkey", Rating = "5" }
            }.AsQueryable());

            mock.Setup(m => m.Reviews).Returns(new Review[]
            {
                new Review { ReviewId = 1, ProductId = 1, Rating = 5 },
                new Review { ReviewId = 2, ProductId = 1, Rating = 5 },
                new Review { ReviewId = 3, ProductId = 1, Rating = 5 },
                new Review { ReviewId = 4, ProductId = 1, Rating = 5 },
                new Review { ReviewId = 5, ProductId = 1, Rating = 5 },
                new Review { ReviewId = 6, ProductId = 1, Rating = 4 }
            }.AsQueryable());

            mock.Setup(m => m.Users).Returns(new User[]
            {
                new User { UserId = 1, UserNameFirst = "Bob", UserNameLast = "Belcher", ProfileName = "H.John_Benjamin", UserEmail = "fake@phony.com", },
                new User { UserId = 1, UserNameFirst = "Tina", UserNameLast = "Belcher", ProfileName = "Dan_Mintz", UserEmail = "fake01@phony.com", },
                new User { UserId = 1, UserNameFirst = "Louise", UserNameLast = "Belcher", ProfileName = "K_Schaal", UserEmail = "fake02@phony.com", }


        }.AsQueryable());
        }
        public void Dispose()
        {
            adminDb.ClearAllProducts();
            adminDb.ClearAllReviews();
            adminDb.ClearAllUsers();
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultProductIndex_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);
            
            //Act
            var result = controller.ProductIndex();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultUserIndex_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);

            //Act
            var result = controller.UserIndex();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultReviewIndex_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);

            //Act
            var result = controller.UserIndex();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultCreateProductPost_RedirectToActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);
            var testProduct = new Product { ProductId = 1 };
            //Act
            var result = controller.CreateProduct(testProduct);

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultCreateReviewPost_RedirectToActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);
            var testReview = new Review { ReviewId = 1 };
            //Act
            var result = controller.CreateReview(testReview);

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultCreateUserPost_RedirectToActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);
            var testUser = new User { UserId = 1 };
            //Act
            var result = controller.CreateUser(testUser);

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultCreateProductGet_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);
            //Act
            var result = controller.CreateProduct();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultCreateReviewGet_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);

            //Act
            var result = controller.CreateReview();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultCreateUserGet_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);

            //Act
            var result = controller.CreateUser();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultEditProductGet_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);

            //Act
            var result = controller.EditProduct(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultEditProductPost_RedirectToActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);
            var testProduct = new Product { ProductId = 1, Name = "Test Monkies", Description = "Like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt = "Chewy Test Monkey", Rating = "0" };
            //Act
            var result = controller.EditProduct(testProduct);

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultEditReviewGet_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);

            //Act
            var result = controller.EditReview(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultEditReviewPost_RedirectToActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);
            var testReview = new Review { ReviewId = 1, ProductId = 1, Rating = 5 };
            //Act
            var result = controller.EditReview(testReview);

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
        [TestMethod]
        public void Mock_GetViewResultEditUserGet_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);

            //Act
            var result = controller.EditUser(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultEditUserPost_RedirectToActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            AdminController controller = new AdminController(mock.Object);
            var testUser = new User { UserId = 1, UserNameFirst = "Louise", UserNameLast = "Belcher", ProfileName = "K_Schaal", UserEmail = "fake02@phony.com", };
        //Act
        var result = controller.EditUser(testUser);

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
    }
}