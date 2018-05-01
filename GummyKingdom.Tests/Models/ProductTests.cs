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
        public Mock<IProductRepository> mock = new Mock<IProductRepository>();
        EFProductRepository productDb = new EFProductRepository(new TestDbContext());
        EFAdminRepository adminDb = new EFAdminRepository(new TestDbContext());
       
        public void DbSetup()
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
            adminDb.ClearAllReviews();
            adminDb.ClearAllProducts();
            adminDb.ClearAllUsers();
        }

        [TestMethod]
        public void Db_CreateAndEqualityTest_Product()
        {
            //Arrange
            Dispose();
            AdminController controller = new AdminController(adminDb);
            var testProduct = new Product { ProductId = 1, Name = "Test Monkies", Description = "Like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt = "Chewy Test Monkey", Rating = "0" };


            //Act
            controller.CreateProduct(testProduct);
            var comparisonProduct = adminDb.Products.ToList()[0];

            //Assert
            Assert.AreEqual(testProduct, comparisonProduct);
        }


        [TestMethod]
        public void DB_ProductSetRatingMethod_String()
        {
            //Arrange
            Dispose();
            var newUser = new User { UserId = 1 };
            var testProduct = new Product { ProductId = 1, Name = "Test Monkies", Description = "Like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt = "Chewy Test Monkey", Rating = "0" };
            var reviewsList = new Review[] {
            new Review { ReviewId = 1, ProductId = 1, UserId = 1, Rating = 5 },
            new Review { ReviewId = 2, ProductId = 1, UserId = 1, Rating = 5 },
            new Review { ReviewId = 3, ProductId = 1, UserId = 1, Rating = 5 },
            new Review { ReviewId = 4, ProductId = 1, UserId = 1, Rating = 5 },
            new Review { ReviewId = 5, ProductId = 1, UserId = 1, Rating = 5 },
            new Review { ReviewId = 6, ProductId = 1, UserId = 1, Rating = 4 }
            };
            AdminController controller = new AdminController(adminDb);
            controller.CreateUser(newUser);
            controller.CreateProduct(testProduct);
            foreach (Review r in reviewsList) { controller.CreateReview(r); }


            //Act
            var thisProduct = adminDb.Products.FirstOrDefault(p => p.ProductId == 1);
            thisProduct.SetRating();
            var result = thisProduct.Rating;

            //Assert
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public void DB_ProductCreate_Product()
        {
            //Arrange
            Dispose();
            AdminController controller = new AdminController(adminDb);
            var testProduct = new Product { ProductId = 1, Name = "Test Monkies", Description = "Like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt = "Chewy Test Monkey", Rating = "0" };

            //Act
            controller.CreateProduct(testProduct);
            var productList = adminDb.Products.ToList();
            var thisProduct = productList[0];

            //Assert
            Assert.IsInstanceOfType(thisProduct, typeof(Product));
            Assert.AreEqual(thisProduct.ProductId, testProduct.ProductId);
        }

        [TestMethod]
        public void DB_EditProduct_ProductName()
        {
            //Arrange
            Dispose();
            AdminController controller = new AdminController(adminDb);
            controller.CreateProduct(new Product { ProductId = 1, Name = "Test Monkies", Description = "It's like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt = "Chewy Test Monkey", Rating = "0" });

            //Act
            var testProduct = adminDb.Products.FirstOrDefault(p => p.ProductId == 1);
            testProduct.Name = "Testier Monkies";
            controller.EditProduct(testProduct);
            var resultProduct = adminDb.Products.ToList()[0];
            
            //Assert
            Assert.AreEqual("Testier Monkies", resultProduct.Name);
            
        }

        [TestMethod]
        public void DB_DeleteProduct_ProductName()
        {
            //Arrange
            Dispose();
            AdminController controller = new AdminController(adminDb);
            controller.CreateProduct(new Product { ProductId = 1, Name = "Test Monkies", Description = "It's like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt = "Chewy Test Monkey", Rating = "0" });
            var productCount = adminDb.Products.ToList().Count();

            //Act
            controller.DeleteProduct(1);
            controller.DeleteProductConfirmed(1);
            var newProductCount = adminDb.Products.ToList().Count();
   
            //Assert
            Assert.AreEqual(1, productCount);
            Assert.AreEqual(0, newProductCount);

        }

        [TestMethod]
        public void DB_ClearAllProducts_Int()
        {
            //Arrange
            Dispose();
            AdminController controller = new AdminController(adminDb);
            controller.CreateProduct(new Product { ProductId = 1, Name = "Test Monkies", Description = "It's like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt = "Chewy Test Monkey", Rating = "0" });
            controller.CreateProduct(new Product { ProductId = 2, Name = "Test Ponies", Description = "It's like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt = "Chewy Test Monkey", Rating = "0" });
            controller.CreateProduct(new Product { ProductId = 3, Name = "Test Toasters", Description = "It's like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt = "Chewy Test Monkey", Rating = "0" });
            var productCount = adminDb.Products.ToList().Count();


            //Act
            controller.DeleteAllProducts();
            var newProductCount = adminDb.Products.ToList().Count();

            //Assert
            Assert.AreEqual(3, productCount);
            Assert.AreEqual(0, newProductCount);
        }

        [TestMethod]
        public void DB_ProductDetails_ProductName()
        {
            //Arrange
            Dispose();
            ProductController controller = new ProductController(productDb);
            controller.Create(new Product { ProductId = 1, Name = "Test Monkies", Description = "It's like an OUTBREAK of flavour in your mouth.", Price = 2, Img = "~/img/testMonkey.jpg", ImgAlt = "Chewy Test Monkey", Rating = "0" });

            //Act

            var resultView = controller.Details(1) as ViewResult;
            var model = resultView.ViewData.Model as Product;

            //Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Product));

        }

    }

}
