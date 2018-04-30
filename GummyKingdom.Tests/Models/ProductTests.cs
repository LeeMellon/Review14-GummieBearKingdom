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
    public class ProductTests
    {
        private Mock<IProductRepository> mock = new Mock<IProductRepository>();
        EFProductRepository db = new EFProductRepository(new TestDbContext());
        EFAdminRepository adminDb = new EFAdminRepository(new TestDbContext());
        private void DbSetup()
        {
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                //new Product {ProductId = 1, Name = "Test Monkies", Description = "Like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt ="Chewy Test Monkey", Rating = "5" },
                new Product {ProductId = 2, Name = "Test Gerbils", Description = "Just like real Gerbils, they're gone before you know it, and it's time for more.", Price = 3, Img = "~/img/Gerbil.jpg", ImgAlt ="Super Tasty Gerbil Candy!", Rating = "5" },
                new Product {ProductId = 3, Name = "Test Rock", Description = "Yum. Gummy Rock. Igneous Delicious!", Price = 9, Img = "~/img/boulder.jpg", ImgAlt ="Chewy Test Monkey", Rating = "5" }
            }.AsQueryable());
        }
        public void Dispose()
        {
            db.ClearAll();
            adminDb.ClearAllProducts();
        }

        [TestMethod]
        public void Db_CreateAndEqualityTest_Product()
        {

            //Arrange
            AdminController controller = new AdminController(adminDb);
            var testProduct = new Product { ProductId = 1, Name = "Test Monkies", Description = "Like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt = "Chewy Test Monkey", Rating = "5" };
            

            //Act
            controller.CreateProduct(testProduct);
            var comparisonProduct = adminDb.Products.ToList()[0];

            //Assert
            Assert.AreEqual(testProduct, comparisonProduct);
            Dispose();
        }
    }
}
