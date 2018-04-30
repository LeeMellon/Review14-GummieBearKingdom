using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review14.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Review14.Controllers
{
    public class HomeController : Controller
    {
        private IAdminRepository AdminRepo;
        private IReviewRepository ReviewRepo;
        public IActionResult Index()
        {
            var newProduct = new Product();
            var reviews = ReviewRepo.Reviews.ToList();
            var SortedList = newProduct.GetFeatured(reviews);
            
            return View(SortedList);
        }

        public IActionResult About()
        {
           

            return View();
        }

        public IActionResult Contact()
        {
         

            return View();
        }


    }
}
