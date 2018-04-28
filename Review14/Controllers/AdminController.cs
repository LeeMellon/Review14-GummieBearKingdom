using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Review14.Models;


namespace Review14.Controllers
{
    public class AdminController : Controller
    {

        private IAdminRepository AdminRepo;

        public AdminController(IAdminRepository repo = null)
        {
            if (repo == null)
            {
                this.AdminRepo = new EFAdminRepository();
            }
            else
            {
                this.AdminRepo = repo;
            }
        }

        //Index//
        public IActionResult Index()
        {

          
            return View();
        }



        //PRODUCT ROUTES//

        //Products Index
        public IActionResult ProductIndex()
        {
            var products = AdminRepo.Products.ToList();
            var productsList = new List<Product> { };
            foreach (Product p in products) { p.SetRating(); productsList.Add(p); }
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
            AdminRepo.SaveProduct(product);
            return RedirectToAction("ProductIndex");
        }

        //Edit Product Route//
        public IActionResult EditProduct(int id)
        {
            var thisProduct = AdminRepo.Products.FirstOrDefault(product => product.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            AdminRepo.EditProduct(product);
            return RedirectToAction("ProductIndex");
        }



        //REVIEW ROUTES//


        //Review Index
        public IActionResult ReviewIndex()
        {
            var reviewsList = AdminRepo.Reviews.ToList();
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
            AdminRepo.SaveReview(review);

            return RedirectToAction("Index", "Product");
        }

        //Edit Review Route//
        public IActionResult EditReview(int id)
        {
            var thisReview = AdminRepo.Reviews.FirstOrDefault(review => review.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult EditReview(Review review)
        {
            AdminRepo.EditReview(review);
            return RedirectToAction("Index", "Review");
        }

        //USER ROUTES//
        
        //User Index
        public IActionResult UserIndex()
        {
            var UsersList = AdminRepo.Users.ToList();
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
            AdminRepo.SaveUser(user);
            return RedirectToAction("Index", "Home");
        }

        //Edit User Route//
        public IActionResult UserEdit(int id)
        {
            var thisUser = AdminRepo.Users.FirstOrDefault(user => user.UserId == id);
            return View(thisUser);
        }

        [HttpPost]
        public IActionResult UserEdit(User user)
        {
            AdminRepo.EditUser(user);
            return RedirectToAction("Index", "Home");
        }


    }
}
