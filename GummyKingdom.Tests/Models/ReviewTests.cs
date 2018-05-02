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

namespace GummyKingdom.Tests
{
    [TestClass]
    public class ReviewTests
    {
        public Mock<IAdminRepository> mock = new Mock<IAdminRepository>();
        EFAdminRepository adminDb = new EFAdminRepository(new TestDbContext());
        public void Dispose()
        {
            adminDb.ClearAllReviews();
            adminDb.ClearAllProducts();
            adminDb.ClearAllUsers();
        }

        [TestMethod]
        public void DB_CreateReviewMethod_Int()
        {
            //Arange
            Dispose();
            AdminController controller = new AdminController(adminDb);
            var testUser = new User { UserId = 1 };
            var testProduct = new Product { ProductId = 1 };
            var testReview = new Review { ReviewId = 1, ProductId = 1, UserId = 1 };
            var reviewCount1 = adminDb.Reviews.ToList().Count();


            //Act
            controller.CreateUser(testUser);
            controller.CreateProduct(testProduct);
            controller.CreateReview(testReview);
            var reviewCount2 = adminDb.Reviews.ToList().Count();

            //Assert
            Assert.AreEqual(0, reviewCount1);
            Assert.AreEqual(1, reviewCount2);
        }

        [TestMethod]
        public void DB_RetrievCorrectReview_Review()
        {
            //Arange
            Dispose();
            AdminController controller = new AdminController(adminDb);
            var testUser = new User { UserId = 1 };
            var testProduct = new Product { ProductId = 1 };
            var testReview1 = new Review { ReviewId = 1, ProductId = 1, UserId = 1 };
            var testReview2 = new Review { ReviewId = 2, ProductId = 1, UserId = 1, ReviewText = "This is Correct"};


            //Act
            controller.CreateUser(testUser);
            controller.CreateProduct(testProduct);
            controller.CreateReview(testReview1);
            controller.CreateReview(testReview2);
            var testReview = adminDb.Reviews.FirstOrDefault(r => r.ReviewId == 2);
            var resultString = testReview.ReviewText;
            //Assert
            Assert.AreEqual("This is Correct", resultString);
           
        }
    }
}

