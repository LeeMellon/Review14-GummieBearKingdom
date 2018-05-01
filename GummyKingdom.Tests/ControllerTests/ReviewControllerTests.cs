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
    public class ReviewControllerTests
    {
        private Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
        EFProductRepository db = new EFProductRepository(new TestDbContext());
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
        }
        public void Dispose()
        {
            db.ClearAll();
            adminDb.ClearAllReviews();
            adminDb.ClearAllUsers();
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            ReviewController controller = new ReviewController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultDeleteGet_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            ReviewController controller = new ReviewController(mock.Object);

            //Act
            var result = controller.Delete(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetViewResultDeletePost_ActionResult()
        {
            //Arrange
            Dispose();
            DbSetup();
            ReviewController controller = new ReviewController(mock.Object);

            //Act
            var result = controller.DeleteConfirmed(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }



        [TestMethod]
        public void Mock_IndexContainsModelData_List()
        {
            //Arrange
            Dispose();
            DbSetup();
            ViewResult indexView = new ReviewController(mock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Product>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsProducts_Collection()
        {

            //Arrange
            Dispose();
            DbSetup();
            ReviewController controller = new ReviewController(mock.Object);
            Review review = new Review { ProductId = 1, Title = "Test Rock", ReviewText = "Yum. Gummy Rock. Igneous Delicious!", UserId = 1, Rating = 5 };

            //Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Product> collection = indexView.ViewData.Model as List<Product>;

            //Assert
            CollectionAssert.Contains(collection, review);
        }
    }
}
