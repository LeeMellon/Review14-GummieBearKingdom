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
        private GummyKingdomDbContext db = new GummyKingdomDbContext();
        public IActionResult Index()
        {
            List<Product> SortedList = db.Products.OrderByDescending(product => product.Rating).ToList();
            var FeaturesList = SortedList.Take(4);
            
            return View(FeaturesList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
