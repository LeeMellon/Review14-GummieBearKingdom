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
        public IActionResult AdminIndex()
        {
            return View();
        }
        


        //PRODUCT ROUTES//


        //Create Product Routes//
        public IActionResult AdminProductCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminProductCreate(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        //Edit Product Route//
        public IActionResult AdminProductEdit(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost]
        public IActionResult AdminProductEdit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }



        //REVIEW ROUTES//


        //Create Review Routes//
        public IActionResult AdminReviewCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminReviewCreate(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        //Edit Review Route//
        public IActionResult AdminReviewEdit(int id)
        {
            var thisReview = db.Reviews.FirstOrDefault(review => review.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult AdminReviewEdit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Review");
        }

        //USER ROUTES//
        
        //User Index
        public IActionResult AdminUserIndex()
        {
            var UsersList = db.Users.ToList();
            return View(UsersList);
        }

        //Create User Routes//
        public IActionResult AdminUserCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminUserCreate(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        //Edit User Route//
        public IActionResult AdminEdit(int id)
        {
            var thisUser = db.Users.FirstOrDefault(user => user.UserId == id);
            return View(thisUser);
        }

        [HttpPost]
        public IActionResult AdminEdit(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


    }
}
