using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Review14.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Review14.Controllers
{
    public class AdminController : Controller
    {

        private GummyKingdomDbContext db = new GummyKingdomDbContext();
        
        //Index//
        public IActionResult Index()
        {

          
            return View();
        }



        //PRODUCT ROUTES//

        //Products Index
        public IActionResult ProductIndex()
        {
            var productsList = db.Products.ToList();
            return View(productsList);
        }


        //Create Product Routes//
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("ProductIndex");
        }

        //Edit Product Route//
        public IActionResult EditProduct(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ProductIndex");
        }



        //REVIEW ROUTES//


        //Review Index
        public IActionResult ReviewIndex()
        {
            var reviewsList = db.Reviews.ToList();
            return View(reviewsList);
        }

        //Create Review Routes//
        public IActionResult CreateReview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        //Edit Review Route//
        public IActionResult EditReview(int id)
        {
            var thisReview = db.Reviews.FirstOrDefault(review => review.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult EditReview(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Review");
        }

        //USER ROUTES//
        
        //User Index
        public IActionResult UserIndex()
        {
            var UsersList = db.Users.ToList();
            return View(UsersList);
        }

        //Create User Routes//
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        //Edit User Route//
        public IActionResult UserEdit(int id)
        {
            var thisUser = db.Users.FirstOrDefault(user => user.UserId == id);
            return View(thisUser);
        }

        [HttpPost]
        public IActionResult UserEdit(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


    }
}
